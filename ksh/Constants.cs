using System;
using Gen=System.Collections.Generic;
using System.Text;

namespace ksh.Physics{
	// (単位・誤差付きの数を定義すると良い)
	// 単位系・接頭辞
	/// <summary>
	/// 単位及び次元を表現するクラスです。
	/// <para>一つの単位に対して一つのインスタンスが用意されます。</para>
	/// <para>
	/// インスタンスの比較には、
	/// 1. 同じ単位名を持っているか
	/// 2. 名前が違っても実質同じ単位か
	/// 3. 次元が同じか
	/// の三種類が存在します。基本的には、比較演算は 2 に依って行われます。
	/// ハッシュコード等も基本的に 2 に従って計算されます。
	/// 3. の比較を行いたい場合には、static int CompareDim() を用いて下さい。
	/// また、1. の比較を行いたい場合には、static int CompareExact() を用いて下さい。
	/// </para>
	/// </summary>
	public class Unit:System.IComparable<Unit>,System.IEquatable<Unit>{
		string name;
		/// <summary>
		/// SI 単位に対する比率を指定します。例: eV → 1.602e-19
		/// 0 を指定した場合には、このインスタンスは単位ではなくて、次元を表すインスタンスとして動作します。
		/// </summary>
		double factor;
		double meter;
		double kgram;
		double second;
		double ampere=0;
		double kelvin=0;
		double candela=0;
		double mol=0;

		private Unit(){
			this.factor=1;
			this.name="[Unknown]";

			this.meter=0;
			this.kgram=0;
			this.second=0;
			this.ampere=0;
			this.kelvin=0;
			this.candela=0;
			this.mol=0;
		}
		/// <summary>
		/// 内部計算用コンストラクタです。
		/// </summary>
		/// <param name="a">コピー元の Unit を指定します。</param>
		private Unit(Unit a){
			this.factor=a.factor;
			this.meter=a.meter;
			this.kgram=a.kgram;
			this.second=a.second;
			this.ampere=a.ampere;
			this.kelvin=a.kelvin;
			this.candela=a.candela;
			this.mol=a.mol;

			this.name=a.name;
		}
		/// <summary>
		/// 内部単位定義用コンストラクタです。
		/// </summary>
		/// <param name="name"></param>
		/// <param name="factor"></param>
		/// <param name="meter"></param>
		/// <param name="kgram"></param>
		/// <param name="second"></param>
		private Unit(string name,double factor,double meter,double kgram,double second){
			this.name=name;
			this.factor=factor;
			this.meter=meter;
			this.kgram=kgram;
			this.second=second;
			Register(this);
		}

		public static class MKSA{
			/// <summary>
			/// 長さの次元の基本単位です。
			/// </summary>
			public static readonly Unit m	=new Unit("m",		1,1,0,0);
			/// <summary>
			/// 重さの次元の基本単位です。
			/// </summary>
			public static readonly Unit kg	=new Unit("kg",		1,0,1,0);
			/// <summary>
			/// 時間の単位の基本単位です。
			/// </summary>
			public static readonly Unit s	=new Unit("s",		1,0,0,1);
			public static readonly Unit A;
			public static readonly Unit N;
			public static readonly Unit J;
			public static readonly Unit W;
			public static readonly Unit Pa;
			public static readonly Unit Hz;

			public static readonly Unit C;
			public static readonly Unit V;
			public static readonly Unit Ohm;
			public static readonly Unit F;
			public static readonly Unit H;
			public static readonly Unit Wb;
			public static readonly Unit S;

			public static readonly Unit mol;
			public static readonly Unit K;
			static MKSA(){
				Unit I=s/s;

				// Newton
				N=kg*m/(s*s);
				N.name="N";
				Register(N);

				// Joule
				J=N*m;
				J.name="J";
				Register(J);

				// Watt
				W=J/s;
				W.name="W";
				Register(W);

				// Pascal
				Pa=N/(m*m);
				Pa.name="Pa";
				Register(Pa);

				// Herz
				Hz=I/s;
				Hz.name="Hz";
				Register(Hz);

				//-------------------------------
				// Ampere
				A=new Unit();
				A.ampere=1;
				A.name="A";
				Register(A);

				// Coulomb
				C=A*s;
				C.name="C";
				Register(C);

				// Volt
				V=J/C;
				V.name="V";
				Register(V);

				// Ohm
				Ohm=V/A;
				Ohm.name="Ω";
				Register(Ohm);

				// Farad
				F=Ohm/s;
				F.name="F";
				Register(F);

				// Henry
				H=Ohm*s;
				H.name="H";
				Register(H);

				// Weber
				Wb=V*s;
				Wb.name="Wb";
				Register(Wb);

				// Siemens
				S=I/Ohm;
				S.name="S";
				Register(S);
				
				//-------------------------------
				// mol
				mol=new Unit();
				mol.mol=1;
				Register(mol);

				//-------------------------------
				// Kelvin
				K=new Unit();
				K.kelvin=1;
				Register(K);
			}
		}
		public Unit Dimension{
			get{
				Unit u=new Unit(this);
				u.factor=0;

				// 既存の次元を検索
				if(Normalize(ref u))return u;
				
				// 新しい次元を登録
				u.name="[Unknown Dimension]";
				Register(u);
				return u;
			}
		}
		// 積によって表現される単位: J・s V/m 等 →派生クラス
		//============================================================
		//		インスタンス管理 (単位の登録)
		//============================================================
		static Gen::Dictionary<string,Unit> units=new System.Collections.Generic.Dictionary<string,Unit>();
		static Unit Register(Unit u){
			if(u.name!="[Unknown Dimension]"){
				units.Add(u.name,u);
				units2.Add(u);
			}
			return u;
		}
		/// <summary>
		/// 正規化 (唯一のインスタンスへの写像) に使用する為の Dictionary です。
		/// </summary>
		static afh.Collections.SortedArrayP<Unit> units2=new afh.Collections.SortedArrayP<Unit>();
		//static Gen::Dictionary<Unit,Unit> dic_units=new System.Collections.Generic.Dictionary<Unit,Unit>();
		/// <summary>
		/// 既に登録されている単位の中から一致する物を検索し、それに置換します。
		/// </summary>
		/// <param name="u"></param>
		/// <returns></returns>
		static bool Normalize(ref Unit u){
			// 登録されていない時: false
			int inf=units2.BinarySearchInf(u);
			if(inf<0||units2.Count<=inf||u!=units2[inf])return false;

			// 厳密に一致する物
			for(int i=inf;i<units2.Count&&units2[i]==u;i++){
				if(CompareExact(units2[i],u)==0)return true;
			}

			// 一致する物
			u=units2[inf];
			return true;
		}
		//============================================================
		//		算術演算
		//============================================================
		public static Unit operator*(Unit a,Unit b){
			Unit u=new Unit(a);
			u.factor*=b.factor;
			u.meter+=b.meter;
			u.kgram+=b.kgram;
			u.second+=b.second;
			u.ampere+=b.ampere;
			u.kelvin+=b.kelvin;
			u.candela+=b.candela;
			u.mol+=b.mol;
			if(!Normalize(ref u)){
				u.name=a.name+"・"+b.name;
				//Register(u);
			}
			return u;
		}
		public static Unit operator/(Unit a,Unit b){
			Unit u=new Unit(a);
			u.factor/=b.factor;
			u.meter-=b.meter;
			u.kgram-=b.kgram;
			u.second-=b.second;
			u.ampere-=b.ampere;
			u.kelvin-=b.kelvin;
			u.candela-=b.candela;
			u.mol-=b.mol;
			if(!Normalize(ref u)){
				u.name=a.name+"・"+b.name+"^(-1)";
				//Register(u);
			}
			return u;
		}
		//============================================================
		//		比較演算
		//============================================================
		//		基本比較演算
		//------------------------------------------------------------
		/// <summary>
		/// 次元用の EPSILON 値です。
		/// 次元の指数が、これよりも小さい場合には、同一の次元の指数と見做されます。
		/// </summary>
		const double DIM_EPSILON=1e-10;
		/// <summary>
		/// 各次元について、その次元の大小を判定します。
		/// DIM_EPSILON より小さい差は無視されて、同じ次元の大きさであると判定されます。
		/// </summary>
		/// <param name="a">比較の右辺を指定します。</param>
		/// <param name="b">比較の左辺を指定します。</param>
		/// <returns>
		/// 右辺が左辺よりも大きい場合に 1 を返します。
		/// 右辺と左辺が同じ次元の大きさであると判定された場合に 0 を返します。
		/// 左辺が右辺よりも小さい場合に -1 を返します。
		/// </returns>
		private static int CompareDim(double a,double b){
			double d=a-b;
			if(d>=0)
				return d<DIM_EPSILON?0: 1;
			else
				return -d<DIM_EPSILON?0: -1;
		}
		/// <summary>
		/// Unit 内の次元全てを纏めて、その順番の大小を判定します。
		/// DIM_EPSILON より小さい差は無視されて、同じ次元の大きさであると判定されます。
		/// </summary>
		/// <param name="a">比較の右辺を指定します。</param>
		/// <param name="b">比較の左辺を指定します。</param>
		/// <returns>
		/// 左辺の次元が右辺の次元よりも若い場合に 1 を返します。
		/// 右辺の次元と左辺の次元が同じ次元の大きさであると判定された場合に 0 を返します。
		/// 左辺の次元が右辺の次元よりも若い場合に -1 を返します。
		/// </returns>
		public static int CompareDim(Unit a,Unit b){
			int r;
			if((r=CompareDim(a.meter,b.meter))!=0)return r;
			if((r=CompareDim(a.kgram,b.kgram))!=0)return r;
			if((r=CompareDim(a.second,b.second))!=0)return r;
			if((r=CompareDim(a.ampere,b.ampere))!=0)return r;
			if((r=CompareDim(a.kelvin,b.kelvin))!=0)return r;
			if((r=CompareDim(a.candela,b.candela))!=0)return r;
			if((r=CompareDim(a.mol,b.mol))!=0)return r;
			return 0;
		}
		/// <summary>
		/// 係数用の EPSILON 値です。
		/// 次元の相対誤差が、これよりも小さい場合には、同一の係数と見做されます。
		/// </summary>
		const double FAC_EPSILON=1e-10;
		private static int CompareFactor(Unit a,Unit b){
			double af=a.factor<0?-a.factor: a.factor;
			double bf=b.factor<0?-b.factor: b.factor;
			double mf=af<bf?af:bf;

			double d=a.factor-b.factor;
			if(d>=0){
				return d<FAC_EPSILON*mf?0: 1;
			}else{
				return -d<FAC_EPSILON*mf?0: -1;
			}
		}
		//------------------------------------------------------------
		//		比較関数
		//------------------------------------------------------------
		/// <summary>
		/// 二つのインスタンスの間の順序を判定します。
		/// </summary>
		/// <param name="a">比較するインスタンスを指定します。</param>
		/// <param name="b">比較するインスタンスを指定します。</param>
		/// <returns>
		/// a の方が b よりも順序が先の場合には -1 を返します。
		/// a が b よりも順序が後の場合には 1 を返します。
		/// 順序が同じであると判定された場合には 0 を返します。</returns>
		public static int Compare(Unit a,Unit b){
			int c=CompareDim(a,b);
			if(c!=0)return c;
			return CompareFactor(a,b);
		}
		// IComparable.CompareTo<Unit>
		/// <summary>
		/// 他の Unit インスタンスとの順番を判定します。
		/// </summary>
		/// <param name="other">比較対象のインスタンスを指定します。</param>
		/// <returns>このインスタンスの方が順番が先の場合に -1 を返します。
		/// このインスタンスの方が順番が後の場合に 1 を返します。
		/// 順序が付けられない場合 (同じ順位の場合) には 0 を返します。</returns>
		public int CompareTo(Unit other){
			return Compare(this,other);
		}
		/// <summary>
		/// Unit インスタンスの間に順序を付けます。
		/// 単位の名称まで含めた厳密な比較を行います。
		/// </summary>
		/// <param name="a">比較するインスタンスを指定します。</param>
		/// <param name="b">比較するインスタンスを指定します。</param>
		/// <returns>a が b よりも順序が先の場合に -1 を返します。
		/// a が b よりも順序が後の場合に 1 を返します。
		/// a と b が完全に同じ単位である時に 0 を返します。</returns>
		public static int CompareExact(Unit a,Unit b){
			int c=Compare(a,b);
			if(c!=0)return c;
			return string.Compare(a.name,b.name);
		}
		public bool Equals(Unit other){
			return other!=null&&CompareTo(other)==0;
		}
		//------------------------------------------------------------
		//		等値比較演算
		//------------------------------------------------------------
		/// <summary>
		/// 二つの単位が等しい単位を表現しているかどうかを判定します。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>指定した二つの単位が、等しい単位を表現していると判断される場合に true を返します。
		/// それ以外の場合に false を返します。</returns>
		public static bool operator==(Unit a,Unit b){
			return CompareDim(a,b)==0&&CompareFactor(a,b)==0;
		}
		/// <summary>
		/// 二つの単位が異なる単位を表現しているかどうかを判定します。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>指定した二つの単位が、異なる単位を表現していると判断される場合に true を返します。
		/// それ以外の場合に false を返します。</returns>
		public static bool operator!=(Unit a,Unit b){
			return !(a==b);
		}
		static readonly double LOGF_EPSILON=System.Math.Log(1+FAC_EPSILON);
		public override int GetHashCode(){
			int hash_dim
				=System.Math.Floor(this.meter/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.kgram/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.second/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.ampere/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.kelvin/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.candela/DIM_EPSILON).GetHashCode()
				^System.Math.Floor(this.mol/DIM_EPSILON).GetHashCode();
			double f=System.Math.Exp(ksh.IntUtils.Floor(System.Math.Log(this.factor),LOGF_EPSILON));
			return hash_dim^f.GetHashCode();
		}
		public override bool Equals(object obj){
			Unit u=obj as Unit;
			return u!=null&&this==u;
		}
		//------------------------------------------------------------
		//		大小比較演算
		//------------------------------------------------------------
		/// <summary>
		/// 二つの単位を並べ替える際に使用する順序を定義します。
		/// この演算子は、小也演算子です。
		/// 同じ次元・同じ係数の場合には、等しい単位として扱われます。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>左辺の方が右辺より小さい場合に true を返します。それ以外の場合には false を返します。</returns>
		public static bool operator<(Unit a,Unit b){
			int r=CompareDim(a,b);
			return r!=0?r<0: CompareFactor(a,b)<0;
		}
		/// <summary>
		/// 二つの単位を並べ替える際に使用する順序を定義します。
		/// この演算子は、大也演算子です。
		/// 同じ次元・同じ係数の場合には、等しい単位として扱われます。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>左辺の方が右辺より大きい場合に true を返します。それ以外の場合には false を返します。</returns>
		public static bool operator>(Unit a,Unit b) { return b<a; }
		/// <summary>
		/// 二つの単位を並べ替える際に使用する順序を定義します。
		/// この演算子は、以下演算子です。
		/// 同じ次元・同じ係数の場合には、等しい単位として扱われます。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>左辺が右辺以下の場合に true を返します。それ以外の場合には false を返します。</returns>
		public static bool operator<=(Unit a,Unit b) { return !(b<a); }
		/// <summary>
		/// 二つの単位を並べ替える際に使用する順序を定義します。
		/// この演算子は、以上演算子です。
		/// 同じ次元・同じ係数の場合には、等しい単位として扱われます。
		/// </summary>
		/// <param name="a">比べる単位の左辺を指定します。</param>
		/// <param name="b">比べる単位の右辺を指定します。</param>
		/// <returns>左辺が右辺以上の場合に true を返します。それ以外の場合には false を返します。</returns>
		public static bool operator>=(Unit a,Unit b) { return !(a<b); }
		//------------------------------------------------------------
		//		比較用デリゲート
		//------------------------------------------------------------
		/// <summary>
		/// 厳密比較用の比較器 (CompareExact) をデリゲートとして取得します。
		/// </summary>
		public static System.Comparison<Unit> ExactComparer{
			get{return CompareExact;}
		}
		/// <summary>
		/// 次元比較用の比較器 (CompareDim) をデリゲートとして取得します。
		/// </summary>
		public static System.Comparison<Unit> DimensionComparer{
			get{return CompareDim;}
		}
	}

	public static class Constants{
		public const double PlankH		=6.62606896e-34;
		public const double PlankHbar	=1.054571628e-34;

		public const double AvogadroNumber=6.0221415e23;
		public static Unit u;
		public static void S(){}
	}
}

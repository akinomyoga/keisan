using System;
using Gen=System.Collections.Generic;
using System.Text;

namespace ksh.Physics{
	// (�P�ʁE�덷�t���̐����`����Ɨǂ�)
	// �P�ʌn�E�ړ���
	/// <summary>
	/// �P�ʋy�ю�����\������N���X�ł��B
	/// <para>��̒P�ʂɑ΂��Ĉ�̃C���X�^���X���p�ӂ���܂��B</para>
	/// <para>
	/// �C���X�^���X�̔�r�ɂ́A
	/// 1. �����P�ʖ��������Ă��邩
	/// 2. ���O������Ă����������P�ʂ�
	/// 3. ������������
	/// �̎O��ނ����݂��܂��B��{�I�ɂ́A��r���Z�� 2 �Ɉ˂��čs���܂��B
	/// �n�b�V���R�[�h������{�I�� 2 �ɏ]���Čv�Z����܂��B
	/// 3. �̔�r���s�������ꍇ�ɂ́Astatic int CompareDim() ��p���ĉ������B
	/// �܂��A1. �̔�r���s�������ꍇ�ɂ́Astatic int CompareExact() ��p���ĉ������B
	/// </para>
	/// </summary>
	public class Unit:System.IComparable<Unit>,System.IEquatable<Unit>{
		string name;
		/// <summary>
		/// SI �P�ʂɑ΂���䗦���w�肵�܂��B��: eV �� 1.602e-19
		/// 0 ���w�肵���ꍇ�ɂ́A���̃C���X�^���X�͒P�ʂł͂Ȃ��āA������\���C���X�^���X�Ƃ��ē��삵�܂��B
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
		/// �����v�Z�p�R���X�g���N�^�ł��B
		/// </summary>
		/// <param name="a">�R�s�[���� Unit ���w�肵�܂��B</param>
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
		/// �����P�ʒ�`�p�R���X�g���N�^�ł��B
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
			/// �����̎����̊�{�P�ʂł��B
			/// </summary>
			public static readonly Unit m	=new Unit("m",		1,1,0,0);
			/// <summary>
			/// �d���̎����̊�{�P�ʂł��B
			/// </summary>
			public static readonly Unit kg	=new Unit("kg",		1,0,1,0);
			/// <summary>
			/// ���Ԃ̒P�ʂ̊�{�P�ʂł��B
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
				Ohm.name="��";
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

				// �����̎���������
				if(Normalize(ref u))return u;
				
				// �V����������o�^
				u.name="[Unknown Dimension]";
				Register(u);
				return u;
			}
		}
		// �ςɂ���ĕ\�������P��: J�Es V/m �� ���h���N���X
		//============================================================
		//		�C���X�^���X�Ǘ� (�P�ʂ̓o�^)
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
		/// ���K�� (�B��̃C���X�^���X�ւ̎ʑ�) �Ɏg�p����ׂ� Dictionary �ł��B
		/// </summary>
		static afh.Collections.SortedArrayP<Unit> units2=new afh.Collections.SortedArrayP<Unit>();
		//static Gen::Dictionary<Unit,Unit> dic_units=new System.Collections.Generic.Dictionary<Unit,Unit>();
		/// <summary>
		/// ���ɓo�^����Ă���P�ʂ̒������v���镨���������A����ɒu�����܂��B
		/// </summary>
		/// <param name="u"></param>
		/// <returns></returns>
		static bool Normalize(ref Unit u){
			// �o�^����Ă��Ȃ���: false
			int inf=units2.BinarySearchInf(u);
			if(inf<0||units2.Count<=inf||u!=units2[inf])return false;

			// �����Ɉ�v���镨
			for(int i=inf;i<units2.Count&&units2[i]==u;i++){
				if(CompareExact(units2[i],u)==0)return true;
			}

			// ��v���镨
			u=units2[inf];
			return true;
		}
		//============================================================
		//		�Z�p���Z
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
				u.name=a.name+"�E"+b.name;
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
				u.name=a.name+"�E"+b.name+"^(-1)";
				//Register(u);
			}
			return u;
		}
		//============================================================
		//		��r���Z
		//============================================================
		//		��{��r���Z
		//------------------------------------------------------------
		/// <summary>
		/// �����p�� EPSILON �l�ł��B
		/// �����̎w�����A��������������ꍇ�ɂ́A����̎����̎w���ƌ��􂳂�܂��B
		/// </summary>
		const double DIM_EPSILON=1e-10;
		/// <summary>
		/// �e�����ɂ��āA���̎����̑召�𔻒肵�܂��B
		/// DIM_EPSILON ��菬�������͖�������āA���������̑傫���ł���Ɣ��肳��܂��B
		/// </summary>
		/// <param name="a">��r�̉E�ӂ��w�肵�܂��B</param>
		/// <param name="b">��r�̍��ӂ��w�肵�܂��B</param>
		/// <returns>
		/// �E�ӂ����ӂ����傫���ꍇ�� 1 ��Ԃ��܂��B
		/// �E�ӂƍ��ӂ����������̑傫���ł���Ɣ��肳�ꂽ�ꍇ�� 0 ��Ԃ��܂��B
		/// ���ӂ��E�ӂ����������ꍇ�� -1 ��Ԃ��܂��B
		/// </returns>
		private static int CompareDim(double a,double b){
			double d=a-b;
			if(d>=0)
				return d<DIM_EPSILON?0: 1;
			else
				return -d<DIM_EPSILON?0: -1;
		}
		/// <summary>
		/// Unit ���̎����S�Ă�Z�߂āA���̏��Ԃ̑召�𔻒肵�܂��B
		/// DIM_EPSILON ��菬�������͖�������āA���������̑傫���ł���Ɣ��肳��܂��B
		/// </summary>
		/// <param name="a">��r�̉E�ӂ��w�肵�܂��B</param>
		/// <param name="b">��r�̍��ӂ��w�肵�܂��B</param>
		/// <returns>
		/// ���ӂ̎������E�ӂ̎��������Ⴂ�ꍇ�� 1 ��Ԃ��܂��B
		/// �E�ӂ̎����ƍ��ӂ̎��������������̑傫���ł���Ɣ��肳�ꂽ�ꍇ�� 0 ��Ԃ��܂��B
		/// ���ӂ̎������E�ӂ̎��������Ⴂ�ꍇ�� -1 ��Ԃ��܂��B
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
		/// �W���p�� EPSILON �l�ł��B
		/// �����̑��Ό덷���A��������������ꍇ�ɂ́A����̌W���ƌ��􂳂�܂��B
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
		//		��r�֐�
		//------------------------------------------------------------
		/// <summary>
		/// ��̃C���X�^���X�̊Ԃ̏����𔻒肵�܂��B
		/// </summary>
		/// <param name="a">��r����C���X�^���X���w�肵�܂��B</param>
		/// <param name="b">��r����C���X�^���X���w�肵�܂��B</param>
		/// <returns>
		/// a �̕��� b ������������̏ꍇ�ɂ� -1 ��Ԃ��܂��B
		/// a �� b ������������̏ꍇ�ɂ� 1 ��Ԃ��܂��B
		/// �����������ł���Ɣ��肳�ꂽ�ꍇ�ɂ� 0 ��Ԃ��܂��B</returns>
		public static int Compare(Unit a,Unit b){
			int c=CompareDim(a,b);
			if(c!=0)return c;
			return CompareFactor(a,b);
		}
		// IComparable.CompareTo<Unit>
		/// <summary>
		/// ���� Unit �C���X�^���X�Ƃ̏��Ԃ𔻒肵�܂��B
		/// </summary>
		/// <param name="other">��r�Ώۂ̃C���X�^���X���w�肵�܂��B</param>
		/// <returns>���̃C���X�^���X�̕������Ԃ���̏ꍇ�� -1 ��Ԃ��܂��B
		/// ���̃C���X�^���X�̕������Ԃ���̏ꍇ�� 1 ��Ԃ��܂��B
		/// �������t�����Ȃ��ꍇ (�������ʂ̏ꍇ) �ɂ� 0 ��Ԃ��܂��B</returns>
		public int CompareTo(Unit other){
			return Compare(this,other);
		}
		/// <summary>
		/// Unit �C���X�^���X�̊Ԃɏ�����t���܂��B
		/// �P�ʂ̖��̂܂Ŋ܂߂������Ȕ�r���s���܂��B
		/// </summary>
		/// <param name="a">��r����C���X�^���X���w�肵�܂��B</param>
		/// <param name="b">��r����C���X�^���X���w�肵�܂��B</param>
		/// <returns>a �� b ������������̏ꍇ�� -1 ��Ԃ��܂��B
		/// a �� b ������������̏ꍇ�� 1 ��Ԃ��܂��B
		/// a �� b �����S�ɓ����P�ʂł��鎞�� 0 ��Ԃ��܂��B</returns>
		public static int CompareExact(Unit a,Unit b){
			int c=Compare(a,b);
			if(c!=0)return c;
			return string.Compare(a.name,b.name);
		}
		public bool Equals(Unit other){
			return other!=null&&CompareTo(other)==0;
		}
		//------------------------------------------------------------
		//		���l��r���Z
		//------------------------------------------------------------
		/// <summary>
		/// ��̒P�ʂ��������P�ʂ�\�����Ă��邩�ǂ����𔻒肵�܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>�w�肵����̒P�ʂ��A�������P�ʂ�\�����Ă���Ɣ��f�����ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�� false ��Ԃ��܂��B</returns>
		public static bool operator==(Unit a,Unit b){
			return CompareDim(a,b)==0&&CompareFactor(a,b)==0;
		}
		/// <summary>
		/// ��̒P�ʂ��قȂ�P�ʂ�\�����Ă��邩�ǂ����𔻒肵�܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>�w�肵����̒P�ʂ��A�قȂ�P�ʂ�\�����Ă���Ɣ��f�����ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�� false ��Ԃ��܂��B</returns>
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
		//		�召��r���Z
		//------------------------------------------------------------
		/// <summary>
		/// ��̒P�ʂ���בւ���ۂɎg�p���鏇�����`���܂��B
		/// ���̉��Z�q�́A���牉�Z�q�ł��B
		/// ���������E�����W���̏ꍇ�ɂ́A�������P�ʂƂ��Ĉ����܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>���ӂ̕����E�ӂ�菬�����ꍇ�� true ��Ԃ��܂��B����ȊO�̏ꍇ�ɂ� false ��Ԃ��܂��B</returns>
		public static bool operator<(Unit a,Unit b){
			int r=CompareDim(a,b);
			return r!=0?r<0: CompareFactor(a,b)<0;
		}
		/// <summary>
		/// ��̒P�ʂ���בւ���ۂɎg�p���鏇�����`���܂��B
		/// ���̉��Z�q�́A��牉�Z�q�ł��B
		/// ���������E�����W���̏ꍇ�ɂ́A�������P�ʂƂ��Ĉ����܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>���ӂ̕����E�ӂ��傫���ꍇ�� true ��Ԃ��܂��B����ȊO�̏ꍇ�ɂ� false ��Ԃ��܂��B</returns>
		public static bool operator>(Unit a,Unit b) { return b<a; }
		/// <summary>
		/// ��̒P�ʂ���בւ���ۂɎg�p���鏇�����`���܂��B
		/// ���̉��Z�q�́A�ȉ����Z�q�ł��B
		/// ���������E�����W���̏ꍇ�ɂ́A�������P�ʂƂ��Ĉ����܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>���ӂ��E�ӈȉ��̏ꍇ�� true ��Ԃ��܂��B����ȊO�̏ꍇ�ɂ� false ��Ԃ��܂��B</returns>
		public static bool operator<=(Unit a,Unit b) { return !(b<a); }
		/// <summary>
		/// ��̒P�ʂ���בւ���ۂɎg�p���鏇�����`���܂��B
		/// ���̉��Z�q�́A�ȏ㉉�Z�q�ł��B
		/// ���������E�����W���̏ꍇ�ɂ́A�������P�ʂƂ��Ĉ����܂��B
		/// </summary>
		/// <param name="a">��ׂ�P�ʂ̍��ӂ��w�肵�܂��B</param>
		/// <param name="b">��ׂ�P�ʂ̉E�ӂ��w�肵�܂��B</param>
		/// <returns>���ӂ��E�ӈȏ�̏ꍇ�� true ��Ԃ��܂��B����ȊO�̏ꍇ�ɂ� false ��Ԃ��܂��B</returns>
		public static bool operator>=(Unit a,Unit b) { return !(a<b); }
		//------------------------------------------------------------
		//		��r�p�f���Q�[�g
		//------------------------------------------------------------
		/// <summary>
		/// ������r�p�̔�r�� (CompareExact) ���f���Q�[�g�Ƃ��Ď擾���܂��B
		/// </summary>
		public static System.Comparison<Unit> ExactComparer{
			get{return CompareExact;}
		}
		/// <summary>
		/// ������r�p�̔�r�� (CompareDim) ���f���Q�[�g�Ƃ��Ď擾���܂��B
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

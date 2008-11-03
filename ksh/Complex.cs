#define FAST
//#define NOCARE

// 何も指定しない場合
// 　　通常の算術演算で毎回 ∞ の判定を行います。
// 　　Real や Imaginary を取得したりする場合には ∞ の判定は簡単な物に留めます。
// FAST を指定した場合
// 　　通常の算術演算では ∞ の判定を無視します。
// 　　Real や Imaginary を取得したりする場合には ∞ の判定を行います。
// 　　→判定を或る程度高速化出来たので、これで行く事にする。
// NOCARE を指定した場合
// 　　通常の算術演算で ∞ の判定を無視します。
// 　　Real や Imaginary を取得したりする場合にも ∞ の判定を無視します。
// 　　従って、この場合には同じ ∞ でも Real や Imaginary や == の結果は毎回異なるという事になります。
using Interop=System.Runtime.InteropServices;

namespace ksh{
	/// <summary>
	/// 複素数を表現する構造体です。
	/// </summary>
	[Interop::StructLayout(Interop::LayoutKind.Sequential)]
	[System.Serializable]
	public struct Complex{
		private double real;
		private double imag;

		public Complex(double real,double imag){
#if !FAST&&!NOCARE
			double z;
			if(double.IsInfinity(z=real+imag)||double.IsNaN(z)){
				this.real=this.imag=double.PositiveInfinity;
				return;
			}
#endif
			this.real=real;
			this.imag=imag;
		}
		/// <summary>
		/// 極形式で Complex を初期化します。
		/// </summary>
		/// <param name="abs">絶対値の大きさを指定します。</param>
		/// <param name="arg">偏角を指定します。</param>
		/// <returns>指定した引数を元に作成した Complex 値を返します。</returns>
		public static Complex FromPolarForm(double abs,double arg){
			return new Complex(abs*System.Math.Cos(arg),abs*System.Math.Sin(arg));
		}
		/// <summary>
		/// 実数値を Complex に変換します。
		/// </summary>
		/// <param name="value">複素数に変換する前の実数値を指定します。</param>
		/// <returns>指定した実数値を Complex で表現した値を返します。</returns>
		public static implicit operator Complex(double value){
			return new Complex(value,0);
		}
		//===========================================================
		//		定数
		//===========================================================
		/// <summary>
		/// 1 を表現する定数です。
		/// </summary>
		public static readonly Complex One=new Complex(1,0);
		/// <summary>
		/// 虚数単位を表現する定数です。
		/// </summary>
		public static readonly Complex I=new Complex(0,1);
		/// <summary>
		/// 無限遠点を表現する定数です。
		/// </summary>
		public static readonly Complex Infinity=new Complex(double.PositiveInfinity,double.PositiveInfinity);
		/// <summary>
		/// 零を表現する定数です。
		/// </summary>
		public static readonly Complex Zero=new Complex(0,0);
		/// <summary>
		/// 自然対数の底を表現する定数です。
		/// </summary>
		public static readonly Complex E=new Complex(System.Math.E,0);
		//===========================================================
		//		状態
		//===========================================================
		/// <summary>
		/// この値の実部を取得します。
		/// </summary>
		public double Real{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:this.real;}
#else
			get{return real;}
#endif
		}
		/// <summary>
		/// この値の虚数部を取得します。
		/// </summary>
		public double Imaginary{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:this.imag;}
#else
			get{return imag;}
#endif
		}
		/// <summary>
		/// この値の絶対値を求めます。
		/// </summary>
		public double Absolute{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:System.Math.Sqrt(this.real*this.real+this.imag*this.imag);}
#else
			get{return System.Math.Sqrt(this.real*this.real+this.imag*this.imag);}
#endif
		}
		/// <summary>
		/// この値の偏角を求めます。
		/// </summary>
		public double Argument{
			get{
				// IsInfinity → ∞ (若し確認しないと(∞,0) → 0 等と出てしまう。)
				return this.IsZero||this.IsInfinity?double.NaN:System.Math.Atan2(imag,real);
			}
		}
		/// <summary>
		/// この値が 0 であるか否かを取得します。
		/// </summary>
		public bool IsZero{
			get{return this.real==0&&this.imag==0;}
		}
		/// <summary>
		/// この値が無限遠点であるか否かを取得します。
		/// </summary>
		public unsafe bool IsInfinity{
			get{
				const long pInfRep=0x7ff0000000000000L;
				double z=this.real+this.imag;
				return (*(long*)(&z)&pInfRep)==pInfRep;
			}
		}
		private unsafe static bool IsNfN(double value){
			const long pInfRep=0x7ff0L<<48;
			return (*(long*)(&value)&pInfRep)==pInfRep;
		}
		/* 古いコード
		public bool IsInfinity{
#if FAST&&!NOCARE
			get{
				return double.IsInfinity(this.real)||double.IsNaN(this.real)
					||double.IsInfinity(this.imag)||double.IsNaN(this.imag)
			}
#else
			get{return this.real==double.PositiveInfinity; }
#endif
		}
		*/
		/// <summary>
		/// この値が実数を表しているか否かを取得します。
		/// </summary>
		public bool IsReal{
#if FAST&&!NOCARE
			get{return !this.IsInfinity||this.imag==0;}
#else
			get{return this.imag==0;}
#endif
		}
		/// <summary>
		/// この値が純虚数を表しているか否かを取得します。
		/// </summary>
		public bool IsPureImaginary{
#if FAST&&!NOCARE
			get{return !this.IsInfinity||this.real==0;}
#else
			get{return this.real==0;}
#endif
		}
		/// <summary>
		/// このインスタンスの値を文字列で表します。
		/// </summary>
		/// <returns>インスタンスの内容を表現する文字列を返します。</returns>
		public override string ToString(){
			if(this.IsInfinity)return "∞";
			if(this.IsReal)return this.real.ToString();
			if(this.IsPureImaginary)return this.imag==1?"i":this.imag.ToString()+"i";
			return this.real.ToString()+" + i "+this.imag.ToString();
		}
		//===========================================================
		//		算術演算: 四則
		//===========================================================
		/// <summary>
		/// 乗法の逆数を取得します。
		/// </summary>
		public Complex Reciprocal{
			get{
				if(this.IsInfinity)return Zero;
				double abs2=this.real*this.real+this.imag*this.imag;
				return new Complex(this.real/abs2,-this.imag/abs2);
			}
		}
		//	0  + 0  = 0
		//  0  + ∞ = ∞
		//  ∞ + ∞ = ∞
		public static Complex operator+(Complex left,Complex right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||right.IsInfinity)return Infinity;
#endif
			return new Complex(left.real+right.real,left.imag+right.imag);
		}
		public static Complex operator+(Complex left,double right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||double.IsInfinity(right)||double.IsNaN(right)) return Infinity;
#endif
			return new Complex(left.real+right,left.imag);
		}
		public static Complex operator+(double left,Complex right){
#if !FAST&&!NOCARE
			if(double.IsInfinity(left)||double.IsNaN(left)||right.IsInfinity) return Infinity;
#endif
			return new Complex(left+right.real,right.imag);
		}
		public static Complex operator-(Complex value){
#if !FAST&&!NOCARE
			if(value.IsInfinity)return Infinity;
#endif
			return new Complex(-value.real,-value.imag);
		}
		//	0  - 0  = 0
		//  0  - ∞ = ∞
		//  ∞ - ∞ = ∞
		public static Complex operator-(Complex left,Complex right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||right.IsInfinity)return Infinity;
#endif
			return new Complex(left.real-right.real,left.imag-right.imag);
		}
		public static Complex operator-(double left,Complex right){
#if !FAST&&!NOCARE
			if(IsNfN(left)||right.IsInfinity)return Infinity;
#endif
			return new Complex(left-right.real,-right.imag);
		}
		public static Complex operator-(Complex left,double right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||IsNfN(right))return Infinity;
#endif
			return new Complex(left.real-right,left.imag);
		}
		//	0  * 0  = 0
		//  f  * ∞ = ∞
		//  ∞ * ∞ = ∞
		public static Complex operator*(Complex left,Complex right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||right.IsInfinity)return Infinity;
#endif
			double real=left.real*right.real-left.imag*right.imag;
			double imag=left.real*right.imag+left.imag*right.real;
			return new Complex(real,imag);
		}
		public static Complex operator*(Complex left,double right){
#if !FAST&&!NOCARE
			if(left.IsInfinity||IsNfN(right))return Infinity;
#endif
			return new Complex(left.real*right,left.real*right);
		}
		public static Complex operator*(double left,Complex right){
#if !FAST&&!NOCARE
			if(IsNfN(left)||right.IsInfinity)return Infinity;
#endif
			return new Complex(left*right.real,left*right.imag);
		}
		//	0  / 0  = ∞
		//  f  / ∞ = 0
		//  ∞ / ∞ = ∞
		//  ∞ / f  = ∞
		public static Complex operator/(Complex left,Complex right){
#if !NOCARE
			if(right.IsInfinity)return left.IsInfinity?Infinity:Zero;
#if !FAST
			if(right.IsZero)return Infinity;
			if(left.IsInfinity)return Infinity;
#endif
#endif
			double abs2=right.real*right.real+right.imag*right.imag;
			double real=(left.real*right.real+left.imag*right.imag)/abs2;
			double imag=(left.imag*right.real-left.real*right.imag)/abs2;
			return new Complex(real,imag);
		}
		public static Complex operator/(double left,Complex right){
#if !NOCARE
			if(right.IsInfinity)return IsNfN(left)?Infinity:Zero;
#if !FAST
			if(right.IsZero)return Infinity;
			if(IsNfN(left))return Infinity;
#endif
#endif
			double abs2=right.real*right.real+right.imag*right.imag;
			return new Complex(left*right.real/abs2,-left*right.imag/abs2);
		}
		public static Complex operator/(Complex left,double right){
#if !NOCARE
			if(IsNfN(right))return left.IsInfinity?Infinity:Zero;
#if !FAST
			if(right==0)return Infinity;
			if(left.IsInfinity)return Infinity;
#endif
#endif
			return new Complex(left.real/right,left.imag/right);
		}
		//===========================================================
		//		算術演算: その他
		//===========================================================
		/// <summary>
		/// 複素共役を取得します。
		/// </summary>
		public Complex Conjugate{
#if FAST&&!NOCARE
			get{return new Complex(this.real,-this.imag);}
#else
			get{return this.IsInfinity?Infinity:new Complex(this.real,-this.imag);}
#endif
		}
		/// <summary>
		/// 与えられた複素数の複素共役を取得します。
		/// </summary>
		/// <param name="value">複素共役を取る複素数を指定します。</param>
		/// <returns>複素共役を取った結果の複素数を返します。</returns>
		public static Complex operator~(Complex value){
#if FAST&&!NOCARE
			return new Complex(value.real,-value.imag);
#else
			return this.IsInfinity?Infinity:new Complex(this.real,-this.imag);
#endif
		}
		/// <summary>
		/// 複素数の羃乗を計算します。
		/// </summary>
		/// <param name="left">羃乗の底を指定します。</param>
		/// <param name="right">羃乗の指数を指定します。</param>
		/// <returns>羃乗を計算した結果を返します。</returns>
		public static Complex operator^(Complex left,Complex right){
			return pow(left,right);
		}
		/// <summary>
		/// 複素数の羃乗を計算します。
		/// </summary>
		/// <param name="left">羃乗の底を指定します。</param>
		/// <param name="right">羃乗の指数を指定します。</param>
		/// <returns>羃乗を計算した結果を返します。</returns>
		public static Complex operator^(Complex left,double right){
			return pow(left,(Complex)right);
		}
		/// <summary>
		/// 複素数の羃乗を計算します。
		/// </summary>
		/// <param name="left">羃乗の底を指定します。</param>
		/// <param name="right">羃乗の指数を指定します。</param>
		/// <returns>羃乗を計算した結果を返します。</returns>
		public static Complex operator^(double left,Complex right){
			if(left==0)
				return right==Complex.Zero?Complex.Infinity:Complex.Zero;
			return exp(right*System.Math.Log(left));
		}
		/// <summary>
		/// 複素数の羃乗を計算します。
		/// </summary>
		/// <param name="left">羃乗の底を指定します。</param>
		/// <param name="right">羃乗の指数を指定します。</param>
		/// <returns>羃乗を計算した結果を返します。</returns>
		public static Complex operator^(Complex left,int right){
			if(right<0){
				left=left.Reciprocal;
				right=-right;
			}
			if(right>=128)return left^(double)right;

			Complex r=1;
			while(true){
				if((right&1)!=0) r*=left;
				if(0==(right>>=1)) return r;
				left*=left;
			}
		}
		//===========================================================
		//		比較演算
		//===========================================================
		public static bool operator==(Complex left,Complex right){
#if FAST&&!NOCARE
			if(left.IsInfinity&&right.IsInfinity)return true;
#endif
			return left.real==right.real&&left.imag==right.imag;
		}
		public static bool operator==(double left,Complex right){
			if(IsNfN(left)&&right.IsInfinity)return true;
			return right.real==left&&right.imag==0;
		}
		public static bool operator==(Complex left,double right){
			if(IsNfN(right)&&left.IsInfinity)return true;
			return left.real==right&&left.imag==0;
		}
		public static bool operator!=(Complex left,Complex right){
			return !(left==right);
		}
		public static bool operator!=(double left,Complex right){
			return !(left==right);
		}
		public static bool operator!=(Complex left,double right){
			return !(left==right);
		}
		public override bool Equals(object obj) {
			if(obj is Complex)return this==(Complex)obj;
			System.Type t=obj.GetType();
			if(t.IsPrimitive&&t!=typeof(bool)&&t!=typeof(char)||t==typeof(decimal)){
				return System.Convert.ToDouble(obj)==this;
			}
			return false;
		}
		public unsafe override int GetHashCode(){
			fixed(Complex* p=&this)
				return (*(long*)&(p->real)|*(long*)&(p->imag)).GetHashCode();
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<(Complex left,Complex right){
			return left.Absolute<right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<(double left,Complex right){
			return System.Math.Abs(left)<right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<(Complex left,double right){
			return left.Absolute<System.Math.Abs(right);
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の絶対値が右辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<=(Complex left,Complex right){
			return left.Absolute<=right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の絶対値が右辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<=(double left,Complex right){
			return System.Math.Abs(left)<=right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 左辺の絶対値が右辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator<=(Complex left,double right){
			return left.Absolute<=System.Math.Abs(right);
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>(Complex left,Complex right){
			return left.Absolute>right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>(double left,Complex right){
			return System.Math.Abs(left)>right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の方が絶対値が小さい場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>(Complex left,double right){
			return left.Absolute>System.Math.Abs(right);
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の絶対値が左辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>=(Complex left,Complex right){
			return left.Absolute>=right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の絶対値が左辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>=(double left,Complex right){
			return System.Math.Abs(left)>=right.Absolute;
		}
		/// <summary>
		/// 絶対値の大きさで大小を比較します。
		/// </summary>
		/// <param name="left">比較する右辺値を指定します。</param>
		/// <param name="right">比較する左辺値を指定します。</param>
		/// <returns>比較した結果を返します。
		/// 右辺の絶対値が左辺の絶対値以下の場合に true を返します。
		/// それ以外の場合には true を返します。</returns>
		public static bool operator>=(Complex left,double right){
			return left.Absolute>=System.Math.Abs(right);
		}
		//===========================================================
		//		初等関数
		//===========================================================
		internal static Complex sin(Complex value){
			return new Complex(
				System.Math.Sin(value.real)*System.Math.Cosh(value.imag),
				System.Math.Cos(value.real)*System.Math.Sinh(value.imag)
				);
		}
		internal static Complex cos(Complex value){
			return new Complex(
				System.Math.Cos(value.real)*System.Math.Cosh(value.imag),
				-System.Math.Sin(value.real)*System.Math.Sinh(value.imag)
				);
		}
		internal static Complex tan(Complex value){
			double t=System.Math.Tan(value.real);
			double h=System.Math.Tanh(value.imag);
			double f=1/(1+t*t*h*h);
			return new Complex(t*(1-h*h)*f,h*(1+t*t)*f);
		}
		internal static Complex sinh(Complex value){
			return new Complex(
				System.Math.Sinh(value.real)*System.Math.Cos(value.imag),
				System.Math.Cosh(value.real)*System.Math.Sin(value.imag)
				);
		}
		internal static Complex cosh(Complex value){
			return new Complex(
				System.Math.Cosh(value.real)*System.Math.Cos(value.imag),
				System.Math.Sinh(value.real)*System.Math.Sin(value.imag)
				);
		}
		internal static Complex tanh(Complex value){
			double t=System.Math.Tan(value.imag);
			double h=System.Math.Tanh(value.real);
			double f=1/(1+t*t*h*h);
			return new Complex(t*(1-h*h)*f,h*(1+t*t)*f);
		} // 488.01 ns
		internal static Complex exp(Complex value){
			return FromPolarForm(System.Math.Exp(value.real),value.imag);
		}
		internal static Complex log(Complex value){
			double theta=value.Argument;

			// value==0||value==Infinity の時
			if(double.IsNaN(theta))return Complex.Infinity;
			
			return new Complex(System.Math.Log(value.Absolute),theta);
		}
		internal static Complex pow(Complex _base,Complex index){
			if(_base==Complex.Zero)
				return index==Complex.Zero?Complex.Infinity:_base;
			return exp(index*log(_base));
		}
	}
}
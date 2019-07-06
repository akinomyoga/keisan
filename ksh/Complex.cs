#define FAST
//#define NOCARE

// �����w�肵�Ȃ��ꍇ
// �@�@�ʏ�̎Z�p���Z�Ŗ��� �� �̔�����s���܂��B
// �@�@Real �� Imaginary ���擾�����肷��ꍇ�ɂ� �� �̔���͊ȒP�ȕ��ɗ��߂܂��B
// FAST ���w�肵���ꍇ
// �@�@�ʏ�̎Z�p���Z�ł� �� �̔���𖳎����܂��B
// �@�@Real �� Imaginary ���擾�����肷��ꍇ�ɂ� �� �̔�����s���܂��B
// �@�@�������������x�������o�����̂ŁA����ōs�����ɂ���B
// NOCARE ���w�肵���ꍇ
// �@�@�ʏ�̎Z�p���Z�� �� �̔���𖳎����܂��B
// �@�@Real �� Imaginary ���擾�����肷��ꍇ�ɂ� �� �̔���𖳎����܂��B
// �@�@�]���āA���̏ꍇ�ɂ͓��� �� �ł� Real �� Imaginary �� == �̌��ʂ͖���قȂ�Ƃ������ɂȂ�܂��B
using Interop=System.Runtime.InteropServices;

namespace ksh{
	/// <summary>
	/// ���f����\������\���̂ł��B
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
		/// �Ɍ`���� Complex �����������܂��B
		/// </summary>
		/// <param name="abs">��Βl�̑傫�����w�肵�܂��B</param>
		/// <param name="arg">�Ίp���w�肵�܂��B</param>
		/// <returns>�w�肵�����������ɍ쐬���� Complex �l��Ԃ��܂��B</returns>
		public static Complex FromPolarForm(double abs,double arg){
			return new Complex(abs*System.Math.Cos(arg),abs*System.Math.Sin(arg));
		}
		/// <summary>
		/// �����l�� Complex �ɕϊ����܂��B
		/// </summary>
		/// <param name="value">���f���ɕϊ�����O�̎����l���w�肵�܂��B</param>
		/// <returns>�w�肵�������l�� Complex �ŕ\�������l��Ԃ��܂��B</returns>
		public static implicit operator Complex(double value){
			return new Complex(value,0);
		}
		//===========================================================
		//		�萔
		//===========================================================
		/// <summary>
		/// 1 ��\������萔�ł��B
		/// </summary>
		public static readonly Complex One=new Complex(1,0);
		/// <summary>
		/// �����P�ʂ�\������萔�ł��B
		/// </summary>
		public static readonly Complex I=new Complex(0,1);
		/// <summary>
		/// �������_��\������萔�ł��B
		/// </summary>
		public static readonly Complex Infinity=new Complex(double.PositiveInfinity,double.PositiveInfinity);
		/// <summary>
		/// ���\������萔�ł��B
		/// </summary>
		public static readonly Complex Zero=new Complex(0,0);
		/// <summary>
		/// ���R�ΐ��̒��\������萔�ł��B
		/// </summary>
		public static readonly Complex E=new Complex(System.Math.E,0);
		//===========================================================
		//		���
		//===========================================================
		/// <summary>
		/// ���̒l�̎������擾���܂��B
		/// </summary>
		public double Real{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:this.real;}
#else
			get{return real;}
#endif
		}
		/// <summary>
		/// ���̒l�̋��������擾���܂��B
		/// </summary>
		public double Imaginary{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:this.imag;}
#else
			get{return imag;}
#endif
		}
		/// <summary>
		/// ���̒l�̐�Βl�����߂܂��B
		/// </summary>
		public double Absolute{
#if FAST&&!NOCARE
			get{return this.IsInfinity?double.PositiveInfinity:System.Math.Sqrt(this.real*this.real+this.imag*this.imag);}
#else
			get{return System.Math.Sqrt(this.real*this.real+this.imag*this.imag);}
#endif
		}
		/// <summary>
		/// ���̒l�̕Ίp�����߂܂��B
		/// </summary>
		public double Argument{
			get{
				// IsInfinity �� �� (�Ⴕ�m�F���Ȃ���(��,0) �� 0 ���Əo�Ă��܂��B)
				return this.IsZero||this.IsInfinity?double.NaN:System.Math.Atan2(imag,real);
			}
		}
		/// <summary>
		/// ���̒l�� 0 �ł��邩�ۂ����擾���܂��B
		/// </summary>
		public bool IsZero{
			get{return this.real==0&&this.imag==0;}
		}
		/// <summary>
		/// ���̒l���������_�ł��邩�ۂ����擾���܂��B
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
		/* �Â��R�[�h
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
		/// ���̒l��������\���Ă��邩�ۂ����擾���܂��B
		/// </summary>
		public bool IsReal{
#if FAST&&!NOCARE
			get{return !this.IsInfinity||this.imag==0;}
#else
			get{return this.imag==0;}
#endif
		}
		/// <summary>
		/// ���̒l����������\���Ă��邩�ۂ����擾���܂��B
		/// </summary>
		public bool IsPureImaginary{
#if FAST&&!NOCARE
			get{return !this.IsInfinity||this.real==0;}
#else
			get{return this.real==0;}
#endif
		}
		/// <summary>
		/// ���̃C���X�^���X�̒l�𕶎���ŕ\���܂��B
		/// </summary>
		/// <returns>�C���X�^���X�̓��e��\�����镶�����Ԃ��܂��B</returns>
		public override string ToString(){
			if(this.IsInfinity)return "��";
			if(this.IsReal)return this.real.ToString();
			if(this.IsPureImaginary)return this.imag==1?"i":this.imag.ToString()+"i";
			return this.real.ToString()+" + i "+this.imag.ToString();
		}
		//===========================================================
		//		�Z�p���Z: �l��
		//===========================================================
		/// <summary>
		/// ��@�̋t�����擾���܂��B
		/// </summary>
		public Complex Reciprocal{
			get{
				if(this.IsInfinity)return Zero;
				double abs2=this.real*this.real+this.imag*this.imag;
				return new Complex(this.real/abs2,-this.imag/abs2);
			}
		}
		//	0  + 0  = 0
		//  0  + �� = ��
		//  �� + �� = ��
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
		//  0  - �� = ��
		//  �� - �� = ��
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
		//  f  * �� = ��
		//  �� * �� = ��
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
		//	0  / 0  = ��
		//  f  / �� = 0
		//  �� / �� = ��
		//  �� / f  = ��
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
		//		�Z�p���Z: ���̑�
		//===========================================================
		/// <summary>
		/// ���f�������擾���܂��B
		/// </summary>
		public Complex Conjugate{
#if FAST&&!NOCARE
			get{return new Complex(this.real,-this.imag);}
#else
			get{return this.IsInfinity?Infinity:new Complex(this.real,-this.imag);}
#endif
		}
		/// <summary>
		/// �^����ꂽ���f���̕��f�������擾���܂��B
		/// </summary>
		/// <param name="value">���f��������镡�f�����w�肵�܂��B</param>
		/// <returns>���f��������������ʂ̕��f����Ԃ��܂��B</returns>
		public static Complex operator~(Complex value){
#if FAST&&!NOCARE
			return new Complex(value.real,-value.imag);
#else
			return this.IsInfinity?Infinity:new Complex(this.real,-this.imag);
#endif
		}
		/// <summary>
		/// ���f����㰏���v�Z���܂��B
		/// </summary>
		/// <param name="left">㰏�̒���w�肵�܂��B</param>
		/// <param name="right">㰏�̎w�����w�肵�܂��B</param>
		/// <returns>㰏���v�Z�������ʂ�Ԃ��܂��B</returns>
		public static Complex operator^(Complex left,Complex right){
			return pow(left,right);
		}
		/// <summary>
		/// ���f����㰏���v�Z���܂��B
		/// </summary>
		/// <param name="left">㰏�̒���w�肵�܂��B</param>
		/// <param name="right">㰏�̎w�����w�肵�܂��B</param>
		/// <returns>㰏���v�Z�������ʂ�Ԃ��܂��B</returns>
		public static Complex operator^(Complex left,double right){
			return pow(left,(Complex)right);
		}
		/// <summary>
		/// ���f����㰏���v�Z���܂��B
		/// </summary>
		/// <param name="left">㰏�̒���w�肵�܂��B</param>
		/// <param name="right">㰏�̎w�����w�肵�܂��B</param>
		/// <returns>㰏���v�Z�������ʂ�Ԃ��܂��B</returns>
		public static Complex operator^(double left,Complex right){
			if(left==0)
				return right==Complex.Zero?Complex.Infinity:Complex.Zero;
			return exp(right*System.Math.Log(left));
		}
		/// <summary>
		/// ���f����㰏���v�Z���܂��B
		/// </summary>
		/// <param name="left">㰏�̒���w�肵�܂��B</param>
		/// <param name="right">㰏�̎w�����w�肵�܂��B</param>
		/// <returns>㰏���v�Z�������ʂ�Ԃ��܂��B</returns>
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
		//		��r���Z
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
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<(Complex left,Complex right){
			return left.Absolute<right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<(double left,Complex right){
			return System.Math.Abs(left)<right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<(Complex left,double right){
			return left.Absolute<System.Math.Abs(right);
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̐�Βl���E�ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<=(Complex left,Complex right){
			return left.Absolute<=right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̐�Βl���E�ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<=(double left,Complex right){
			return System.Math.Abs(left)<=right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// ���ӂ̐�Βl���E�ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator<=(Complex left,double right){
			return left.Absolute<=System.Math.Abs(right);
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>(Complex left,Complex right){
			return left.Absolute>right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>(double left,Complex right){
			return System.Math.Abs(left)>right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̕�����Βl���������ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>(Complex left,double right){
			return left.Absolute>System.Math.Abs(right);
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̐�Βl�����ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>=(Complex left,Complex right){
			return left.Absolute>=right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̐�Βl�����ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>=(double left,Complex right){
			return System.Math.Abs(left)>=right.Absolute;
		}
		/// <summary>
		/// ��Βl�̑傫���ő召���r���܂��B
		/// </summary>
		/// <param name="left">��r����E�Ӓl���w�肵�܂��B</param>
		/// <param name="right">��r���鍶�Ӓl���w�肵�܂��B</param>
		/// <returns>��r�������ʂ�Ԃ��܂��B
		/// �E�ӂ̐�Βl�����ӂ̐�Βl�ȉ��̏ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� true ��Ԃ��܂��B</returns>
		public static bool operator>=(Complex left,double right){
			return left.Absolute>=System.Math.Abs(right);
		}
		//===========================================================
		//		�����֐�
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

			// value==0||value==Infinity �̎�
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
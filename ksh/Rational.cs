#define USE_ANY
#define CHECKED

using Gen=System.Collections.Generic;

namespace ksh{
	/// <summary>
	/// �L�����\���̂ł��Bulong �𕪎q����Ɏ��L�����\����񋟂��܂��B
	/// </summary>
	[System.Serializable]
	public struct Rational
		:System.IComparable<Rational>,System.IEquatable<Rational>,System.ICloneable
	{
		private ulong numer;
		private ulong denom;
		private Signature sign;

		[System.Flags]
		private enum Signature{
			Zero=0,
			Positive=0x01,
			Negative=0x02,

			Infinity=0x04,
			PositiveInfinity=Positive|Infinity,
			NegativeInfinity=Negative|Infinity,
			Indefinite	=0x10,

#if USE_ANY
			Any			=0x20,
#endif
			Impossible	=0x30,

			NaN		=Indefinite|
#if USE_ANY
					Any|
#endif
					Impossible,

			NfN		=Infinity|NaN,
		}
		//===========================================================
		//		�������q
		//===========================================================
		/// <summary>
		/// �w�肵�����q�E������ȂėL���������������܂��B
		/// </summary>
		/// <param name="numerator">�����̕��q���w�肵�܂��B</param>
		/// <param name="denominator">�����̕�����w�肵�܂��B</param>
		public Rational(long numerator,long denominator){
			if(denominator<0){
				denominator=-denominator;
				numerator=-numerator;
			}
			if(numerator==0){
				this.numer=0;
				this.denom=0;
#if USE_ANY
				this.sign=denominator!=0?Signature.Zero:Signature.Any;
#else
				this.sign=Signature.Zero;
#endif
			}else if(numerator>0){
				this.numer=(ulong)numerator;
				this.denom=(ulong)denominator;
				this.sign=Signature.Positive;
			}else{
				this.numer=(ulong)(-numerator);
				this.denom=(ulong)denominator;
				this.sign=Signature.Negative;
			}

			this.Normalize();
		}
		/// <summary>
		/// �w�肵�����q�E������ȂėL���������������܂��B
		/// </summary>
		/// <param name="numerator">�����̕��q���w�肵�܂��B</param>
		/// <param name="denominator">�����̕�����w�肵�܂��B</param>
		public Rational(ulong numerator,ulong denominator):this(numerator,denominator,Signature.Zero){
#if USE_ANY
			if(numerator==0&&denominator==0)sign=Signature.Any;
#endif
		}
		private Rational(ulong numerator,ulong denominator,Signature sign){
			this.denom=denominator;
			this.numer=numerator;
			this.sign=sign;
			this.Normalize();
		}
		/// <summary>
		/// ���K�������s���܂��B���̒l���L���l�̏ꍇ�ɂ͊��񕪐��ɂ��܂��B
		/// </summary>
		private void Normalize(){
			if(this.IsNfN){
				this.denom=this.numer=0;
				return;
			}
			
			if(numer==0){
				sign=Signature.Zero;
				this.denom=0;
				return;
			}else if(sign==Signature.Zero){
				sign=Signature.Positive;
			}

			if(this.denom==0){
				this.numer=0;
				this.sign|=Signature.Infinity;
			}else{
				IntUtils.Reduct(ref this.numer,ref this.denom);
			}
		}

		//===========================================================
		//		�萔
		//===========================================================
		/// <summary>
		/// 0 (�댳) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational Zero			=new Rational(0,0,Signature.Zero);
		/// <summary>
		/// 1 (�P�ʌ�) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational One				=new Rational(1,1,Signature.Positive);
		/// <summary>
		/// -1 (1 �̋t��) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational MinusOne		=new Rational(1,1,Signature.Negative);
		/// <summary>
		/// +�� (���̖�����) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational PositiveInfinity=new Rational(0,0,Signature.PositiveInfinity);
		/// <summary>
		/// -�� (���̖�����) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational NegativeInfinity=new Rational(0,0,Signature.NegativeInfinity);
		/// <summary>
		/// NaN (�񐔒l) ��\������ Rational �l��ێ����܂��B
		/// </summary>
		public static readonly Rational NaN				=new Rational(0,0,Signature.Indefinite);
		//===========================================================
		//		���
		//===========================================================
		/// <summary>
		/// ���q�̒l���擾���܂��B
		/// </summary>
		public ulong Numerator{
			get{return numer;}
		}
		/// <summary>
		/// ����̒l���擾���܂��B
		/// </summary>
		public ulong Denominator{
			get{return denom;}
		}
		/// <summary>
		/// ���̒l�𕶎���ŕ\�����܂��B
		/// </summary>
		/// <returns>���̒l�𕶎���ŕ\�����ĕԂ��܂��B</returns>
		public override string ToString(){
			switch(this.sign){
				case Signature.Impossible:		return "�~";
#if USE_ANY
				case Signature.Any:				return "any";
#endif
				case Signature.Indefinite:		return "?";
				case Signature.PositiveInfinity:return "��";
				case Signature.NegativeInfinity:return "-��";
				case Signature.Zero:			return "0";
				case Signature.Positive:
					return this.numer.ToString()+(this.denom==1?"":"/"+this.denom.ToString());
				case Signature.Negative:
					return "-"+this.numer.ToString()+(this.denom==1?"":"/"+this.denom.ToString());
				default:
					return "<��`����Ă��Ȃ����>";
			}
		}
		/// <summary>
		/// ���̒l���񐔒l�ł��邩�ǂ������擾���܂��B
		/// </summary>
		public bool IsNaN{
			get{return (sign&Signature.NaN)!=0;}
		}
		/// <summary>
		/// ���̒l���L���̐��l�łȂ����ǂ������擾���܂��B
		/// �܂�A�l�������傩�񐔒l�̏ꍇ�� true ��Ԃ��܂��B����ȊO�̏ꍇ�� false ��Ԃ��܂��B
		/// </summary>
		public bool IsNfN{
			get{return (sign&Signature.NfN)!=0;}
		}
		/// <summary>
		/// ���̒l���@0 �ł��邩�ǂ������擾���܂��B
		/// </summary>
		public bool IsZero{
			get{return sign==Signature.Zero;}
		}
		/// <summary>
		/// ���̒l�����̒l�ł��邩�ǂ������擾���܂��B
		/// </summary>
		public bool IsPositive{
			get{return (sign&Signature.Positive)!=0;}
		}
		/// <summary>
		/// ���̒l�����̒l�ł��邩�ǂ������擾���܂��B
		/// </summary>
		public bool IsNegative{
			get{return (sign&Signature.Negative)!=0;}
		}
		/// <summary>
		/// ���̒l���������̖�����ł��邩�ۂ����擾���܂��B
		/// </summary>
		public bool IsInfinity{
			get{return (sign&Signature.Infinity)!=0;}
		}
		//===========================================================
		//		�Z�p���Z
		//===========================================================
		public static Rational operator+(Rational value){
			return value;
		}
		public static Rational operator+(Rational left,Rational right){
			if(left.IsNfN||right.IsNfN){
				return OperateNaN(OP_ADD,left.sign,right.sign);
			}else if(left.IsZero)
				return right;
			else if(right.IsZero)
				return left;
			else{
#if CHECKED
				ulong den=IntUtils.LCM_checked(left.denom,right.denom);
				ulong numL=checked(left.numer*(den/left.denom));
				ulong numR=checked(right.numer*(den/right.denom));
#else
				ulong den=IntUtils.LCM(left.denom,right.denom);
				ulong numL=left.numer*(den/left.denom);
				ulong numR=right.numer*(den/right.denom);
#endif

				if(left.sign==right.sign){
#if CHECKED
					return new Rational(checked(numL+numR),den,left.sign);
#else
					return new Rational(numL+numR,den,left.sign);
#endif
				}else if(numL>numR){
					return new Rational(numL-numR,den,left.sign==Signature.Positive?Signature.Positive:Signature.Negative);
				}else{
					return new Rational(numR-numL,den,left.sign==Signature.Positive?Signature.Negative:Signature.Positive);
				}
			}
		}
		public static Rational operator-(Rational value){
			if(value.IsPositive){
				value.sign=value.sign&~Signature.Positive|Signature.Negative;
			}else if(value.IsNegative){
				value.sign=value.sign&~Signature.Negative|Signature.Positive;
			}
			return value;
		}
		public static Rational operator-(Rational left,Rational right){
			return left+(-right);
		}
		public static Rational operator*(Rational left,Rational right){
			if(left.IsNfN||right.IsNfN){
				return OperateNaN(OP_MUL,left.sign,right.sign);
			}else if(left.IsZero)
				return Zero;
			else if(right.IsZero)
				return Zero;
			else{
				IntUtils.Reduct(ref left.numer,ref right.denom);
				IntUtils.Reduct(ref right.numer,ref left.denom);
#if CHECKED
				return new Rational(
					checked(left.numer*right.numer),
					checked(left.denom*right.denom),
					left.sign==right.sign?Signature.Positive:Signature.Negative);
#else
				return new Rational(left.numer*right.numer,left.denom*right.denom,left.sign==right.sign?Signature.Positive:Signature.Negative);
#endif
			}
		}
		/// <summary>
		/// ��Z�Ɋւ���t�����擾���܂��B
		/// </summary>
		/// <returns>��Z�Ɋւ���t����Ԃ��܂��B</returns>
		public Rational Reciprocal(){
			if(this.IsInfinity)return Zero;
			if(this.IsZero)return PositiveInfinity;
			return new Rational(this.denom,this.numer,this.sign);
		}
		public static Rational operator/(Rational left,Rational right){
#if USE_ANY
			if(left.IsZero&&right.IsZero)return new Rational(0,0,Signature.Any);
#endif
			return left*right.Reciprocal();
		}
		public static implicit operator Rational(ulong value){return new Rational(value,1);}
		public static implicit operator Rational(long value){return new Rational(value,1);}
		public static implicit operator Rational(uint value){return new Rational((ulong)value,1);}
		public static implicit operator Rational(int value){return new Rational((long)value,1);}
		public static implicit operator Rational(ushort value){return new Rational((ulong)value,1);}
		public static implicit operator Rational(short value){return new Rational((long)value,1);}
		public static implicit operator Rational(byte value){return new Rational((ulong)value,1);}
		public static implicit operator Rational(sbyte value){return new Rational((long)value,1);}
		public static explicit operator double(Rational value){
			switch(value.sign){
				case Signature.Zero:return 0.0;
				case Signature.Positive:return (double)value.numer/(double)value.denom;
				case Signature.Negative:return -(double)value.numer/(double)value.denom;
				case Signature.PositiveInfinity:return double.PositiveInfinity;
				case Signature.NegativeInfinity:return double.NegativeInfinity;
				default:return double.NaN;
			}
		}
		//===========================================================
		//		��r���Z
		//===========================================================
		public override int GetHashCode(){
			return (this.denom^this.numer^(ulong)this.sign).GetHashCode();
		}
		public override bool Equals(object obj){
			return obj is Rational&&(Rational)obj==this||(double)this==System.Convert.ToDouble(obj);
		}
		public static bool operator==(Rational left,Rational right){
			if(left.IsNaN&&right.IsNaN)return false;
			return left.sign==right.sign&&left.numer==right.numer&&left.denom==right.denom;
		}
		public static bool operator !=(Rational left,Rational right){
			return !(left==right);
		}
		public static bool operator>(Rational left,Rational right){
			if(left.IsNfN||right.IsNfN){
				return OperateNaN_bool(OP_GT,left.sign,right.sign);
			}else if(left.IsZero){
				return right.sign==Signature.Negative;
			}else if(right.IsZero){
				return left.sign==Signature.Positive;
			}else if(left.sign==right.sign){
				ulong den=IntUtils.LCM(left.denom,right.denom);
#if CHECKED
				return checked(left.numer*(den/left.denom))>checked(right.numer*(den/right.denom));
#else
				return left.numer*(den/left.denom)>right.numer*(den/right.denom);
#endif
			}else{
				return left.sign==Signature.Positive;
			}
		}
		public static bool operator<(Rational left,Rational right){
			return right>left;
		}
		public static bool operator<=(Rational left,Rational right){
			return left==right||right>left;
		}
		public static bool operator>=(Rational left,Rational right){
			return left==right||left>right;
		}
		int System.IComparable<Rational>.CompareTo(Rational other){
			return this==other?0:this>other?1:-1;
		}
		bool System.IEquatable<Rational>.Equals(Rational other){
			return this==other;
		}
		object System.ICloneable.Clone(){
			// �� ����͒l�^
			return (object)this;
		}
		//===========================================================
		//		���Z�\
		//===========================================================
		private const int SHIFT=12;
		private const int OP_ADD=0x1000000;
		private const int OP_MUL=0x2000000;
		private const int OP_GT	=0x3000000;
		//private const int OP_GE	=0x4000000;
		private static Rational OperateNaN(int opCode,Signature leftsig,Signature rightsig){
			Signature sign;

			int code=(int)leftsig<<SHIFT|(int)rightsig;
			if(operateNaN.TryGetValue(opCode|code,out sign)){
				return new Rational(1,1,sign);
			}else if(operateNaN.TryGetValue(code,out sign)){
				return new Rational(1,1,sign);
			}else throw new System.Exception("���Z���ʂ���`����Ă��܂���B");
		}
		private static bool OperateNaN_bool(int opCode,Signature leftsig,Signature rightsig){
			bool ret;

			int code=(int)leftsig<<SHIFT|(int)rightsig;
			if(operateNaN_bool.TryGetValue(opCode|code,out ret)){
				return ret;
			}else if(operateNaN_bool.TryGetValue(code,out ret)){
				return ret;
			}else throw new System.Exception("���Z���ʂ���`����Ă��܂���B");
		}
		private static Gen::Dictionary<int,Signature> operateNaN;
		private static Gen::Dictionary<int,bool> operateNaN_bool;
		private static void operateNaN_Register(int op_code,Signature leftsig,Signature rightsig,Signature retsig){
			operateNaN[op_code|(int)leftsig<<SHIFT|(int)rightsig]=retsig;
		}
		private static void operateNaN_Register(int op_code,Signature leftsig,Signature rightsig,bool retval){
			operateNaN_bool[op_code|(int)leftsig<<SHIFT|(int)rightsig]=retval;
		}
		static Rational(){
			operateNaN		=new Gen::Dictionary<int,Signature>();
			operateNaN_bool	=new Gen::Dictionary<int,bool>();

			//
			//		����
			//

			//	�� ����ł� any �y�� impossible �͏o�������Ȃ�
			/*
			operateNaN_Register(0,Signature.Impossible,Signature.Impossible,		Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.Any,				Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.Indefinite,		Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.PositiveInfinity,	Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.NegativeInfinity,	Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.Positive,			Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.Negative,			Signature.Impossible);
			operateNaN_Register(0,Signature.Impossible,Signature.Zero,				Signature.Impossible);
			operateNaN_Register(0,Signature.Indefinite,Signature.Impossible,		Signature.Impossible);
			operateNaN_Register(0,Signature.Any,Signature.Impossible,			Signature.Impossible);
			operateNaN_Register(0,Signature.PositiveInfinity,Signature.Impossible,	Signature.Impossible);
			operateNaN_Register(0,Signature.NegativeInfinity,Signature.Impossible,	Signature.Impossible);
			operateNaN_Register(0,Signature.Positive,Signature.Impossible,			Signature.Impossible);
			operateNaN_Register(0,Signature.Negative,Signature.Impossible,			Signature.Impossible);
			operateNaN_Register(0,Signature.Zero,Signature.Impossible,				Signature.Impossible);
			//*/

#if USE_ANY
			operateNaN_Register(0,Signature.Any,Signature.Any,				Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.Indefinite,		Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.PositiveInfinity,	Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.NegativeInfinity,	Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.Zero,				Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.Positive,			Signature.Any);
			operateNaN_Register(0,Signature.Any,Signature.Negative,			Signature.Any);
			operateNaN_Register(0,Signature.Indefinite,Signature.Any,		Signature.Any);
			operateNaN_Register(0,Signature.PositiveInfinity,Signature.Any,	Signature.Any);
			operateNaN_Register(0,Signature.NegativeInfinity,Signature.Any,	Signature.Any);
			operateNaN_Register(0,Signature.Zero,Signature.Any,				Signature.Any);
			operateNaN_Register(0,Signature.Positive,Signature.Any,			Signature.Any);
			operateNaN_Register(0,Signature.Negative,Signature.Any,			Signature.Any);

			operateNaN_Register(0,Signature.Any,Signature.Any,				false);
			operateNaN_Register(0,Signature.Any,Signature.Indefinite,		false);
			operateNaN_Register(0,Signature.Any,Signature.PositiveInfinity,	false);
			operateNaN_Register(0,Signature.Any,Signature.NegativeInfinity,	false);
			operateNaN_Register(0,Signature.Any,Signature.Zero,				false);
			operateNaN_Register(0,Signature.Any,Signature.Positive,			false);
			operateNaN_Register(0,Signature.Any,Signature.Negative,			false);
			operateNaN_Register(0,Signature.Indefinite,Signature.Any,		false);
			operateNaN_Register(0,Signature.PositiveInfinity,Signature.Any,	false);
			operateNaN_Register(0,Signature.NegativeInfinity,Signature.Any,	false);
			operateNaN_Register(0,Signature.Zero,Signature.Any,				false);
			operateNaN_Register(0,Signature.Positive,Signature.Any,			false);
			operateNaN_Register(0,Signature.Negative,Signature.Any,			false);
#endif

			operateNaN_Register(0,Signature.Indefinite,Signature.Indefinite,		Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.NegativeInfinity,	Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.PositiveInfinity,	Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.Zero,				Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.Positive,			Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.Negative,			Signature.Indefinite);
			operateNaN_Register(0,Signature.NegativeInfinity,Signature.Indefinite,	Signature.Indefinite);
			operateNaN_Register(0,Signature.PositiveInfinity,Signature.Indefinite,	Signature.Indefinite);
			operateNaN_Register(0,Signature.Zero,Signature.Indefinite,				Signature.Indefinite);
			operateNaN_Register(0,Signature.Positive,Signature.Indefinite,			Signature.Indefinite);
			operateNaN_Register(0,Signature.Negative,Signature.Indefinite,			Signature.Indefinite);
			operateNaN_Register(0,Signature.Indefinite,Signature.Indefinite,		false);
			operateNaN_Register(0,Signature.Indefinite,Signature.NegativeInfinity,	false);
			operateNaN_Register(0,Signature.Indefinite,Signature.PositiveInfinity,	false);
			operateNaN_Register(0,Signature.Indefinite,Signature.Zero,				false);
			operateNaN_Register(0,Signature.Indefinite,Signature.Positive,			false);
			operateNaN_Register(0,Signature.Indefinite,Signature.Negative,			false);
			operateNaN_Register(0,Signature.NegativeInfinity,Signature.Indefinite,	false);
			operateNaN_Register(0,Signature.PositiveInfinity,Signature.Indefinite,	false);
			operateNaN_Register(0,Signature.Zero,Signature.Indefinite,				false);
			operateNaN_Register(0,Signature.Positive,Signature.Indefinite,			false);
			operateNaN_Register(0,Signature.Negative,Signature.Indefinite,			false);

			//
			//		���Z
			//
			operateNaN_Register(OP_ADD,Signature.NegativeInfinity,Signature.NegativeInfinity,	Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.NegativeInfinity,Signature.PositiveInfinity,	Signature.Indefinite);
			operateNaN_Register(OP_ADD,Signature.NegativeInfinity,Signature.Zero,				Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.NegativeInfinity,Signature.Negative,			Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.NegativeInfinity,Signature.Positive,			Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.Zero,Signature.NegativeInfinity,				Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.Negative,Signature.NegativeInfinity,			Signature.NegativeInfinity);
			operateNaN_Register(OP_ADD,Signature.Positive,Signature.NegativeInfinity,			Signature.NegativeInfinity);

			operateNaN_Register(OP_ADD,Signature.PositiveInfinity,Signature.NegativeInfinity,	Signature.Indefinite);
			operateNaN_Register(OP_ADD,Signature.PositiveInfinity,Signature.PositiveInfinity,	Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.PositiveInfinity,Signature.Zero,				Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.PositiveInfinity,Signature.Negative,			Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.PositiveInfinity,Signature.Positive,			Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.Zero,Signature.PositiveInfinity,				Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.Negative,Signature.PositiveInfinity,			Signature.PositiveInfinity);
			operateNaN_Register(OP_ADD,Signature.Positive,Signature.PositiveInfinity,			Signature.PositiveInfinity);

			//
			//		��Z
			//
			operateNaN_Register(OP_MUL,Signature.NegativeInfinity,Signature.NegativeInfinity,	Signature.PositiveInfinity);
			operateNaN_Register(OP_MUL,Signature.NegativeInfinity,Signature.PositiveInfinity,	Signature.NegativeInfinity);
			operateNaN_Register(OP_MUL,Signature.NegativeInfinity,Signature.Zero,				Signature.Indefinite);
			operateNaN_Register(OP_MUL,Signature.NegativeInfinity,Signature.Negative,			Signature.PositiveInfinity);
			operateNaN_Register(OP_MUL,Signature.NegativeInfinity,Signature.Positive,			Signature.NegativeInfinity);
			operateNaN_Register(OP_MUL,Signature.Zero,Signature.NegativeInfinity,				Signature.Indefinite);
			operateNaN_Register(OP_MUL,Signature.Negative,Signature.NegativeInfinity,			Signature.PositiveInfinity);
			operateNaN_Register(OP_MUL,Signature.Positive,Signature.NegativeInfinity,			Signature.NegativeInfinity);

			operateNaN_Register(OP_MUL,Signature.PositiveInfinity,Signature.NegativeInfinity,	Signature.NegativeInfinity);
			operateNaN_Register(OP_MUL,Signature.PositiveInfinity,Signature.PositiveInfinity,	Signature.PositiveInfinity);
			operateNaN_Register(OP_MUL,Signature.PositiveInfinity,Signature.Zero,				Signature.Indefinite);
			operateNaN_Register(OP_MUL,Signature.PositiveInfinity,Signature.Negative,			Signature.NegativeInfinity);
			operateNaN_Register(OP_MUL,Signature.PositiveInfinity,Signature.Positive,			Signature.PositiveInfinity);
			operateNaN_Register(OP_MUL,Signature.Zero,Signature.PositiveInfinity,				Signature.Indefinite);
			operateNaN_Register(OP_MUL,Signature.Negative,Signature.PositiveInfinity,			Signature.NegativeInfinity);
			operateNaN_Register(OP_MUL,Signature.Positive,Signature.PositiveInfinity,			Signature.PositiveInfinity);

			//
			//		��Ȃ��r
			//
			operateNaN_Register(OP_GT,Signature.NegativeInfinity,Signature.NegativeInfinity,	false);
			operateNaN_Register(OP_GT,Signature.NegativeInfinity,Signature.PositiveInfinity,	false);
			operateNaN_Register(OP_GT,Signature.NegativeInfinity,Signature.Zero,				false);
			operateNaN_Register(OP_GT,Signature.NegativeInfinity,Signature.Negative,			false);
			operateNaN_Register(OP_GT,Signature.NegativeInfinity,Signature.Positive,			false);
			operateNaN_Register(OP_GT,Signature.Zero,Signature.NegativeInfinity,				true);
			operateNaN_Register(OP_GT,Signature.Negative,Signature.NegativeInfinity,			true);
			operateNaN_Register(OP_GT,Signature.Positive,Signature.NegativeInfinity,			true);

			operateNaN_Register(OP_GT,Signature.PositiveInfinity,Signature.NegativeInfinity,	true);
			operateNaN_Register(OP_GT,Signature.PositiveInfinity,Signature.PositiveInfinity,	false);
			operateNaN_Register(OP_GT,Signature.PositiveInfinity,Signature.Zero,				true);
			operateNaN_Register(OP_GT,Signature.PositiveInfinity,Signature.Negative,			true);
			operateNaN_Register(OP_GT,Signature.PositiveInfinity,Signature.Positive,			true);
			operateNaN_Register(OP_GT,Signature.Zero,Signature.PositiveInfinity,				false);
			operateNaN_Register(OP_GT,Signature.Negative,Signature.PositiveInfinity,			false);
			operateNaN_Register(OP_GT,Signature.Positive,Signature.PositiveInfinity,			false);

			/*
			//
			//		�� ��r
			//
			operateNaN_Register(OP_GE,Signature.NegativeInfinity,Signature.NegativeInfinity,	true);
			operateNaN_Register(OP_GE,Signature.NegativeInfinity,Signature.PositiveInfinity,	false);
			operateNaN_Register(OP_GE,Signature.NegativeInfinity,Signature.Zero,				false);
			operateNaN_Register(OP_GE,Signature.NegativeInfinity,Signature.Negative,			false);
			operateNaN_Register(OP_GE,Signature.NegativeInfinity,Signature.Positive,			false);
			operateNaN_Register(OP_GE,Signature.Zero,Signature.NegativeInfinity,				true);
			operateNaN_Register(OP_GE,Signature.Negative,Signature.NegativeInfinity,			true);
			operateNaN_Register(OP_GE,Signature.Positive,Signature.NegativeInfinity,			true);

			operateNaN_Register(OP_GE,Signature.PositiveInfinity,Signature.NegativeInfinity,	true);
			operateNaN_Register(OP_GE,Signature.PositiveInfinity,Signature.PositiveInfinity,	true);
			operateNaN_Register(OP_GE,Signature.PositiveInfinity,Signature.Zero,				false);
			operateNaN_Register(OP_GE,Signature.PositiveInfinity,Signature.Negative,			false);
			operateNaN_Register(OP_GE,Signature.PositiveInfinity,Signature.Positive,			false);
			operateNaN_Register(OP_GE,Signature.Zero,Signature.PositiveInfinity,				true);
			operateNaN_Register(OP_GE,Signature.Negative,Signature.PositiveInfinity,			true);
			operateNaN_Register(OP_GE,Signature.Positive,Signature.PositiveInfinity,			true);
			*/
		}
		//===========================================================
		//		���̑��̎Z�p���Z
		//===========================================================
		/// <summary>
		/// �w�肵�� Rational �l�̐�Βl��Ԃ��܂��B
		/// </summary>
		/// <param name="value">��Βl�̎擾���ł��� Rational �l���w�肵�܂��B</param>
		/// <returns>�w�肵�� Rational �l�̐�Βl��Ԃ��܂��B</returns>
		public static Rational Abs(Rational value){
			return value.IsNegative?-value:value;
		}
		/// <summary>
		/// HTML �\�L (IE ����) ���擾���܂��B
		/// </summary>
		/// <returns>�����̓��e�� HTML �ŕ\����������Ԃ��܂��B</returns>
		public string ToHtml(){
			return this.ToHtml(false);
		}
		/// <summary>
		/// HTML �\�L (IE ����) ���擾���܂��B
		/// </summary>
		/// <param name="ksh_style">ksh ��p�X�^�C���V�[�g�𗘗p���邩�ǂ������w�肵�܂��B
		/// ��p�X�^�C���V�[�g���g�p����ꍇ�ɂ� true ���w�肵�܂��B
		/// ��p�X�^�C���V�[�g���g�p���Ȃ��ꍇ�ɂ� false ���w�肵�܂��B
		/// <para>��p�X�^�C���V�[�g���g�p����ꍇ�ɂ́Ainline-style �\�L���T���� class �w����s���܂��̂ŁA�e�ʂ����������鎖���o���܂��B</para>
		/// <para>�g�p���Ȃ��ꍇ�ɂ́Ainline-style �ŃX�^�C�����L�q����̂ŁA�����ɑ}�����Ă��������`���ŕ\������܂��B</para>
		/// </param>
		/// <returns>�����̓��e�� HTML �ŕ\����������Ԃ��܂��B</returns>
		public string ToHtml(bool ksh_style){
			switch(this.sign) {
				case Signature.Impossible:return "�~";
#if USE_ANY
				case Signature.Any:return "any";
#endif
				case Signature.Indefinite:return "?";
				case Signature.PositiveInfinity:return "��";
				case Signature.NegativeInfinity:return "-��";
				case Signature.Zero:return "0";
				case Signature.Positive:
					return ToHtml_fracform(ksh_style);
				case Signature.Negative:
					return "�|"+ToHtml_fracform(ksh_style);
				default:
					return "<��`����Ă��Ȃ����>";
			}
		}
		private string ToHtml_fracform(bool ksh_style){
			if(this.denom==1)return this.numer.ToString();
			if(ksh_style){
				return "<ksh:frac><ksh:num>"+this.numer.ToString()+"</ksh:num><ksh:den>"+this.denom.ToString()+"</ksh:den></ksh:frac>";
			}else{
				return "<span style='display:inline-block;vertical-align:middle;text-align:center;'>"
					+"<span style='display:block;'>"
					+this.numer.ToString()
					+"</span><span style='border-top:1px solid black;display:block;'>"
					+this.denom.ToString()
					+"</span></span>";
			}
		}
	}
}
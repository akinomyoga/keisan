namespace ksh{
	using in_t=System.Double;
	using ret_t=System.Double;

	public static partial class Functions{
		//===========================================================
		//		�~�֐�
		//===========================================================
		//#��template xdocJN<_name>
		/// <summary>
		/// �w�肵���l�ɑ΂���##_name##���擾���܂��B
		/// </summary>
		/// <param name="x">�p�x��ʑ��̒l���w�肵�܂��B</param>
		/// <returns>_name##�̒l��Ԃ��܂��B</returns>
		//#��template
		//-----------------------------------------------------------
		//#��template trigs<in_t,ret_t>
		//#xdocJN<����>
		public static ret_t sin(in_t x){return _sin(x);}
		//#xdocJN<�]��>
		public static ret_t cos(in_t x){return _cos(x);}
		//#xdocJN<����>
		public static ret_t tan(in_t x){return _tan(x);}
		//#xdocJN<�]��>
		public static ret_t cot(in_t x){return 1/_tan(x);}
		//#xdocJN<����>
		public static ret_t sec(in_t x){return 1/_cos(x);}
		//#xdocJN<�]��>
		public static ret_t cosec(in_t x){return 1/_sin(x);}
		//#xdocJN<����>
		public static ret_t vers(in_t x){return 1-_cos(x);}
		//#xdocJN<�]��>
		public static ret_t covers(in_t x){return 1-_sin(x);}
		//#xdocJN<�C���{�����[�g>
		public static ret_t inv(in_t x){return _inv(x);}
		//#��template
		//-----------------------------------------------------------
		//#��template dummy<in_t,ret_t>
		//#xdocJN<�����p����>
		public static ret_t hav(in_t x){return (1-_cos(x))/2;}
		//#xdocJN<�����p�]��>
		public static ret_t cohav(in_t x){return (1+_cos(x))/2;}
		//#xdocJN<ex����>
		public static ret_t exsec(in_t x){return 1/_cos(x)-1;}
		//#xdocJN<ex�]��>
		public static ret_t excosec(in_t x){return 1/_sin(x)-1;}
		//#��template
		//-----------------------------------------------------------
		//#��template atrigs<in_t,ret_t>
		//#xdocJN<�t����>
		public static ret_t Arcsin(in_t x){return _Asin(x);}
		//#xdocJN<�t�]��>
		public static ret_t Arccos(in_t x){return _Acos(x);}
		//#xdocJN<�t����>
		public static ret_t Arctan(in_t x){return _Atan(x);}
		//#xdocJN<�t�]��>
		public static ret_t Arccot(in_t x){return _Atan(1/x);}
		//#xdocJN<�t����>
		public static ret_t Arcsec(in_t x){return _Acos(1/x);}
		//#xdocJN<�t�]��>
		public static ret_t Arccosec(in_t x){return _Asin(1/x);}
		//#xdocJN<�t����>
		public static ret_t Arcvers(in_t x){return _Acos(1-x);}
		//#xdocJN<�t�]��>
		public static ret_t Arccovers(in_t x){return _Asin(1-x);}
		//#xdocJN<�ɃC���{�����[�g>
		public static ret_t invr(in_t x){ret_t phi;return _tan("#phi=_Acos(x)#")-phi;}
		//#��template
		//-----------------------------------------------------------
		//#define _sin(x)	System.Math.Sin(x)
		//#define _cos(x)	System.Math.Cos(x)
		//#define _tan(x)	System.Math.Tan(x)
		//#define _Asin(x)	System.Math.Asin(x)
		//#define _Acos(x)	System.Math.Acos(x)
		//#define _Atan(x)	System.Math.Atan(x)
		//#define _inv(x)	_tan(x)-x
		//#trigs<double,double>
		//#atrigs<double,double>
		//#define _sin(x)	(float)System.Math.Sin(x)
		//#define _cos(x)	(float)System.Math.Cos(x)
		//#define _tan(x)	(float)System.Math.Tan(x)
		//#define _Asin(x)	(float)System.Math.Asin(x)
		//#define _Acos(x)	(float)System.Math.Acos(x)
		//#define _Atan(x)	(float)System.Math.Atan(x)
		//#define _inv(x)	_tan(x)-x
		//#trigs<float,float>
		//#atrigs<float,float>
		//#define _sin(x)	Complex.sin(x)
		//#define _cos(x)	Complex.cos(x)
		//#define _tan(x)	Complex.tan(x)
		//#define _inv(x)	_tan(x)-x
		//#trigs<Complex,Complex>
		//#define _sin(x)	System.Math.Sin(x.ToRadian())
		//#define _cos(x)	System.Math.Cos(x.ToRadian())
		//#define _tan(x)	System.Math.Tan(x.ToRadian())
		//#define _inv(x)	_tan(x)-x.ToRadian()
		//#trigs<AngleRad,double>
		//#trigs<AngleDeg,double>
		//-----------------------------------------------------------
		//===========================================================
		//		�o�Ȑ��֐�
		//===========================================================
		//#��template xdocJN<_name>
		/// <summary>
		/// �w�肵���l�ɑ΂���##_name##���擾���܂��B
		/// </summary>
		/// <param name="x">�֐��ɗ^����l���w�肵�܂��B</param>
		/// <returns>_name##�̒l��Ԃ��܂��B</returns>
		//#��template
		//-----------------------------------------------------------
		//#��template hypes<in_t,ret_t>
		//#xdocJN<�o�Ȑ�����>
		public static ret_t sinh(in_t x){return _sinh(x);}
		//#xdocJN<�o�Ȑ��]��>
		public static ret_t cosh(in_t x){return _cosh(x);}
		//#xdocJN<�o�Ȑ�����>
		public static ret_t tanh(in_t x){return _tanh(x);}
		//#xdocJN<�o�Ȑ��]��>
		public static ret_t coth(in_t x){return 1/_tanh(x);}
		//#xdocJN<�o�Ȑ�����>
		public static ret_t sech(in_t x){return 1/_cosh(x);}
		//#xdocJN<�o�Ȑ��]��>
		public static ret_t cosech(in_t x){return 1/_sinh(x);}
		//#��template
		//-----------------------------------------------------------
		//#��template ahypes<in_t,ret_t>
		//#xdocJN<�t�o�Ȑ�����>
		public static ret_t Arcsinh(in_t x){return _Asinh(x);}
		//#xdocJN<�t�o�Ȑ��]��>
		public static ret_t Arccosh(in_t x){return _Acosh(x);}
		//#xdocJN<�t�o�Ȑ�����>
		public static ret_t Arctanh(in_t x){return _Atanh(x);}
		//#xdocJN<�t�o�Ȑ��]��>
		public static ret_t Arccoth(in_t x){return _Atanh(1/x);}
		//#xdocJN<�t�o�Ȑ�����>
		public static ret_t Arcsech(in_t x){return _Acosh(1/x);}
		//#xdocJN<�t�o�Ȑ��]��>
		public static ret_t Arccosech(in_t x){return _Asinh(1/x);}
		//#��template
		//-----------------------------------------------------------
		//#define _sinh(x)	System.Math.Sinh(x)
		//#define _cosh(x)	System.Math.Cosh(x)
		//#define _tanh(x)	System.Math.Tanh(x)
		//#define _Asinh(x)	System.Math.Log(x+System.Math.Sqrt(x*x+1))
		//#define _Acosh(x)	System.Math.Log(x+System.Math.Sqrt(x*x-1))
		//#define _Atanh(x)	System.Math.Log((1+x)/(1-x))/2
		//#hypes<double,double>
		//#ahypes<double,double>
		//#define _sinh(x)	(float)System.Math.Sinh(x)
		//#define _cosh(x)	(float)System.Math.Cosh(x)
		//#define _tanh(x)	(float)System.Math.Tanh(x)
		//#define _Asinh(x)	(float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)+1.0))
		//#define _Acosh(x)	(float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)-1.0))
		//#define _Atanh(x)	(float)(System.Math.Log((1.0+x)/(1.0-x))/2)
		//#hypes<float,float>
		//#ahypes<float,float>
	}
}
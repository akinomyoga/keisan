namespace ksh{
	using in_t=System.Double;
	using ret_t=System.Double;

	public static partial class Functions{
		//===========================================================
		//		円関数
		//===========================================================
		//#→template xdocJN<_name>
		/// <summary>
		/// 指定した値に対する##_name##を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>_name##の値を返します。</returns>
		//#←template
		//-----------------------------------------------------------
		//#→template trigs<in_t,ret_t>
		//#xdocJN<正弦>
		public static ret_t sin(in_t x){return _sin(x);}
		//#xdocJN<余弦>
		public static ret_t cos(in_t x){return _cos(x);}
		//#xdocJN<正接>
		public static ret_t tan(in_t x){return _tan(x);}
		//#xdocJN<余接>
		public static ret_t cot(in_t x){return 1/_tan(x);}
		//#xdocJN<正割>
		public static ret_t sec(in_t x){return 1/_cos(x);}
		//#xdocJN<余割>
		public static ret_t cosec(in_t x){return 1/_sin(x);}
		//#xdocJN<正矢>
		public static ret_t vers(in_t x){return 1-_cos(x);}
		//#xdocJN<余矢>
		public static ret_t covers(in_t x){return 1-_sin(x);}
		//#xdocJN<インボリュート>
		public static ret_t inv(in_t x){return _inv(x);}
		//#←template
		//-----------------------------------------------------------
		//#→template dummy<in_t,ret_t>
		//#xdocJN<半頂角正弦>
		public static ret_t hav(in_t x){return (1-_cos(x))/2;}
		//#xdocJN<半頂角余弦>
		public static ret_t cohav(in_t x){return (1+_cos(x))/2;}
		//#xdocJN<ex正割>
		public static ret_t exsec(in_t x){return 1/_cos(x)-1;}
		//#xdocJN<ex余割>
		public static ret_t excosec(in_t x){return 1/_sin(x)-1;}
		//#←template
		//-----------------------------------------------------------
		//#→template atrigs<in_t,ret_t>
		//#xdocJN<逆正弦>
		public static ret_t Arcsin(in_t x){return _Asin(x);}
		//#xdocJN<逆余弦>
		public static ret_t Arccos(in_t x){return _Acos(x);}
		//#xdocJN<逆正接>
		public static ret_t Arctan(in_t x){return _Atan(x);}
		//#xdocJN<逆余接>
		public static ret_t Arccot(in_t x){return _Atan(1/x);}
		//#xdocJN<逆正割>
		public static ret_t Arcsec(in_t x){return _Acos(1/x);}
		//#xdocJN<逆余割>
		public static ret_t Arccosec(in_t x){return _Asin(1/x);}
		//#xdocJN<逆正矢>
		public static ret_t Arcvers(in_t x){return _Acos(1-x);}
		//#xdocJN<逆余矢>
		public static ret_t Arccovers(in_t x){return _Asin(1-x);}
		//#xdocJN<極インボリュート>
		public static ret_t invr(in_t x){ret_t phi;return _tan("#phi=_Acos(x)#")-phi;}
		//#←template
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
		//		双曲線関数
		//===========================================================
		//#→template xdocJN<_name>
		/// <summary>
		/// 指定した値に対する##_name##を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>_name##の値を返します。</returns>
		//#←template
		//-----------------------------------------------------------
		//#→template hypes<in_t,ret_t>
		//#xdocJN<双曲線正弦>
		public static ret_t sinh(in_t x){return _sinh(x);}
		//#xdocJN<双曲線余弦>
		public static ret_t cosh(in_t x){return _cosh(x);}
		//#xdocJN<双曲線正接>
		public static ret_t tanh(in_t x){return _tanh(x);}
		//#xdocJN<双曲線余接>
		public static ret_t coth(in_t x){return 1/_tanh(x);}
		//#xdocJN<双曲線正割>
		public static ret_t sech(in_t x){return 1/_cosh(x);}
		//#xdocJN<双曲線余割>
		public static ret_t cosech(in_t x){return 1/_sinh(x);}
		//#←template
		//-----------------------------------------------------------
		//#→template ahypes<in_t,ret_t>
		//#xdocJN<逆双曲線正弦>
		public static ret_t Arcsinh(in_t x){return _Asinh(x);}
		//#xdocJN<逆双曲線余弦>
		public static ret_t Arccosh(in_t x){return _Acosh(x);}
		//#xdocJN<逆双曲線正接>
		public static ret_t Arctanh(in_t x){return _Atanh(x);}
		//#xdocJN<逆双曲線余接>
		public static ret_t Arccoth(in_t x){return _Atanh(1/x);}
		//#xdocJN<逆双曲線正割>
		public static ret_t Arcsech(in_t x){return _Acosh(1/x);}
		//#xdocJN<逆双曲線余割>
		public static ret_t Arccosech(in_t x){return _Asinh(1/x);}
		//#←template
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
namespace ksh{
	using in_t=System.Double;
	using ret_t=System.Double;

	public static partial class Functions{
		//===========================================================
		//		â~ä÷êî
		//===========================================================
		//#Å®template xdocJN<_name>
		/// <summary>
		/// éwíËÇµÇΩílÇ…ëŒÇ∑ÇÈ##_name##ÇéÊìæÇµÇ‹Ç∑ÅB
		/// </summary>
		/// <param name="x">äpìxÇ‚à ëäÇÃílÇéwíËÇµÇ‹Ç∑ÅB</param>
		/// <returns>_name##ÇÃílÇï‘ÇµÇ‹Ç∑ÅB</returns>
		//#Å©template
		//-----------------------------------------------------------
		//#Å®template trigs<in_t,ret_t>
		//#xdocJN<ê≥å∑>
		public static ret_t sin(in_t x){return _sin(x);}
		//#xdocJN<ó]å∑>
		public static ret_t cos(in_t x){return _cos(x);}
		//#xdocJN<ê≥ê⁄>
		public static ret_t tan(in_t x){return _tan(x);}
		//#xdocJN<ó]ê⁄>
		public static ret_t cot(in_t x){return 1/_tan(x);}
		//#xdocJN<ê≥äÑ>
		public static ret_t sec(in_t x){return 1/_cos(x);}
		//#xdocJN<ó]äÑ>
		public static ret_t cosec(in_t x){return 1/_sin(x);}
		//#xdocJN<ê≥ñÓ>
		public static ret_t vers(in_t x){return 1-_cos(x);}
		//#xdocJN<ó]ñÓ>
		public static ret_t covers(in_t x){return 1-_sin(x);}
		//#xdocJN<ÉCÉìÉ{ÉäÉÖÅ[Ég>
		public static ret_t inv(in_t x){return _inv(x);}
		//#Å©template
		//-----------------------------------------------------------
		//#Å®template dummy<in_t,ret_t>
		//#xdocJN<îºí∏äpê≥å∑>
		public static ret_t hav(in_t x){return (1-_cos(x))/2;}
		//#xdocJN<îºí∏äpó]å∑>
		public static ret_t cohav(in_t x){return (1+_cos(x))/2;}
		//#xdocJN<exê≥äÑ>
		public static ret_t exsec(in_t x){return 1/_cos(x)-1;}
		//#xdocJN<exó]äÑ>
		public static ret_t excosec(in_t x){return 1/_sin(x)-1;}
		//#Å©template
		//-----------------------------------------------------------
		//#Å®template atrigs<in_t,ret_t>
		//#xdocJN<ãtê≥å∑>
		public static ret_t Arcsin(in_t x){return _Asin(x);}
		//#xdocJN<ãtó]å∑>
		public static ret_t Arccos(in_t x){return _Acos(x);}
		//#xdocJN<ãtê≥ê⁄>
		public static ret_t Arctan(in_t x){return _Atan(x);}
		//#xdocJN<ãtó]ê⁄>
		public static ret_t Arccot(in_t x){return _Atan(1/x);}
		//#xdocJN<ãtê≥äÑ>
		public static ret_t Arcsec(in_t x){return _Acos(1/x);}
		//#xdocJN<ãtó]äÑ>
		public static ret_t Arccosec(in_t x){return _Asin(1/x);}
		//#xdocJN<ãtê≥ñÓ>
		public static ret_t Arcvers(in_t x){return _Acos(1-x);}
		//#xdocJN<ãtó]ñÓ>
		public static ret_t Arccovers(in_t x){return _Asin(1-x);}
		//#xdocJN<ã…ÉCÉìÉ{ÉäÉÖÅ[Ég>
		public static ret_t invr(in_t x){ret_t phi;return _tan("#phi=_Acos(x)#")-phi;}
		//#Å©template
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
		//		ëoã»ê¸ä÷êî
		//===========================================================
		//#Å®template xdocJN<_name>
		/// <summary>
		/// éwíËÇµÇΩílÇ…ëŒÇ∑ÇÈ##_name##ÇéÊìæÇµÇ‹Ç∑ÅB
		/// </summary>
		/// <param name="x">ä÷êîÇ…ó^Ç¶ÇÈílÇéwíËÇµÇ‹Ç∑ÅB</param>
		/// <returns>_name##ÇÃílÇï‘ÇµÇ‹Ç∑ÅB</returns>
		//#Å©template
		//-----------------------------------------------------------
		//#Å®template hypes<in_t,ret_t>
		//#xdocJN<ëoã»ê¸ê≥å∑>
		public static ret_t sinh(in_t x){return _sinh(x);}
		//#xdocJN<ëoã»ê¸ó]å∑>
		public static ret_t cosh(in_t x){return _cosh(x);}
		//#xdocJN<ëoã»ê¸ê≥ê⁄>
		public static ret_t tanh(in_t x){return _tanh(x);}
		//#xdocJN<ëoã»ê¸ó]ê⁄>
		public static ret_t coth(in_t x){return 1/_tanh(x);}
		//#xdocJN<ëoã»ê¸ê≥äÑ>
		public static ret_t sech(in_t x){return 1/_cosh(x);}
		//#xdocJN<ëoã»ê¸ó]äÑ>
		public static ret_t cosech(in_t x){return 1/_sinh(x);}
		//#Å©template
		//-----------------------------------------------------------
		//#Å®template ahypes<in_t,ret_t>
		//#xdocJN<ãtëoã»ê¸ê≥å∑>
		public static ret_t Arcsinh(in_t x){return _Asinh(x);}
		//#xdocJN<ãtëoã»ê¸ó]å∑>
		public static ret_t Arccosh(in_t x){return _Acosh(x);}
		//#xdocJN<ãtëoã»ê¸ê≥ê⁄>
		public static ret_t Arctanh(in_t x){return _Atanh(x);}
		//#xdocJN<ãtëoã»ê¸ó]ê⁄>
		public static ret_t Arccoth(in_t x){return _Atanh(1/x);}
		//#xdocJN<ãtëoã»ê¸ê≥äÑ>
		public static ret_t Arcsech(in_t x){return _Acosh(1/x);}
		//#xdocJN<ãtëoã»ê¸ó]äÑ>
		public static ret_t Arccosech(in_t x){return _Asinh(1/x);}
		//#Å©template
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
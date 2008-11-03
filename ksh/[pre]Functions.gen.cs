/*
	このソースコードは [afh.Design.dll] afh.Design.TemplateProcessor によって自動的に生成された物です。
	このソースコードを変更しても、このソースコードの元になったファイルを変更しないと変更は適用されません。

	This source code was generated automatically by a file-generator, '[afh.Design.dll] afh.Design.TemplateProcessor'.
	Changes to this source code may not be applied to the binary file, which will cause inconsistency of the whole project.
	If you want to modify any logics in this file, you should change THE SOURCE OF THIS FILE. 
*/
namespace ksh{
	using in_t=System.Double;
	using ret_t=System.Double;

	public static partial class Functions{
		//===========================================================
		//		円関数
		//===========================================================

		//-----------------------------------------------------------

		//-----------------------------------------------------------

		//-----------------------------------------------------------

		//-----------------------------------------------------------
		//#define _sin(x)	System.Math.Sin(x)
		//#define _cos(x)	System.Math.Cos(x)
		//#define _tan(x)	System.Math.Tan(x)
		//#define _Asin(x)	System.Math.Asin(x)
		//#define _Acos(x)	System.Math.Acos(x)
		//#define _Atan(x)	System.Math.Atan(x)
		//#define _inv(x)	System.Math.Tan(x)-x
		/// <summary>
		/// 指定した値に対する正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正弦の値を返します。</returns>
		public static double sin(double x){return System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対する余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余弦の値を返します。</returns>
		public static double cos(double x){return System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正接の値を返します。</returns>
		public static double tan(double x){return System.Math.Tan(x);}
		/// <summary>
		/// 指定した値に対する余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余接の値を返します。</returns>
		public static double cot(double x){return 1/System.Math.Tan(x);}
		/// <summary>
		/// 指定した値に対する正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正割の値を返します。</returns>
		public static double sec(double x){return 1/System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余割の値を返します。</returns>
		public static double cosec(double x){return 1/System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対する正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正矢の値を返します。</returns>
		public static double vers(double x){return 1-System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余矢の値を返します。</returns>
		public static double covers(double x){return 1-System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対するインボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>インボリュートの値を返します。</returns>
		public static double inv(double x){return System.Math.Tan(x)-x;}
		/// <summary>
		/// 指定した値に対する逆正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正弦の値を返します。</returns>
		public static double Arcsin(double x){return System.Math.Asin(x);}
		/// <summary>
		/// 指定した値に対する逆余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余弦の値を返します。</returns>
		public static double Arccos(double x){return System.Math.Acos(x);}
		/// <summary>
		/// 指定した値に対する逆正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正接の値を返します。</returns>
		public static double Arctan(double x){return System.Math.Atan(x);}
		/// <summary>
		/// 指定した値に対する逆余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余接の値を返します。</returns>
		public static double Arccot(double x){return System.Math.Atan(1/x);}
		/// <summary>
		/// 指定した値に対する逆正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正割の値を返します。</returns>
		public static double Arcsec(double x){return System.Math.Acos(1/x);}
		/// <summary>
		/// 指定した値に対する逆余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余割の値を返します。</returns>
		public static double Arccosec(double x){return System.Math.Asin(1/x);}
		/// <summary>
		/// 指定した値に対する逆正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正矢の値を返します。</returns>
		public static double Arcvers(double x){return System.Math.Acos(1-x);}
		/// <summary>
		/// 指定した値に対する逆余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余矢の値を返します。</returns>
		public static double Arccovers(double x){return System.Math.Asin(1-x);}
		/// <summary>
		/// 指定した値に対する極インボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>極インボリュートの値を返します。</returns>
		public static double invr(double x){double phi;return System.Math.Tan(phi=System.Math.Acos(x))-phi;}
		//#define System.Math.Sin(x)	(float)System.Math.Sin(x)
		//#define System.Math.Cos(x)	(float)System.Math.Cos(x)
		//#define System.Math.Tan(x)	(float)System.Math.Tan(x)
		//#define System.Math.Asin(x)	(float)System.Math.Asin(x)
		//#define System.Math.Acos(x)	(float)System.Math.Acos(x)
		//#define System.Math.Atan(x)	(float)System.Math.Atan(x)
		//#define System.Math.Tan(x)-x	(float)System.Math.Tan(x)-x
		/// <summary>
		/// 指定した値に対する正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正弦の値を返します。</returns>
		public static float sin(float x){return (float)System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対する余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余弦の値を返します。</returns>
		public static float cos(float x){return (float)System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正接の値を返します。</returns>
		public static float tan(float x){return (float)System.Math.Tan(x);}
		/// <summary>
		/// 指定した値に対する余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余接の値を返します。</returns>
		public static float cot(float x){return 1/(float)System.Math.Tan(x);}
		/// <summary>
		/// 指定した値に対する正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正割の値を返します。</returns>
		public static float sec(float x){return 1/(float)System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余割の値を返します。</returns>
		public static float cosec(float x){return 1/(float)System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対する正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正矢の値を返します。</returns>
		public static float vers(float x){return 1-(float)System.Math.Cos(x);}
		/// <summary>
		/// 指定した値に対する余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余矢の値を返します。</returns>
		public static float covers(float x){return 1-(float)System.Math.Sin(x);}
		/// <summary>
		/// 指定した値に対するインボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>インボリュートの値を返します。</returns>
		public static float inv(float x){return (float)System.Math.Tan(x)-x;}
		/// <summary>
		/// 指定した値に対する逆正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正弦の値を返します。</returns>
		public static float Arcsin(float x){return (float)System.Math.Asin(x);}
		/// <summary>
		/// 指定した値に対する逆余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余弦の値を返します。</returns>
		public static float Arccos(float x){return (float)System.Math.Acos(x);}
		/// <summary>
		/// 指定した値に対する逆正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正接の値を返します。</returns>
		public static float Arctan(float x){return (float)System.Math.Atan(x);}
		/// <summary>
		/// 指定した値に対する逆余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余接の値を返します。</returns>
		public static float Arccot(float x){return (float)System.Math.Atan(1/x);}
		/// <summary>
		/// 指定した値に対する逆正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正割の値を返します。</returns>
		public static float Arcsec(float x){return (float)System.Math.Acos(1/x);}
		/// <summary>
		/// 指定した値に対する逆余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余割の値を返します。</returns>
		public static float Arccosec(float x){return (float)System.Math.Asin(1/x);}
		/// <summary>
		/// 指定した値に対する逆正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆正矢の値を返します。</returns>
		public static float Arcvers(float x){return (float)System.Math.Acos(1-x);}
		/// <summary>
		/// 指定した値に対する逆余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>逆余矢の値を返します。</returns>
		public static float Arccovers(float x){return (float)System.Math.Asin(1-x);}
		/// <summary>
		/// 指定した値に対する極インボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>極インボリュートの値を返します。</returns>
		public static float invr(float x){float phi;return (float)System.Math.Tan(phi=(float)System.Math.Acos(x))-phi;}
		//#define (float)System.Math.Sin(x)	Complex.sin(x)
		//#define (float)System.Math.Cos(x)	Complex.cos(x)
		//#define (float)System.Math.Tan(x)	Complex.tan(x)
		//#define (float)System.Math.Tan(x)-x	Complex.tan(x)-x
		/// <summary>
		/// 指定した値に対する正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正弦の値を返します。</returns>
		public static Complex sin(Complex x){return Complex.sin(x);}
		/// <summary>
		/// 指定した値に対する余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余弦の値を返します。</returns>
		public static Complex cos(Complex x){return Complex.cos(x);}
		/// <summary>
		/// 指定した値に対する正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正接の値を返します。</returns>
		public static Complex tan(Complex x){return Complex.tan(x);}
		/// <summary>
		/// 指定した値に対する余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余接の値を返します。</returns>
		public static Complex cot(Complex x){return 1/Complex.tan(x);}
		/// <summary>
		/// 指定した値に対する正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正割の値を返します。</returns>
		public static Complex sec(Complex x){return 1/Complex.cos(x);}
		/// <summary>
		/// 指定した値に対する余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余割の値を返します。</returns>
		public static Complex cosec(Complex x){return 1/Complex.sin(x);}
		/// <summary>
		/// 指定した値に対する正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正矢の値を返します。</returns>
		public static Complex vers(Complex x){return 1-Complex.cos(x);}
		/// <summary>
		/// 指定した値に対する余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余矢の値を返します。</returns>
		public static Complex covers(Complex x){return 1-Complex.sin(x);}
		/// <summary>
		/// 指定した値に対するインボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>インボリュートの値を返します。</returns>
		public static Complex inv(Complex x){return Complex.tan(x)-x;}
		//#define Complex.sin(x)	System.Math.Sin(x.ToRadian())
		//#define Complex.cos(x)	System.Math.Cos(x.ToRadian())
		//#define Complex.tan(x)	System.Math.Tan(x.ToRadian())
		//#define Complex.tan(x)-x	System.Math.Tan(x.ToRadian())-x.ToRadian()
		/// <summary>
		/// 指定した値に対する正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正弦の値を返します。</returns>
		public static double sin(AngleRad x){return System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余弦の値を返します。</returns>
		public static double cos(AngleRad x){return System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正接の値を返します。</returns>
		public static double tan(AngleRad x){return System.Math.Tan(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余接の値を返します。</returns>
		public static double cot(AngleRad x){return 1/System.Math.Tan(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正割の値を返します。</returns>
		public static double sec(AngleRad x){return 1/System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余割の値を返します。</returns>
		public static double cosec(AngleRad x){return 1/System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正矢の値を返します。</returns>
		public static double vers(AngleRad x){return 1-System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余矢の値を返します。</returns>
		public static double covers(AngleRad x){return 1-System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対するインボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>インボリュートの値を返します。</returns>
		public static double inv(AngleRad x){return System.Math.Tan(x.ToRadian())-x.ToRadian();}
		/// <summary>
		/// 指定した値に対する正弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正弦の値を返します。</returns>
		public static double sin(AngleDeg x){return System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余弦を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余弦の値を返します。</returns>
		public static double cos(AngleDeg x){return System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正接の値を返します。</returns>
		public static double tan(AngleDeg x){return System.Math.Tan(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余接を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余接の値を返します。</returns>
		public static double cot(AngleDeg x){return 1/System.Math.Tan(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正割の値を返します。</returns>
		public static double sec(AngleDeg x){return 1/System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余割を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余割の値を返します。</returns>
		public static double cosec(AngleDeg x){return 1/System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する正矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>正矢の値を返します。</returns>
		public static double vers(AngleDeg x){return 1-System.Math.Cos(x.ToRadian());}
		/// <summary>
		/// 指定した値に対する余矢を取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>余矢の値を返します。</returns>
		public static double covers(AngleDeg x){return 1-System.Math.Sin(x.ToRadian());}
		/// <summary>
		/// 指定した値に対するインボリュートを取得します。
		/// </summary>
		/// <param name="x">角度や位相の値を指定します。</param>
		/// <returns>インボリュートの値を返します。</returns>
		public static double inv(AngleDeg x){return System.Math.Tan(x.ToRadian())-x.ToRadian();}
		//-----------------------------------------------------------
		//===========================================================
		//		双曲線関数
		//===========================================================

		//-----------------------------------------------------------

		//-----------------------------------------------------------

		//-----------------------------------------------------------
		//#define _sinh(x)	System.Math.Sinh(x)
		//#define _cosh(x)	System.Math.Cosh(x)
		//#define _tanh(x)	System.Math.Tanh(x)
		//#define _Asinh(x)	System.Math.Log(x+System.Math.Sqrt(x*x+1))
		//#define _Acosh(x)	System.Math.Log(x+System.Math.Sqrt(x*x-1))
		//#define _Atanh(x)	System.Math.Log((1+x)/(1-x))/2
		/// <summary>
		/// 指定した値に対する双曲線正弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正弦の値を返します。</returns>
		public static double sinh(double x){return System.Math.Sinh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余弦の値を返します。</returns>
		public static double cosh(double x){return System.Math.Cosh(x);}
		/// <summary>
		/// 指定した値に対する双曲線正接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正接の値を返します。</returns>
		public static double tanh(double x){return System.Math.Tanh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余接の値を返します。</returns>
		public static double coth(double x){return 1/System.Math.Tanh(x);}
		/// <summary>
		/// 指定した値に対する双曲線正割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正割の値を返します。</returns>
		public static double sech(double x){return 1/System.Math.Cosh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余割の値を返します。</returns>
		public static double cosech(double x){return 1/System.Math.Sinh(x);}
		/// <summary>
		/// 指定した値に対する逆双曲線正弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正弦の値を返します。</returns>
		public static double Arcsinh(double x){return System.Math.Log(x+System.Math.Sqrt(x*x+1));}
		/// <summary>
		/// 指定した値に対する逆双曲線余弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余弦の値を返します。</returns>
		public static double Arccosh(double x){return System.Math.Log(x+System.Math.Sqrt(x*x-1));}
		/// <summary>
		/// 指定した値に対する逆双曲線正接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正接の値を返します。</returns>
		public static double Arctanh(double x){return System.Math.Log((1+x)/(1-x))/2;}
		/// <summary>
		/// 指定した値に対する逆双曲線余接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余接の値を返します。</returns>
		public static double Arccoth(double x){return System.Math.Log((1+1/x)/(1-1/x))/2;}
		/// <summary>
		/// 指定した値に対する逆双曲線正割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正割の値を返します。</returns>
		public static double Arcsech(double x){return System.Math.Log(1/x+System.Math.Sqrt(1/x*1/x-1));}
		/// <summary>
		/// 指定した値に対する逆双曲線余割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余割の値を返します。</returns>
		public static double Arccosech(double x){return System.Math.Log(1/x+System.Math.Sqrt(1/x*1/x+1));}
		//#define System.Math.Sinh(x)	(float)System.Math.Sinh(x)
		//#define System.Math.Cosh(x)	(float)System.Math.Cosh(x)
		//#define System.Math.Tanh(x)	(float)System.Math.Tanh(x)
		//#define System.Math.Log(x+System.Math.Sqrt(x*x+1))	(float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)+1.0))
		//#define System.Math.Log(x+System.Math.Sqrt(x*x-1))	(float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)-1.0))
		//#define System.Math.Log((1+x)/(1-x))/2	(float)(System.Math.Log((1.0+x)/(1.0-x))/2)
		/// <summary>
		/// 指定した値に対する双曲線正弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正弦の値を返します。</returns>
		public static float sinh(float x){return (float)System.Math.Sinh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余弦の値を返します。</returns>
		public static float cosh(float x){return (float)System.Math.Cosh(x);}
		/// <summary>
		/// 指定した値に対する双曲線正接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正接の値を返します。</returns>
		public static float tanh(float x){return (float)System.Math.Tanh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余接の値を返します。</returns>
		public static float coth(float x){return 1/(float)System.Math.Tanh(x);}
		/// <summary>
		/// 指定した値に対する双曲線正割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線正割の値を返します。</returns>
		public static float sech(float x){return 1/(float)System.Math.Cosh(x);}
		/// <summary>
		/// 指定した値に対する双曲線余割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>双曲線余割の値を返します。</returns>
		public static float cosech(float x){return 1/(float)System.Math.Sinh(x);}
		/// <summary>
		/// 指定した値に対する逆双曲線正弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正弦の値を返します。</returns>
		public static float Arcsinh(float x){return (float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)+1.0));}
		/// <summary>
		/// 指定した値に対する逆双曲線余弦を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余弦の値を返します。</returns>
		public static float Arccosh(float x){return (float)System.Math.Log(x+System.Math.Sqrt(x*(double)(x)-1.0));}
		/// <summary>
		/// 指定した値に対する逆双曲線正接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正接の値を返します。</returns>
		public static float Arctanh(float x){return (float)(System.Math.Log((1.0+x)/(1.0-x))/2);}
		/// <summary>
		/// 指定した値に対する逆双曲線余接を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余接の値を返します。</returns>
		public static float Arccoth(float x){return (float)(System.Math.Log((1.0+1/x)/(1.0-1/x))/2);}
		/// <summary>
		/// 指定した値に対する逆双曲線正割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線正割の値を返します。</returns>
		public static float Arcsech(float x){return (float)System.Math.Log(1/x+System.Math.Sqrt(1/x*(double)(1/x)-1.0));}
		/// <summary>
		/// 指定した値に対する逆双曲線余割を取得します。
		/// </summary>
		/// <param name="x">関数に与える値を指定します。</param>
		/// <returns>逆双曲線余割の値を返します。</returns>
		public static float Arccosech(float x){return (float)System.Math.Log(1/x+System.Math.Sqrt(1/x*(double)(1/x)+1.0));}
	}
}
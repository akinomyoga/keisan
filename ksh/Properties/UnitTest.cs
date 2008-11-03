using Compiler=System.Runtime.CompilerServices;
using Interop=System.Runtime.InteropServices;

namespace ksh{
#if DEBUG
	internal static class UnitTest{
		public static void dbg_Rational(afh.Application.Log log){
			log.WriteLine(10/(Rational)15+1);
			log.WriteLine(new Rational(3,8)-11);
			log.WriteLine(new Rational(1,2)+new Rational(2,3));
			log.WriteLine(new Rational(2,3)/Rational.Zero);
			log.WriteLine(new Rational(-2,3)/Rational.Zero);
			log.WriteLine(Rational.Zero/Rational.Zero);
			log.WriteLine(Rational.PositiveInfinity+Rational.NegativeInfinity);
		}

		public static void tst_FloatRem(afh.Application.Log log){
			log.WriteLine(11.2%3.1);
			log.WriteLine(-11.2%3.1);
			log.WriteLine(-11.2-IntUtils.Floor(-11.2,3.1));
			log.WriteLine(System.Math.IEEERemainder(-11.2,3.1));
			log.WriteLine("--角度の実験--");
			log.WriteLine(System.Math.Atan2(-1,1));
		}

		public static void tst_DoubleNaN(afh.Application.Log log){
			log.Lock();
			log.WriteLine("NaN 同士");
			log.WriteLine(double.NaN==0);
			log.WriteLine(double.NaN!=0);
			log.WriteLine(double.NaN==double.NaN);
			log.WriteLine(double.NaN!=double.NaN);
			log.WriteLine(double.NaN<0);
			log.WriteLine(double.NaN>=0);
			log.WriteLine(double.NaN<double.NaN);
			log.WriteLine(double.NaN>=double.NaN);
			log.WriteLine();
			log.WriteLine("+∞ 同士");
			log.WriteLine(double.PositiveInfinity==double.PositiveInfinity);
			log.WriteLine(double.PositiveInfinity!=double.PositiveInfinity);
			log.WriteLine(double.PositiveInfinity<double.PositiveInfinity);
			log.WriteLine(double.PositiveInfinity>=double.PositiveInfinity);
			log.WriteLine();
			log.WriteLine("-∞ 同士");
			log.WriteLine(double.NegativeInfinity==double.NegativeInfinity);
			log.WriteLine(double.NegativeInfinity!=double.NegativeInfinity);
			log.WriteLine(double.NegativeInfinity<double.NegativeInfinity);
			log.WriteLine(double.NegativeInfinity>=double.NegativeInfinity);
			log.WriteLine();
			log.WriteLine("NaN > 色々");
			log.WriteLine(double.NaN>0);
			log.WriteLine(double.NaN>1);
			log.WriteLine(double.NaN>-1);
			log.WriteLine(double.NaN>double.NegativeInfinity);
			log.WriteLine(double.NaN>double.PositiveInfinity);
			log.WriteLine();
			log.Unlock();

			const double inf=double.PositiveInfinity;
			const double NaN=double.NaN;
			log.Lock();
			log.WriteLine("初等関数と NaN");
			log.WriteVar("Atan2(∞,∞)",System.Math.Atan2(inf,inf));
			log.WriteVar("Atan2(∞,NaN)",System.Math.Atan2(inf,NaN));
			log.WriteVar("Atan2(0,0)",System.Math.Atan2(0,0));
			log.WriteVar("Sqrt(∞)",System.Math.Sqrt(inf));
			log.WriteVar("Sqrt(NaN)",System.Math.Sqrt(NaN));
			log.Unlock();
		}
	}

	[afh.Tester.TestTarget]
	public static class UnitTestForComplex{
		private partial struct tComplex {
			public double real;
			public double imag;
			public tComplex(double real,double imag) {
				this.real=real;
				this.imag=imag;
			}
		}

		#region 無限遠点: 確認 & 速度
		//===========================================================
		//		IsInfinity: NaN or Infinity の実験
		//===========================================================
		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 0: 空の関数")]
		public static void bench_NanOrInfCheck0(){
			bench_NanOrInfCheck0_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck0_wk(double x,double y){
			return false;
		} // 24.91 ns

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 1: 加算してから IsInfinity と IsNaN")]
		public static void bench_NanOrInfCheck1(){
			bench_NanOrInfCheck1_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck1_wk(double x,double y){
			double z;
			return double.IsInfinity(z=x+y)||double.IsNaN(z);
		} // 67.06 - 24.91 = 42.15 ns

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 2: IsInfinity と IsNaN の連発")]
		public static void bench_NanOrInfCheck2(){
			bench_NanOrInfCheck2_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck2_wk(double x,double y){
			return double.IsInfinity(x)||double.IsNaN(x)||double.IsInfinity(y)||double.IsNaN(y);
		} // 57.51 - 24.91 = 32.60 ns

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 3: ∞ に常に正規化されていると仮定")]
		public static void bench_NanOrInfCheck3(){
			bench_NanOrInfCheck3_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck3_wk(double x,double y){
			return x==double.PositiveInfinity;
		} // 27.71 - 24.91 = 02.80 ns


		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 4: /∞ で全て NaN にしてから")]
		public static void bench_NanOrInfCheck4(){
			bench_NanOrInfCheck4_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck4_wk(double x,double y){
			return double.IsNaN((x+y)/double.PositiveInfinity);
		} // 201.17 - 24.91 = 176.26 ns // 最悪

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 5: == 総当たり → NaN は !(x<0||x>=0) で")]
		public static void bench_NanOrInfCheck5(){
			bench_NanOrInfCheck5_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck5_wk(double x,double y){
			return x==double.PositiveInfinity||x==double.NegativeInfinity||!(x<0||x>=0)
				||y==double.PositiveInfinity||y==double.NegativeInfinity||!(y<0||y>=0);
		} // 49.59 - 24.91 = 24.68 ns // #2

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 6: 加算→ == 総当たり")]
		public static void bench_NanOrInfCheck6(){
			bench_NanOrInfCheck6_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private static bool bench_NanOrInfCheck6_wk(double x,double y){
			double z;
			return (z=x+y)==double.PositiveInfinity||z==double.NegativeInfinity||!(z<0||z>=0);
		} // 67.99 - 24.91 = 43.08 ns

		public static unsafe void tst_NanOrInf_Representation(afh.Application.Log log){
			System.Action<double> test=delegate(double value){
				long signif16=(int)(*(long*)(&value)>>48);
				string str="";
				for(int i=0x8000;i>0;i>>=1)str+=(signif16&i)!=0?'1':'0';
				log.WriteVar(value.ToString(),str);
			};
			test(0);
			test(1);
			test(1121.44);
			test(.31312312e-10);
			test(-1);
			test(-0.5);
			test(-0.25);
			log.WriteLine();
			test(3.1415926575323846264e100);
			test(3.1415926575323846264e-100);
			log.WriteLine();
			test(double.NaN);
			test(double.PositiveInfinity);
			test(double.NegativeInfinity);
		}
		public static unsafe void tst_NanOrInf_Representation2(afh.Application.Log log){
			//double inf_d=double.PositiveInfinity;
			long inf=0x7ff0000000000000; //*(long*)(&inf_d);

			int i=0,pinf=0,ninf=0,nan=0;
			System.Random r=new System.Random();
			byte[] buff=new byte[8];
			fixed(byte* p=buff){
				long* plong=(long*)p;
				for(i=0;i<0x100000;i++){
					r.NextBytes(buff);
					*plong|=inf;

					//         0x0123456789ABCDEF
					//*plong&=~0x4000000000000000;
					//*plong&=~0x2000000000000000;
					//*plong&=~0x1000000000000000;
					//*plong&=~0x0800000000000000;
					//*plong&=~0x0400000000000000;
					//*plong&=~0x0200000000000000;
					//*plong&=~0x0100000000000000;
					//*plong&=~0x0080000000000000;
					//*plong&=~0x0040000000000000;
					//*plong&=~0x0020000000000000;
					//*plong&=~0x0010000000000000;
					//・ ↑ のどれか一つでも実行すると全て finite になる
					//・ 何も実行しないと全て NaN に為る (∞ が出ないのは確率的な問題)
					//→ と言う事は、finite かどうかは (value&0x7fff....!=0x7fff...) を調べれば良さそう?

					double val=0+*(double*)plong;
					if(double.IsPositiveInfinity(val))
						pinf++;
					else if(double.IsNegativeInfinity(val))
						ninf++;
					else if(double.IsNaN(val))
						nan++;
				}
			}
			i-=pinf+ninf+nan;

			log.WriteVar("+∞",pinf.ToString());
			log.WriteVar("-∞",ninf.ToString());
			log.WriteVar("NaN",nan.ToString());
			log.WriteVar("finite",i.ToString());
		}

		private const long pInfRep=0x7fff000000000000;

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 7: それぞれ bitmask")]
		public static void bench_NanOrInfCheck7(){
			bench_NanOrInfCheck7_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private unsafe static bool bench_NanOrInfCheck7_wk(double x,double y){
			double x1=x;
			double y1=y;
			return (*(long*)(&x1)&pInfRep)==pInfRep||(*(long*)(&y1)&pInfRep)==pInfRep;
		} // 64.26 - 24.91 = 44.35 ns // 若し値のコピーがなければ 4.43 ns

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか 8: 加算 bitmask")]
		public static void bench_NanOrInfCheck8(){
			bench_NanOrInfCheck8_wk(11.2321321,37189371298.0);
		}
		[Compiler::MethodImpl(Compiler::MethodImplOptions.NoInlining)]
		private unsafe static bool bench_NanOrInfCheck8_wk(double x,double y){
			double z=x+y;
			return (*(long*)(&z)&pInfRep)==pInfRep;
		} // 35.62 - 24.91 = 10.71 ns // #2


		//===========================================================
		//		IsInfinity Complex 上で実験
		//===========================================================
		// L0 88.48 ns
		// L1 94.06 ns ←これは fixed なので GC がないという事の運試しである (多分)
		// L2 96.86 ns ←何度かやっていると L2 の方が速い様な気がする。際どい所なのでどちらでも良いが
		//

		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか L0: Complex 上 空")]
		public static void bench_NanOrInfCheckLast0(){
			tComplex c=new tComplex(11.2321321,37189371298.0);
			bool r=c.IsInfinity0;
		}
		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか L1: Complex 上 bitmask fixed")]
		public static void bench_NanOrInfCheckLast1(){
			tComplex c=new tComplex(11.2321321,37189371298.0);
			bool r=c.IsInfinity1;
		}
		[afh.Tester.BenchMethod("Complex.IsInfinity どれが早いか L2: Complex 上 加算 bitmask")]
		public static void bench_NanOrInfCheckLast2(){
			tComplex c=new tComplex(11.2321321,37189371298.0);
			bool r=c.IsInfinity2;
		}

		private partial struct tComplex{
			// 以下は Complex の内容
			internal bool IsInfinity0{
				get{
					return false;
				}
			}
			internal unsafe bool IsInfinity1{
				get{
					fixed(double* x=&this.real)
						return (*(long*)x&pInfRep)==pInfRep||(*(long*)(x+1)&pInfRep)==pInfRep;
				}
			}
			internal unsafe bool IsInfinity2{
				get{
					double z=this.real+this.imag;
					return (*(long*)(&z)&pInfRep)==pInfRep;
				}
			}
		}

		//===========================================================
		//		IsInfinity 加算比較の有効性
		//===========================================================
		public static void tst_NanOrInf加算比較有効性(afh.Application.Log log){
			double[] ddd=new double[]{double.NaN,double.PositiveInfinity,double.NegativeInfinity};
			for(int x=0;x<3;x++)for(int y=0;y<3;y++){
				double result=ddd[x]+ddd[y];
				bool ok=double.IsNaN(result)||double.IsInfinity(result);
				log.WriteLine("{0} + {1} = {2} : {3}",ddd[x],ddd[y],result,ok?"OK":"×××");
			}
		}
		public static void tst_LongLiteral(afh.Application.Log log){
			log.WriteLine(0x7ff0000000000000L);
			log.WriteLine(0x7ffL<<52);
		}
		#endregion

		//===========================================================
		//		GetHashCode 速度
		//===========================================================
		private static readonly tComplex c=new tComplex(11.2321321,37189371298.0);
		[afh.Tester.BenchMethod("Complex.GetHashCode どれが早いか 0: empty")]
		public static int getHashCode0(){
			return 123456789;
		} // 09.60 ns
		[afh.Tester.BenchMethod("Complex.GetHashCode どれが早いか 1: ptr &&&")]
		public static int getHashCode1(){
			return c.GetHashCode1();
		} // 69.85 ns
		[afh.Tester.BenchMethod("Complex.GetHashCode どれが早いか 2: get|get")]
		public static int getHashCode2(){
			return c.GetHashCode2();
		} // 82.89 ns
		[afh.Tester.BenchMethod("Complex.GetHashCode どれが早いか 3: ptr &+")]
		public static int getHashCode3(){
			return c.GetHashCode3();
		} // 69.85 ns

		private partial struct tComplex{
			public unsafe int GetHashCode1(){
				fixed(tComplex* p=&this)
					return (*(long*)&(p->real)|*(long*)&(p->imag)).GetHashCode();
			}
			public int GetHashCode2(){
				return this.real.GetHashCode()|this.imag.GetHashCode();
			}
			public unsafe int GetHashCode3(){
				fixed(double* p=&this.real)
					return (*(long*)p|*(long*)(p+1)).GetHashCode();
			}

			public static bool AreEqual(tComplex a,tComplex b){
				return a.real==b.real&&a.imag==b.imag;
			}
			public static bool AreAlmostEqual(tComplex a,tComplex b){
				return (a.real-b.real)<=double.Epsilon&&(a.imag-b.imag)<=double.Epsilon;
			}
			public static bool AreNear(tComplex a,tComplex b){
				return (a.real-b.real)<double.Epsilon*10&&(a.imag-b.imag)<double.Epsilon*10;
			}
		}

		static Complex[] cplx_arr;
		static int cplx_i=0;
		static tComplex[] cmpx_arr;
		static int cmpx_i=0;
		const int ARRSIZE=0x100;
		static UnitTestForComplex(){
			System.Random r=new System.Random();
			cmpx_arr=new tComplex[ARRSIZE];
			cplx_arr=new Complex[ARRSIZE];
			for(int i=0;i<ARRSIZE;i++) {
				cmpx_arr[i].real=r.NextDouble();
				cmpx_arr[i].imag=r.NextDouble();
				cplx_arr[i]=new Complex(r.NextDouble(),r.NextDouble());
			}
			//byte[] buff=new byte[sizeof(tComplex)*0x100];
			//Interop::Marshal.Copy(
		}

		#region 円関数・双曲線関数 速度
		//===========================================================
		//		tanh 速度
		//===========================================================
		
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 0: empty")]
		public static void tanh0(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh0(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 1")]
		public static void tanh1(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh1(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 2")]
		public static void tanh2(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh2(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 3")]
		public static void tanh3(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh3(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 4: 3 亜種")]
		public static void tanh4(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh4(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 5: 1 亜種")]
		public static void tanh5(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh5(cmpx_arr[cmpx_i]);
		}
		[afh.Tester.BenchMethod("Complex.tanh どれが早いか 6: 3 亜種")]
		public static void tanh6(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			tanh6(cmpx_arr[cmpx_i]);
		}
		private static tComplex tanh0(tComplex value){
			return new tComplex(value.imag,value.real);
		} // 77.30 ns
		private static tComplex tanh1(tComplex value){
			double r2=value.real*2;
			double i2=value.imag*2;
			double den=System.Math.Cosh(r2)+System.Math.Cos(i2);
			return new tComplex(System.Math.Sinh(r2)/den,System.Math.Sin(i2)/den);
		} // 823.29 ns
		private static tComplex tanh2(tComplex value){
			// std::complex より
			double t=System.Math.Tan(value.imag);
			double s=System.Math.Sinh(value.real);
			double b=s*(1+t*t);
			double d=1+b*s;
			return new tComplex(System.Math.Sqrt(1+s*s)*b/d,t/d);
		} // 540.17 ns
		private static tComplex tanh3(tComplex value){
			double t=System.Math.Tan(value.imag)	,t2=t*t;
			double h=System.Math.Tanh(value.real)	,h2=h*h;
			double f=1/(1+t2*h2);
			return new tComplex(t*(1-h2)*f,h*(1+t2)*f);
		} // 506.64 ns
		private static tComplex tanh4(tComplex value){
			double t=System.Math.Tan(value.imag);
			double h=System.Math.Tanh(value.real);
			double t2,h2,d=1+(t2=t*t)*(h2=h*h);
			return new tComplex(h*(1+t2)/d,t*(1-h2)/d);
		} // 514.09 ns
		private static tComplex tanh5(tComplex value){
			double ch=System.Math.Cosh(value.real*2);
			double cn=System.Math.Cos(value.imag*2);
			double f=1/(ch+cn);
			return new tComplex(f*System.Math.Sqrt(ch*ch-1),f*System.Math.Sqrt(1-cn*cn)); // sin の符号が不正確
		} // 543.89 ns
		private static tComplex tanh6(tComplex value){
			double t=System.Math.Tan(value.imag);
			double h=System.Math.Tanh(value.real);
			double f=1/(1+t*t*h*h);
			return new tComplex(t*(1-h*h)*f,h*(1+t*t)*f);
		} // 488.01 ns
		//===========================================================
		//		sin 速度
		//===========================================================
		public static void test_sin_correctness(afh.Application.Log log){
			for(int i=0;i<30;i++){
				tComplex x=sin1(cmpx_arr[i]);
				tComplex y=sin2(cmpx_arr[i]);
				if(tComplex.AreEqual(x,y))
					log.WriteLine("sin1 ＝ sin2");
				else if(tComplex.AreAlmostEqual(x,y))
					log.WriteLine("sin1 ≒ sin2");
				else if(tComplex.AreNear(x,y))
					log.WriteLine("sin1 ～ sin2");
				else{
					log.WriteLine("sin1 ≠ sin2");
					log.WriteLine(cmpx_arr[i].real);
					log.WriteLine(sin_corr_1(cmpx_arr[i].real));
					log.WriteLine(sin_corr_2(cmpx_arr[i].real));
				}
			}
		}
		[afh.Tester.BenchMethod("Complex.sin どれが早いか 1")]
		public static void sin1(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			sin1(cmpx_arr[cmpx_i]);
		} // 763.68 ns
		[afh.Tester.BenchMethod("Complex.sin どれが早いか 2")]
		public static void sin2(){
			cmpx_i=(cmpx_i+1)%ARRSIZE;
			sin2(cmpx_arr[cmpx_i]);
		} // 607.22 ns // 微妙に早いけれども sqrt で精度が落ちている可能性。
		private static tComplex sin1(tComplex value){
			return new tComplex(
				System.Math.Sin(value.real)*System.Math.Cosh(value.imag),
				System.Math.Cos(value.real)*System.Math.Sinh(value.imag)
				);
		}
		private static tComplex sin2(tComplex value){
			double c=System.Math.Cos(value.real);
			double sh=System.Math.Sinh(value.imag);
			return new tComplex(
				(System.Math.IEEERemainder(value.real,2*System.Math.PI)<System.Math.PI?1:-1)*System.Math.Sqrt(1-c*c)*System.Math.Sqrt(1+sh*sh),
				c*sh);
		}
		private static double sin_corr_1(double val){
			return System.Math.Sin(val);
		}
		private static double sin_corr_2(double val){
			double c=System.Math.Cos(val);
			return (System.Math.IEEERemainder(val,2*System.Math.PI)<System.Math.PI?1:-1)*System.Math.Sqrt(1-c*c);
		}
		#endregion

		//===========================================================
		//		argument
		//===========================================================
		public static void tstMathAtan2(afh.Application.Log log){
			log.WriteLine(System.Math.Atan2(0,0));	// 0
			log.WriteLine(System.Math.Atan2(double.NaN,double.NaN)); // NaN
			log.WriteLine(System.Math.Atan2(double.PositiveInfinity,double.PositiveInfinity)); // NaN
			log.WriteLine(System.Math.Atan2(double.PositiveInfinity,0)); // π/2
			log.WriteLine(System.Math.Atan2(0,double.PositiveInfinity)); // 0
		}

		//===========================================================
		//		累乗 速度
		//===========================================================
		const int POW_INDEX=127;
		[afh.Tester.BenchMethod("累乗 Complex.operator^ 0")]
		public static void pow0(){
			cplx_i=(cplx_i+1)%ARRSIZE;
			Complex r=pow0(cplx_arr[cplx_i],POW_INDEX);
		}
		private static Complex pow0(Complex v,int x){return v;}

		[afh.Tester.BenchMethod("累乗 Complex.operator^ int")]
		public static void pow1() {
			cplx_i=(cplx_i+1)%ARRSIZE;
			Complex r=pow1(cplx_arr[cplx_i],POW_INDEX);
		}
		public static Complex pow1(Complex left,int right){
			Complex x;
			if((right&~63)!=0)return left^(double)right;
			switch(right){
				case 1:return left;
				case 2:return left*left;
				case 3:return left*left*left;
				case 4:left*=left;return left*left;
				case 5:x=left*left;return left*x*x;
				case 6:left*=left;goto case 3;
				case 7:x=left*left;left*=x;return left*x*x;
				case 8:left*=left;goto case 4;
				case 9:left*=left*left;goto case 3;
				case 10:left*=left;goto case 5;
				x4l:
					x*=x;
					return left*x*x;
				case 11:x=left*left;left*=x;goto x4l;
				case 12:left*=left*left;goto case 4;
				case 13:x=left*left*left;goto x4l;
				case 14:left*=left;goto case 7;
				case 15:left*=left*left;goto case 5;
				case 16:left*=left;goto case 8;
				case 17:x=left*left;x*=x;goto x4l;
				case 18:left*=left;goto case 9;
				case 19:x=left*left;left*=x;x*=x;goto x4l;
				case 20:left*=left;goto case 10;
				case 21:x=left*left;x*=x;left*=x;goto x4l;
				case 22:left*=left;goto case 11;
				case 23:x=left*left;left*=x;x*=left;goto x4l;
				case 24:left*=left*left;goto case 8;
				case 25:x=left*left;left*=x*x;goto case 5;
				case 26:left*=left;goto case 13;
				case 27:left*=left*left;goto case 9;
				case 28:left*=left;goto case 14;
				x6l:
					x*=x;
					return left*x*x*x;
				case 29:x=left*left;x*=x;left*=x;goto x6l;
				case 30:left*=left;goto case 15;
				case 31:x=left*left;x*=x;x*=left;goto x6l;
				case 32:left*=left;goto case 16;
				case 33:left*=left*left;goto case 11;
				case 34:left*=left*left;goto case 17;
				case 35:x=left*left;left*=x;x*=x;x*=x;goto x4l;
				case 36:left*=left;goto case 18;
				case 37:x=left*left;x*=x;left*=x;x*=x;goto x4l;
				case 38:left*=left;goto case 19;
				case 39:left*=left*left;goto case 13;
				case 40:left*=left;goto case 20;
				case 41:x=left*left;x*=x;x*=x;left*=x;goto x4l;
				case 42:left*=left;goto case 21;
				case 43:x=left*left;x*=x*x*left;goto x4l;
				case 44:left*=left;goto case 22;
				case 45:left*=left*left;goto case 15;
				case 46:left*=left;goto case 23;
				case 47:x=left*left;left*=x;x*=x;x*=x;x*=left;goto x4l;
				case 48:left*=left;goto case 24;
				case 49:x=left*left;left*=x*x*x;goto case 7;
				case 50:left*=left;goto case 25;
				case 51:left*=left*left;goto case 17;
				case 52:left*=left;goto case 26;
				case 53:x=left*left;x*=x;left*=x;x*=x;goto x6l;
				case 54:left*=left;goto case 27;
				case 55:x=left*left;left*=x*x;goto case 11;
				case 56:left*=left;goto case 28;
				case 57:left*=left*left;goto case 19;
				case 58:left*=left;goto case 29;
				case 59:x=left*left;x*=x;left*=x;x*=left;goto x6l;
				case 60:left*=left;goto case 30;
				case 61:x=left*left;x*=x;x*=left;x*=x;goto x6l;
				case 62:left*=left;goto case 31;
				case 63:left*=left*left;goto case 21;
					/*
				case 64:left*=left;goto case 32;
				//*/
				default:return left^(double)right;
			}
		}
		[afh.Tester.BenchMethod("累乗 Complex.operator^ double")]
		public static void pow2() {
			cplx_i=(cplx_i+1)%ARRSIZE;
			Complex r=cplx_arr[cplx_i]^(double)POW_INDEX;
		}
		[afh.Tester.BenchMethod("累乗 Complex.operator^ 8")]
		public static void pow3() {
			cplx_i=(cplx_i+1)%ARRSIZE;
			Complex r=pow3(cplx_arr[cplx_i],POW_INDEX);
		}
		public static Complex pow3(Complex left,int right){
			if(right<0){
				left=left.Reciprocal;
				right=-right;
			}
			Complex r=1;
			Complex x;
			while(true){
				switch(right&7) {
					case 1: r*=left;break;
					case 2: r*=left*left; break;
					case 3: r*=left*left*left; break;
					case 4: left*=left; r*=left*left; break;
					case 5: x=left*left; r*=left*x*x; break;
					case 6: left*=left; goto case 3;
					case 7: x=left*left; left*=x; r*=left*x*x; break;
					default: break;
				}

				right>>=3;
				if(right==0)return r;

				left*=left;left*=left;left*=left;
			}
		}
		[afh.Tester.BenchMethod("累乗 Complex.operator^ 8")]
		public static void pow4() {
			cplx_i=(cplx_i+1)%ARRSIZE;
			Complex r=pow4(cplx_arr[cplx_i],POW_INDEX);
		}
		public static Complex pow4(Complex left,int right){
			if(right<0){
				left=left.Reciprocal;
				right=-right;
			}
			if(right>=128)return left^(double)right;

			Complex r;/*
			switch(right){
				case 1:return left;
				case 2:return left*left;
				case 3:return left*left*left;
				case 4:left*=left;return left*left;
				case 5:r=left*left;return left*r*r;
				case 6:left*=left;goto case 3;
				case 7:r=left*left;left*=r;return left*r*r;
			}//*/

			r=1;
			while(true){
				if((right&1)!=0)r*=left;
				if(0==(right>>=1))return r;
				left*=left;
			}
		}
	}
#endif
}
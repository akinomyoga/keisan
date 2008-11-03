/*
	このソースコードは [afh.Design.dll] afh.Design.TemplateProcessor によって自動的に生成された物です。
	このソースコードを変更しても、このソースコードの元になったファイルを変更しないと変更は適用されません。

	This source code was generated automatically by a file-generator, '[afh.Design.dll] afh.Design.TemplateProcessor'.
	Changes to this source code may not be applied to the binary file, which will cause inconsistency of the whole project.
	If you want to modify any logics in this file, you should change THE SOURCE OF THIS FILE. 
*/
using Diag=System.Diagnostics;
using type=System.Double;

namespace ksh{
	public static partial class IntUtils{
		//===========================================================
		//		Template GCM/LCM/約分
		//===========================================================

		//-----------------------------------------------------------
		//#define ensure_not_neg(x,type)	##
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static ulong GCM(ulong a,ulong b){
			;
			;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static ulong LCM(ulong a,ulong b){
			return (ulong)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、ulong 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static ulong LCM_checked(ulong a,ulong b){
			return (ulong)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static ulong Reduct(ref ulong a,ref ulong b){
			ulong gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static uint GCM(uint a,uint b){
			;
			;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static uint LCM(uint a,uint b){
			return (uint)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、uint 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static uint LCM_checked(uint a,uint b){
			return (uint)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static uint Reduct(ref uint a,ref uint b){
			uint gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static ushort GCM(ushort a,ushort b){
			;
			;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static ushort LCM(ushort a,ushort b){
			return (ushort)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、ushort 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static ushort LCM_checked(ushort a,ushort b){
			return (ushort)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static ushort Reduct(ref ushort a,ref ushort b){
			ushort gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static byte GCM(byte a,byte b){
			;
			;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static byte LCM(byte a,byte b){
			return (byte)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、byte 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static byte LCM_checked(byte a,byte b){
			return (byte)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static byte Reduct(ref byte a,ref byte b){
			byte gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		//#define 	if(x<0)x=(type)(-x);
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static long GCM(long a,long b){
			if(a<0)a=(long)(-a);;
			if(b<0)b=(long)(-b);;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static long LCM(long a,long b){
			return (long)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、long 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static long LCM_checked(long a,long b){
			return (long)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static long Reduct(ref long a,ref long b){
			long gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static int GCM(int a,int b){
			if(a<0)a=(int)(-a);;
			if(b<0)b=(int)(-b);;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static int LCM(int a,int b){
			return (int)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、int 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static int LCM_checked(int a,int b){
			return (int)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static int Reduct(ref int a,ref int b){
			int gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static short GCM(short a,short b){
			if(a<0)a=(short)(-a);;
			if(b<0)b=(short)(-b);;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static short LCM(short a,short b){
			return (short)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、short 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static short LCM_checked(short a,short b){
			return (short)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static short Reduct(ref short a,ref short b){
			short gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static sbyte GCM(sbyte a,sbyte b){
			if(a<0)a=(sbyte)(-a);;
			if(b<0)b=(sbyte)(-b);;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static sbyte LCM(sbyte a,sbyte b){
			return (sbyte)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、sbyte 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static sbyte LCM_checked(sbyte a,sbyte b){
			return (sbyte)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static sbyte Reduct(ref sbyte a,ref sbyte b){
			sbyte gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
		public static decimal GCM(decimal a,decimal b){
			if(a<0)a=(decimal)(-a);;
			if(b<0)b=(decimal)(-b);;
			if(a<b)goto a_lt_b;
		a_gt_b:
			if(b==0)return a;
			a%=b;
		a_lt_b:
			if(a==0)return b;
			b%=a;
			goto a_gt_b;
		}
		/// <summary>
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static decimal LCM(decimal a,decimal b){
			return (decimal)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、decimal 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static decimal LCM_checked(decimal a,decimal b){
			return (decimal)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static decimal Reduct(ref decimal a,ref decimal b){
			decimal gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		//-----------------------------------------------------------

		//-----------------------------------------------------------
		//		xml documents
		//-----------------------------------------------------------

		//#define PARAM(paramName)		<paramref name="paramName"/>

		//===========================================================
		//		Template 天井/床/丸め/切り捨て/切り上げ
		//===========================================================
		//		depending functions
		//-----------------------------------------------------------
		//#define ceil_float(value)		(float)System.Math.Ceiling((double)(value))
		//#define ceil_double(value)	System.Math.Ceiling(value)
		//#define ceil_decimal(value)	decimal.Ceiling(value)
		//#define flor_float(value)		(float)System.Math.Floor((double)(value))
		//#define flor_double(value)	System.Math.Floor(value)
		//#define flor_decimal(value)	decimal.Floor(value)
		//#define roud_float(value)		(float)System.Math.Round((double)(value))
		//#define roud_double(value)	System.Math.Round(value)
		//#define roud_decimal(value)	decimal.Round(value)
		//#define CONC(str,str2)		str##_##str2
		//#define swch_sgn(positive,negative,type)		(value>=0?positive_type(value):negative_type(value))
		//-----------------------------------------------------------

		//-----------------------------------------------------------
		/// <summary>
		/// 指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の整数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		public static float Ceiling(float value){
			return (float)System.Math.Ceiling((double)(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static float Ceiling(float value,float unit){
			return (float)System.Math.Ceiling((double)(value/unit))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CeilingOffset(float value,float offset){
			return (float)System.Math.Ceiling((double)(value-offset))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CeilingOffset(float value,float unit,float offset){
			return (float)System.Math.Ceiling((double)((value-offset)/unit))*unit+offset;
		}
		/// <summary>
		/// 指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の整数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		public static float Floor(float value){
			return (float)System.Math.Floor((double)(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static float Floor(float value,float unit) {
			return (float)System.Math.Floor((double)(value/unit))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float FloorOffset(float value,float offset) {
			return (float)System.Math.Floor((double)(value-offset))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float FloorOffset(float value,float unit,float offset) {
			return (float)System.Math.Floor((double)((value-offset)/unit))*unit+offset;
		}
		/// <summary>
		/// 指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		public static float Round(float value){
			return (float)System.Math.Round((double)(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static float Round(float value,float unit) {
			return (float)System.Math.Round((double)(value/unit))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float RoundOffset(float value,float offset) {
			return (float)System.Math.Round((double)(value-offset))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float RoundOffset(float value,float unit,float offset) {
			return (float)System.Math.Round((double)((value-offset)/unit))*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		public static float CutDown(float value){
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static float CutDown(float value,float unit) {
			value/=unit;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CutDownOffset(float value,float offset) {
			value-=offset;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CutDownOffset(float value,float unit,float offset) {
			value=(value-offset)/unit;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		public static float CutUp(float value){
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static float CutUp(float value,float unit) {
			value/=unit;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CutUpOffset(float value,float offset) {
			value-=offset;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static float CutUpOffset(float value,float unit,float offset) {
			value=(value-offset)/unit;
			return (value>=0?(float)System.Math.Floor((double)(value)):(float)System.Math.Ceiling((double)(value)))*unit+offset;
		}
		/// <summary>
		/// 指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の整数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		public static double Ceiling(double value){
			return System.Math.Ceiling(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static double Ceiling(double value,double unit){
			return System.Math.Ceiling(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CeilingOffset(double value,double offset){
			return System.Math.Ceiling(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CeilingOffset(double value,double unit,double offset){
			return System.Math.Ceiling((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の整数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		public static double Floor(double value){
			return System.Math.Floor(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static double Floor(double value,double unit) {
			return System.Math.Floor(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double FloorOffset(double value,double offset) {
			return System.Math.Floor(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double FloorOffset(double value,double unit,double offset) {
			return System.Math.Floor((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		public static double Round(double value){
			return System.Math.Round(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static double Round(double value,double unit) {
			return System.Math.Round(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double RoundOffset(double value,double offset) {
			return System.Math.Round(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double RoundOffset(double value,double unit,double offset) {
			return System.Math.Round((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		public static double CutDown(double value){
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static double CutDown(double value,double unit) {
			value/=unit;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CutDownOffset(double value,double offset) {
			value-=offset;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CutDownOffset(double value,double unit,double offset) {
			value=(value-offset)/unit;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		public static double CutUp(double value){
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static double CutUp(double value,double unit) {
			value/=unit;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CutUpOffset(double value,double offset) {
			value-=offset;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static double CutUpOffset(double value,double unit,double offset) {
			value=(value-offset)/unit;
			return (value>=0?System.Math.Floor(value):System.Math.Ceiling(value))*unit+offset;
		}
		/// <summary>
		/// 指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の整数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		public static decimal Ceiling(decimal value){
			return decimal.Ceiling(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static decimal Ceiling(decimal value,decimal unit){
			return decimal.Ceiling(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CeilingOffset(decimal value,decimal offset){
			return decimal.Ceiling(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CeilingOffset(decimal value,decimal unit,decimal offset){
			return decimal.Ceiling((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の整数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		public static decimal Floor(decimal value){
			return decimal.Floor(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static decimal Floor(decimal value,decimal unit) {
			return decimal.Floor(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + 整数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal FloorOffset(decimal value,decimal offset) {
			return decimal.Floor(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal FloorOffset(decimal value,decimal unit,decimal offset) {
			return decimal.Floor((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		public static decimal Round(decimal value){
			return decimal.Round(value);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static decimal Round(decimal value,decimal unit) {
			return decimal.Round(value/unit)*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal RoundOffset(decimal value,decimal offset) {
			return decimal.Round(value-offset)+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal RoundOffset(decimal value,decimal unit,decimal offset) {
			return decimal.Round((value-offset)/unit)*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		public static decimal CutDown(decimal value){
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static decimal CutDown(decimal value,decimal unit) {
			value/=unit;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CutDownOffset(decimal value,decimal offset) {
			value-=offset;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CutDownOffset(decimal value,decimal unit,decimal offset) {
			value=(value-offset)/unit;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))*unit+offset;
		}
		/// <summary>
		/// 指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		public static decimal CutUp(decimal value){
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value));
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static decimal CutUp(decimal value,decimal unit) {
			value/=unit;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))*unit;
		}
		/// <summary>
		/// 指定した値を基準にして、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CutUpOffset(decimal value,decimal offset) {
			value-=offset;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))+offset;
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static decimal CutUpOffset(decimal value,decimal unit,decimal offset) {
			value=(value-offset)/unit;
			return (value>=0?decimal.Floor(value):decimal.Ceiling(value))*unit+offset;
		}
		//-----------------------------------------------------------

		//===========================================================
		//		Template 整数の天井/床/丸め/切り捨て/切り上げ
		//===========================================================
		//#define REM_PLUS				((value%=unit)<0?value:value+unit)
		//#define FLOOR(type,add)		(type)((value=(type)(value+(add)))-((value%=unit)<0?value:value+unit))
		//#define FLOOR_OFST(type,add)	(type)((value=(type)(value+(add)-offset))-((value%=unit)<0?value:value+unit)+offset)
		//-----------------------------------------------------------

		//-----------------------------------------------------------
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static long Ceiling(long value,long unit){
			return (long)((value=(long)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static long CeilingOffset(long value,long unit,long offset) {
			return (long)((value=(long)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static long Floor(long value,long unit) {
			return (long)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static long FloorOffset(long value,long unit,long offset) {
			return (long)((value=(long)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static long Round(long value,long unit) {
			return (long)((value=(long)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  long RoundOffset(long value,long unit,long offset) {
			return (long)((value=(long)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static long CutDown(long value,long unit) {
			return (long)((value=(long)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static long CutDownOffset(long value,long unit,long offset) {
			return (long)((value=(long)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static long CutUp(long value,long unit){
			return (long)((value=(long)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static long CutUpOffset(long value,long unit,long offset) {
			return (long)((value=(long)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ulong Ceiling(ulong value,ulong unit){
			return (ulong)((value=(ulong)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ulong CeilingOffset(ulong value,ulong unit,ulong offset) {
			return (ulong)((value=(ulong)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ulong Floor(ulong value,ulong unit) {
			return (ulong)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ulong FloorOffset(ulong value,ulong unit,ulong offset) {
			return (ulong)((value=(ulong)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ulong Round(ulong value,ulong unit) {
			return (ulong)((value=(ulong)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  ulong RoundOffset(ulong value,ulong unit,ulong offset) {
			return (ulong)((value=(ulong)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ulong CutDown(ulong value,ulong unit) {
			return (ulong)((value=(ulong)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ulong CutDownOffset(ulong value,ulong unit,ulong offset) {
			return (ulong)((value=(ulong)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ulong CutUp(ulong value,ulong unit){
			return (ulong)((value=(ulong)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ulong CutUpOffset(ulong value,ulong unit,ulong offset) {
			return (ulong)((value=(ulong)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static int Ceiling(int value,int unit){
			return (int)((value=(int)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static int CeilingOffset(int value,int unit,int offset) {
			return (int)((value=(int)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static int Floor(int value,int unit) {
			return (int)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static int FloorOffset(int value,int unit,int offset) {
			return (int)((value=(int)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static int Round(int value,int unit) {
			return (int)((value=(int)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  int RoundOffset(int value,int unit,int offset) {
			return (int)((value=(int)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static int CutDown(int value,int unit) {
			return (int)((value=(int)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static int CutDownOffset(int value,int unit,int offset) {
			return (int)((value=(int)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static int CutUp(int value,int unit){
			return (int)((value=(int)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static int CutUpOffset(int value,int unit,int offset) {
			return (int)((value=(int)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static uint Ceiling(uint value,uint unit){
			return (uint)((value=(uint)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static uint CeilingOffset(uint value,uint unit,uint offset) {
			return (uint)((value=(uint)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static uint Floor(uint value,uint unit) {
			return (uint)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static uint FloorOffset(uint value,uint unit,uint offset) {
			return (uint)((value=(uint)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static uint Round(uint value,uint unit) {
			return (uint)((value=(uint)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  uint RoundOffset(uint value,uint unit,uint offset) {
			return (uint)((value=(uint)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static uint CutDown(uint value,uint unit) {
			return (uint)((value=(uint)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static uint CutDownOffset(uint value,uint unit,uint offset) {
			return (uint)((value=(uint)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static uint CutUp(uint value,uint unit){
			return (uint)((value=(uint)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static uint CutUpOffset(uint value,uint unit,uint offset) {
			return (uint)((value=(uint)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static short Ceiling(short value,short unit){
			return (short)((value=(short)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static short CeilingOffset(short value,short unit,short offset) {
			return (short)((value=(short)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static short Floor(short value,short unit) {
			return (short)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static short FloorOffset(short value,short unit,short offset) {
			return (short)((value=(short)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static short Round(short value,short unit) {
			return (short)((value=(short)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  short RoundOffset(short value,short unit,short offset) {
			return (short)((value=(short)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static short CutDown(short value,short unit) {
			return (short)((value=(short)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static short CutDownOffset(short value,short unit,short offset) {
			return (short)((value=(short)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static short CutUp(short value,short unit){
			return (short)((value=(short)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static short CutUpOffset(short value,short unit,short offset) {
			return (short)((value=(short)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ushort Ceiling(ushort value,ushort unit){
			return (ushort)((value=(ushort)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ushort CeilingOffset(ushort value,ushort unit,ushort offset) {
			return (ushort)((value=(ushort)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ushort Floor(ushort value,ushort unit) {
			return (ushort)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ushort FloorOffset(ushort value,ushort unit,ushort offset) {
			return (ushort)((value=(ushort)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ushort Round(ushort value,ushort unit) {
			return (ushort)((value=(ushort)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  ushort RoundOffset(ushort value,ushort unit,ushort offset) {
			return (ushort)((value=(ushort)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ushort CutDown(ushort value,ushort unit) {
			return (ushort)((value=(ushort)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ushort CutDownOffset(ushort value,ushort unit,ushort offset) {
			return (ushort)((value=(ushort)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static ushort CutUp(ushort value,ushort unit){
			return (ushort)((value=(ushort)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static ushort CutUpOffset(ushort value,ushort unit,ushort offset) {
			return (ushort)((value=(ushort)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static sbyte Ceiling(sbyte value,sbyte unit){
			return (sbyte)((value=(sbyte)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static sbyte CeilingOffset(sbyte value,sbyte unit,sbyte offset) {
			return (sbyte)((value=(sbyte)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static sbyte Floor(sbyte value,sbyte unit) {
			return (sbyte)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static sbyte FloorOffset(sbyte value,sbyte unit,sbyte offset) {
			return (sbyte)((value=(sbyte)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static sbyte Round(sbyte value,sbyte unit) {
			return (sbyte)((value=(sbyte)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  sbyte RoundOffset(sbyte value,sbyte unit,sbyte offset) {
			return (sbyte)((value=(sbyte)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static sbyte CutDown(sbyte value,sbyte unit) {
			return (sbyte)((value=(sbyte)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static sbyte CutDownOffset(sbyte value,sbyte unit,sbyte offset) {
			return (sbyte)((value=(sbyte)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static sbyte CutUp(sbyte value,sbyte unit){
			return (sbyte)((value=(sbyte)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static sbyte CutUpOffset(sbyte value,sbyte unit,sbyte offset) {
			return (sbyte)((value=(sbyte)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static byte Ceiling(byte value,byte unit){
			return (byte)((value=(byte)(value+(unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の天井を取得します。
		/// 茲での天井とは、その数以上の最小の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">天井を求めたい数を指定します。</param>
		/// <returns>指定した数の天井を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">天井の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static byte CeilingOffset(byte value,byte unit,byte offset) {
			return (byte)((value=(byte)(value+(unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の <paramref name="unit"/> の倍数を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static byte Floor(byte value,byte unit) {
			return (byte)(value-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の床を取得します。
		/// 茲での床とは、その数以下の最大の (offset + <paramref name="unit"/> の倍数) を指します。
		/// </summary>
		/// <param name="value">床を求めたい数を指定します。</param>
		/// <returns>指定した数の床を返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">床の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static byte FloorOffset(byte value,byte unit,byte offset) {
			return (byte)((value=(byte)(value-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static byte Round(byte value,byte unit) {
			return (byte)((value=(byte)(value+(unit>>1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の丸めを取得します。
		/// 茲での丸めとは、床と天井の内近い方を指します。
		/// </summary>
		/// <param name="value">丸めを求めたい数を指定します。</param>
		/// <returns>指定した数の丸めを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">丸めの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static  byte RoundOffset(byte value,byte unit,byte offset) {
			return (byte)((value=(byte)(value+(unit>>1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 0 に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static byte CutDown(byte value,byte unit) {
			return (byte)((value=(byte)(value+(value>=0?0:unit-1)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り捨てを取得します。
		/// 茲での切り捨てとは、床と天井の内 <paramref name="offset"/> に近い方を指します。
		/// </summary>
		/// <param name="value">切り捨てを求めたい数を指定します。</param>
		/// <returns>指定した数の切り捨てを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り捨ての基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static byte CutDownOffset(byte value,byte unit,byte offset) {
			return (byte)((value=(byte)(value+(value>=0?0:unit-1)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		/// <summary>
		/// 階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 0 から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		public static byte CutUp(byte value,byte unit){
			return (byte)((value=(byte)(value+(value>=0?unit-1:0)))-((value%=unit)<0?value:value+unit));
		}
		/// <summary>
		/// 指定した値を基準にして、階の高さ <paramref name="unit"/> を以て、指定した数の切り上げを取得します。
		/// 茲での切り上げとは、床と天井の内 <paramref name="offset"/> から遠い方を指します。
		/// </summary>
		/// <param name="value">切り上げを求めたい数を指定します。</param>
		/// <returns>指定した数の切り上げを返します。</returns>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		/// <param name="offset">切り上げの基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		public static byte CutUpOffset(byte value,byte unit,byte offset) {
			return (byte)((value=(byte)(value+(value>=0?unit-1:0)-offset))-((value%=unit)<0?value:value+unit)+offset);
		}
		//-----------------------------------------------------------
	}
}
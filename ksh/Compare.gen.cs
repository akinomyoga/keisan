/*
	このソースコードは [afh.Design.dll] afh.Design.TemplateProcessor によって自動的に生成された物です。
	このソースコードを変更しても、このソースコードの元になったファイルを変更しないと変更は適用されません。

	This source code was generated automatically by a file-generator, '[afh.Design.dll] afh.Design.TemplateProcessor'.
	Changes to this source code may not be applied to the binary file, which will cause inconsistency of the whole project.
	If you want to modify any logics in this file, you should change THE SOURCE OF THIS FILE. 
*/
namespace ksh{
	/// <summary>
	/// 数の大きさの比較に関する関数を提供します。
	/// </summary>
	public static partial class Compare{

		
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref sbyte min,ref sbyte max){
			if(min<=max)return;
			sbyte c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref sbyte min,ref sbyte mid,ref sbyte max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					sbyte c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					sbyte c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				sbyte c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				sbyte c=min;min=max;max=c;
			}else{
				// mid < max < min
				sbyte c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static sbyte Clamp(sbyte value,sbyte min,sbyte max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref byte min,ref byte max){
			if(min<=max)return;
			byte c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref byte min,ref byte mid,ref byte max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					byte c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					byte c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				byte c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				byte c=min;min=max;max=c;
			}else{
				// mid < max < min
				byte c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static byte Clamp(byte value,byte min,byte max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref short min,ref short max){
			if(min<=max)return;
			short c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref short min,ref short mid,ref short max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					short c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					short c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				short c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				short c=min;min=max;max=c;
			}else{
				// mid < max < min
				short c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static short Clamp(short value,short min,short max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref ushort min,ref ushort max){
			if(min<=max)return;
			ushort c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref ushort min,ref ushort mid,ref ushort max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					ushort c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					ushort c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				ushort c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				ushort c=min;min=max;max=c;
			}else{
				// mid < max < min
				ushort c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static ushort Clamp(ushort value,ushort min,ushort max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref uint min,ref uint max){
			if(min<=max)return;
			uint c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref uint min,ref uint mid,ref uint max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					uint c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					uint c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				uint c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				uint c=min;min=max;max=c;
			}else{
				// mid < max < min
				uint c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static uint Clamp(uint value,uint min,uint max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref long min,ref long max){
			if(min<=max)return;
			long c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref long min,ref long mid,ref long max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					long c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					long c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				long c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				long c=min;min=max;max=c;
			}else{
				// mid < max < min
				long c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static long Clamp(long value,long min,long max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref ulong min,ref ulong max){
			if(min<=max)return;
			ulong c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref ulong min,ref ulong mid,ref ulong max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					ulong c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					ulong c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				ulong c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				ulong c=min;min=max;max=c;
			}else{
				// mid < max < min
				ulong c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static ulong Clamp(ulong value,ulong min,ulong max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref float min,ref float max){
			if(min<=max)return;
			float c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref float min,ref float mid,ref float max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					float c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					float c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				float c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				float c=min;min=max;max=c;
			}else{
				// mid < max < min
				float c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static float Clamp(float value,float min,float max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref double min,ref double max){
			if(min<=max)return;
			double c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref double min,ref double mid,ref double max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					double c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					double c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				double c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				double c=min;min=max;max=c;
			}else{
				// mid < max < min
				double c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static double Clamp(double value,double min,double max){
			return value>max?max:value<min?min:value;
		}
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref decimal min,ref decimal max){
			if(min<=max)return;
			decimal c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref decimal min,ref decimal mid,ref decimal max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					decimal c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					decimal c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				decimal c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				decimal c=min;min=max;max=c;
			}else{
				// mid < max < min
				decimal c=min;min=mid;mid=max;max=c;
			}
		}
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx より
		/// <summary>
		/// 指定した値を、指定した範囲内にはいる様に調整します。
		/// </summary>
		/// <param name="value">指定した範囲内に入る事を保証したい値を指定します。</param>
		/// <param name="min">許される値の範囲の最小値を指定します。</param>
		/// <param name="max">許される値の範囲の最大値を指定します。</param>
		/// <returns><paramref name="value"/> が指定した範囲に入っている場合にはその値をそのまま返します。
		/// <paramref name="value"/>  が <paramref name="max"/> より大きい場合には <paramref name="max"/> を返します。
		/// <paramref name="value"/> が <paramref name="min"/> より小さい場合には <paramref name="min"/> を返します。</returns>
		public static decimal Clamp(decimal value,decimal min,decimal max){
			return value>max?max:value<min?min:value;
		}
	}
}
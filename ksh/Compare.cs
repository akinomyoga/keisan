namespace ksh{
	/// <summary>
	/// 数の大きさの比較に関する関数を提供します。
	/// </summary>
	public static partial class Compare{
		//#→template Math<int>
		/// <summary>
		/// 指定した数の内で、大きい方と小さい方を取得します。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内小さい方を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内大きい方を返します。</param>
		public static void MinMax(ref int min,ref int max){
			if(min<=max)return;
			int c=min;max=min;max=c;
		}
		/// <summary>
		/// 指定した数を小さい順に並べ替えます。
		/// </summary>
		/// <param name="min">比較する数を指定します。指定した数の内、最も小さい物を返します。</param>
		/// <param name="mid">比較する数を指定します。指定した数の内、中間の大きさを持った物を返します。</param>
		/// <param name="max">比較する数を指定します。指定した数の内、最も大きい物を返します。</param>
		public static void MinMax(ref int min,ref int mid,ref int max){
			if(min<=mid){
				// (min<=mid)?max
				if(mid<max)return;
				// (min?max)<=mid
				if(min<=max){
					// min<=max<=mid
					int c=mid;mid=max;max=c;
				}else{
					// max<min<=mid
					int c=min;min=max;max=mid;mid=c;
				}
			}else if(min<=max){ // (mid<min)?max
				// mid < min <= max
				int c=min;min=mid;mid=c;
			}else if(max<=mid){ // mid?max<min
				// max <= mid < min
				int c=min;min=max;max=c;
			}else{
				// mid < max < min
				int c=min;min=mid;mid=max;max=c;
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
		public static int Clamp(int value,int min,int max){
			return value>max?max:value<min?min:value;
		}
		//#←template
		
		//#Math<sbyte>
		//#Math<byte>
		//#Math<short>
		//#Math<ushort>
		//#Math<uint>
		//#Math<long>
		//#Math<ulong>
		//#Math<float>
		//#Math<double>
		//#Math<decimal>
	}
}
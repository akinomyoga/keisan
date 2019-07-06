namespace ksh{
	/// <summary>
	/// ���̑傫���̔�r�Ɋւ���֐���񋟂��܂��B
	/// </summary>
	public static partial class Compare{
		//#��template Math<int>
		/// <summary>
		/// �w�肵�����̓��ŁA�傫�����Ə����������擾���܂��B
		/// </summary>
		/// <param name="min">��r���鐔���w�肵�܂��B�w�肵�����̓�����������Ԃ��܂��B</param>
		/// <param name="max">��r���鐔���w�肵�܂��B�w�肵�����̓��傫������Ԃ��܂��B</param>
		public static void MinMax(ref int min,ref int max){
			if(min<=max)return;
			int c=min;max=min;max=c;
		}
		/// <summary>
		/// �w�肵���������������ɕ��בւ��܂��B
		/// </summary>
		/// <param name="min">��r���鐔���w�肵�܂��B�w�肵�����̓��A�ł�����������Ԃ��܂��B</param>
		/// <param name="mid">��r���鐔���w�肵�܂��B�w�肵�����̓��A���Ԃ̑傫��������������Ԃ��܂��B</param>
		/// <param name="max">��r���鐔���w�肵�܂��B�w�肵�����̓��A�ł��傫������Ԃ��܂��B</param>
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
		// http://www.codeproject.com/KB/cs/generic_clamp_function.aspx ���
		/// <summary>
		/// �w�肵���l���A�w�肵���͈͓��ɂ͂���l�ɒ������܂��B
		/// </summary>
		/// <param name="value">�w�肵���͈͓��ɓ��鎖��ۏ؂������l���w�肵�܂��B</param>
		/// <param name="min">�������l�͈̔͂̍ŏ��l���w�肵�܂��B</param>
		/// <param name="max">�������l�͈̔͂̍ő�l���w�肵�܂��B</param>
		/// <returns><paramref name="value"/> ���w�肵���͈͂ɓ����Ă���ꍇ�ɂ͂��̒l�����̂܂ܕԂ��܂��B
		/// <paramref name="value"/>  �� <paramref name="max"/> ���傫���ꍇ�ɂ� <paramref name="max"/> ��Ԃ��܂��B
		/// <paramref name="value"/> �� <paramref name="min"/> ��菬�����ꍇ�ɂ� <paramref name="min"/> ��Ԃ��܂��B</returns>
		public static int Clamp(int value,int min,int max){
			return value>max?max:value<min?min:value;
		}
		//#��template
		
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
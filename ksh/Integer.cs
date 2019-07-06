using Diag=System.Diagnostics;
using type=System.Double;

namespace ksh{
	public static partial class IntUtils{
		//===========================================================
		//		Template GCM/LCM/��
		//===========================================================
		//#��template gcm<type>
		/// <summary>
		/// �w�肵�����̍ő���񐔂��擾���܂��B
		/// </summary>
		/// <param name="a">�ő���񐔂����߂������̈�����w�肵�܂��B</param>
		/// <param name="b">�ő���񐔂����߂������̈�����w�肵�܂��B</param>
		/// <returns>�w�肵�����̍ő���񐔂�Ԃ��܂��B</returns>
		public static type GCM(type a,type b){
			ensure_not_neg(a,type);
			ensure_not_neg(b,type);
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
		/// �w�肵�����̍ŏ����{�����擾���܂��B
		/// </summary>
		/// <param name="a">�ŏ����{�������߂������̈�����w�肵�܂��B</param>
		/// <param name="b">�ŏ����{�������߂������̈�����w�肵�܂��B</param>
		/// <returns>�w�肵�����̍ŏ����{����Ԃ��܂��B</returns>
		public static type LCM(type a,type b){
			return (type)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// �w�肵�����̍ŏ����{���� overflow �`�F�b�N�t���Ŏ擾���܂��B
		/// </summary>
		/// <param name="a">�ŏ����{�������߂������̈�����w�肵�܂��B</param>
		/// <param name="b">�ŏ����{�������߂������̈�����w�肵�܂��B</param>
		/// <returns>�w�肵�����̍ŏ����{����Ԃ��܂��B</returns>
		/// <exception cref="System.OverflowException">
		/// �ŏ����{�����傫������ׂɁAtype �^�ŕ\���o���Ȃ������ꍇ�ɔ������܂��B
		/// </exception>
		[Diag::DebuggerHidden]
		public static type LCM_checked(type a,type b){
			return (type)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// �w�肵�������̒l��񕪂��܂��B
		/// </summary>
		/// <param name="a">�񕪂̑Ώۂ̒l���w�肵�܂��B�񕪂�����̒l��Ԃ��܂��B</param>
		/// <param name="b">�񕪂̑Ώۂ̒l���w�肵�܂��B�񕪂�����̒l��Ԃ��܂��B</param>
		/// <returns>�󂷂�̂Ɏg�p�����l��Ԃ��܂��B���� a �� b �̍ő���񐔂ł��B</returns>
		public static type Reduct(ref type a,ref type b){
			type gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		//#��template
		//-----------------------------------------------------------
		//#define ensure_not_neg(x,type)	##
		//#gcm<ulong>
		//#gcm<uint>
		//#gcm<ushort>
		//#gcm<byte>
		//#define ensure_not_neg(x,type)	if(x<0)x=(type)(-x);
		//#gcm<long>
		//#gcm<int>
		//#gcm<short>
		//#gcm<sbyte>
		//#gcm<decimal>
		//-----------------------------------------------------------

		//-----------------------------------------------------------
		//		xml documents
		//-----------------------------------------------------------
		//#��template xdocFUNC1<_name,_desc>
		/// <summary>
		/// �w�肵������##_name##���擾���܂��B
		/// 䢂ł�##_name##�Ƃ́A##_desc##���w���܂��B
		/// </summary>
		/// <param name="value">_name##�����߂��������w�肵�܂��B</param>
		/// <returns>�w�肵������##_name##��Ԃ��܂��B</returns>
		//#��template
		//#��template xdocFUNC1<_name,_desc,_desc2>
		/// <summary>
		/// _desc2�A�w�肵������##_name##���擾���܂��B
		/// 䢂ł�##_name##�Ƃ́A##_desc##���w���܂��B
		/// </summary>
		/// <param name="value">_name##�����߂��������w�肵�܂��B</param>
		/// <returns>�w�肵������##_name##��Ԃ��܂��B</returns>
		//#��template
		//#define PARAM(paramName)		<paramref name="paramName"/>
		//#��template xdocP_Unit<_name>
		/// <param name="unit">�u���ꂼ��̊K�̍����v���w�肵�܂��B</param>
		//#��template
		//#��template xdocP_Offset<_name>
		/// <param name="offset">_name##�̊���w�肵�܂��B�܂�A��K�̍����ł���ƍl���ĉ������B</param>
		//#��template
		//===========================================================
		//		Template �V��/��/�ۂ�/�؂�̂�/�؂�グ
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
		//#define swch_sgn(positive,negative,type)		(value>=0?CONC(positive,type)(value):CONC(negative,type)(value))
		//-----------------------------------------------------------
		//#��template functions<type>
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��̐���>
		public static type Ceiling(type value){
			return CONC(ceil,type)(value);
		}
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��� PARAM(unit) �̔{��,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�V��>
		public static type Ceiling(type value,type unit){
			return CONC(ceil,type)(value/unit)*unit;
		}
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��� (offset + ����) ##,�w�肵���l����ɂ���>
		//#xdocP_Offset<�V��>
		public static type CeilingOffset(type value,type offset){
			return CONC(ceil,type)(value-offset)+offset;
		}
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��� (offset + PARAM(unit) �̔{��) ##,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�V��>
		//#xdocP_Offset<�V��>
		public static type CeilingOffset(type value,type unit,type offset){
			return CONC(ceil,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�̐���>
		public static type Floor(type value){
			return CONC(flor,type)(value);
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�� PARAM(unit) �̔{��,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<��>
		public static type Floor(type value,type unit) {
			return CONC(flor,type)(value/unit)*unit;
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�� (offset + ����) ##,�w�肵���l����ɂ���>
		//#xdocP_Offset<��>
		public static type FloorOffset(type value,type offset) {
			return CONC(flor,type)(value-offset)+offset;
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�� (offset + PARAM(unit) �̔{��) ##,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<��>
		//#xdocP_Offset<��>
		public static type FloorOffset(type value,type unit,type offset) {
			return CONC(flor,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���>
		public static type Round(type value){
			return CONC(roud,type)(value);
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�ۂ�>
		public static type Round(type value,type unit) {
			return CONC(roud,type)(value/unit)*unit;
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���,�w�肵���l����ɂ���>
		//#xdocP_Offset<�ۂ�>
		public static type RoundOffset(type value,type offset) {
			return CONC(roud,type)(value-offset)+offset;
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�ۂ�>
		//#xdocP_Offset<�ۂ�>
		public static type RoundOffset(type value,type unit,type offset) {
			return CONC(roud,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� 0 �ɋ߂���>
		public static type CutDown(type value){
			return swch_sgn(flor,ceil,type);
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� 0 �ɋ߂���,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�̂�>
		public static type CutDown(type value,type unit) {
			value/=unit;
			return swch_sgn(flor,ceil,type)*unit;
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� PARAM(offset) �ɋ߂���,�w�肵���l����ɂ���>
		//#xdocP_Offset<�؂�̂�>
		public static type CutDownOffset(type value,type offset) {
			value-=offset;
			return swch_sgn(flor,ceil,type)+offset;
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� PARAM(offset) �ɋ߂���,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�̂�>
		//#xdocP_Offset<�؂�̂�>
		public static type CutDownOffset(type value,type unit,type offset) {
			value=(value-offset)/unit;
			return swch_sgn(flor,ceil,type)*unit+offset;
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� 0 ���牓����>
		public static type CutUp(type value){
			return swch_sgn(flor,ceil,type);
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� 0 ���牓����,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�グ>
		public static type CutUp(type value,type unit) {
			value/=unit;
			return swch_sgn(flor,ceil,type)*unit;
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� PARAM(offset) ���牓����,�w�肵���l����ɂ���>
		//#xdocP_Offset<�؂�グ>
		public static type CutUpOffset(type value,type offset) {
			value-=offset;
			return swch_sgn(flor,ceil,type)+offset;
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� PARAM(offset) ���牓����,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�グ>
		//#xdocP_Offset<�؂�グ>
		public static type CutUpOffset(type value,type unit,type offset) {
			value=(value-offset)/unit;
			return swch_sgn(flor,ceil,type)*unit+offset;
		}
		//#��template
		//-----------------------------------------------------------
		//#functions<float>
		//#functions<double>
		//#functions<decimal>
		//-----------------------------------------------------------

		//===========================================================
		//		Template �����̓V��/��/�ۂ�/�؂�̂�/�؂�グ
		//===========================================================
		//#define REM_PLUS				((value%=unit)<0?value:value+unit)
		//#define FLOOR(type,add)		(type)((value=(type)(value+(add)))-REM_PLUS)
		//#define FLOOR_OFST(type,add)	(type)((value=(type)(value+(add)-offset))-REM_PLUS+offset)
		//-----------------------------------------------------------
		//#��template ceil2<type>
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��� PARAM(unit) �̔{��,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�V��>
		public static type Ceiling(type value,type unit){
			return FLOOR(type,unit-1);
		}
		//#xdocFUNC1<�V��,���̐��ȏ�̍ŏ��� (offset + PARAM(unit) �̔{��) ##,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�V��>
		//#xdocP_Offset<�V��>
		public static type CeilingOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,unit-1);
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�� PARAM(unit) �̔{��,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<��>
		public static type Floor(type value,type unit) {
			return (type)(value-REM_PLUS);
		}
		//#xdocFUNC1<��,���̐��ȉ��̍ő�� (offset + PARAM(unit) �̔{��) ##,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<��>
		//#xdocP_Offset<��>
		public static type FloorOffset(type value,type unit,type offset) {
			return (type)((value=(type)(value-offset))-REM_PLUS+offset);
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�ۂ�>
		public static type Round(type value,type unit) {
			return FLOOR(type,unit>>1);
		}
		//#xdocFUNC1<�ۂ�,���ƓV��̓��߂���,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�ۂ�>
		//#xdocP_Offset<�ۂ�>
		public static  type RoundOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,unit>>1);
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� 0 �ɋ߂���,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�̂�>
		public static type CutDown(type value,type unit) {
			return FLOOR(type,value>=0?0:unit-1);
		}
		//#xdocFUNC1<�؂�̂�,���ƓV��̓� PARAM(offset) �ɋ߂���,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�̂�>
		//#xdocP_Offset<�؂�̂�>
		public static type CutDownOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,value>=0?0:unit-1);
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� 0 ���牓����,�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�グ>
		public static type CutUp(type value,type unit){
			return FLOOR(type,value>=0?unit-1:0);
		}
		//#xdocFUNC1<�؂�グ,���ƓV��̓� PARAM(offset) ���牓����,�w�肵���l����ɂ��āA�K�̍��� PARAM(unit) ���Ȃ�>
		//#xdocP_Unit<�؂�グ>
		//#xdocP_Offset<�؂�グ>
		public static type CutUpOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,value>=0?unit-1:0);
		}
		//#��template
		//-----------------------------------------------------------
		//#ceil2<long>
		//#ceil2<ulong>
		//#ceil2<int>
		//#ceil2<uint>
		//#ceil2<short>
		//#ceil2<ushort>
		//#ceil2<sbyte>
		//#ceil2<byte>
		//-----------------------------------------------------------
	}
}
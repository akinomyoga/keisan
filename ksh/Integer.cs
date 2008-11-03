using Diag=System.Diagnostics;
using type=System.Double;

namespace ksh{
	public static partial class IntUtils{
		//===========================================================
		//		Template GCM/LCM/約分
		//===========================================================
		//#→template gcm<type>
		/// <summary>
		/// 指定した数の最大公約数を取得します。
		/// </summary>
		/// <param name="a">最大公約数を求めたい数の一方を指定します。</param>
		/// <param name="b">最大公約数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最大公約数を返します。</returns>
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
		/// 指定した数の最小公倍数を取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		public static type LCM(type a,type b){
			return (type)(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した数の最小公倍数を overflow チェック付きで取得します。
		/// </summary>
		/// <param name="a">最小公倍数を求めたい数の一方を指定します。</param>
		/// <param name="b">最小公倍数を求めたい数の一方を指定します。</param>
		/// <returns>指定した数の最小公倍数を返します。</returns>
		/// <exception cref="System.OverflowException">
		/// 最小公倍数が大きすぎる為に、type 型で表現出来なかった場合に発生します。
		/// </exception>
		[Diag::DebuggerHidden]
		public static type LCM_checked(type a,type b){
			return (type)checked(a*(b/GCM(a,b)));
		}
		/// <summary>
		/// 指定した複数の値を約分します。
		/// </summary>
		/// <param name="a">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <param name="b">約分の対象の値を指定します。約分した後の値を返します。</param>
		/// <returns>訳するのに使用した値を返します。則ち a と b の最大公約数です。</returns>
		public static type Reduct(ref type a,ref type b){
			type gcm=GCM(a,b);
			if(gcm>1){
				a/=gcm;b/=gcm;
			}
			return gcm;
		}
		//#←template
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
		//#→template xdocFUNC1<_name,_desc>
		/// <summary>
		/// 指定した数の##_name##を取得します。
		/// 茲での##_name##とは、##_desc##を指します。
		/// </summary>
		/// <param name="value">_name##を求めたい数を指定します。</param>
		/// <returns>指定した数の##_name##を返します。</returns>
		//#←template
		//#→template xdocFUNC1<_name,_desc,_desc2>
		/// <summary>
		/// _desc2、指定した数の##_name##を取得します。
		/// 茲での##_name##とは、##_desc##を指します。
		/// </summary>
		/// <param name="value">_name##を求めたい数を指定します。</param>
		/// <returns>指定した数の##_name##を返します。</returns>
		//#←template
		//#define PARAM(paramName)		<paramref name="paramName"/>
		//#→template xdocP_Unit<_name>
		/// <param name="unit">「それぞれの階の高さ」を指定します。</param>
		//#←template
		//#→template xdocP_Offset<_name>
		/// <param name="offset">_name##の基準を指定します。つまり、零階の高さであると考えて下さい。</param>
		//#←template
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
		//#define swch_sgn(positive,negative,type)		(value>=0?CONC(positive,type)(value):CONC(negative,type)(value))
		//-----------------------------------------------------------
		//#→template functions<type>
		//#xdocFUNC1<天井,その数以上の最小の整数>
		public static type Ceiling(type value){
			return CONC(ceil,type)(value);
		}
		//#xdocFUNC1<天井,その数以上の最小の PARAM(unit) の倍数,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<天井>
		public static type Ceiling(type value,type unit){
			return CONC(ceil,type)(value/unit)*unit;
		}
		//#xdocFUNC1<天井,その数以上の最小の (offset + 整数) ##,指定した値を基準にして>
		//#xdocP_Offset<天井>
		public static type CeilingOffset(type value,type offset){
			return CONC(ceil,type)(value-offset)+offset;
		}
		//#xdocFUNC1<天井,その数以上の最小の (offset + PARAM(unit) の倍数) ##,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<天井>
		//#xdocP_Offset<天井>
		public static type CeilingOffset(type value,type unit,type offset){
			return CONC(ceil,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<床,その数以下の最大の整数>
		public static type Floor(type value){
			return CONC(flor,type)(value);
		}
		//#xdocFUNC1<床,その数以下の最大の PARAM(unit) の倍数,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<床>
		public static type Floor(type value,type unit) {
			return CONC(flor,type)(value/unit)*unit;
		}
		//#xdocFUNC1<床,その数以下の最大の (offset + 整数) ##,指定した値を基準にして>
		//#xdocP_Offset<床>
		public static type FloorOffset(type value,type offset) {
			return CONC(flor,type)(value-offset)+offset;
		}
		//#xdocFUNC1<床,その数以下の最大の (offset + PARAM(unit) の倍数) ##,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<床>
		//#xdocP_Offset<床>
		public static type FloorOffset(type value,type unit,type offset) {
			return CONC(flor,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<丸め,床と天井の内近い方>
		public static type Round(type value){
			return CONC(roud,type)(value);
		}
		//#xdocFUNC1<丸め,床と天井の内近い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<丸め>
		public static type Round(type value,type unit) {
			return CONC(roud,type)(value/unit)*unit;
		}
		//#xdocFUNC1<丸め,床と天井の内近い方,指定した値を基準にして>
		//#xdocP_Offset<丸め>
		public static type RoundOffset(type value,type offset) {
			return CONC(roud,type)(value-offset)+offset;
		}
		//#xdocFUNC1<丸め,床と天井の内近い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<丸め>
		//#xdocP_Offset<丸め>
		public static type RoundOffset(type value,type unit,type offset) {
			return CONC(roud,type)("#(value-offset)/unit#")*unit+offset;
		}
		//#xdocFUNC1<切り捨て,床と天井の内 0 に近い方>
		public static type CutDown(type value){
			return swch_sgn(flor,ceil,type);
		}
		//#xdocFUNC1<切り捨て,床と天井の内 0 に近い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り捨て>
		public static type CutDown(type value,type unit) {
			value/=unit;
			return swch_sgn(flor,ceil,type)*unit;
		}
		//#xdocFUNC1<切り捨て,床と天井の内 PARAM(offset) に近い方,指定した値を基準にして>
		//#xdocP_Offset<切り捨て>
		public static type CutDownOffset(type value,type offset) {
			value-=offset;
			return swch_sgn(flor,ceil,type)+offset;
		}
		//#xdocFUNC1<切り捨て,床と天井の内 PARAM(offset) に近い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り捨て>
		//#xdocP_Offset<切り捨て>
		public static type CutDownOffset(type value,type unit,type offset) {
			value=(value-offset)/unit;
			return swch_sgn(flor,ceil,type)*unit+offset;
		}
		//#xdocFUNC1<切り上げ,床と天井の内 0 から遠い方>
		public static type CutUp(type value){
			return swch_sgn(flor,ceil,type);
		}
		//#xdocFUNC1<切り上げ,床と天井の内 0 から遠い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り上げ>
		public static type CutUp(type value,type unit) {
			value/=unit;
			return swch_sgn(flor,ceil,type)*unit;
		}
		//#xdocFUNC1<切り上げ,床と天井の内 PARAM(offset) から遠い方,指定した値を基準にして>
		//#xdocP_Offset<切り上げ>
		public static type CutUpOffset(type value,type offset) {
			value-=offset;
			return swch_sgn(flor,ceil,type)+offset;
		}
		//#xdocFUNC1<切り上げ,床と天井の内 PARAM(offset) から遠い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り上げ>
		//#xdocP_Offset<切り上げ>
		public static type CutUpOffset(type value,type unit,type offset) {
			value=(value-offset)/unit;
			return swch_sgn(flor,ceil,type)*unit+offset;
		}
		//#←template
		//-----------------------------------------------------------
		//#functions<float>
		//#functions<double>
		//#functions<decimal>
		//-----------------------------------------------------------

		//===========================================================
		//		Template 整数の天井/床/丸め/切り捨て/切り上げ
		//===========================================================
		//#define REM_PLUS				((value%=unit)<0?value:value+unit)
		//#define FLOOR(type,add)		(type)((value=(type)(value+(add)))-REM_PLUS)
		//#define FLOOR_OFST(type,add)	(type)((value=(type)(value+(add)-offset))-REM_PLUS+offset)
		//-----------------------------------------------------------
		//#→template ceil2<type>
		//#xdocFUNC1<天井,その数以上の最小の PARAM(unit) の倍数,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<天井>
		public static type Ceiling(type value,type unit){
			return FLOOR(type,unit-1);
		}
		//#xdocFUNC1<天井,その数以上の最小の (offset + PARAM(unit) の倍数) ##,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<天井>
		//#xdocP_Offset<天井>
		public static type CeilingOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,unit-1);
		}
		//#xdocFUNC1<床,その数以下の最大の PARAM(unit) の倍数,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<床>
		public static type Floor(type value,type unit) {
			return (type)(value-REM_PLUS);
		}
		//#xdocFUNC1<床,その数以下の最大の (offset + PARAM(unit) の倍数) ##,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<床>
		//#xdocP_Offset<床>
		public static type FloorOffset(type value,type unit,type offset) {
			return (type)((value=(type)(value-offset))-REM_PLUS+offset);
		}
		//#xdocFUNC1<丸め,床と天井の内近い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<丸め>
		public static type Round(type value,type unit) {
			return FLOOR(type,unit>>1);
		}
		//#xdocFUNC1<丸め,床と天井の内近い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<丸め>
		//#xdocP_Offset<丸め>
		public static  type RoundOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,unit>>1);
		}
		//#xdocFUNC1<切り捨て,床と天井の内 0 に近い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り捨て>
		public static type CutDown(type value,type unit) {
			return FLOOR(type,value>=0?0:unit-1);
		}
		//#xdocFUNC1<切り捨て,床と天井の内 PARAM(offset) に近い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り捨て>
		//#xdocP_Offset<切り捨て>
		public static type CutDownOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,value>=0?0:unit-1);
		}
		//#xdocFUNC1<切り上げ,床と天井の内 0 から遠い方,階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り上げ>
		public static type CutUp(type value,type unit){
			return FLOOR(type,value>=0?unit-1:0);
		}
		//#xdocFUNC1<切り上げ,床と天井の内 PARAM(offset) から遠い方,指定した値を基準にして、階の高さ PARAM(unit) を以て>
		//#xdocP_Unit<切り上げ>
		//#xdocP_Offset<切り上げ>
		public static type CutUpOffset(type value,type unit,type offset) {
			return FLOOR_OFST(type,value>=0?unit-1:0);
		}
		//#←template
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
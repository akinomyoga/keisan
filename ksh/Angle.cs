namespace ksh{
	public static partial class Constants{
		public const double ÉŒ=System.Math.PI;
		public const double e=System.Math.E;
	}

	[System.Serializable]
	public struct AngleRad{
		public double value;
		public AngleRad(double radian){
			this.value=System.Math.IEEERemainder(radian,PERIOD);
		}
		public AngleRad(double x,double y):this(System.Math.Atan2(y,x)){
		}
		public static AngleRad FromDegree(double value){
			return new AngleRad(AngleRad.PERIOD/AngleDeg.PERIOD*value);
		}
		public static AngleRad FromRadian(double value){
			return new AngleRad(value);
		}
		//===========================================================
		//		íËêî
		//===========================================================
		internal const double PERIOD	=2*Constants.ÉŒ;
		private const double RIGHT	=Constants.ÉŒ/2;

		public static readonly AngleRad Right=new AngleRad(RIGHT);
		public static readonly AngleRad Period=new AngleRad(PERIOD);
		//===========================================================
		//		éZèpââéZ
		//===========================================================
		public AngleRad Complementary{
			get{return new AngleRad(RIGHT-this.value);}
		}
		public AngleRad Supplementary{
			get{return new AngleRad(Constants.ÉŒ-this.value);}
		}
		public static AngleRad operator+(AngleRad value){return value;}
		public static AngleRad operator+(AngleRad left,AngleRad right){
			return new AngleRad(left.value+right.value);
		}
		public static AngleRad operator-(AngleRad value){
			return new AngleRad(-value.value);
		}
		public static AngleRad operator-(AngleRad left,AngleRad right){
			return new AngleRad(left.value-right.value);
		}
		public static AngleRad operator*(AngleRad value,double rate){
			return new AngleRad(value.value*rate);
		}
		public static AngleRad operator*(double rate,AngleRad value){
			return new AngleRad(rate*value.value);
		}
		//===========================================================
		//		î‰ärââéZ
		//===========================================================
		public static bool operator==(AngleRad left,AngleRad right){
			return left.value==right.value;
		}
		public static bool operator!=(AngleRad left,AngleRad right){
			return left.value!=right.value;
		}
		public static bool operator==(AngleRad left,AngleDeg right){
			return left==(AngleRad)right;
		}
		public static bool operator!=(AngleRad left,AngleDeg right){
			return left!=(AngleRad)right;
		}
		public static bool operator==(AngleDeg left,AngleRad right){
			return (AngleRad)left==right;
		}
		public static bool operator!=(AngleDeg left,AngleRad right){
			return (AngleRad)left!=right;
		}
		public override int GetHashCode() {
			return this.value.GetHashCode();
		}
		public override bool Equals(object obj) {
			if(obj is AngleRad)return this==(AngleRad)obj;
			if(obj is AngleDeg)return this==(AngleDeg)obj;
			System.Type t=obj.GetType();
			if(t.IsPrimitive&&t!=typeof(bool)&&t!=typeof(char)||t==typeof(decimal)){
				return System.Convert.ToDouble(obj)==this.value;
			}
			return false;
		}
		//===========================================================
		//		ïœä∑
		//===========================================================
		public static implicit operator double(AngleRad angle){
			return angle.value;
		}
		public static implicit operator AngleRad(double angle){
			return new AngleRad(angle);
		}
		public static explicit operator AngleDeg(AngleRad angle){
			return new AngleDeg(AngleDeg.PERIOD/AngleRad.PERIOD*angle.value);
		}
		public override string ToString(){
			return this.value.ToString()+" [rad]";
		}
		public double ToDouble(){
			return this.value;
		}
		public double ToDegree(){
			return AngleDeg.PERIOD/AngleRad.PERIOD*this;
		}
		public double ToRadian(){
			return this.value;
		}
	}

	[System.Serializable]
	public struct AngleDeg{
		public double value;
		public AngleDeg(double degree){
			this.value=System.Math.IEEERemainder(degree,PERIOD);
		}
		public AngleDeg(double x,double y):this(AngleDeg.PERIOD/AngleRad.PERIOD*System.Math.Atan2(y,x)){
		}
		//===========================================================
		//		íËêî
		//===========================================================
		internal const double PERIOD	=360;
		private const double HEIKAKU	=180;
		private const double RIGHT		=90;

		public static readonly AngleDeg Right=new AngleDeg(RIGHT);
		public static readonly AngleDeg Period=new AngleDeg(PERIOD);
		//===========================================================
		//		éZèpââéZ
		//===========================================================
		public AngleDeg Complementary{
			get{return new AngleDeg(RIGHT-this.value);}
		}
		public AngleDeg Supplementary{
			get{return new AngleDeg(HEIKAKU-this.value);}
		}
		public static AngleDeg operator+(AngleDeg value){return value;}
		public static AngleDeg operator+(AngleDeg left,AngleDeg right){
			return new AngleDeg(left.value+right.value);
		}
		public static AngleDeg operator-(AngleDeg value){
			return new AngleDeg(-value.value);
		}
		public static AngleDeg operator-(AngleDeg left,AngleDeg right){
			return new AngleDeg(left.value-right.value);
		}
		public static AngleDeg operator*(AngleDeg value,double rate){
			return new AngleDeg(value.value*rate);
		}
		public static AngleDeg operator*(double rate,AngleDeg value){
			return new AngleDeg(rate*value.value);
		}
		//===========================================================
		//		î‰ärââéZ
		//===========================================================
		public static bool operator==(AngleDeg left,AngleDeg right){
			return left.value==right.value;
		}
		public static bool operator!=(AngleDeg left,AngleDeg right){
			return left.value!=right.value;
		}
		public override int GetHashCode() {
			return this.value.GetHashCode();
		}
		public override bool Equals(object obj) {
			if(obj is AngleRad)return this==(AngleRad)obj;
			if(obj is AngleDeg)return this==(AngleDeg)obj;
			System.Type t=obj.GetType();
			if(t.IsPrimitive&&t!=typeof(bool)&&t!=typeof(char)||t==typeof(decimal)) {
				return System.Convert.ToDouble(obj)==AngleRad.PERIOD/AngleDeg.PERIOD*this.value;
			}
			return false;
		}
		//===========================================================
		//		ïœä∑
		//===========================================================
		public static explicit operator double(AngleDeg angle){
			return angle.value;
		}
		public static implicit operator AngleRad(AngleDeg angle){
			return new AngleRad(AngleRad.PERIOD/AngleDeg.PERIOD*angle.value);
		}
		public override string ToString(){
			return this.value.ToString()+" [deg]";
		}
		public double ToDouble(){
			return this.value;
		}
		public double ToRadian(){
			return AngleRad.PERIOD/AngleDeg.PERIOD*this.value;
		}
	}
}
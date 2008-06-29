using Forms=System.Windows.Forms;
using DFunc=System.Converter<double,double>;
using Pens=System.Drawing.Pens;
using kshf=ksh.Functions;

namespace Drill4.No4{
	public static class Q2_2{
		static Graph.Form1 frm;
		public static void main(){
			frm=new Graph.Form1();
			frm.Load+=new System.EventHandler(frm_Load);
			Forms::Application.Run(frm);
		}

		static void frm_Load(object sender,System.EventArgs e) {
			const int N=100;
			DFunc Np=delegate(double M) { return (N+M)/2; };
			DFunc Nm=delegate(double M) { return (N-M)/2; };
			DFunc TInv=delegate(double E) {
				double m=E*20;
				if(m<-N||N<m) return 0;
				double np=Np(m);
				double nm=Nm(m);
				return System.Math.Log(nm)+1/(2*nm)-System.Math.Log(np)-1/(2*np);
			};

			// 逆温度
			frm.AddFunction(TInv,System.Drawing.Pens.Green);

			// 温度
			frm.AddFunction(delegate(double E){ return 1/TInv(E); },System.Drawing.Pens.Red);

			DFunc DE_TInv=delegate(double E){
				double m=E*20;
				if(m<-N||N<m) return 1;
				double np=Np(m);
				double nm=Nm(m);
				return 1/nm-1/(2*nm*nm)+1/np-1/(2*np*np);
			};

			// 比熱
			frm.AddFunction(delegate(double E){
				double tinv=TInv(E);
				return DE_TInv(E)*tinv*tinv;
			},System.Drawing.Pens.Olive);
		}
	}

	/// <summary>
	/// E = - \偏微分[ln Z]{\beta} とする所を誤って E = - \偏微分[Z]{\beta} で計算した結果である。
	/// </summary>
	public static class Q2_3_err{
		static Graph.Form1 frm;
		public static void main(){
			frm=new Graph.Form1();
			frm.Load+=new System.EventHandler(frm_Load);
			Forms::Application.Run(frm);
		}

		static double scaleY=1;
		static void frm_Load(object sender,System.EventArgs e) {

			scaleY=System.Math.Abs(E(10));

			// E
			frm.AddFunction(delegate(double T){
				return E(T)/scaleY;
			},Pens.Red);

			// C
			frm.AddFunction(delegate(double T){
				return C(T)/scaleY;
			},Pens.Olive);
		}

		static double C(double T){
			if(T<0)return 0;
			double mHb=muH/T;
			double db_z1=dbeta_Z1(T);
			return N*mHb*mHb*System.Math.Pow(Z1(T),N-2)*(N*db_z1*db_z1+4);
		}
		static double E(double T){
			if(T<0)return 0;
			return -System.Math.Pow(Z1(T),N-1)*dbeta_Z1(T);
		}

		const double N=100;
		const double muH=1;
		static double Z1(double T){
			double beta=1/T;
			return 2*System.Math.Cosh(beta*muH);
		}
		static double dbeta_Z1(double T){
			double beta=1/T;
			return muH*2*System.Math.Sinh(beta*muH);
		}
	}

	public static class Q2_3{
		static Graph.Form1 frm;
		public static void main(){
			frm=new Graph.Form1();
			frm.Load+=new System.EventHandler(frm_Load);
			Forms::Application.Run(frm);
		}

		static double scaleY=1;
		static void frm_Load(object sender,System.EventArgs e) {

			scaleY=System.Math.Abs(E(10));

			// E
			frm.AddFunction(delegate(double T){
				return E(T)/scaleY;
			},Pens.Red);

			// C
			frm.AddFunction(delegate(double T){
				return C(T)/scaleY;
			},Pens.Olive);
		}

		static double C(double T){
			if(T<0)return 0;
			double x=muH/T;
			double xsec=x*kshf.sech(x);
			return N*xsec*xsec;
		}
		static double E(double T){
			if(T<0)return 0;
			double x=muH/T;
			return -N*muH*System.Math.Tanh(x);
		}

		const double N=100;
		const double muH=1;
		static double Z1(double T){
			double beta=1/T;
			return 2*System.Math.Cosh(beta*muH);
		}
		static double dx_Z1(double T){
			double beta=1/T;
			return muH*2*System.Math.Sinh(beta*muH);
		}
	}

	public static class Q2_4{
		public static void main(){
			System.Console.WriteLine(
				"x tanh x == 1: x="+二分法(
					delegate(double x){
						return x*kshf.tanh(x)-1;
					},0,2
				)
			);
		}

		public static double 二分法(DFunc f,double min,double max){
			double a=f(min);
			double b=f(max);
			if(a==0)return min;
			if(b==0)return max;
			if(a*b>0)return double.NaN;
			if(a>b){
				double c;
				c=min;min=max;max=c;
				c=a=a=b;b=c;
			}
			while(max-min>0.0001){
				double mid=(max+min)/2;
				double c=f(mid);
				if(c==0)return mid;

				if(a*c>0){
					// ac 同符号
					a=c;
					min=mid;
				}else{
					b=c;
					max=mid;
				}
			}
			return min;
		}
	}
}
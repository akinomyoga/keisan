using Gen=System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Gdi=System.Drawing;

using DFunc=System.Converter<double,double>;

namespace Graph {
	public partial class Form1:System.Windows.Forms.Form {
		public Form1(){
			this.originX=100;
			this.originY=100;
			this.scaleX=10;
			this.scaleY=10;
			InitializeComponent();
		}

		private Gen::List<Function> funcs=new Gen::List<Function>();

		private void Form1_Load(object sender,System.EventArgs e) {
			this.AddFunction(delegate(double v){return 1;},Gdi::Pens.Silver);
			this.AddFunction(delegate(double v){
				const double M=4;
				double l=System.Math.Sin(M*v)/System.Math.Sin(v);
				return l*l;
			},Gdi::Pens.Blue);


			/*
			 * エレクトロニクスⅡ 実験 2
			this.AddFunction(delegate(double v){
				const double H=2;
				const double A=8*H/(System.Math.PI*System.Math.PI);
				double s=0;
				double sgn=1;
				for(int n=1;n<100;n+=2,sgn=-sgn){
					s+=sgn/(n*n)*System.Math.Sin(n*v);
				}
				return A*s;
			},Gdi::Pens.Green);
			this.AddFunction(delegate(double v){
				const double H=2;
				const double A=4*H/System.Math.PI;
				double s=0;
				for(int n=1;n<100;n+=2){
					s+=A/n*System.Math.Sin(n*v);
				}
				return s;
			},Gdi::Pens.Red);
			//*/

			// this.AddFunction(delegate(double v){return SinDivX(v+6.28)-SinDivX(v-6.28);},System.Drawing.Pens.Green);
			// this.AddFunction(delegate(double v){return SinDivX(v+6.28)+SinDivX(v-6.28);},System.Drawing.Pens.Red);
		}
		public void AddFunction(System.Converter<double,double> func,System.Drawing.Pen pen){
			this.funcs.Add(new Function(func,pen));
		}

		/*
		private static double SinDivX(double v){
			return 30*(v==0?1d:System.Math.Sin(v)/v);
		}//*/

		private double originX;
		private double originY;
		private double scaleX;
		private double scaleY;
		private void Form1_Paint(object sender,System.Windows.Forms.PaintEventArgs e) {
			int w=this.Width;
			System.Drawing.Pen pen=System.Drawing.Pens.Black;
			e.Graphics.Clear(System.Drawing.Color.White);
			if(0<=this.originY&&this.originY<=this.Height)
				e.Graphics.DrawLine(System.Drawing.Pens.Blue,0,(float)this.originY,w,(float)this.originY);
			if(0<=this.originX&&this.originX<=this.Width)
				e.Graphics.DrawLine(System.Drawing.Pens.Blue,(float)this.originX,0,(float)this.originX,this.Height);
			System.Drawing.PointF[] points=new System.Drawing.PointF[w];
			foreach(Function func in funcs){
				FunctionToPoints(points,func.Calculate);
				e.Graphics.DrawLines(func.pen,points);
			}
		}
		private void FunctionToPoints(System.Drawing.PointF[] points,System.Converter<double,double> func){
			for(int x=0;x<points.Length;x++){
				double y=this.originY-this.scaleX*func((x-this.originX)/this.scaleY);
				if(y<0)y=-1;
				else if(double.IsNaN(y))y=0;
				else if(y>this.Height)y=this.Height+1;
				points[x]=new System.Drawing.PointF(x,(float)y);
			}
		}

		private System.Drawing.Point p_beforeDrag;
		private void Form1_MouseDown(object sender,System.Windows.Forms.MouseEventArgs e) {
			if(e.Button==System.Windows.Forms.MouseButtons.Left){
				p_beforeDrag=e.Location;
				this.Cursor=System.Windows.Forms.Cursors.SizeAll;
				this.Capture=true;
			}
		}

		private void Form1_MouseUp(object sender,System.Windows.Forms.MouseEventArgs e) {
			if(e.Button==System.Windows.Forms.MouseButtons.Left){
				this.Cursor=System.Windows.Forms.Cursors.Default;
				this.Capture=false;
				this.originX+=e.X-p_beforeDrag.X;
				this.originY+=e.Y-p_beforeDrag.Y;
				this.Refresh();
			}
		}

		private const int DELTA_UNIT=120;
		private void Form1_MouseWheel(object sender,System.Windows.Forms.MouseEventArgs e){
			int d=e.Delta/DELTA_UNIT;
			if(d==1){
				this.scaleX*=1.1;
				this.scaleY*=1.1;
				this.originX+=(this.originX-e.X)*0.1;
				this.originY+=(this.originY-e.Y)*0.1;
			}else if(d==-1){
				this.scaleX*=1/1.1;
				this.scaleY*=1/1.1;
				this.originX+=(this.originX-e.X)*(1/1.1-1);
				this.originY+=(this.originY-e.Y)*(1/1.1-1);
			}
			this.Refresh();
		}
	}
	public struct Function{
		public System.Converter<double,double> Calculate;
		public System.Drawing.Pen pen;

		public Function(System.Converter<double,double> func,System.Drawing.Pen pen){
			this.Calculate=func;
			this.pen=pen;
		}
	}
}
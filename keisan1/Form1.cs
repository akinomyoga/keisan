using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace keisan1 {
	public partial class Form1:Form {
		public Form1() {
			InitializeComponent();
		}
		static string css_data;
		static Form1(){
			System.IO.Stream str=typeof(ksh.Rational).Assembly.GetManifestResourceStream("ksh.ksh.css");
			System.IO.StreamReader sr=new System.IO.StreamReader(str);
			css_data=sr.ReadToEnd();
			sr.Close();
			str.Close();
		}
		private void Form1_Load(object sender,EventArgs e) {
			wb.Navigate("about:blank");

			wb.Document.Write("<html><head><title>Blank</title><style>"+css_data+"</style></head><body><button onclick=\"window.location='button:start'\">åvéZäJén</button></body></html>");
		}
		private void WbClear(){
			wb.Document.Body.InnerHtml="";
		}
		private void WbAddLine(string html){
			if(this.InvokeRequired){
				this.Invoke((System.Action<string>)WbAddLine,html);
			}else{
				HtmlElement elem=wb.Document.CreateElement("p");
				elem.InnerHtml=html;
				wb.Document.Body.AppendChild(elem);
			}
		}

		private void Calculate(){
			for(int v=20;v>=0;v--){
				AdamsBashforth.Variable.RegisterVariable("f["+v.ToString()+"]");
			}

			for(int order=1;order<16;order++){
				string str_order=order.ToString();

				AdamsBashforth.AdamsBash ab=new AdamsBashforth.AdamsBash(order);
				WbAddLine("Å° Adams Bashforth "+str_order+@" à åˆéÆÇåvéZíÜ...");

				System.IO.StreamWriter sw=new System.IO.StreamWriter("AdamsBashforth"+str_order+".htm");
				sw.Write(@"<html xmlns:ksh=""http://www.example.com/ksh/"">
<head>
<title>Adams Bashforth "+str_order+@" à åˆéÆ</title>
<style type=""text/css"">
"+css_data+@"
</style>
</head>
<body>
<h1>Adams Bashforth "+str_order+@" à åˆéÆ</h1>
"+ab.Calculate()+@"
</body>
</html>");
				sw.Close();
				WbAddLine("åvéZåãâ  (AdamsBashforth"+str_order+".htm Ç…èëÇ´çûÇ›Ç‹ÇµÇΩ):");
				WbAddLine("&nbsp;&nbsp;&nbsp;&nbsp;"+ab.GetFinalEquationAsHtml());
			
			}
		}

		private void wb_Navigating(object sender,WebBrowserNavigatingEventArgs e){
			if(e.Url.ToString()=="button:start"){
				this.WbClear();
				System.Threading.Thread th=new System.Threading.Thread(Calculate);
				th.IsBackground=true;
				th.Priority=System.Threading.ThreadPriority.BelowNormal;
				th.Start();
				e.Cancel=true;
			}
		}//*/
	}
}
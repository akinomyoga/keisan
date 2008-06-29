using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Graph {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Drill4.No4.Q2_4.main();
			Application.Run(new Form1());
		}
	}
}
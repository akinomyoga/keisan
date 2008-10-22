using Gen=System.Collections.Generic;
using Frms=System.Windows.Forms;

public static class Program {
	[System.STAThread]
	public static void Main() {
		Frms::Application.EnableVisualStyles();
		Frms::Application.SetCompatibleTextRenderingDefault(false);
		//Frms::Application.Run(new keisan1.Form1());

		PhysExp2Micro._.Calc();
		System.Console.ReadLine();
	}
}

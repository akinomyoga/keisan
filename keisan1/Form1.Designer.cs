﻿namespace keisan1 {
	partial class Form1 {
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.wb=new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// wb
			// 
			this.wb.Dock=System.Windows.Forms.DockStyle.Fill;
			this.wb.Location=new System.Drawing.Point(0,0);
			this.wb.MinimumSize=new System.Drawing.Size(20,20);
			this.wb.Name="wb";
			this.wb.Size=new System.Drawing.Size(803,498);
			this.wb.TabIndex=0;
			this.wb.Navigating+=new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
			// 
			// Form1
			// 
			this.AutoScaleDimensions=new System.Drawing.SizeF(6F,12F);
			this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize=new System.Drawing.Size(803,498);
			this.Controls.Add(this.wb);
			this.Name="Form1";
			this.Text="Adams Bashforth 公式";
			this.Load+=new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wb;
	}
}
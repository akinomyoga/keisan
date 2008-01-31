namespace Filename {
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
			this.btnBrowse = new System.Windows.Forms.Button();
			this.chk_SubDir = new System.Windows.Forms.CheckBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.clm_Before = new System.Windows.Forms.ColumnHeader();
			this.clm_After = new System.Windows.Forms.ColumnHeader();
			this.btnRename = new System.Windows.Forms.Button();
			this.Page1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_Dir = new System.Windows.Forms.TextBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.dlg_Folder = new System.Windows.Forms.FolderBrowserDialog();
			this.Page2 = new System.Windows.Forms.Panel();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.Page1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Page2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(340,38);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75,23);
			this.btnBrowse.TabIndex = 0;
			this.btnBrowse.Text = "参照...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// chk_SubDir
			// 
			this.chk_SubDir.AutoSize = true;
			this.chk_SubDir.Location = new System.Drawing.Point(190,65);
			this.chk_SubDir.Name = "chk_SubDir";
			this.chk_SubDir.Size = new System.Drawing.Size(144,16);
			this.chk_SubDir.TabIndex = 1;
			this.chk_SubDir.Text = "サブディレクトリも検索する";
			this.chk_SubDir.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_Before,
            this.clm_After});
			this.listView1.Location = new System.Drawing.Point(3,3);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(451,148);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// clm_Before
			// 
			this.clm_Before.Text = "変換前";
			this.clm_Before.Width = 212;
			// 
			// clm_After
			// 
			this.clm_After.Text = "変換後";
			this.clm_After.Width = 228;
			// 
			// btnRename
			// 
			this.btnRename.Location = new System.Drawing.Point(367,157);
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(87,23);
			this.btnRename.TabIndex = 3;
			this.btnRename.Text = "変換";
			this.btnRename.UseVisualStyleBackColor = true;
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// Page1
			// 
			this.Page1.Controls.Add(this.groupBox2);
			this.Page1.Controls.Add(this.groupBox1);
			this.Page1.Controls.Add(this.btnNext);
			this.Page1.Location = new System.Drawing.Point(5,2);
			this.Page1.Name = "Page1";
			this.Page1.Size = new System.Drawing.Size(457,199);
			this.Page1.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Location = new System.Drawing.Point(5,97);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(442,62);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "本来の文字コード";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(8,18);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(407,20);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txt_Dir);
			this.groupBox1.Controls.Add(this.btnBrowse);
			this.groupBox1.Controls.Add(this.chk_SubDir);
			this.groupBox1.Location = new System.Drawing.Point(5,3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(442,88);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ファイルの在処";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6,15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(414,13);
			this.label1.TabIndex = 3;
			this.label1.Text = "名前の文字化けを修正したいファイルが存在しているディレクトリを指定して下さい";
			// 
			// txt_Dir
			// 
			this.txt_Dir.Location = new System.Drawing.Point(8,40);
			this.txt_Dir.Name = "txt_Dir";
			this.txt_Dir.Size = new System.Drawing.Size(326,19);
			this.txt_Dir.TabIndex = 2;
			this.txt_Dir.TextChanged += new System.EventHandler(this.txt_Dir_TextChanged);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(363,165);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(84,23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "次へ";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// dlg_Folder
			// 
			this.dlg_Folder.ShowNewFolderButton = false;
			// 
			// Page2
			// 
			this.Page2.Controls.Add(this.btnSelectAll);
			this.Page2.Controls.Add(this.listView1);
			this.Page2.Controls.Add(this.btnRename);
			this.Page2.Location = new System.Drawing.Point(5,207);
			this.Page2.Name = "Page2";
			this.Page2.Size = new System.Drawing.Size(457,183);
			this.Page2.TabIndex = 5;
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Location = new System.Drawing.Point(3,157);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(75,23);
			this.btnSelectAll.TabIndex = 4;
			this.btnSelectAll.Text = "全選択";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F,12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466,447);
			this.Controls.Add(this.Page2);
			this.Controls.Add(this.Page1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "ファイル名文字化け";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Page1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.Page2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnBrowse;
		[afh.Configuration.RestoreProperties("Checked")]
		private System.Windows.Forms.CheckBox chk_SubDir;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader clm_Before;
		private System.Windows.Forms.ColumnHeader clm_After;
		private System.Windows.Forms.Button btnRename;
		private System.Windows.Forms.Panel Page1;
		[afh.Configuration.RestoreProperties("Text")]
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label1;
		[afh.Configuration.RestoreProperties("Text")]
		private System.Windows.Forms.TextBox txt_Dir;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FolderBrowserDialog dlg_Folder;
		private System.Windows.Forms.Panel Page2;
		private System.Windows.Forms.Button btnSelectAll;

	}
}


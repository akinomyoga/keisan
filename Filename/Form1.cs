using Gen=System.Collections.Generic;

namespace Filename {
	[afh.Configuration.RestoreProperties]
	public partial class Form1:System.Windows.Forms.Form {
		public Form1(){
			this.InitializeComponent();
			EncInfo[] infos=System.Array.ConvertAll<System.Text.EncodingInfo,EncInfo>(System.Text.Encoding.GetEncodings(),EncInfo.convert);
			System.Array.Sort<EncInfo>(infos,EncInfo.compare);
			this.comboBox1.Items.AddRange(infos);
			this.comboBox1.Text=System.Text.Encoding.Default.EncodingName;

			UpdateNextButtonEnabled();
			afh.Configuration.RestorePropertiesAttribute.Restore(this);
		}

		private void btnBrowse_Click(object sender,System.EventArgs e) {
			// 初期フォルダの設定
			if(System.IO.Directory.Exists(this.txt_Dir.Text)&&this.txt_Dir.Text!=this.dlg_Folder.SelectedPath)
				this.dlg_Folder.SelectedPath=this.txt_Dir.Text;

			if(this.dlg_Folder.ShowDialog()!=System.Windows.Forms.DialogResult.OK)return;
			this.txt_Dir.Text=this.dlg_Folder.SelectedPath;
		}
		//=================================================
		//		[次へ] button の有効性
		//=================================================
		private void UpdateNextButtonEnabled(){
			this.btnNext.Enabled=System.IO.Directory.Exists(this.txt_Dir.Text)&&this.comboBox1.SelectedIndex>=0;
		}
		private void txt_Dir_TextChanged(object sender,System.EventArgs e){
			UpdateNextButtonEnabled();
		}
		private void comboBox1_SelectedIndexChanged(object sender,System.EventArgs e){
			UpdateNextButtonEnabled();
		}
		//=================================================
		//		[次へ]
		//=================================================
		Gen::List<RenameItem> candidates;
		System.Text.Encoding encoding;
		private void btnNext_Click(object sender,System.EventArgs e){
			if(!System.IO.Directory.Exists(this.txt_Dir.Text)){
				System.Windows.Forms.MessageBox.Show("指定したディレクトリは有効なディレクトリではありません。");
				return;
			}
			
			EncInfo info=this.comboBox1.SelectedItem as EncInfo;
			if(info==null){
				System.Windows.Forms.MessageBox.Show("文字コードが正しく選択されていません。");
				return;
			}
			this.encoding=info.GetEncoding();

			this.listView1.Items.Clear();
			this.candidates=new Gen::List<RenameItem>();
			search_dir(new System.IO.DirectoryInfo(this.txt_Dir.Text));
			this.listView1.Items.AddRange(this.candidates.ToArray());
		}
		private void search_dir(System.IO.DirectoryInfo dir){
			foreach(System.IO.FileInfo f in dir.GetFiles()){
				string before=f.Name;
				string after=encoding.GetString(System.Text.Encoding.Default.GetBytes(before));
				if(before==after)continue;
				this.candidates.Add(new RenameItem(dir.FullName,before,after));
			}
			foreach(System.IO.DirectoryInfo d in dir.GetDirectories()){
				// 1. サブディレクトリ検索
				if(this.chk_SubDir.Checked)search_dir(d);

				// 2. ディレクトリ自体の名前の変更
				string before=d.Name;
				string after=encoding.GetString(System.Text.Encoding.Default.GetBytes(before));
				if(before==after)continue;
				this.candidates.Add(new RenameItem(dir.FullName,before,after));
			}
		}
		//=================================================
		//		[変換]
		//=================================================
		private void btnSelectAll_Click(object sender,System.EventArgs e) {
			foreach(RenameItem item in this.candidates){
				item.Checked=true;
			}
		}
		private void btnRename_Click(object sender,System.EventArgs e) {
			foreach(RenameItem item in this.candidates) {
				if(item.Checked)item.ExecuteRename();
			}
		}
		private void Form1_FormClosing(object sender,System.Windows.Forms.FormClosingEventArgs e) {
			afh.Configuration.RestorePropertiesAttribute.Save(this);
		}
	}
	public class RenameItem:System.Windows.Forms.ListViewItem{
		private string b_path;
		private string a_path;
		public RenameItem(string dir,string before,string after):base(new string[]{before,after}){
			this.b_path=System.IO.Path.Combine(dir,before);
			this.a_path=System.IO.Path.Combine(dir,afh.Application.Path.GetValidFileName(after));
		}
		public void ExecuteRename(){
			if(System.IO.File.Exists(this.b_path)){
				string a_path2=afh.Application.Path.GetAvailablePath(this.a_path);
				System.IO.File.Move(this.b_path,a_path2);
			}else if(System.IO.Directory.Exists(this.b_path)){
				try{
					System.IO.Directory.Move(this.b_path,afh.Application.Path.GetAvailablePath(this.a_path));
				}catch(System.IO.IOException){
					System.Windows.Forms.MessageBox.Show("指定したファイル '"+this.b_path+"' の名前を変更出来ません。\r\n使用中でないか確認して下さい。");
				}
			}else throw new System.ApplicationException("指定した名前のファイル又はディレクトリは見つかりません。");
		}
	}
	public class EncInfo{
		System.Text.EncodingInfo info;
		public EncInfo(System.Text.EncodingInfo info){
			this.info=info;
		}

		public override string ToString(){
			return this.info.DisplayName;
		}

		public System.Text.Encoding GetEncoding(){
			return this.info.GetEncoding();
		}

		internal static EncInfo convert(System.Text.EncodingInfo info){
			return new EncInfo(info);
		}
		internal static int compare(EncInfo e1,EncInfo e2){
			return e1.ToString().CompareTo(e2.ToString());
		}
	}
}
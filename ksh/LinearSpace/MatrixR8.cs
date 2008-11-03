using Rational=ksh.Rational;
using Serial=System.Runtime.Serialization;
using Compiler=System.Runtime.CompilerServices;

namespace ksh.LinearSpace{

	#region class:Matrix
	/// <summary>
	/// ksh.Rational (8 byte 有理数) を各要素とする行列を表現します。
	/// </summary>
	[System.Serializable]
	public class MatrixR8:System.ICloneable,Serial::ISerializable{
		private readonly int height;
		private readonly int width;
		private readonly Rational[,] vals;

		public MatrixR8(Rational[,] data){
			this.vals=data;
			this.height=data.GetLength(0);
			this.width=data.GetLength(1);
			this.lines=new LineCollection(this);
		}
		public MatrixR8(int height,int width){
			this.vals=new Rational[height,width];
			this.height=height;
			this.width=width;
			this.lines=new LineCollection(this);
		}

		#region ISerializable メンバ
		MatrixR8(Serial::SerializationInfo info,Serial::StreamingContext context)
			:this((Rational[,])info.GetValue("vals",typeof(Rational[,]))){}
		void Serial::ISerializable.GetObjectData(Serial::SerializationInfo info,Serial::StreamingContext context){
			info.AddValue("vals",this.vals);
		}
		#endregion

		public static MatrixR8 Identical(int dim){
			MatrixR8 m=new MatrixR8(dim,dim);
			for(int i=0;i<dim;i++) m.vals[i,i]=Rational.One;
			return m;
		}
		//===========================================================
		//		データ
		//===========================================================
		/// <summary>
		/// この行列の行の数を取得します。
		/// </summary>
		public int Height{
			get{return this.height;}
		}
		/// <summary>
		/// この行列の列の数を取得します。
		/// </summary>
		public int Width{
			get{return this.width;}
		}
		/// <summary>
		/// この行列の指定した要素を取得します。
		/// </summary>
		/// <param name="line">取得したい要素の 0 から始まる行番号を指定します。</param>
		/// <param name="column">取得したい要素の 0 から始まる列番号を指定します。</param>
		/// <returns>指定した行と列に位置している要素の値を返します。</returns>
		public Rational this[int line,int column]{
			get{return this.vals[line,column];}
			set{this.vals[line,column]=value;}
		}
		//===========================================================
		//		単位化
		//===========================================================
		/// <summary>
		/// この行列の Rank を計算します。
		/// </summary>
		/// <returns>計算した rank を返します。</returns>
		public int Rank(){
			return this.Clone()._Identicalize();
		}
		/// <summary>
		/// 行基本変形による頭の単位化を実行します。
		/// </summary>
		/// <returns>
		/// 最後まで単位化出来た場合に true を返します。
		/// それ以外の場合に false を返します。
		/// </returns>
		public bool Identicalize(){
			return _Identicalize()==System.Math.Min(height,width);
		}
		/// <summary>
		/// 行基本変形による頭の単位化を実行します。
		/// </summary>
		/// <returns>Rank を返します。</returns>
		internal int _Identicalize(){
			int cmin=System.Math.Min(height,width);
			bool[] sweeped=new bool[this.height];

			for(int c=0;c<cmin;c++){

				// 列 c で最大の絶対値を持つ物 l_m
				Rational max=-1;
				int l_m=-1;
				for(int l=0;l<height;l++){
					Rational cand=Rational.Abs(vals[l,c]);
					if(!sweeped[l]&&Rational.Abs(vals[l,c])>max){
						max=cand;
						l_m=l;
					}
				}

				if(vals[l_m,c].IsZero)return c;

				// pivot[l_m,c] で掃き出し
				if(vals[l_m,c]!=Rational.One)
					lines.Divide(l_m,this.vals[l_m,c]);

				for(int l=0;l<height;l++){
					if(l==l_m||vals[l,c].IsZero)continue;
					lines.SubtractLine(l,l_m,vals[l,c]);
				}

				sweeped[l_m]=true;
			}

			// 並び替え
			for(int c=0;c<height;c++){
				for(int l=c;l<height;l++){
					if(vals[l,c]==Rational.One){
						lines.ExchangeLines(l,c);
						break;
					}
				}
			}

			return cmin;
		}
		//===========================================================
		//		連結・部分行列
		//===========================================================
		public static MatrixR8 Connect(MatrixR8 m1,MatrixR8 m2){
			if(m1.height!=m2.height)
				throw new System.ArgumentException("異なる行数の行列を連結する事は出来ません。");
			MatrixR8 m=new MatrixR8(m1.height,m1.width+m2.width);
			for(int l=0;l<m1.height;l++){
				int c=0;
				int c1=0;
				while(c1<m1.width)m.vals[l,c++]=m1.vals[l,c1++];
				c1=0;
				while(c1<m2.width)m.vals[l,c++]=m2.vals[l,c1++];
			}
			return m;
		}
		public static MatrixR8 operator|(MatrixR8 m1,MatrixR8 m2){
			return Connect(m1,m2);
		}
		/// <summary>
		/// 部分行列を取得又は設定します。
		/// 取得する場合には、指定した範囲の要素をコピーして得られた Matrix インスタンスを返します。
		/// 設定する場合には、代入した行列の内容を、当行列の指定した範囲に書き込みます。
		/// </summary>
		/// <param name="st_line">部分行列の、当行列内に於ける開始位置を指定します。</param>
		/// <param name="st_column">部分行列の、当行列内に於ける開始列を指定します。</param>
		/// <param name="width">部分行列の幅を指定します。</param>
		/// <param name="height">部分行列の高さを指定します。</param>
		/// <returns>生成した部分行列を返します。</returns>
		public MatrixR8 this[int st_line,int st_column,int width,int height]{
			get{
				if(height<0)height=this.height-st_line;
				if(width<0)width=this.width-st_column;
				return this.SubMatrix(st_line,st_column,width,height);
			}
			set{
				if(height<0)height=this.height-st_line;
				if(width<0)width=this.width-st_column;
				this.checkContainsRect(st_line,st_column,width,height);

				if(height>value.height)height=value.height;
				if(width>value.width)width=value.width;

				for(int l=0;l<height;l++)for(int c=0;c<width;c++){
					this.vals[st_line++,st_column++]=value.vals[l,c];
				}
			}
		}
		public MatrixR8 SubMatrix(int st_line,int st_column){
			return this.SubMatrix(st_line,st_column,this.height-st_line,this.width-st_column);
		}
		public MatrixR8 SubMatrix(int st_line,int st_column,int width,int height){
			this.checkContainsRect(st_line,st_column,height,width);

			MatrixR8 m=new MatrixR8(width,height);
			for(int l=0;l<width;l++)for(int c=0;c<height;c++){
				m.vals[l,c]=this.vals[st_line++,st_column++];
			}
			return m;
		}
		private void checkContainsRect(int st_line,int st_column,int width,int height){
			if(st_line<0||this.height<=st_line)
				throw new System.ArgumentOutOfRangeException("st_line");
			if(st_column<0||this.width<=st_column)
				throw new System.ArgumentOutOfRangeException("st_column");

			width+=st_line;
			height+=st_column;
			if(height<=st_line||this.height<height)
				throw new System.ArgumentOutOfRangeException("width");
			if(width<=st_line||this.width<width)
				throw new System.ArgumentOutOfRangeException("height");
		}
		//===========================================================
		//		複製
		//===========================================================
		/// <summary>
		/// Matrix のコピーコンストラクタです。
		/// </summary>
		/// <param name="matrix">複製元の Matrix を指定します。</param>
		public MatrixR8(MatrixR8 matrix){
			this.vals=new Rational[
				this.height=matrix.height,
				this.width=matrix.width
				];

			for(int l=0;l<this.height;l++)for(int c=0;c<this.width;c++)
					this.vals[l,c]=matrix.vals[l,c];
		}
		public MatrixR8 Clone(){
			return new MatrixR8(this);
		}
		object System.ICloneable.Clone(){
			return new MatrixR8(this);
		}
		//===========================================================
		//		表示
		//===========================================================
		public string ToHtml(){
			System.Text.StringBuilder build=new System.Text.StringBuilder();
			build.Append("<table style='display:inline;vertical-align:middle;'>\r\n");
			build.AppendFormat(@"<colgroup>
	<col style='padding:0;width:3px;font-size:1px;'/>
	<col style='text-align:center;white-space:nowrap;padding-left:.5ex;padding-right:.5ex' span='{0}'/>
	<col style='padding:0;width:3px;font-size:1px;'/>
</colgroup>
",this.width);
			for(int l=0;l<this.height;l++){
				build.Append("<tr>");
				if(l==0)
					build.AppendFormat("\r\n<td style='border:1px solid black;border-right-width:0;' rowspan='{0}'>&nbsp;</td>\r\n",this.height);
				for(int c=0;c<this.width;c++){
					build.Append("<td>");
					build.Append(this.vals[l,c].ToHtml());
					build.Append("</td>");
				}
				if(l==0)
					build.AppendFormat("\r\n<td style='border:1px solid black;border-left-width:0;' rowspan='{0}'>&nbsp;</td>\r\n",this.height);
				build.Append("</tr>\r\n");
			}
			build.Append("</table>\r\n");
			return build.ToString();
		}
		public string ToHtml(bool ksh_style){
			if(!ksh_style)return this.ToHtml();

			System.Text.StringBuilder build=new System.Text.StringBuilder();
			build.Append("<table class='ksh-matrix'>\r\n");
			build.AppendFormat(@"<colgroup>
	<col style='padding:0;width:3px;font-size:1px;'/>
	<col style='text-align:center;white-space:nowrap;padding-left:.5ex;padding-right:.5ex' span='{0}'/>
	<col style='padding:0;width:3px;font-size:1px;'/>
</colgroup>
",this.width);
			for(int l=0;l<this.height;l++){
				build.Append("<tr>");
				if(l==0)
					build.AppendFormat("\r\n<td class='ksh-matrix-left' rowspan='{0}'>&nbsp;</td>\r\n",this.height);
				for(int c=0;c<this.width;c++){
					build.Append("<td>");
					build.Append(this.vals[l,c].ToHtml(ksh_style));
					build.Append("</td>");
				}
				if(l==0)
					build.AppendFormat("\r\n<td class='ksh-matrix-right' rowspan='{0}'>&nbsp;</td>\r\n",this.height);
				build.Append("</tr>\r\n");
			}
			build.Append("</table>\r\n");
			return build.ToString();
		}
		//===========================================================
		//		行
		//===========================================================
		LineCollection lines;
		public LineCollection Lines{
			get{return lines;}
		}

		public class LineCollection{
			readonly MatrixR8 parent;

			internal LineCollection(MatrixR8 parent){
				this.parent=parent;
			}
			/// <summary>
			/// 行の数を取得します。
			/// </summary>
			public int Count{
				get{return this.parent.height;}
			}
			//=======================================================
			//		行演算達
			//=======================================================
			public void Multiply(int line,Rational value){
				if(line<0||parent.height<=line)
					throw new System.ArgumentOutOfRangeException("line","行番号が正しくありません。");
				for(int column=0;column<parent.width;column++)
					parent.vals[line,column]*=value;
			}
			public void Divide(int line,Rational value) {
				if(line<0||parent.height<=line)
					throw new System.ArgumentOutOfRangeException("line","行番号が正しくありません。");
				for(int column=0;column<parent.width;column++)
					parent.vals[line,column]/=value;
			}
			/// <summary>
			/// <paramref name="line1"/> に <paramref name="r"/> * <paramref name="line2"/>
			/// を足した結果を <paramref name="line1"/> に格納します。
			/// </summary>
			/// <param name="line1">足される側の行を指定します。</param>
			/// <param name="line2">足す側の行を指定します。</param>
			/// <param name="factor">line2 に掛ける倍率を指定します。</param>
			public void AddLine(int line1,int line2,Rational factor) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","行番号が正しくありません。");

				for(int column=0;column<parent.width;column++) {
					parent.vals[line1,column]-=factor*parent.vals[line2,column];
				}
			}
			/// <summary>
			/// <paramref name="line1"/> から <paramref name="r"/> * <paramref name="line2"/>
			/// を引いた結果を <paramref name="line1"/> に格納します。
			/// </summary>
			/// <param name="line1">引かれる側の行を指定します。</param>
			/// <param name="line2">引く側の行を指定します。</param>
			/// <param name="factor">line2 に掛ける倍率を指定します。</param>
			public void SubtractLine(int line1,int line2,Rational factor) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","行番号が正しくありません。");
				for(int column=0;column<parent.width;column++) {
					parent.vals[line1,column]-=factor*parent.vals[line2,column];
				}
			}
			/// <summary>
			/// 指定した行の内容を交換します。
			/// </summary>
			/// <param name="line1">交換する行の一方を指定します。</param>
			/// <param name="line2">交換する行の他方を指定します。</param>
			public void ExchangeLines(int line1,int line2) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","行番号が正しくありません。");
				if(line1==line2) return;
				for(int column=0;column<parent.width;column++) {
					Rational c=parent.vals[line1,column];
					parent.vals[line1,column]=parent.vals[line2,column];
					parent.vals[line2,column]=c;
				}
			}
		}
	}
	#endregion
}
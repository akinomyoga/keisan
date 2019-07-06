using Rational=ksh.Rational;
using Serial=System.Runtime.Serialization;
using Compiler=System.Runtime.CompilerServices;

namespace ksh.LinearSpace{

	#region class:Matrix
	/// <summary>
	/// ksh.Rational (8 byte �L����) ���e�v�f�Ƃ���s���\�����܂��B
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

		#region ISerializable �����o
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
		//		�f�[�^
		//===========================================================
		/// <summary>
		/// ���̍s��̍s�̐����擾���܂��B
		/// </summary>
		public int Height{
			get{return this.height;}
		}
		/// <summary>
		/// ���̍s��̗�̐����擾���܂��B
		/// </summary>
		public int Width{
			get{return this.width;}
		}
		/// <summary>
		/// ���̍s��̎w�肵���v�f���擾���܂��B
		/// </summary>
		/// <param name="line">�擾�������v�f�� 0 ����n�܂�s�ԍ����w�肵�܂��B</param>
		/// <param name="column">�擾�������v�f�� 0 ����n�܂��ԍ����w�肵�܂��B</param>
		/// <returns>�w�肵���s�Ɨ�Ɉʒu���Ă���v�f�̒l��Ԃ��܂��B</returns>
		public Rational this[int line,int column]{
			get{return this.vals[line,column];}
			set{this.vals[line,column]=value;}
		}
		//===========================================================
		//		�P�ʉ�
		//===========================================================
		/// <summary>
		/// ���̍s��� Rank ���v�Z���܂��B
		/// </summary>
		/// <returns>�v�Z���� rank ��Ԃ��܂��B</returns>
		public int Rank(){
			return this.Clone()._Identicalize();
		}
		/// <summary>
		/// �s��{�ό`�ɂ�铪�̒P�ʉ������s���܂��B
		/// </summary>
		/// <returns>
		/// �Ō�܂ŒP�ʉ��o�����ꍇ�� true ��Ԃ��܂��B
		/// ����ȊO�̏ꍇ�� false ��Ԃ��܂��B
		/// </returns>
		public bool Identicalize(){
			return _Identicalize()==System.Math.Min(height,width);
		}
		/// <summary>
		/// �s��{�ό`�ɂ�铪�̒P�ʉ������s���܂��B
		/// </summary>
		/// <returns>Rank ��Ԃ��܂��B</returns>
		internal int _Identicalize(){
			int cmin=System.Math.Min(height,width);
			bool[] sweeped=new bool[this.height];

			for(int c=0;c<cmin;c++){

				// �� c �ōő�̐�Βl������ l_m
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

				// pivot[l_m,c] �ő|���o��
				if(vals[l_m,c]!=Rational.One)
					lines.Divide(l_m,this.vals[l_m,c]);

				for(int l=0;l<height;l++){
					if(l==l_m||vals[l,c].IsZero)continue;
					lines.SubtractLine(l,l_m,vals[l,c]);
				}

				sweeped[l_m]=true;
			}

			// ���ёւ�
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
		//		�A���E�����s��
		//===========================================================
		public static MatrixR8 Connect(MatrixR8 m1,MatrixR8 m2){
			if(m1.height!=m2.height)
				throw new System.ArgumentException("�قȂ�s���̍s���A�����鎖�͏o���܂���B");
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
		/// �����s����擾���͐ݒ肵�܂��B
		/// �擾����ꍇ�ɂ́A�w�肵���͈̗͂v�f���R�s�[���ē���ꂽ Matrix �C���X�^���X��Ԃ��܂��B
		/// �ݒ肷��ꍇ�ɂ́A��������s��̓��e���A���s��̎w�肵���͈͂ɏ������݂܂��B
		/// </summary>
		/// <param name="st_line">�����s��́A���s����ɉ�����J�n�ʒu���w�肵�܂��B</param>
		/// <param name="st_column">�����s��́A���s����ɉ�����J�n����w�肵�܂��B</param>
		/// <param name="width">�����s��̕����w�肵�܂��B</param>
		/// <param name="height">�����s��̍������w�肵�܂��B</param>
		/// <returns>�������������s���Ԃ��܂��B</returns>
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
		//		����
		//===========================================================
		/// <summary>
		/// Matrix �̃R�s�[�R���X�g���N�^�ł��B
		/// </summary>
		/// <param name="matrix">�������� Matrix ���w�肵�܂��B</param>
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
		//		�\��
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
		//		�s
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
			/// �s�̐����擾���܂��B
			/// </summary>
			public int Count{
				get{return this.parent.height;}
			}
			//=======================================================
			//		�s���Z�B
			//=======================================================
			public void Multiply(int line,Rational value){
				if(line<0||parent.height<=line)
					throw new System.ArgumentOutOfRangeException("line","�s�ԍ�������������܂���B");
				for(int column=0;column<parent.width;column++)
					parent.vals[line,column]*=value;
			}
			public void Divide(int line,Rational value) {
				if(line<0||parent.height<=line)
					throw new System.ArgumentOutOfRangeException("line","�s�ԍ�������������܂���B");
				for(int column=0;column<parent.width;column++)
					parent.vals[line,column]/=value;
			}
			/// <summary>
			/// <paramref name="line1"/> �� <paramref name="r"/> * <paramref name="line2"/>
			/// �𑫂������ʂ� <paramref name="line1"/> �Ɋi�[���܂��B
			/// </summary>
			/// <param name="line1">������鑤�̍s���w�肵�܂��B</param>
			/// <param name="line2">�������̍s���w�肵�܂��B</param>
			/// <param name="factor">line2 �Ɋ|����{�����w�肵�܂��B</param>
			public void AddLine(int line1,int line2,Rational factor) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","�s�ԍ�������������܂���B");

				for(int column=0;column<parent.width;column++) {
					parent.vals[line1,column]-=factor*parent.vals[line2,column];
				}
			}
			/// <summary>
			/// <paramref name="line1"/> ���� <paramref name="r"/> * <paramref name="line2"/>
			/// �����������ʂ� <paramref name="line1"/> �Ɋi�[���܂��B
			/// </summary>
			/// <param name="line1">������鑤�̍s���w�肵�܂��B</param>
			/// <param name="line2">�������̍s���w�肵�܂��B</param>
			/// <param name="factor">line2 �Ɋ|����{�����w�肵�܂��B</param>
			public void SubtractLine(int line1,int line2,Rational factor) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","�s�ԍ�������������܂���B");
				for(int column=0;column<parent.width;column++) {
					parent.vals[line1,column]-=factor*parent.vals[line2,column];
				}
			}
			/// <summary>
			/// �w�肵���s�̓��e���������܂��B
			/// </summary>
			/// <param name="line1">��������s�̈�����w�肵�܂��B</param>
			/// <param name="line2">��������s�̑������w�肵�܂��B</param>
			public void ExchangeLines(int line1,int line2) {
				if(line1<0||parent.height<=line1||line2<0||parent.height<=line2)
					throw new System.ArgumentOutOfRangeException("line1,line2","�s�ԍ�������������܂���B");
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
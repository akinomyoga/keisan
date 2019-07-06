using Rational=ksh.Rational;
using Matrix=ksh.LinearSpace.MatrixR8;
using Frms=System.Windows.Forms;
using Gen=System.Collections.Generic;
using Rgx=System.Text.RegularExpressions;

namespace AdamsBashforth{
	public class AdamsBash{
		public int ORDER;
		public System.Text.StringBuilder build=new System.Text.StringBuilder();

		Expression[] equations;
		string[] varnames;
		public Matrix mat;
		MatrixExp vec;

		public Expression e_f;

		public AdamsBash(int order){
			this.ORDER=order;
			equations=new Expression[ORDER-1];
			varnames=new string[ORDER-1];
		}
		//===========================================================
		//		�X�P�W���[��
		//===========================================================
		public string Calculate(){
			build.AppendFormat("<h2>f<sub>1</sub> �` f<sub>{0}</sub> �� Taylor �W�J</h2>\r\n",ORDER-1);
			build.Append("<p>�悸 Taylor �W�J���l����B</p>\r\n");
			InitializeEquations();
			WriteEquations();

			build.AppendFormat("<h2>h<sup>n</sup>f<sub>0�`{0}</sub><sup>(n)</sup> �̏���</h2>\r\n",ORDER-2);
			build.AppendFormat("<p>���Ɋe�������� h<sup>n</sup>f<sub>0�`{0}</sub> ����������B�܂�A</p>\r\n",ORDER-2);
			UpdatePastDifferentials();
			build.Append("<p>�������āA</p>\r\n");
			WriteEquations();
			build.Append("<p>�ƂȂ�B</p>\r\n");

			build.AppendFormat("<h2>h<sup>n</sup>f<sub>{0}</sub><sup>(n)</sup> �Ɋւ��ĉ���</h2>\r\n",ORDER-1);
			build.Append("<p>��̕��������s��ŕ\������ƁA</p>\r\n");
			ExpressInMatrixForm();
			WriteMatrixEquation();
			build.Append("<p>�ƂȂ�̂ŁA�����ό`���āA</p>\r\n");
			if(!mat.Identicalize()){
				build.Append("<p>...</p>\r\n");
				WriteMatrixEquation();
				build.Append("<p>... �������s�����悤�ł��B���悤�Ȃ�...</p>\r\n");
				goto end;
			}
			WriteMatrixEquation();
			build.Append("<p>�X�Ɍ��ɖ߂��΁A</p>\r\n");
			BackFromMatrixForm();
			WriteEquations2();

			build.AppendFormat("<h2>x<sub>{0}</sub> �� Taylor �W�J�ɑ������B</h2>\r\n",ORDER);
			build.AppendFormat("<p>x<sub>{0}</sub> �� Taylor �W�J�����������ƁA</p>\r\n",ORDER);
			MainEquation();
			WriteEquation3();
			build.AppendFormat("<p>����ɁA������߂� h<sup>n</sup>f<sub>{0}</sub><sup>(n)</sup> ���������</p>\r\n",ORDER-1);
			SubstituteMainEquation();
			WriteEquation3();
			build.Append("<p>�ƂȂ�B</p>\r\n");

		end:
			string ret=build.ToString();
			ret=Rgx::Regex.Replace(ret,"(?<h>hh+)f",delegate(Rgx::Match m){
				return "h<sup>"+m.Groups["h"].Length.ToString()+"</sup>f";
			});
			return ret;
		}

		//===========================================================
		//		�\��
		//===========================================================
		private void WriteEquations(){
			build.Append("<ol>\r\n");
			foreach(Expression x in equations){
				build.Append("<li>");
				build.Append(x.ToHtml(true) +"�� O(h<sup>"+ORDER.ToString()+"</sup>)");
				build.Append("</li>\r\n");
			}
			build.Append("</ol>\r\n");
		}
		private void WriteMatrixEquation(){
			build.Append("<p>");
			build.Append(mat.ToHtml(true));
			build.Append(vec.ToHtml());
			build.Append(" �� O(h<sup>"+ORDER.ToString()+"</sup>)</p>\r\n");
		}
		private void WriteEquations2(){
			build.Append("<ol>\r\n");
			for(int i=0;i<equations.Length;i++){
				build.Append("<li>");
				build.Append(Member.EasyParse(varnames[i]).ToHtml(true));
				build.Append(" �� ");
				build.Append(equations[i].ToHtml(true));
				build.AppendFormat(" �{ O(h<sup>{0}</sup>)",ORDER);
				build.Append("</li>\r\n");
			}
			build.Append("</ol>\r\n");
		}

		private void WriteEquation3(){
			build.AppendFormat("<p>x<sub>{0}</sub> �� x<sub>{1}</sub> �{ h (",ORDER,ORDER-1);
			build.Append(e_f.ToHtml(true));
			build.AppendFormat(") �{ O(h<sup>{0}</sup>)</p>\r\n",ORDER+1);
		}

		public string GetFinalEquationAsHtml(){
			return string.Format("x<sub>{0}</sub> �� x<sub>{1}</sub> �{ h (",ORDER,ORDER-1)
				+e_f.ToHtml(true)
				+string.Format(") �{ O(h<sup>{0}</sup>)",ORDER+1);
		}

		//===========================================================
		//		�v�Z
		//===========================================================
		/// <summary>
		/// ���𐶐����܂��B
		/// </summary>
		private void InitializeEquations(){
			string exp="-f[{0}]+f[{1}]";
			Rational f=1;
			string var="f[{1}]";
			for(int i=1;i<ORDER;i++) {
				f/=i;
				var="h"+var+"'";
				exp+="+"+f.ToString()+" "+var;
			}
			for(int i=ORDER-2;i>=0;i--){
				equations[i]=Expression.EasyParse(string.Format(exp,i+1,i));
			}
		}

		/// <summary>
		/// ���� f[n-1]^(m) �ŕ\�������܂��B
		/// </summary>
		private void UpdatePastDifferentials(){
			build.Append("<ul>\r\n");
			string var="f[{0}]";
			for(int n=1;n<ORDER;n++){
				var="h"+var+"'";

				// ������鎮�̏���������𐶐�
				Rational f2=1;
				string var2=var;
				string exp2=var;
				for(int m=1;m<ORDER-n;m++){
					f2/=-m;
					var2="h"+var2+"'";
					exp2+="+"+f2.ToString()+" "+var2;
				}

				// ����\��
				for(int i=0;i<=ORDER-2;i++){
					string varname=string.Format(var,i);
					Expression x=Expression.EasyParse(string.Format(exp2,i+1));
					for(int j=0;j<equations.Length;j++)
						equations[j]=equations[j].Substitute(varname,x);
					//----------
					build.Append("<li>");
					build.Append(Expression.EasyParse(varname).ToHtml(true));
					build.Append(" �� ");
					build.Append(x.ToHtml(true));
					build.Append(" �{ O(h<sup>"+ORDER.ToString()+"</sup>)</li>\r\n");
				}
			}
			build.Append("</ul>\r\n");
		}
		/// <summary>
		/// �����s��`���ŕ\�����܂��B
		/// </summary>
		private void ExpressInMatrixForm(){
			int height=ORDER-1;
			int width=height+ORDER;
			mat=new Matrix(height,width);
			vec=new MatrixExp(width,1);

			int c;

			string var="f["+(ORDER-1).ToString()+"]";
			for(c=0;c<height;c++){
				Member mem=Member.EasyParse(var="h"+var+"'");
				vec[c,0]=(Expression)mem;
				for(int l=0;l<height;l++){
					mat[l,c]=equations[l].GetFactorOfMember(mem);
				}
			}

			var="f[{0}]";
			int i=0;
			for(;c<width;c++,i++){
				Member mem=Member.EasyParse(string.Format(var,i));
				vec[c,0]=(Expression)mem;
				for(int l=0;l<height;l++)
					mat[l,c]=equations[l].GetFactorOfMember(mem);
			}
		}

		/// <summary>
		/// �s��`���̎������̎��ɖ߂��܂��B
		/// </summary>
		private void BackFromMatrixForm(){
			for(int l=0;l<mat.Height;l++){
				varnames[l]=vec[l,0].ToString();
				equations[l]=new Expression(0);
				for(int c=mat.Height;c<mat.Width;c++) {
					equations[l]+=(Expression)(-mat[l,c]*vec[c,0]);
				}
			}
		}

		/// <summary>
		/// x[n] �̎��𐶐����܂��B
		/// </summary>
		private void MainEquation(){
			Rational f=1;
			string var=string.Format("f[{0}]",ORDER-1);
			string exp=var;
			for(int i=1;i<ORDER;i++) {
				f/=(i+1);
				var="h"+var+"'";
				exp+="+"+f.ToString()+" "+var;
			}
			e_f=Expression.EasyParse(exp);
		}

		/// <summary>
		/// x[n] �̎��ɑ�����܂��B
		/// </summary>
		private void SubstituteMainEquation(){
			for(int l=0;l<mat.Height;l++) {
				e_f=e_f.Substitute(varnames[l],equations[l]);
			}
		}
	}
	public class Calc{
		public static string Calc3(){
			AdamsBash ab=new AdamsBash(14);
			return ab.Calculate();
		}
		public static string Calc2(){
			System.Text.StringBuilder build=new System.Text.StringBuilder();
			Member m1=Member.EasyParse("14/9 a b b c c c");
			Member m2=Member.EasyParse("3/2 a/b/b/b c c");
			build.Append("<p>");
			build.Append(m1.ToHtml(true));
			build.Append("</p>\r\n");
			build.Append("<p>");
			build.Append(m2.ToHtml(true));
			build.Append("</p>\r\n");
			build.Append("<hr/>");

			Expression x=Expression.EasyParse("x x + y - 1");
			build.Append("<p>");
			build.Append(x.ToHtml(true));
			build.Append("</p>\r\n");
			build.Append("<p>");
			build.Append(x.Substitute("x",new Rational(2,5)).ToHtml(true));
			build.Append("</p>\r\n");
			return build.ToString();
		}
		public static string Calc1(){
			Rational hf=new Rational(1,2);
			Matrix m=new Matrix(new ksh.Rational[,]{
				{1,new Rational(1,2),0,-1,1},
				{1,-new Rational(3,2),-1,1,0},
			});

			int cmin=System.Math.Min(m.Height,m.Width);
			bool[] sweeped=new bool[m.Height];
			for(int c=0;c<cmin;c++) {
				// �� c �ōő�̐�Βl������ l_m
				Rational max=-1;int l_m=-1;
				for(int l=0;l<m.Height;l++) {
					Rational cand=Rational.Abs(m[l,c]);
					if(!sweeped[l]&&Rational.Abs(m[l,c])>max) {
						max=cand;
						l_m=l;
					}
				}

				if(m[l_m,c].IsZero)continue;

				if(m[l_m,c]!=Rational.One)
					m.Lines.Divide(l_m,m[l_m,c]);

				for(int l=0;l<m.Height;l++) {
					if(l==l_m||m[l,c].IsZero)continue;
					m.Lines.SubtractLine(l,l_m,m[l,c]);
				}

				sweeped[l_m]=true;
			}
			
			return m.ToHtml();
		}

		public static string InverseMatrix(){
			Matrix m=new Matrix(new ksh.Rational[,]{
				{3,0,2},
				{5,4,6},
				{2,7,-4},
			});
			
			System.Text.StringBuilder build=new System.Text.StringBuilder();
			build.Append("<h1>�t�s��̋��ߕ�</h1>\r\n");
			build.Append("<p>�ȉ��̍s��̋t�s������߂����Ǝv���܂��B</p>\r\n");
			build.Append("<p>"+m.ToHtml()+"</p>\r\n");

			build.Append("<p>�悸�E����P�ʍs����������܂��B</p>\r\n");
			m|=Matrix.Identical(m.Height);
			build.Append("<p>"+m.ToHtml()+"</p>\r\n");

			bool[] sweeped=new bool[m.Height];
			for(int c=0;c<3;c++){
				// �� c �ōő�̐�Βl������ l_m (���ɑ|���o�������͏���)
				Rational max=-1;int l_m=-1;
				for(int l=0;l<m.Height;l++) {
					Rational cand=Rational.Abs(m[l,c]);
					if(!sweeped[l]&&Rational.Abs(m[l,c])>max){
						max=cand;
						l_m=l;
					}
				}

				if(m[l_m,c].IsZero){
					build.Append("<p>����ς艽�������߂��Ȃ����͋C�ł�...</p>");
					break;
				}

				build.AppendFormat("<p>({0},{1}) �����ɒ��ڂ��܂��B���ꂪ 1 �Ɉׂ�l�ɍs�S�̂�����Z���܂��B</p>\r\n",l_m+1,c+1);
				if(m[l_m,c]==Rational.One){
					build.Append("<p>(�Ǝv������A������ 1 �ł���...)</p>\r\n");
				}else{
					m.Lines.Divide(l_m,m[l_m,c]);
					build.Append("<p>"+m.ToHtml()+"</p>\r\n");
				}

				build.AppendFormat("<p>���� ({0},{1}) �������g���đ|���o�������s���܂��B</p>\r\n",l_m+1,c+1);
				bool haki=false;
				for(int l=0;l<m.Height;l++){
					if(l==l_m||m[l,c].IsZero)continue;
					haki=true;
					build.AppendFormat("<p>{0} �s�ڂ��� ({1} �s��)�~{2} ����������܂�</p>\r\n",l+1,l_m+1,m[l,c].ToHtml());
					m.Lines.SubtractLine(l,l_m,m[l,c]);
					build.Append("<p>"+m.ToHtml()+"</p>\r\n");
				}
				if(!haki)
					build.Append("<p>�Ǝv������A������|���o���ꂽ�`�ɂȂ��Ă���̂Ŏ��ɐi�݂܂��B</p>\r\n");

				sweeped[l_m]=true;
			}

			return build.ToString();
		}
	}

	#region class:Expression
	/// <summary>
	/// ��������\������N���X�ł��B
	/// </summary>
	public class Expression{
		Gen::List<Member> mems;
		/// <summary>
		/// Expression �̃R�s�[�R���X�g���N�^�ł��B
		/// </summary>
		/// <param name="x">�R�s�[���� Expression �C���X�^���X���w�肵�܂��B</param>
		public Expression(Expression x){
			this.mems=new Gen::List<Member>(x.mems);
		}
		/// <summary>
		/// �P�Ȃ�L������l�Ɏ��� Expression �����������܂��B
		/// </summary>
		/// <param name="r">Expression �̒l��L�����Ŏw�肵�܂��B</param>
		public Expression(Rational r):this(){
			this.AddMember(new Member(r));
		}
		private Expression(){
			this.mems=new Gen::List<Member>();
		}
		private Expression(Gen::List<Member> mems){
			this.mems=mems;
		}
		public static explicit operator Expression(Member m){
			Expression ret=new Expression();
			ret.AddMember(m);
			return ret;
		}
		public static implicit operator Expression(Rational r){
			return new Expression(r);
		}
		/// <summary>
		/// �w�肵�� member �Ɠ��������W���������̌W�����擾���܂��B
		/// </summary>
		/// <param name="member">�擾���������̈����W�����w�肵�܂��B</param>
		/// <returns>�w�肵���������������ꍇ�ɂ͂��̌W����Ԃ��܂��B
		/// ����ȊO�̏ꍇ�ɂ� false ��Ԃ��܂��B</returns>
		public Rational GetFactorOfMember(Member member){
			int index=this.mems.BinarySearch(member,Member.MemberOrderComparer);
			return index<0?(Rational)0:mems[index].Factor;
		}
		//===========================================================
		//		���
		//===========================================================
		/// <summary>
		/// �w�肵���ϐ��Ɏw�肵�����������������v�Z���܂��B
		/// </summary>
		/// <param name="varname">�����̕ϐ������w�肵�܂��B</param>
		/// <param name="x">������鎮���w�肵�܂��B</param>
		public Expression Substitute(string varname,Expression x){
			if(!Variable.IsRegistered(varname)){
				return this;
			}

			Variable v=new Variable(varname);
			Expression ret=new Expression();
			foreach(Member m in this.mems){
				Expression result=m.Substitute(v,x);
				if(result==null){
					ret.AddMember(m);
				}else{
					ret+=result;
				}
			}

			return ret;
		}
		//===========================================================
		//		�\���E�ǂݎ��
		//===========================================================
		public override string ToString() {
			if(mems.Count==0)return "0";

			System.Text.StringBuilder build=new System.Text.StringBuilder();

			bool first=true;
			foreach(Member m in this.mems){
				string memstr=m.ToString();
				if(!first){
					char c=memstr[0];
					if(c!='-'&&c!='+')build.Append('+');
				}else first=false;
				
				build.Append(memstr);
			}

			return build.ToString();
		}
		public string ToHtml(bool ksh_style){
			if(mems.Count==0)return "0";

			System.Text.StringBuilder build=new System.Text.StringBuilder();

			bool first=true;
			foreach(Member m in this.mems){
				string memstr=m.ToHtml(ksh_style);
				
				char c=memstr[0];
				if(c=='-'){
					build.Append('�|');
					memstr=memstr.Substring(1);
				}else if(c=='+'){
					build.Append('�{');
					memstr=memstr.Substring(1);
				}else if(!first&&c!='�|'&&c!='�{'){
					build.Append('�{');
				}
				build.Append(memstr);

				first=false;
			}

			return build.ToString();
		}
		public static Expression EasyParse(string str) {
			Expression x=new Expression();

			int sign=1;
			int i=0;
			int start=i;
			string w;
			Gen::Dictionary<string,int> dic=new Gen::Dictionary<string,int>();
			while(i<str.Length){
				char c=str[i];

				if(c=='+'||c=='-'){
					w=str.Substring(start,i-start).Trim();
					if(w!=""){
						Member m=Member.EasyParse(w);
						x.AddMember(sign==1?m:-m);
						sign=1;
					}

					if(c=='-')sign=-sign;
					start=i+1;
				}

				i++;
			}

			w=str.Substring(start,i-start).Trim();
			if(w!=""){
				Member m=Member.EasyParse(w);
				x.AddMember(sign==1?m:-m);
				sign=1;
			}

			return x;
		}
		internal void AddMember(Member member){
			if(member.IsZero)return;

			int m=0;int s=mems.Count; // [m,s) �͈̔͂�񕪒T��
			while(m<s){
				int c=(s+m)/2;
				int cmp=Member.MemberOrder(member,mems[c]);
				if(cmp==0){
					mems[c]+=member; // ���������W��������
					return;
				}else if(cmp<0){
					s=c;
				}else{
					m=c+1;
				}
			}

			// mems[m]<member<mems[s]
			mems.Insert(s,member);
			return;
		}
		//===========================================================
		//		�ݏ�
		//===========================================================
		public static Expression Pow(Expression x,int power){
			if(power<0)throw new System.ArgumentException("�w���� 0 �ȏ�łȂ���Έׂ�܂���B","power");

			Expression ret=new Expression(1);

			while(true){
				if((power&1)==1)ret*=x;
				if((power>>=1)==0)return ret;
				x*=x;
			}
		}
		//===========================================================
		//		������
		//===========================================================
		public static Expression operator+(Expression l,Expression r) {
			Gen::List<Member> mems=new Gen::List<Member>();
			int il=0,ilM=l.mems.Count;
			int ir=0,irM=r.mems.Count;
			while(il<ilM&&ir<irM){
				int val=Member.MemberOrder(l.mems[il],r.mems[ir]);
				if(val<0){
					mems.Add(l.mems[il++]);
				}else if(val>0){
					mems.Add(r.mems[ir++]);
				}else{
					Member m=l.mems[il++]+r.mems[ir++];
					if(!m.IsZero)mems.Add(m);
				}
			}

			if(il<ilM){
				do mems.Add(l.mems[il++]);while(il<ilM);
			}else if(ir<irM){
				do mems.Add(r.mems[ir++]);while(ir<irM);
			}

			return new Expression(mems);
		}
		public static Expression operator-(Expression l,Expression r){
			Gen::List<Member> mems=new Gen::List<Member>();
			int il=0,ilM=l.mems.Count;
			int ir=0,irM=r.mems.Count;
			while(il<ilM&&ir<irM){
				int val=Member.MemberOrder(l.mems[il],r.mems[ir]);
				if(val<0){
					mems.Add(l.mems[il++]);
				}else if(val>0){
					mems.Add(-r.mems[ir++]);
				}else{
					Member m=l.mems[il++]-r.mems[ir++];
					if(!m.IsZero)mems.Add(m);
				}
			}

			if(il<ilM){
				do mems.Add(l.mems[il++]);while(il<ilM);
			}else if(ir<irM){
				do mems.Add(-r.mems[ir++]);while(ir<irM);
			}

			return new Expression(mems);
		}
		public static Expression operator*(Member m,Expression x){
			Gen::List<Member> list=new Gen::List<Member>();
			foreach(Member m1 in x.mems){
				list.Add(m*m1);
			}
			list.Sort(Member.MemberOrderComparer);
			return new Expression(list);
		}
		public static Expression operator*(Expression x1,Expression x2){
			Expression x=null;
			foreach(Member m1 in x1.mems){
				if(x==null)
					x=m1*x2;
				else
					x+=m1*x2;
			}
			return x??new Expression();
		}
	}
	#endregion

	#region struct:Member
#warning Rational �� NaN �Ɉׂ������ɂ��Ή�����
	public struct Member{
		readonly Rational factor;
		/// <summary>
		/// ���̍��Ɋ܂܂������ϐ���ێ����܂��B
		/// �e������ Variable.VariableOrderWithoutExp �ɂ���Đ��񂳂�Ă���K�v������܂��B
		/// </summary>
		readonly Variable[] vars;

		public Member(Rational r){
			this.factor=r;
			this.vars=new Variable[0];
		}
		private Member(Variable v){
			this.factor=1;
			this.vars=new Variable[]{v};
		}
		private Member(Rational r,Variable[] vars){
			this.factor=r;
			this.vars=vars;
		}
		public Rational Factor{
			get{return this.factor;}
		}

		public bool IsIdenticalVariables(Member mem){
			if(mem.vars.Length!=this.vars.Length)return false;
			for(int i=0;i<vars.Length;i++)
				if(this.vars[i]!=mem.vars[i])return false;
			return true;
		}

		public bool IsZero{
			get{return this.factor.IsZero;}
		}
		//===========================================================
		//		��� (�����̒u��)
		//===========================================================
		/// <summary>
		/// �w�肵���ϐ��ɑ΂����������݂܂��B
		/// </summary>
		/// <param name="v">����̑Ώۂ̕ϐ����w�肵�܂��B�w�����͖�������܂��B</param>
		/// <param name="x">v �Ŏw�肵���ϐ��ɑ�����鎮���w�肵�܂��B</param>
		/// <returns>
		/// �w�肵���ϐ��������鎖���o�����ꍇ�ɂ͂��̑���������ʂ�Ԃ��܂��B
		/// ���̍����܂�ł���w�肵���ϐ�����㰂������Ă����ꍇ�ɂ͑���͎��s���Anull ��Ԃ��܂��B
		/// ���̍����w�肵���ϐ����܂�ł��炸�A�]���đ������K�v���Ȃ������ꍇ�ɂ� null ��Ԃ��܂��B
		/// </returns>
		internal Expression Substitute(Variable v,Expression x){
			for(int i=0;i<vars.Length;i++){
				Variable v1=vars[i];
				if(v1.Exponent<=0)return null;
				if(v.IsSameVarname(v1)){
					return (this/new Member(v1))*Expression.Pow(x,v1.Exponent);
				}
			}
			return null;
		}
		internal bool ContainsVariable(Variable v1){
			for(int i=0;i<vars.Length;i++)
				if(v1.IsSameVarname(vars[i]))
					return true;
			return false;
		}
		//===========================================================
		//		��r
		//===========================================================
		/// <summary>
		/// �ϐ��������g�p���ă����o�ɏ��Ԃ�t���܂��B
		/// ���Ԃ�t����̂ɌW���̗L�����͎g�p���܂���B
		/// �����W���̗L���������قȂ��āA���������ꍇ�ɂ� 0 ��Ԃ��܂��B
		/// </summary>
		/// <param name="left">��r���� Member �l�̈�����w�肵�܂��B</param>
		/// <param name="right">��r���� Member �l�̑������w�肵�܂��B</param>
		/// <returns>���Ԃ������Ɣ��肳�ꂽ�ꍇ�ɂ� 0 ��Ԃ��܂��B
		/// left �̕������Ԃ������Ɣ��肳�ꂽ�ꍇ�ɂ͕��̒l��Ԃ��܂��B
		/// right �̕������Ԃ������Ɣ��肳�ꂽ�ꍇ�ɂ͐��̒l��Ԃ��܂��B</returns>
		public static int MemberOrder(Member left,Member right){
			int val=left.vars.Length-right.vars.Length;
			if(val!=0)return val;
			for(int i=0;i<left.vars.Length;i++){
				val=Variable.VariableOrder(left.vars[i],right.vars[i]);
				if(val!=0)return val;
			}
			return 0;
		}
		public static readonly System.Comparison<Member> memberOrder=MemberOrder;
		public static readonly Gen::IComparer<Member> MemberOrderComparer=new _MemberOrderComparer();
		private sealed class _MemberOrderComparer:Gen::IComparer<Member> {
			public _MemberOrderComparer(){}
			public int Compare(Member x,Member y) {
				return MemberOrder(x,y);
			}
		}
		//===========================================================
		//		�揜
		//===========================================================
		public static Member operator*(Member l,Member r){
			Gen::List<Variable> vars=new Gen::List<Variable>();
			int il=0,ilM=l.vars.Length;
			int ir=0,irM=r.vars.Length;
			while(il<ilM&&ir<irM){
				int val=Variable.VariableOrderWithoutExp(l.vars[il],r.vars[ir]);
				if(val<0){
					vars.Add(l.vars[il++]);
				}else if(val>0){
					vars.Add(r.vars[ir++]);
				}else{
					Variable v=l.vars[il++]*r.vars[ir++];
					if(!v.IsConstant)vars.Add(v);
				}
			}

			if(il<ilM){
				do vars.Add(l.vars[il++]);while(il<ilM);
			}else if(ir<irM){
				do vars.Add(r.vars[ir++]);while(ir<irM);
			}

			return new Member(l.factor*r.factor,vars.ToArray());
		}
		public static Member operator/(Member l,Member r){
			Gen::List<Variable> vars=new Gen::List<Variable>();
			int il=0,ilM=l.vars.Length;
			int ir=0,irM=r.vars.Length;
			while(il<ilM&&ir<irM){
				int val=Variable.VariableOrderWithoutExp(l.vars[il],r.vars[ir]);
				if(val<0){
					vars.Add(l.vars[il++]);
				}else if(val>0){
					vars.Add(r.vars[ir++].Reciprocal);
				}else{
					Variable v=l.vars[il++]/r.vars[ir++];
					if(!v.IsConstant)vars.Add(v);
				}
			}

			if(il<ilM){
				do vars.Add(l.vars[il++]);while(il<ilM);
			}else if(ir<irM){
				do vars.Add(r.vars[ir++].Reciprocal);while(ir<irM);
			}

			return new Member(l.factor/r.factor,vars.ToArray());
		}
		//===========================================================
		//		�����t�������Z
		//===========================================================
		/// <summary>
		/// ���������W�����������m�����Z���܂��B�قȂ�����W�����������m�����Z�����ꍇ�̓���Ɋւ��Ă͕ۏ؂��܂���B
		/// </summary>
		/// <param name="l">���Z���鍀�̈�����w�肵�܂��B</param>
		/// <param name="r">���Z���鍀�̑������w�肵�܂��B�����͗��҂ň�v���Ă���K�v������܂��B</param>
		/// <returns>���Z�������ʂ̍���Ԃ��܂��B</returns>
		public static Member operator+(Member l,Member r){
			return new Member(l.factor+r.factor,l.vars);
		}
		/// <summary>
		/// ���������W�����������m�Ō��Z�����܂��B�قȂ�����W�����������m�����Z�����ꍇ�̓���Ɋւ��Ă͕ۏ؂��܂���B
		/// </summary>
		/// <param name="l">���������̍����w�肵�܂��B</param>
		/// <param name="r">�������̍����w�肵�܂��B�����͗��҂ň�v���Ă���K�v������܂��B</param>
		/// <returns>���Z�������ʂ̍���Ԃ��܂��B</returns>
		public static Member operator-(Member l,Member r){
			return new Member(l.factor-r.factor,l.vars);
		}
		public static Member operator+(Member m){
			return m;
		}
		public static Member operator-(Member m){
			return new Member(-m.factor,m.vars);
		}
		//===========================================================
		//		�\���E�ǂݎ��
		//===========================================================
		public override string ToString(){
			if(vars.Length==0)return this.factor.ToString();

			System.Text.StringBuilder build=new System.Text.StringBuilder();
			if(this.factor==Rational.MinusOne){
				build.Append("-");
			}else if(this.factor!=Rational.One){
				build.Append(this.factor.ToString());
				build.Append('�E');
			}

			foreach(Variable var in vars){
				build.Append(var.ToString());
				build.Append(' ');
			}
			
			return build.ToString().TrimEnd();
		}
		public string ToHtml(bool ksh_style) {
			if(vars.Length==0) return this.factor.ToHtml();

			System.Text.StringBuilder build=new System.Text.StringBuilder();
			if(this.factor==Rational.MinusOne){
				build.Append("-");
			}else if(this.factor!=Rational.One){
				build.Append(this.factor.ToHtml(ksh_style));
				build.Append(' ');
			}

			foreach(Variable var in vars){
				build.Append(var.ToHtml(ksh_style));
				build.Append(' ');
			}
			
			return build.ToString();
		}
		/// <summary>
		/// �ȒP�ȕ�����ǂݎ������s���܂��B
		/// �������Ȃ�������̓ǂݎ������s�����ꍇ�̓���͖���ł��B
		/// </summary>
		/// <param name="str">�e�ϐ����󔒁A'*'�A'/' �ŋ�؂������X�g�����̕\���Ƃ��ēn���܂��B</param>
		/// <returns>�ǂݎ�������ʐ��������������Ԃ��܂��B</returns>
		public static Member EasyParse(string str){
			int i=0;
			char mode='*';
			string w="";

			Rational r=1;
			Gen::Dictionary<string,int> dic=new Gen::Dictionary<string,int>();
			while(i<str.Length){
				char c=str[i++];

				// ��������
				if(c<=' '){
					c='*';
				}else if(c==':'){
					c='/';
				}

				// �ǂݎ��
				if(c=='/'||c=='*'){
					// �ϐ��̓o�^
					if(w!="")EasyParse_addfactor(ref r,dic,w,mode);
					mode=c;w="";
				}else{
					w+=c;
				}
			}

			// �ϐ��̓o�^
			if(w!="")EasyParse_addfactor(ref r,dic,w,mode);

			// Member ����
			Variable[] vars=new Variable[dic.Count];
			i=0;
			foreach(Gen::KeyValuePair<string,int> pair in dic){
				vars[i++]=new Variable(pair.Key,pair.Value);
			}
			return new Member(r,vars);
		}
		private static void EasyParse_addfactor(ref Rational r,Gen::Dictionary<string,int> dic,string w,char mode){
			try{
				long val=long.Parse(w);
				if(mode=='/')
					r/=val;
				else
					r*=val;
			}catch{
				int exp=mode=='/'?-1:1;
				if(!dic.ContainsKey(w)){
					dic[w]=exp;
				}else{
					if((dic[w]+=exp)==0)dic.Remove(w);
				}
			}
		}
	}
	#endregion

	#region struct:Variable
	/// <summary>
	/// �����\������ꌳ��萔������\�����܂��B
	/// </summary>
	internal struct Variable{
		int code;
		int exp;

		public Variable(string name){
			if(!v_codes.ContainsKey(name))
				RegisterVariable(name);

			this.code=v_codes[name];
			this.exp=1;
		}
		public Variable(string name,int exp):this(name){
			this.exp=exp;
		}
		private Variable(int type,int exp){
			this.code=type;
			this.exp=exp;
		}
		public bool IsConstant{
			get{return this.exp==0;}
		}
		public bool IsSameVarname(Variable v){
			return this.code==v.code;
		}
		/// <summary>
		/// ���̈����Ɋ|�����Ă���w�����擾���܂��B
		/// </summary>
		public int Exponent{
			get{return this.exp;}
		}
		//===========================================================
		//		�ϐ���
		//===========================================================
		static Gen::Dictionary<int,string> v_names=new Gen::Dictionary<int,string>();
		static Gen::Dictionary<string,int> v_codes=new Gen::Dictionary<string,int>();
		public static void RegisterVariable(string name){
			int type=v_names.Count;
			v_names.Add(type,name);
			v_codes.Add(name,type);
		}
		public static bool IsRegistered(string varname){
			return v_codes.ContainsKey(varname);
		}
		/*
		/// <summary>
		/// �ϐ��ɑΉ����� code ���擾���܂��B�ϐ��̌����̍ۂɎg�p���鎖���o���܂��B
		/// </summary>
		/// <param name="varname">�Ή����� code ��m�肽���ϐ������w�肵�܂��B</param>
		/// <returns>�w�肵���ϐ����o�^����Ă����ꍇ�ɂ͂��� code ��Ԃ��܂��B
		/// �w�肵�����O�̕ϐ����o�^����Ă��Ȃ������ꍇ�ɂ� -1 ��Ԃ��܂��B</returns>
		public static int GetVariableCode(string varname){
			int ret;
			return v_codes.TryGetValue(varname,out ret)?ret:-1;
		}
		//*/
		//===========================================================
		//		�\��
		//===========================================================
		public override string ToString(){
			if(exp==1)return v_names[this.code];
			return v_names[this.code]+"^"+exp.ToString();
		}
		public string ToHtml(bool ksh_style) {
			string name=v_names[this.code];

			// index �����t��
			while(true){
				int st=name.LastIndexOf('[');
				if(st<0)break;
				
				int ed=name.IndexOf(']',st);
				if(ed<0)break;

				name=name.Substring(0,st++)+(ksh_style?"<ksh:sub>":"<sub>")+name.Substring(st,ed-st)+(ksh_style?"</ksh:sub>":"</sub>")+name.Substring(ed+1);
			}

			if(exp==1)return name;
			return name+(ksh_style?"<ksh:sup>":"<sup>")+exp.ToString()+(ksh_style?"</ksh:sup>":"</sup>");
		}
		//===========================================================
		//		��r���Z
		//===========================================================
		public static int VariableOrderWithoutExp(Variable left,Variable right){
			return left.code-right.code;
		}
		public static int VariableOrder(Variable left,Variable right){
			int val=left.code-right.code;
			return val!=0?val:left.exp-right.exp;
		}
		public static bool operator==(Variable v1,Variable v2){
			return v1.code==v2.code&&v1.exp==v2.exp;
		}
		public static bool operator!=(Variable v1,Variable v2){
			return !(v1==v2);
		}
		public override bool Equals(object obj) {
			return obj is Variable&&this==(Variable)obj;
		}
		public override int GetHashCode(){
			return v_names[this.code].GetHashCode()^this.exp.GetHashCode();
		} 
		//===========================================================
		//		�����t�����Z
		//===========================================================
		/// <summary>
		/// �ϐ�������̏ꍇ�ɂ̂ݓK�p���鎖�̏o�����Z�ł��B
		/// �ϐ��������قȂ�ꍇ�̓���Ɋւ��Ă͕ۏ؂��܂���B
		/// </summary>
		/// <param name="l">�|�����킹��ϐ��̈�����w�肵�܂��B</param>
		/// <param name="r">�|�����킹��ϐ��̑������w�肵�܂��B</param>
		/// <returns>�|�����킹�����ʂ̎w�������ϐ���Ԃ��܂��B</returns>
		public static Variable operator*(Variable l,Variable r){
			return new Variable(l.code,l.exp+r.exp);
		}
		/// <summary>
		/// �ϐ�������̏ꍇ�ɂ̂ݓK�p���鎖�̏o���鏜�Z�ł��B
		/// �ϐ��������قȂ�ꍇ�̓���Ɋւ��Ă͕ۏ؂��܂���B
		/// </summary>
		/// <param name="l">�폜�ϐ����w�肵�܂��B</param>
		/// <param name="r">�@ (����) ���w�肵�܂��B</param>
		/// <returns>����Z�������ʂ̎w�������ϐ���Ԃ��܂��B</returns>
		public static Variable operator/(Variable l,Variable r){
			return new Variable(l.code,l.exp-r.exp);
		}
		/// <summary>
		/// ���̃C���X�^���X�̋t�����擾���܂��B�����A�t�̎w�����������l�ɂȂ�܂��B
		/// </summary>
		public Variable Reciprocal{
			get{return new Variable(this.code,-this.exp);}
		}
	}
	#endregion

	#region class:MatrixExp
	/// <summary>
	/// �L�������e�v�f�Ƃ���s���\�����܂��B
	/// </summary>
	public class MatrixExp:System.ICloneable{
		private readonly int lines;
		private readonly int columns;
		private readonly Expression[,] vals;

		public MatrixExp(int lines,int columns){
			this.lines=lines;
			this.columns=columns;
			this.vals=new Expression[lines,columns];
		}
		
		/// <summary>
		/// ���̍s��̍s�̐����擾���܂��B
		/// </summary>
		public int LineCount{
			get{return this.lines;}
		}
		/// <summary>
		/// ���̍s��̗�̐����擾���܂��B
		/// </summary>
		public int ColumnCount{
			get{return this.columns;}
		}
		public Expression this[int line,int column]{
			get{return this.vals[line,column];}
			set{this.vals[line,column]=value;}
		}
		//===========================================================
		//		����
		//===========================================================
		/// <summary>
		/// Matrix �̃R�s�[�R���X�g���N�^�ł��B
		/// </summary>
		/// <param name="matrix">�������� Matrix ���w�肵�܂��B</param>
		public MatrixExp(MatrixExp matrix){
			this.vals=new Expression[
				this.lines=matrix.lines,
				this.columns=matrix.columns
				];

			for(int l=0;l<this.lines;l++)for(int c=0;c<this.columns;c++)
				this.vals[l,c]=matrix.vals[l,c];
		}
		public MatrixExp Clone(){
			return new MatrixExp(this);
		}
		object System.ICloneable.Clone(){
			return new MatrixExp(this);
		}
		//===========================================================
		//		�\��
		//===========================================================
		public string ToHtml(){
			System.Text.StringBuilder build=new System.Text.StringBuilder();
			build.Append("<table style='display:inline;vertical-align:middle;'>\r\n");
			build.AppendFormat(@"<colgroup>
	<col style='padding:0;width:3px;font-size:1px;'/>
	<col style='text-align:center;padding-left:.5ex;padding-right:.5ex' span='{0}'/>
	<col style='padding:0;width:3px;font-size:1px;'/>
</colgroup>
",this.columns);
			for(int l=0;l<this.lines;l++){
				build.Append("<tr>");
				if(l==0)
					build.AppendFormat("\r\n<td style='border:1px solid black;border-right-width:0;' rowspan='{0}'>&nbsp;</td>\r\n",this.lines);
				for(int c=0;c<this.columns;c++){
					build.Append("<td>");
					build.Append(this.vals[l,c].ToHtml(true));
					build.Append("</td>");
				}
				if(l==0)
					build.AppendFormat("\r\n<td style='border:1px solid black;border-left-width:0;' rowspan='{0}'>&nbsp;</td>\r\n",this.lines);
				build.Append("</tr>\r\n");
			}
			build.Append("</table>\r\n");
			return build.ToString();
		}
	}
	#endregion
}
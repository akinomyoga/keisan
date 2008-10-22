using Gen=System.Collections.Generic;

namespace PhysDrillReportCalc{
	public static class Program{
		public const int mk=7;
		public static readonly Kou _1	=new Kou(0,0,0,0,0,0,0);
		public static readonly Kou r_inv=new Kou(1,0,0,0,0,0,0);
		public static readonly Kou r1	=new Kou(0,1,0,0,0,0,0);
		public static readonly Kou r2	=new Kou(0,0,1,0,0,0,0);
		public static readonly Kou r3	=new Kou(0,0,0,1,0,0,0);
		public static readonly Kou p1	=new Kou(0,0,0,0,1,0,0);
		public static readonly Kou p2	=new Kou(0,0,0,0,0,1,0);
		public static readonly Kou p3	=new Kou(0,0,0,0,0,0,1);

		public static readonly Vector vec_r=new Vector(r1,r2,r3);
		public static readonly Vector vec_p=new Vector(p1,p2,p3);

		public static void Calculate() {
			Vector vec_L=vec_r*vec_p;
			Vector vec_pL=vec_p*vec_L;
			Vector vec_rL=vec_r*vec_L;
			Vector vec_F=-mk*r_inv*vec_r;
			Vector vec_A=vec_pL+vec_F;

			Shiki L1=vec_L.x;
			Shiki L2=vec_L.y;
			Shiki L3=vec_L.z;
			Shiki pXL1=vec_pL.x;
			Shiki pXL2=vec_pL.y;
			Shiki pXL3=vec_pL.z;
			Shiki rXL1=vec_rL.x;
			Shiki rXL2=vec_rL.y;
			Shiki rXL3=vec_rL.z;
			Shiki F1=vec_F.x;
			Shiki F2=vec_F.y;
			Shiki F3=vec_F.z;
			Shiki A1=vec_A.x;
			Shiki A2=vec_A.y;
			Shiki A3=vec_A.z;

			Shiki _2mH=(vec_p&vec_p)-2*mk*r_inv;

			//System.Console.WriteLine(L1);
			//System.Console.WriteLine(L2);
			//System.Console.WriteLine(L3);

			//===========================================================
			//	1)
			//===========================================================
			//*
			System.Console.WriteLine("[Ax,2mH] == {0}",Poisson(A1,_2mH));
			System.Console.WriteLine("[Ay,2mH] == {0}",Poisson(A2,_2mH));
			System.Console.WriteLine("[Az,2mH] == {0}",Poisson(A3,_2mH));
			//*/
			//===========================================================
			//		2)
			//===========================================================
			//		[L,****]
			//-----------------------------------------------------------
			/*
			System.Console.WriteLine(Poisson(L1,r2)==r3);
			System.Console.WriteLine(Poisson(L2,r3)==r1);
			System.Console.WriteLine(Poisson(L3,r1)==r2);
			System.Console.WriteLine(Poisson(L1,p2)==p3);
			System.Console.WriteLine(Poisson(L2,p3)==p1);
			System.Console.WriteLine(Poisson(L3,p1)==p2);
			System.Console.WriteLine(Poisson(L1,L2)==L3);
			System.Console.WriteLine(Poisson(L2,L3)==L1);
			System.Console.WriteLine(Poisson(L3,L1)==L2);
			//*/
			//-----------------------------------------------------------
			//		[p×L,****]
			//-----------------------------------------------------------
			/*
			Shiki r_p=r1*p1+r2*p2+r3*p3;
			Shiki p_p=p1*p1+p2*p2+p3*p3;

			System.Console.WriteLine(Poisson(pXL1,r1)==1*r_p-r1*p1);
			System.Console.WriteLine(Poisson(pXL2,r2)==1*r_p-r2*p2);
			System.Console.WriteLine(Poisson(pXL3,r3)==1*r_p-r3*p3);
			System.Console.WriteLine(Poisson(pXL1,r2)==0*r_p+p1*r2-2*r1*p2);
			System.Console.WriteLine(Poisson(pXL2,r3)==0*r_p+p2*r3-2*r2*p3);
			System.Console.WriteLine(Poisson(pXL3,r1)==0*r_p+p3*r1-2*r3*p1);

			System.Console.WriteLine(Poisson(pXL1,p1)==1*p_p-p1*p1);
			System.Console.WriteLine(Poisson(pXL2,p2)==1*p_p-p2*p2);
			System.Console.WriteLine(Poisson(pXL3,p3)==1*p_p-p3*p3);
			System.Console.WriteLine(Poisson(pXL1,p2)==0*p_p-p1*p2);
			System.Console.WriteLine(Poisson(pXL2,p3)==0*p_p-p2*p3);
			System.Console.WriteLine(Poisson(pXL3,p1)==0*p_p-p3*p1);

			System.Console.WriteLine(Poisson(pXL1,r_inv)==rXL1*(r_inv*r_inv*r_inv));
			System.Console.WriteLine(Poisson(pXL2,r_inv)==rXL2*(r_inv*r_inv*r_inv));
			System.Console.WriteLine(Poisson(pXL3,r_inv)==rXL3*(r_inv*r_inv*r_inv));

			System.Console.WriteLine(Poisson(pXL1,L2)==pXL3);
			System.Console.WriteLine(Poisson(pXL2,L3)==pXL1);
			System.Console.WriteLine(Poisson(pXL3,L1)==pXL2);
			//*/
			//-----------------------------------------------------------
			//		[Ax,Ay]
			//-----------------------------------------------------------
			/*
			System.Console.WriteLine(Poisson(F1,F2)==0*_1);
			System.Console.WriteLine(Poisson(pXL1,F2)+Poisson(F1,pXL2)==2*mk*r_inv*L3);
			System.Console.WriteLine(Poisson(pXL1,pXL2)==-L3*(vec_p&vec_p));
			//*/ //*
			System.Console.WriteLine("[Ax,Ay] == -2mH Lz : {0}",Poisson(A1,A2)==-L3*_2mH);
			System.Console.WriteLine("[Ay,Az] == -2mH Lx : {0}",Poisson(A2,A3)==-L1*_2mH);
			System.Console.WriteLine("[Az,Ax] == -2mH Ly : {0}",Poisson(A3,A1)==-L2*_2mH);
			//*/

			//===========================================================
			//		3)
			//===========================================================
			System.Console.WriteLine("A・L == 0 : {0}",(vec_A&vec_L)==0*_1);
			System.Console.WriteLine("A・A == (mk)^2 + 2mH L・L : {0}",(vec_A&vec_A)==mk*mk*_1+_2mH*(vec_L&vec_L));
		}

		public static Shiki Poisson(Shiki s1,Shiki s2){
			Shiki pois=new Shiki();
			pois+=(s1>>1)*(s2>>4)-(s1>>4)*(s2>>1);
			pois+=(s1>>2)*(s2>>5)-(s1>>5)*(s2>>2);
			pois+=(s1>>3)*(s2>>6)-(s1>>6)*(s2>>3);
			return pois;
		}
	}

	public class Vector{
		public Shiki x;
		public Shiki y;
		public Shiki z;

		public Vector(Shiki x,Shiki y,Shiki z){
			this.x=x;
			this.y=y;
			this.z=z;
		}
		internal Vector(){
			this.x=this.y=this.z=null;
		}
		public static Vector operator*(Kou k1,Vector v2){
			Vector vec=new Vector();
			vec.x=k1*v2.x;
			vec.y=k1*v2.y;
			vec.z=k1*v2.z;
			return vec;
		}
		public static Vector operator*(Shiki s1,Vector v2) {
			Vector vec=new Vector();
			vec.x=s1*v2.x;
			vec.y=s1*v2.y;
			vec.z=s1*v2.z;
			return vec;
		}
		public static Vector operator*(Vector v1,Vector v2) {
			Vector vec=new Vector();
			vec.x=v1.y*v2.z-v1.z*v2.y;
			vec.y=v1.z*v2.x-v1.x*v2.z;
			vec.z=v1.x*v2.y-v1.y*v2.x;
			return vec;
		}
		public static Shiki operator&(Vector v1,Vector v2){
			return v1.x*v2.x+v1.y*v2.y+v1.z*v2.z;
		}
		public static Vector operator+(Vector v1,Vector v2){
			return new Vector(v1.x+v2.x,v1.y+v2.y,v1.z+v2.z);
		}
	}

	public class Kou {
		public int keisu;
		public int[] inshi;

		public Kou() {
			this.keisu=1;
			this.inshi=new int[7]; // x1~x3, p1~p3, 1/r
		}

		public Kou Clone() {
			Kou ret=new Kou();

			ret.keisu=this.keisu;
			System.Array.Copy(this.inshi,ret.inshi,7);

			return ret;
		}

		public int InshiCode {
			get {
				return inshi[0]|inshi[1]<<3|inshi[2]<<6
					|inshi[3]<<9|inshi[4]<<12|inshi[5]<<15|inshi[6]<<18;
			}
		}

		public override string ToString() {
			string ret=keisu.ToString();
			ret+=ToString_Exp("r",-inshi[0]);
			ret+=ToString_Exp("rx",inshi[1]);
			ret+=ToString_Exp("ry",inshi[2]);
			ret+=ToString_Exp("rz",inshi[3]);
			ret+=ToString_Exp("px",inshi[4]);
			ret+=ToString_Exp("py",inshi[5]);
			ret+=ToString_Exp("pz",inshi[6]);
			return ret;
		}
		private static string ToString_Exp(string inshi,int exp) {
			if(exp==0) return "";
			if(exp==1) return "・"+inshi;
			if(exp<0) return "・"+inshi+"^("+exp.ToString()+")";
			return "・"+inshi+"^"+exp.ToString();
		}

		public static Shiki operator+(Kou k1,Kou k2) {
			Shiki shiki=new Shiki();

			shiki.AddKou(k1.Clone());
			shiki.AddKou(k2.Clone());

			return shiki;
		}
		public static Shiki operator-(Kou k1) {
			return (-1)*k1;
		}
		public static Shiki operator-(Kou k1,Kou k2) {
			return k1+(-1)*k2;
		}
		public static Kou operator*(int v,Kou k1) {
			Kou ret=k1.Clone();
			ret.keisu*=v;
			return ret;
		}
		public static Kou operator*(Kou k1,Kou k2) {
			Kou ret=new Kou();

			ret.keisu=k1.keisu*k2.keisu;
			for(int i=0;i<7;i++) {
				ret.inshi[i]=k1.inshi[i]+k2.inshi[i];
			}

			return ret;
		}

		public void Henbi(Shiki shiki,int index) {
			if(index<=0||6<index) throw new System.Exception("そんな偏微分には対応していないよ");

			Kou ret=this.Clone();
			ret.keisu*=ret.inshi[index]--;
			shiki.AddKou(ret);

			if(index>3||this.inshi[0]==0) return;

			ret=this.Clone();
			ret.keisu*=-ret.inshi[0];
			ret.inshi[0]+=2;
			ret.inshi[index]++;
			shiki.AddKou(ret);
		}

		public Kou(int r,int r1,int r2,int r3,int p1,int p2,int p3) {
			this.keisu=1;
			this.inshi=new int[7];
			this.inshi[0]=r;
			this.inshi[1]=r1;
			this.inshi[2]=r2;
			this.inshi[3]=r3;
			this.inshi[4]=p1;
			this.inshi[5]=p2;
			this.inshi[6]=p3;
		}

	}

	public class Shiki {
		Gen::List<Kou> list;

		public Shiki() {
			list=new Gen::List<Kou>();
		}

		public void AddKou(Kou kou) {
			if(kou.keisu==0) return;

			Kou removee;
			foreach(Kou k in this.list) {
				if(kou.InshiCode==k.InshiCode) {
					k.keisu+=kou.keisu;
					if(k.keisu==0) {
						removee=k;
						goto remove;
					}
					return;
				}
			}
			this.list.Add(kou.Clone());
			return;
		remove:
			this.list.Remove(removee);
		}

		public override string ToString(){
			this.Normalize();

			if(list.Count==0) return "0";
			bool start=true;
			string ret="";
			foreach(Kou k in this.list) {
				if(start) {
					start=false;
				} else ret+="+";
				ret+=k.ToString();
			}
			return ret.Replace("+-","-").Replace("1・","");
		}
		public void Normalize(){
			int c;do{
				c=this.list.Count;
				this._Normalize();
			}while(c!=this.list.Count);
		}
		public void _Normalize() {
			Kou k1;
			foreach(Kou k in this.list) {
				if(k.inshi[1]>=2) {
					k1=k;
					goto norm;
				}
			}
			return;
		norm:
			Kou k2=null;
			Kou k3=null;
			foreach(Kou k in this.list) {
				if(Normalize_check12(k1,k)) {
					k2=k;
				} else if(Normalize_check13(k1,k)) {
					k3=k;
				}
			}
			if(k2!=null&&k3!=null) {
				this.list.Remove(k1);
				this.list.Remove(k2);
				this.list.Remove(k3);
				k1.inshi[1]-=2;
				k1.inshi[0]-=2;
				this.AddKou(k1);
			}else{
				this.list.Remove(k1);
				this.Normalize();
				this.list.Add(k1);
			}
		}
		private bool Normalize_check12(Kou k1,Kou k2) {
			return k1.inshi[0]==k2.inshi[0]
				&&k1.inshi[1]-2==k2.inshi[1]
				&&k1.inshi[2]+2==k2.inshi[2]
				&&k1.inshi[3]==k2.inshi[3]
				&&k1.inshi[4]==k2.inshi[4]
				&&k1.inshi[5]==k2.inshi[5]
				&&k1.inshi[6]==k2.inshi[6];
		}
		private bool Normalize_check13(Kou k1,Kou k3) {
			return k1.inshi[0]==k3.inshi[0]
				&&k1.inshi[1]-2==k3.inshi[1]
				&&k1.inshi[2]==k3.inshi[2]
				&&k1.inshi[3]+2==k3.inshi[3]
				&&k1.inshi[4]==k3.inshi[4]
				&&k1.inshi[5]==k3.inshi[5]
				&&k1.inshi[6]==k3.inshi[6];
		}

		public static implicit operator Shiki(Kou k) {
			Shiki ret=new Shiki();
			ret.AddKou(k.Clone());
			return ret;
		}
		public static Shiki operator+(Shiki s1,Shiki s2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) ret.AddKou(k1.Clone());
			foreach(Kou k2 in s2.list) ret.AddKou(k2.Clone());
			return ret;
		}
		public static Shiki operator+(Shiki s1,Kou k2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) ret.AddKou(k1.Clone());
			ret.AddKou(k2.Clone());
			return ret;
		}
		public static Shiki operator-(Shiki s){
			return (-1)*s;
		}
		public static Shiki operator-(Shiki s1,Shiki s2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) ret.AddKou(k1.Clone());
			foreach(Kou k2 in s2.list) ret.AddKou((-1)*k2);
			return ret;
		}
		public static Shiki operator-(Shiki s1,Kou k2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) ret.AddKou(k1.Clone());
			ret.AddKou((-1)*k2);
			return ret;
		}
		public static Shiki operator*(Shiki s1,Shiki s2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) foreach(Kou k2 in s2.list) {
					ret.AddKou(k1*k2);
				}
			return ret;
		}
		public static Shiki operator*(Shiki s1,Kou k2) {
			Shiki ret=new Shiki();
			foreach(Kou k1 in s1.list) {
				ret.AddKou(k1*k2);
			}
			return ret;
		}
		public static Shiki operator*(Kou k1,Shiki s2) {
			Shiki ret=new Shiki();
			foreach(Kou k2 in s2.list) {
				ret.AddKou(k1*k2);
			}
			return ret;
		}
		public static Shiki operator*(int v,Shiki s) {
			Shiki ret=new Shiki();
			foreach(Kou k2 in s.list) ret.AddKou(v*k2);
			return ret;
		}
		public static bool operator==(Shiki s1,Shiki s2) {
			Shiki s=s1-s2;
			s.Normalize();
			return s.list.Count==0;
		}
		public static bool operator!=(Shiki s1,Shiki s2){
			return !(s1==s2);
		}
		public override bool Equals(object obj) {
			return obj is Shiki&&this==(Shiki)obj;
		}
		public override int GetHashCode() {
			this.Normalize();
			return base.GetHashCode();
		}
		/// <summary>
		/// 偏微分
		/// </summary>
		/// <param name="s1"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static Shiki operator>>(Shiki s1,int index) {
			Shiki ret=new Shiki();

			foreach(Kou k in s1.list) k.Henbi(ret,index);

			return ret;
		}
	}
}
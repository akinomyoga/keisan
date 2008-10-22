using M=ksh.Physics.Constants;
namespace PhysExp2Micro{
	public class _{
		public static void Calc(){
			ksh.Rational c;
			System.Console.WriteLine("1→2 (m=1) : {0}",c=Estr2(2,1)-Estr2(1,1));
			//double dE=
			//System.Console.WriteLine();
			System.Console.WriteLine("1→2 (m=0) : {0}",Estr2(2,0)-Estr2(1,0));
		}

		/// <summary>
		/// 水素原子に対する、シュタルク効果 (二次摂動) を計算します。
		/// </summary>
		public static ksh.Rational Estr2(int J,int M){
			if(J==0)return new ksh.Rational(1,3);
			int j2=J*(J+1);
			return new ksh.Rational(j2-3*M*M,j2*(2*J-1)*(2*J+3));
		}
	}
}
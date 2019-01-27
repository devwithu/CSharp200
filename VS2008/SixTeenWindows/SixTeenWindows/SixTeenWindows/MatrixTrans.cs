using System;
namespace Matrix2to1
{
	public class MatrixTrans
	{
		public static int[]  Mat2to1(int [  ,  ] t){
			int x=t.GetLength(0);  //t[x,y] 몇줄
			int y=t.GetLength(1);  //몇 칼럼
			int [] temp=new int[x*y];
			for(int i=0;i<x;i++){
				for(int j=0;j<y;j++)
				{
					temp[i*y+j]=t[i,j];
				}
			}
			return temp;
		}//Mat2to1
		public static int[,]  Mat1to2(int [] t,int m,int n)
		{
			//System.Console.WriteLine("1:   m={0}  n={1}",m,n);
			int [,]   a=   new int[m,n];
			if( !  IsPossible(t,m,n)){
				return a;
			}
			//System.Console.WriteLine("2:   m={0}  n={1}",m,n);
			int tem=t.Length;
			//System.Console.WriteLine("3:   tem={0}  ",tem);
			int slash=n;
			for(int i=0;i<tem;i++)
			{
					//System.Console.WriteLine("4:   m={0}  n={1}",i/slash,i%slash);
					a[ i / slash , i % slash ]=t[ i ];
			}
			return a;
		}//Mat2to1
		public static bool IsPossible(int [] t, int la,int lb){
			bool isP=false;
			if(t.Length==la*lb){
				isP=true;
			}
			return isP;
		}//
		public static void print(int [,] t)
		{
			for(int i=0;i<t.GetLength(0);i++)
			{
				for(int j=0;j<t.GetLength(1);j++)
				{
					System.Console.Write("{0}  ",t[i,j]);
				}
				System.Console.WriteLine();
			}
		}//print
		public static void print(int [] t)
		{
			for(int i=0;i<t.Length;i++)
			{
				System.Console.Write("{0}  ",t[i]);
			}
			System.Console.WriteLine();
		}//print
	}//class
}//name

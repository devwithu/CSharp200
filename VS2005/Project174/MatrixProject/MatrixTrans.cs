using System;
namespace Com.JungBo.Logic{
 //모든 기본타입에 적용할수 있도록 한다.
 public class MatrixTrans<T>{
    public static T[] Mat2to1(T[,] t){
		int row=t.GetLength(0);  //t[x,y] 몇줄
		int col=t.GetLength(1);  //몇 칼럼
        T[] temp = new T[row * col];
		for(int i=0;i<row;i++){
			for(int j=0;j<col;j++){
				temp[i*col+j]=t[i,j];
			}
		}
		return temp;
	}//Mat2to1
    public static T[,] Mat1to2(T[] t,int row,int col){
        T[,] a = new T[row, col];
		int tem=t.Length;
		for(int i=0;i<tem;i++){
            a[i / col, i % col] = t[i];
		}
		return a;
	}
    public static T[,] Mat2Clone(T[,] t){
        T[,] a = new T[t.GetLength(0), t.GetLength(1)];
        int row = a.GetLength(0);
        int col = a.GetLength(1);
        for (int i = 0; i < row; i++){
            for (int j = 0; j < col; j++){
                a[i, j] = t[i, j];
            }
        }
        return a;
    }//Mat2Clone
    public static T[][] MatToZigZag(T[,] t) {
        int row = t.GetLength(0);
        int col = t.GetLength(1);
        T[][] a = new T[row][];
        for (int i = 0; i < row; i++){
            a[i] = new T[col];
        }
        for (int i = 0; i < row; i++){
            for (int j = 0; j < col; j++){
                a[i][j] = t[i, j];
            }
        }
        return a;
    }//Mat2to1
    public static void Print(T[,] t){
		for(int i=0;i<t.GetLength(0);i++){
			for(int j=0;j<t.GetLength(1);j++){
				System.Console.Write("{0}  ",t[i,j]);
			}
			System.Console.WriteLine();
		}
	}//print
    public static void Print(T[] t){
		for(int i=0;i<t.Length;i++){
			System.Console.Write("{0}  ",t[i]);
		}
		System.Console.WriteLine();
	}//print
 }//class
}//name

using System;
namespace Com.JungBo.Logic{  
 public class Program{
    public  static void Main(string[] args){
        //x + 2y + 4z = 11
        //2x + 5y + 2z = 3
        //4x - y + z = 8
        double[,] A ={ { 1,2,4 }, { 2,5,2 }, {4,-1,1 } };
        double[,] Y ={ { 11 }, { 3 }, { 8 } };
        //2차원배열->1차원배열
        double[] m = MatrixTrans<double>.Mat2to1(A);
        MatrixTrans<double>.Print(m);
        //1차원배열->2차원배열
        double[,] n = MatrixTrans<double>.Mat1to2(m, 3, 3);
        MatrixTrans<double>.Print(n);
    }
 }
}

using System;
namespace Com.JungBo.Logic{ 
    public class Program{
        public  static void Main(string[] args){
            //x + 2y + 4z = 11
            //2x + 5y + 2z = 3
            //4x - y + z = 8
            double[,] A ={ { 1,2,4 }, { 2,5,2 }, {4,-1,1 } };
            double[,] Y ={ { 11 }, { 3 }, { 8 } };

            Matrix mat = new Matrix(3);
            mat.SetMatrixs(A, Y);
            //mat.PrintMatrxsA();
            mat.Make();
            Console.WriteLine("A ");
            mat.PrintMatrxsA();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("A_1 ");
            mat.PrintReversA();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("A_1Y ¡Ô «ÿ ");
            mat.PrintMatrxsY();
        }
    }
}

using System;
namespace Com.JungBo.Logic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //x + 2y + 4z = 11
            //2x + 5y + 2z = 3
            //4x - y + z = 8
            double[,] A = { { 1, 2, 4 }, { 2, 5, 2 }, { 4, -1, 1 } };
            double[,] Y = { { 11 }, { 3 }, { 8 } };
            MatrixD matA = new MatrixD(A);
            matA.PrintMatrxsA();  //A출력
            Console.WriteLine("A ");
            MatrixD matRA = ~matA;  //~A,A역행렬 출력
            Console.WriteLine("-----------------------");
            Console.WriteLine("A_1 ");
            matRA.PrintMatrxsA();
            Console.WriteLine("------------------------");
            Console.WriteLine("A_1Y 즉 해 ");
            MatrixD mY = new MatrixD(Y);
            MatrixD A_1Y = ~matA * mY; //~A*Y =해
            A_1Y.PrintMatrxsA();
        }
    }
}

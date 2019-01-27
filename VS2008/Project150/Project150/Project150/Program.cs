using System;
using Com.JungBo.Maths;
namespace FunctionProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Srqt(2)의 추측값 1.5를 이용->1.42xxx
            Console.WriteLine(YenaMath.Sqrt(2, 1.5));
            //Srqt(100)의 추측값 20를 이용->10
            Console.WriteLine(YenaMath.Sqrt(100, 20));
        }
    }
}

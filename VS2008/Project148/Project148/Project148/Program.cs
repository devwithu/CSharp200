using System;
using Com.JungBo.Maths;
namespace FunctionProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double[] mfunct = { -1, 0, 1, 1 };
            //f(x)= -x^3 + x + 1
            Funct func = new Funct(mfunct);
            double x = 3;
            func.X = x;  //-27+3+1
            Console.WriteLine("f({0})={1}", x, func.Function());
            x = -1;
            func.X = x;  //1-1+1
            Console.WriteLine("f({0})={1}", x, func.Function());
        }
    }
}

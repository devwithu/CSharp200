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
            double right = 3;
            func.X = right;  //-27+3+1
            Console.WriteLine("f({0})={1}", right, func.Function());

            double left = -1;
            func.X = left;  //1-1+1
            Console.WriteLine("f({0})={1}", left, func.Function());

            MeanValue mean = new MeanValue(func, left, right);
            mean.Make();
            Console.WriteLine("f(x)=0을 만족시키는 x={0}", mean.MeanVal);

            //확인 
            func.X = mean.MeanVal;//구한 근사값을 넣고 확인
            Console.WriteLine("f({0})={1}", mean.MeanVal, func.Function());
        }
    }
}

using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Z z1 = new Z(3, 2);
            Z z2 = new Z(3, -5);
            //Z1과 내용이 동일하지만 다른 객체
            Z z3 = new Z(z1);
            Console.WriteLine(z3);
            z3.X = 5;             //x에 5대입
            z3.Y = -9;            //y에 -9대입

            Console.WriteLine(z1);
            Console.WriteLine(z2);
            Console.WriteLine(z3);
        }
    }
}

using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Z z1 = new Z(4, 4);
            Console.WriteLine("z1\t{0}", z1);
            Z z2 = new Z(3, -5);
            Console.WriteLine("z2\t{0}", z2);
            //Z1과 내용이 동일하지만 다른 객체
            Z z3 = new Z(z1);
            Console.WriteLine(z3 == z1);  //개체는 같은 수 없다.
            Console.WriteLine(z3.Equals(z1));  //개체는 같은 수 없다.
            Console.WriteLine("{0}의 복사생성자: {1}", z1, z3);
            z3.X = 5;             //x에 5대입
            z3.Y = -9;            //y에 -9대입
            Console.WriteLine("z3\t{0}", z3);
            Z z4 = z1 * z2;
            Console.WriteLine("z4\t{0}", z4);
            Z z5 = z3 / z1;
            Console.WriteLine("z5\t{0}/{1}={2}", z3, z1, z5);
        }
    }
}

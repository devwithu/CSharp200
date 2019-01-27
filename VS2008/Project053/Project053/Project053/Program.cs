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
            z2.X = 4;
            z2.Y = 4;
            //같은 개체는 없지만  equals 오버라이딩하여 
            //내용이 같으면 같은개체가 되도록 했다.
            Console.WriteLine(z3 == z1);
            Console.WriteLine(z3.Equals(z1));
            Console.WriteLine("{0}의 복사생성자: {1}", z1, z3);
            Console.WriteLine(z2 == z1);
            Console.WriteLine(z2.Equals(z1));

        }
    }
}

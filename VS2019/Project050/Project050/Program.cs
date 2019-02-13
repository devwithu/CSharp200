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
            //참조타입 레퍼런스는 .ToString()이 붙는다.
            Console.WriteLine(z1);//z1.ToString()
            Console.WriteLine(z2);
        }
    }
}
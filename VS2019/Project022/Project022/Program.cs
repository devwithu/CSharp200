using Com.JungBo.Maths;
using System;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {

            double taylor = PowerSeries.Taylor(1);

            Console.WriteLine(taylor);
            Console.WriteLine(System.Math.E);
        }
    }
}

using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int ten = 68;
            string s2 = SimpleBits.TenToBinary(ten);
            Console.WriteLine("10진수 {0}--> 2진수: {1}",
                ten, s2);

            string sb1 = SimpleBits.BosuForOne(ten);
            Console.WriteLine("{0}에 대한 1의보수 : {1}",
                ten, sb1);

            string sb2 = SimpleBits.BosuForTwo(ten);
            Console.WriteLine("{0}에 대한 2의보수 : {1}",
                ten, sb2);
            string sb3 = SimpleBits.BosuForTwo2(ten);
            Console.WriteLine("{0}에 대한 2의보수 : {1}",
                ten, sb3);

            //Strings ss = new Strings();
            //ss.StringM();
            //ss.Show();
        }
    }
}

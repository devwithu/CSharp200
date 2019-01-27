using System;
using Com.JungBo.Maths;

namespace Com.JungBo.Basic {
    public class Program{
        public static void Main(string[] args){

            int ten=12345;
            string s2=SimpleBits.TenToBinary(ten);
            Console.WriteLine("10진수 {0}--> 2진수: {1}",
                ten,s2);
            
            string sb = SimpleBits.BosuForOne(ten);
            Console.WriteLine("{0}에 대한 1의보수 : {1}",
                ten, sb);

            string s8 = SimpleBits.BosuForTwo(ten);
            Console.WriteLine("{0}에 대한 2의보수 : {1}",
                ten, s8);
        }
    }
}

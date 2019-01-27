using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int ten = 123;
            string s2 = SimpleBits.TenToBinary(ten);
            Console.WriteLine("10진수 {0}--> 2진수: {1}",
               ten, s2);
            string s8 = SimpleBits.TenToOcta(ten);
            Console.WriteLine("10진수 {0}--> 8진수: {1}",
                ten, s8);

            string s16 = SimpleBits.TenToHexa(ten);
            Console.WriteLine("10진수 {0}--> 16진수: {1}",
                ten, s16);
        }
    }
}

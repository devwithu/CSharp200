using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int ten = 123;
            string s2 = SimpleBits.TenToBinary(ten);
            Console.WriteLine("10���� {0}--> 2����: {1}",
               ten, s2);
            string s8 = SimpleBits.TenToOcta(ten);
            Console.WriteLine("10���� {0}--> 8����: {1}",
                ten, s8);

            string s16 = SimpleBits.TenToHexa(ten);
            Console.WriteLine("10���� {0}--> 16����: {1}",
                ten, s16);
        }
    }
}

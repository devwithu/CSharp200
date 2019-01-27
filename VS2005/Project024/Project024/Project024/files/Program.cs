using System;
using Com.JungBo.Maths;

namespace Com.JungBo.Basic {
    public class Program{
        public static void Main(string[] args){

            int ten=12345;
            string s2=SimpleBits.TenToBinary(ten);
            Console.WriteLine("10���� {0}--> 2����: {1}",
                ten,s2);
            
            string sb = SimpleBits.BosuForOne(ten);
            Console.WriteLine("{0}�� ���� 1�Ǻ��� : {1}",
                ten, sb);

            string s8 = SimpleBits.BosuForTwo(ten);
            Console.WriteLine("{0}�� ���� 2�Ǻ��� : {1}",
                ten, s8);
        }
    }
}

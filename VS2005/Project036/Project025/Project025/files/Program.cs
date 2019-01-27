using System;
using Com.JungBo.Maths;

namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){

            int ten = 68;
            string s2 = SimpleBits.TenToBinary(ten);
            Console.WriteLine("10���� {0}--> 2����: {1}",
                ten, s2);
           
            string sb1 = SimpleBits.BosuForOne(ten);
            Console.WriteLine("{0}�� ���� 1�Ǻ��� : {1}",
                ten, sb1);

            string sb2 = SimpleBits.BosuForTwo(ten);
            Console.WriteLine("{0}�� ���� 2�Ǻ��� : {1}",
                ten, sb2);
            string sb3 = SimpleBits.BosuForTwo2(ten);
            Console.WriteLine("{0}�� ���� 2�Ǻ��� : {1}",
                ten, sb3);
        }
    }
}

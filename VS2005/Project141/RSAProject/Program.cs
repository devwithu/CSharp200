using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args) {

            Console.WriteLine("�Է��ϼ���");
            string message = Console.ReadLine();
           
            int[] h = Korean.ToBits(message);
            //2byte�� �ѱ���
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();

            string str=Korean.ToKorea(h);
            Console.WriteLine(str);
        }
    }
}

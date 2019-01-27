using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args) {

            Console.WriteLine("입력하세요");
            string message = Console.ReadLine();
           
            int[] h = Korean.ToBits(message);
            //2byte가 한글자
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();

            string str=Korean.ToKorea(h);
            Console.WriteLine(str);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic {

    public class Program
    {
        public static void Main(string[] args)
        {
            
           
            RSA rsa = new RSA();
            rsa.Make();

            //N, E 공개
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //Console.WriteLine(ren.ToC(67));
            //"n보다 작은 정수를 입력해야 정상적으로 처리된다."


            int[] h = Korean.ToBits("놀러가요 Hello!!");


            //int[] h ={ 65,44,22,45,35,67};
            for (int i = 0; i < h.Length; i++)
            {
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//암호화
            ren.PrintAlpha();//암호화된 숫자 출력하기
            int[] m = ren.GepC();

            int[] rm = rsa.ToPS(m);//복호화
            for (int i = 0; i < rm.Length; i++){
               Console.Write(rm[i] + "\t");
            }
            Console.WriteLine();

            string sss = Korean.ToKorea(rm);
            Console.WriteLine(sss);

        }
    }
}

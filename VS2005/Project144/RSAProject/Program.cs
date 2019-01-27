using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            RSA rsa = new RSA();
            rsa.Make();

            //N, E 공개
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //"놀러가요 Hello!!"를 암호화 시킨다.
            int[] h = Korean.ToBits("놀러가요 Hello!!");
            //암호화되기전 한글을 숫자로 변환
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//암호화
            ren.PrintAlpha();//암호화된 숫자 출력하기

        }
    }
}

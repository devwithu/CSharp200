using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            RSA rsa = new RSA();
            rsa.Make();

            //N, E 공개
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //암화화 시키기 위해 숫자로 변환한다.
            int[] h = Korean.ToBits("놀러가요 Hello!!");
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//암호화
            ren.PrintAlpha();//암호화된 숫자 출력하기
            //암호화된 숫자를 얻어서
            int[] m = ren.GepC();
            //해독한다.
            int[] rm = rsa.ToPS(m);
            for (int i = 0; i < rm.Length; i++){
               Console.Write(rm[i] + "\t");
            }
            Console.WriteLine();
            //숫자를 한글로 변환시킨다.
            string sss = Korean.ToKorea(rm);
            Console.WriteLine(sss);
        }
    }
}

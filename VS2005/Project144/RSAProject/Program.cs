using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            RSA rsa = new RSA();
            rsa.Make();

            //N, E ����
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //"����� Hello!!"�� ��ȣȭ ��Ų��.
            int[] h = Korean.ToBits("����� Hello!!");
            //��ȣȭ�Ǳ��� �ѱ��� ���ڷ� ��ȯ
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//��ȣȭ
            ren.PrintAlpha();//��ȣȭ�� ���� ����ϱ�

        }
    }
}

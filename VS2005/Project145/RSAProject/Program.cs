using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            RSA rsa = new RSA();
            rsa.Make();

            //N, E ����
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //��ȭȭ ��Ű�� ���� ���ڷ� ��ȯ�Ѵ�.
            int[] h = Korean.ToBits("����� Hello!!");
            for (int i = 0; i < h.Length; i++){
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//��ȣȭ
            ren.PrintAlpha();//��ȣȭ�� ���� ����ϱ�
            //��ȣȭ�� ���ڸ� ��
            int[] m = ren.GepC();
            //�ص��Ѵ�.
            int[] rm = rsa.ToPS(m);
            for (int i = 0; i < rm.Length; i++){
               Console.Write(rm[i] + "\t");
            }
            Console.WriteLine();
            //���ڸ� �ѱ۷� ��ȯ��Ų��.
            string sss = Korean.ToKorea(rm);
            Console.WriteLine(sss);
        }
    }
}

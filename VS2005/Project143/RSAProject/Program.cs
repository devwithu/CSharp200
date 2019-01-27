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

            //N, E ����
            RsaEncode ren = new RsaEncode(rsa.N, rsa.E);
            //Console.WriteLine(ren.ToC(67));
            //"n���� ���� ������ �Է��ؾ� ���������� ó���ȴ�."


            int[] h = Korean.ToBits("����� Hello!!");


            //int[] h ={ 65,44,22,45,35,67};
            for (int i = 0; i < h.Length; i++)
            {
                Console.Write(h[i] + "\t");
            }
            Console.WriteLine();
            ren.SetP(h);//��ȣȭ
            ren.PrintAlpha();//��ȣȭ�� ���� ����ϱ�
            int[] m = ren.GepC();

            int[] rm = rsa.ToPS(m);//��ȣȭ
            for (int i = 0; i < rm.Length; i++){
               Console.Write(rm[i] + "\t");
            }
            Console.WriteLine();

            string sss = Korean.ToKorea(rm);
            Console.WriteLine(sss);

        }
    }
}

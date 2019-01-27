using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths {
    //StringBuilder
    public class SimpleBits {

        public const int MASK02=1;    

        //10������ 2������ ������ȯ
        public static string TenToBinary(int n) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                sb.Insert(0,aa);
                n >>= 1;//����Ʈ������ ����,��� ����
            }
            sb.Remove(0, sb.ToString().IndexOf("1"));
            return sb.ToString();
        }//
        //1�� ���� ����
        public static string BosuForOne(int n){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                int aa = (n & MASK02) ^ MASK02;
                sb.Insert(0, aa);
                n >>= 1;
            }
            sb.Remove(0, sb.ToString().IndexOf("1"));
            return sb.ToString();
        }//
        //2�� ���� ����
        public static string BosuForTwo(int n){
            StringBuilder sb = new StringBuilder();
            bool first = false;
            for (int i = 0; i < 32; i++)
            {
                int aa = 0;
                if ((n & MASK02) == 1 && !first)
                {//first!=true
                    aa = (n & MASK02);
                    first = true;
                }
                else if (first)
                {//first==true
                    aa = (n & MASK02) ^ MASK02;
                }
                sb.Insert(0, aa);
                n >>= 1;
            }
            sb.Remove(0, sb.ToString().IndexOf("1"));
            return sb.ToString();
        }//
        //2�� ���� ����
        public static string BosuForTwo2(int n){
            StringBuilder sb = new StringBuilder();
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                sb.Insert(0, aa);//������ �ٴ´�.
                n >>= 1;//����Ʈ������ ����,��� ����
            }
            
            int lastIndex = sb.ToString().LastIndexOf("1");
            string ts = sb.ToString().Substring(lastIndex);
            string bs = sb.ToString().Substring(0, lastIndex);
            sb.Remove(0,sb.Length);//��� �����
            //StringBuilder sbs = new StringBuilder(bs);
            sb.Append(bs);
            sb.Replace("1", "3")
            .Replace("0", "1")
            .Replace("3", "0");
            //000001���� 00000����
            sb.Remove(0, sb.ToString().IndexOf("1"));
            //�����ʿ��� �������� ó������ 1
            //���ö����� ������� �״��
            sb.Append(ts);//�ڷ� �ٴ´�.
            return sb.ToString();
        }//
    }
}

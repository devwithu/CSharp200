using System;
namespace Com.JungBo.Maths {
    //string
    public class SimpleBits {

        public const int MASK02=1;    

        //10������ 2������ ������ȯ
        public static string TenToBinary(int n) {
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                s = aa + s;
                n >>= 1;//����Ʈ������ ����,��� ����
            }
            s = s.Substring(s.IndexOf("1"));
            return s;
        }//
        //1�� ���� ����
        public static string BosuForOne(int n){
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = (n & MASK02) ^ MASK02;
                //�⺻Ÿ��+string-->string�� �ȴ�.
                s = string.Concat(aa, s);
                n >>= 1;
            }
            s = s.Substring(s.IndexOf("1"));
            return s;
        }//
        //2�� ���� ����
        public static string BosuForTwo(int n){
            string s = string.Empty;
            bool first = false;
            for (int i = 0;  i < 32; i++){
                int aa = 0;
                if ((n & MASK02)==1 && !first){
                    aa = (n & MASK02);
                    first = true;
                }
                else if (first){//first==true
                    aa = (n & MASK02) ^ MASK02;
                }
                s = string.Concat(aa, s);
                n >>= 1;
            }
            s = s.Substring(s.IndexOf("1"));
            return s;
        }//
        //2�� ���� ����
        public static string BosuForTwo2(int n){
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                s = string.Concat(aa, s);
                n >>= 1;//����Ʈ������ ����,��� ����
            }
            int lastIndex = s.LastIndexOf("1");
            string ts = s.Substring(lastIndex);
            string bs = s.Remove(lastIndex);
            //string bs = s.Substring(0, lastIndex);
            bs = bs.Replace("1", "3");//1->3->0
            bs = bs.Replace("0", "1");//0->1
            bs = bs.Replace("3", "0");  
            //000001���� 00000����
            bs = bs.Substring(bs.IndexOf("1"));
            //�����ʿ��� �������� ó������ 1
            //���ö����� ������� �״��
            bs += ts;
            return bs;
        }//
    }
}

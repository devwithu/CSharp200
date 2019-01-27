using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths {
    //��Ʈ ������
    public class SimpleBits {

        public const int MASK02=1;
        public const int MASK08 = 7;
        public const int MASK083 =3;
        //����� ���� ������ȯ
        public static string TenToBinary(int n) {
            string s = "";
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                s = aa + s;
                n /= 2;
            }
            return s;
        }//
        public static string BosuForOne(int n){
            string s = "";
            for (int i = 0; i < 32; i++){
                int aa = (n & MASK02) ^ MASK02;
                s = aa + s;
                n /= 2;
            }
            return s;
        }//
        public static string BosuForTwo(int n){
            string s = "";
            bool first = false;
            for (int i = 0; i < 32; i++){
                int aa = 0;
                if ((n & MASK02)==1 && !first){//first!=true
                    aa = (n & MASK02);
                    first = true;
                }
                else if (first){//first==true
                    aa = (n & MASK02) ^ MASK02;
                }
                
                s = aa + s;
                n /= 2;
            }
            return s;
        }//

        public static string TenToOcta(int n){
            string s = "";
            for (int i = 0; i < 32/3 +1; i++){
                int aa = 0;
                if (i < 32 / 3){
                    aa = n & MASK08;
                }
                else{
                    aa = n & MASK083;
                }
                s = aa + s;
                n /= 8;
            }
            return s;
        }//
    }
}

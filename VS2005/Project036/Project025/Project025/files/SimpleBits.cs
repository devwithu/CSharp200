using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths {
    //string
    public class SimpleBits {

        public const int MASK02=1;    

        //10진수를 2진수로 진수변환
        public static string TenToBinary(int n) {
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                s = aa + s;
                n >>= 1;//쉬프트연산은 음수,양수 무관
            }
            s = s.Substring(s.IndexOf("1"));
            return s;
        }//
        //1에 대한 보수
        public static string BosuForOne(int n){
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = (n & MASK02) ^ MASK02;
                //기본타입+string-->string이 된다.
                s = string.Concat(aa, s);
                n >>= 1;
            }
            s = s.Substring(s.IndexOf("1"));
            return s;
        }//
        //2에 대한 보수
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
        //2에 대한 보수
        public static string BosuForTwo2(int n){
            string s = string.Empty;
            for (int i = 0; i < 32; i++){
                int aa = n & MASK02;
                s = string.Concat(aa, s);
                n >>= 1;//쉬프트연산은 음수,양수 무관
            }
            int lastIndex = s.LastIndexOf("1");
            string ts = s.Substring(lastIndex);
            string bs = s.Substring(0, lastIndex);
            bs = bs.Replace("1", "3");//1->3->0
            bs = bs.Replace("0", "1");//0->1
            bs = bs.Replace("3", "0");  
            //000001에서 00000제거
            bs = bs.Substring(bs.IndexOf("1"));
            //오른쪽에서 왼쪽으로 처음으로 1
            //나올때까지 변경없이 그대로
            bs += ts;
            return bs;
        }//
    }
}

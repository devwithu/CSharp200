using System;
namespace Com.JungBo.Maths{
    public class SimpleBits{
        public const int MASK02 = 1;
        public const int MASK08 = 7; // 111
        public const int MASK083 = 3;//  11
        public const int MASK16 = 15;//1111

        //10진수를 2진수로 진수변환
        public static string TenToBinary(int n){
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
            for (int i = 0; i < 32; i++){
                int aa = 0;
                if ((n & MASK02) == 1 && !first){
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
        //0이 몇개 있는가 00000123 -->5
        private static int Location(string sixchars) {
            int count = 0;
            for (int i = 0; i < sixchars.Length; i++){
                if (sixchars[i] == '0'){
                    count++;
                }
                else{
                    break;
                }
            }
            return count;
        }
        //10진수를 16진수로 진수변환
        public static string TenToHexa(int n){
            string s = "";
            for (int i = 0; i < 8; i++){
                int aa = n & MASK16;
                s = Tosixteen(aa) + s;
                n >>= 4;
            }
            s = s.Substring(Location(s));
            return s;
        }//
        //0~15 사이의 수를 16진수로 바꾸기
        private static string Tosixteen(int m){
            string s = "";
            switch (m){
                case 10: s = "A"; break;
                case 11: s = "B"; break;
                case 12: s = "C"; break;
                case 13: s = "D"; break;
                case 14: s = "E"; break;
                case 15: s = "F"; break;
                default: s = m.ToString(); break;
            }
            return s;
        }
        //10진수를 8진수로 진수변환
        public static string TenToOcta(int n) {
            string s = "";
            for (int i = 0; i < 32 / 3 + 1; i++){
                int aa = 0;
                if (i < 32 / 3){
                    aa = n & MASK08;
                }
                else{
                    aa = n & MASK083;
                }
                s = aa + s;
                n >>= 3;
            }
            s = s.Substring(Location(s));
            return s;
        }//
    }
}

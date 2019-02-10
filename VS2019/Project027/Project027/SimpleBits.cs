using System;
namespace Com.JungBo.Maths
{
    //쉬프트 연산자
    public class SimpleBits
    {

        public const int MASK08 = 7; // 111
        public const int MASK083 = 3;//  11
        public const int MASK16 = 15;//1111

        //10진수를 16진수로 진수변환
        public static string TenToHexa(int n)
        {
            string s = "";
            for (int i = 0; i < 8; i++)
            {
                int aa = n & MASK16;
                s = Tosixteen(aa) + s;
                n >>= 4;
            }
            return s;
        }//
        //0~15 사이의 수를 16진수로 바꾸기
        public static string Tosixteen(int m)
        {
            string s = "";
            switch (m)
            {
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
        public static string TenToOcta(int n)
        {
            string s = "";
            for (int i = 0; i < 32 / 3 + 1; i++)
            {
                int aa = 0;
                if (i < 32 / 3)
                {
                    aa = n & MASK08;
                }
                else
                {
                    aa = n & MASK083;
                }
                s = aa + s;
                n >>= 3;
            }
            return s;
        }//
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths
{
    //비트 연산자
    public class SimpleBits
    {

        public const int MASK02 = 1;//1
        //양수에 대한 진수변환
        public static string TenToBinary(int n)
        {
            string s = "";
            for (int i = 0; i < 32; i++)
            {
                int aa = n & MASK02;
                s = aa + s;
                n /= 2;
            }
            return s;
        }//
        public static string BosuForOne(int n)
        {
            string s = "";
            for (int i = 0; i < 32; i++)
            {
                int aa = (n & MASK02) ^ MASK02;
                s = aa + s;
                n /= 2;
            }
            return s;
        }//
        public static string BosuForTwo(int n)
        {
            string s = "";
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

                s = aa + s;
                n /= 2;
            }
            return s;
        }//
    }
}

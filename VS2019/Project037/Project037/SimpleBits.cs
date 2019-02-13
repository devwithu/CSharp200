using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths
{
    //StringBuilder
    public class SimpleBits
    {

        public const int MASK02 = 1;

        //10진수를 2진수로 진수변환
        public static string TenToBinary(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                int aa = n & MASK02;
                sb.Insert(0, aa);
                n >>= 1;//쉬프트연산은 음수,양수 무관
            }
            sb.Remove(0, sb.ToString().IndexOf("1"));
            return sb.ToString();
        }//
        //1에 대한 보수
        public static string BosuForOne(int n)
        {
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
        //2에 대한 보수
        public static string BosuForTwo(int n)
        {
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
        //2에 대한 보수
        public static string BosuForTwo2(int n)
        {
            StringBuilder sb = new StringBuilder();
            string s = string.Empty;
            for (int i = 0; i < 32; i++)
            {
                int aa = n & MASK02;
                sb.Insert(0, aa);//앞으로 붙는다.
                n >>= 1;//쉬프트연산은 음수,양수 무관
            }

            int lastIndex = sb.ToString().LastIndexOf("1");
            string ts = sb.ToString().Substring(lastIndex);
            string bs = sb.ToString().Substring(0, lastIndex);
            sb.Remove(0, sb.Length);//모두 지우기
            //StringBuilder sbs = new StringBuilder(bs);
            sb.Append(bs);
            sb.Replace("1", "3")
            .Replace("0", "1")
            .Replace("3", "0");
            //000001에서 00000제거
            sb.Remove(0, sb.ToString().IndexOf("1"));
            //오른쪽에서 왼쪽으로 처음으로 1
            //나올때까지 변경없이 그대로
            sb.Append(ts);//뒤로 붙는다.
            return sb.ToString();
        }//
    }
}

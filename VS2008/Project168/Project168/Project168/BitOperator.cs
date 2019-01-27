using System;
namespace Com.JungBo.Logics{
    public class BitOperator{
        private int[] twoBit;
        private int[] eightBit;
        private int[] hxoBit;
        public BitOperator(){
            twoBit = new int[8 * 4];
            eightBit = new int[11];
            hxoBit = new int[8 * 1];
        }
        public void MakeTo2(int m){
            int PIVOT = 1;
            int n = m;
            int count = twoBit.Length;
            Array.Clear(twoBit, 0, count);//0으로 초기화
            while (n != 0 && count > 0){
                twoBit[--count] = n & PIVOT;
                n >>= 1;
            }
        }
        public void Show2(){
            bool zeros = false;
            int count = twoBit.Length;
            for (int i = 0; i < count; i++){
                //zeros==true와 zeros는 동일
                if (twoBit[i] != 0 || zeros){
                    Console.Write("{0}", twoBit[i]);
                    zeros = true;
                }
            }
            Console.WriteLine("(2)");
        }
        public void MakeTo8(int m){
            int PIVOT = 7;
            int n = m;
            int count = eightBit.Length;
            Array.Clear(eightBit, 0, count);
            while (n != 0 && count > 0){
                eightBit[--count] = n & PIVOT;
                if (count >= 2){
                    n >>= 3;
                }
                else{
                    PIVOT = 3;
                    n >>= 3;
                }
            }
        }
        public void Show8(){
            bool zeros = false;
            int count = eightBit.Length;
            for (int i = 0; i < count; i++){
                if (eightBit[i] != 0 || zeros){
                    Console.Write("{0}", eightBit[i]);
                    zeros = true;
                }
            }
            Console.WriteLine("(8)");
        }
        public void MakeTo16(int m){
            int PIVOT = 15;
            int n = m;
            int count = hxoBit.Length;
            Array.Clear(hxoBit, 0, count);
            while (n != 0 && count > 0){
                hxoBit[--count] = n & PIVOT;
                n >>= 4;
            }
        }
        public void Show16(){
            bool zeros = false;
            int count = hxoBit.Length;
            for (int i = 0; i < count; i++){
                if (hxoBit[i] != 0 || zeros){
                    Console.Write("{0}", Tos(hxoBit[i]));
                    zeros = true;
                }
            }
            Console.WriteLine("(16)");
        }
        // 10 - A, 11 -B...  16진수 10이상은 영문으로 변환해야됨
        public string Tos(int m){
            string s = "";
            switch (m){
                case 10: s = "A"; break;
                case 11: s = "B"; break;
                case 12: s = "C"; break;
                case 13: s = "D"; break;
                case 14: s = "E"; break;
                case 15: s = "F"; break;
                default: s = string.Concat(m); break;
            }
            return s;
        }
    }
}

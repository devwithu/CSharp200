using System;

namespace Com.JungBo.Middle.Oper{
    public class BitOperator{
        //0~15 사이의 수를 16진수로 바꾸기
        public string Tosixteen(int m){
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
        }//Tosixteen
        //10진수를 16진수로 바꿔 출력
        public void PrintSixteen() {
            for (int i = 0; i < 16; i++){
                string s = Tosixteen(i);
                Console.Write("{0}   ",s);
            }
            Console.WriteLine();
        }//PrintSixteen
    }
}

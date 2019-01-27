using System;
using System.Collections.Generic;
using System.Text;
//Math.Abs() 사용
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("다이아몬드를 출력합니다.");
            Console.Write("홀수인 정수 한개의 입력하세요: ");
            int iNum = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            Asterisk.ShowDiamond(iNum);
            Console.WriteLine();
            Asterisk.ShowReverseDiamond(iNum);
        }
    }
    public class Asterisk{
        //다이아몬드형
        public static void ShowDiamond(int n){
            for (int i = 0; i < n; i++){
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write(" ");
                }
                for (int k = 0; k < n - 2 * Math.Abs(i - n / 2); k++){
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
        //공백과 X과 바뀐 다이아몬드형
        public static void ShowReverseDiamond(int n){
            for (int i = 0; i < n; i++){
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write("X");
                }
                for (int k = 0; k < n - 2 * Math.Abs(i -n / 2); k++){
                    Console.Write(" ");
                }
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
    }
}

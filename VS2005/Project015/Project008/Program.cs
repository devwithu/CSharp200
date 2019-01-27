using System;
using System.Collections.Generic;
using System.Text;
//등차수열 2 * i + 1
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("삼각형을 출력합니다.");
            Console.Write("정수 한개를 입력하세요: ");
            int iNum = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환
            Asterisk.ShowStageTree(iNum);
            Console.WriteLine();
            Asterisk.ShowStageV(iNum);
        }
    }
    public class Asterisk{
        public static void ShowStageTree(int n){
            for (int i = 0; i < n; i++){
                for (int k = 0; k < n - i - 1; k++){
                    Console.Write(" ");
                }//in for
                for (int j = 0; j < 2 * i + 1; j++){
                    Console.Write("X");
                }//in for
                Console.WriteLine();
            }//out for
        }//
        public static void ShowStageV(int n){
            for (int i = 0; i < n; i++){
                for (int k = 0; k < n - i - 1; k++){
                    Console.Write("X");
                }//in for
                for (int j = 0; j < 2 * i + 1; j++){
                    Console.Write(" ");
                }//in for
                for (int k = 0; k < n - i - 1; k++){
                    Console.Write("X");
                }//in for
                Console.WriteLine();
            }//out for
        }//
    }
}

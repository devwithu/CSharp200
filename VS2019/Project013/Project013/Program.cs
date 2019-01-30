using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jungbo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("입력받은 수 만큼 X를 출력합니다.");

            Console.Write("한개의 정수를 입력하세요: ");
            int iNum = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            Asterisk.ShowLine(iNum);
        }
    }
    public class Asterisk
    {
        //입력받은 수 만큼 X를 출력한다.
        public static void ShowLine(int n)
        {
            //n이 3이면 i가 0,1,2일 때 x 출력 
            for (int i = 0; i < n; i++)
            {
                Console.Write("X");//옆으로 붙여서
            }
            Console.WriteLine();//아래로 한 줄
        }//
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Basic
{
    public class OneFor
    {
        public static void Main(string[] args)
        {
            Asterisk.ShowLine(20);
        }
    }
    //같은 네임스페이스에 새로운 클래스 선언
    public class Asterisk{
        //입력받은 수 만큼 X를 출력한다.
        public static void ShowLine(int n){
            //n이 3이면 i가 0,1,2일 때 x 출력 
            for (int i = 0; i < n; i++){
                Console.Write("X");//옆으로 붙여서
            }
            Console.WriteLine();//아래로 한 줄
        }//
    }
}

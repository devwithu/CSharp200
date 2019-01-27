using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jungbo.Basic
{ 
    public class Hello
    {

    
        public static void Main(string[] args)
        {
            Console.WriteLine("덧셈을 하려고 합니다. 두 수를 입력하세요.");

            Console.Write("첫번째 수를 입력하세요: ");
            int num1 = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            Console.Write("두번째 수를 입력하세요: ");
            int num2 = int.Parse(Console.ReadLine());//두 번째 수 입력후 변환

            //{0}위치에 num1이, {1}위치에 num2이 들어간다.
            Console.WriteLine("두수의 합: {0}+{1}={2}", num1, num2, num1 + num2);
        }
    }
}

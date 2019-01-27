using System; //System에 있는 Console을 사용한다.

namespace Com.Jungbo.Basic
{
    /// <summary>
    /// 두수를 입력받는다. 두 수를 각각 int로 변환시킨다.
    /// 두수를 합하여 결과를 출력한다.
    /// </summary>
    public class HelloMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("덧셈을 하려고 합니다. 두 수를 입력하세요.");

            Console.Write("첫번째 수를 입력하세요: ");
            int num1 = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            Console.Write("두번째 수를 입력하세요: ");
            int num2 = int.Parse(Console.ReadLine());//두 번째 수 입력후 변환

            //{0}위치에 num1이, {1}위치에 num2이 들어간다.
            Console.WriteLine("두수의 합: {0}+{1}={2}",num1,num2,num1+num2);
        }
    }
}

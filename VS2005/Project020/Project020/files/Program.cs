
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            //2~100 짝수의 합
            int iEvenSum = Numbers.SumOfEven(100);
            //1~99 홀수의 합
            int iOddSum = Numbers.SumOfOdd(100);
            //using 없을 경우
            System.Console.WriteLine("2~100 짝수의 합 :{0}",iEvenSum);
            System.Console.WriteLine("1~99 홀수의 합 :{0}", iOddSum);
        }
    }
}

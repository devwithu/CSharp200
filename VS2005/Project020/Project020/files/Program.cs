
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            //2~100 ¦���� ��
            int iEvenSum = Numbers.SumOfEven(100);
            //1~99 Ȧ���� ��
            int iOddSum = Numbers.SumOfOdd(100);
            //using ���� ���
            System.Console.WriteLine("2~100 ¦���� �� :{0}",iEvenSum);
            System.Console.WriteLine("1~99 Ȧ���� �� :{0}", iOddSum);
        }
    }
}

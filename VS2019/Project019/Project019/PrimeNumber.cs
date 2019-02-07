using System;
//for break
namespace Com.JungBo.Logic
{
    public class PrimNumber
    {
        public static bool IsPrime1(int n)
        {
            bool isP = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }//
        public static bool IsPrime2(int n)
        {
            bool isP = true;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }//

        public static void PrintPrime(int n)
        {
            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                //if (IsPrime1(i)){//솟수라면
                if (IsPrime2(i))
                {//IsPrime2(i)==true 동일
                    Console.Write("{0}\t", i);
                    count++; //count=count+1과 동일
                }
            }
            Console.WriteLine();
            Console.WriteLine("2부터 {0}까지 약수: {1}개",
                n, count);
        }
    }
}

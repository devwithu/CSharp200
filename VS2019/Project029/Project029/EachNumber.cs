using System;

namespace Com.JungBo.Game
{
    //do~while
    public class EachNumber
    {

        public int Sum(int n)
        {
            int total = 0;
            do
            {
                total += n % 10;
                n /= 10;
            } while (n != 0);

            return total;
        }//

        public void PrintSum(int m)
        {
            for (int i = 0; i <= m; i++)
            {
                Console.WriteLine("{0}의 각 자리수의 합: {1}",
                    i, Sum(i));
            }
        }//
    }
}

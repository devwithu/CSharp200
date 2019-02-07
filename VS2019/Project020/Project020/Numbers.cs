using System;
//continue
namespace Com.JungBo.Basic
{
    public class Numbers
    {
        //짝수의 합
        public static int SumOfEven(int num)
        {
            int total = 0;
            for (int i = 2; i <= num; i = i + 2)
            {
                //if(i%2==0){//짝수면 
                total = total + i;//합하자
                //}
            }
            return total;
        }
        //홀수의합
        public static int SumOfOdd(int num)
        {
            int total = 0;
            for (int i = 1; i <= num; i++)
            {
                if (i % 2 == 1)
                {//i%2!=0 동일,홀수면 
                    total = total + i;//합하자
                }
                else
                { //짝수면
                    continue; //i 다음스텝에서 계속
                }
            }
            return total;
        }
    }
}

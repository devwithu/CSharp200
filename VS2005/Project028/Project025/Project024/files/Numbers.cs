using System;
namespace Com.JungBo.Maths{
    public class Numbers{
        /// <summary>
        /// 1만들기 함수 n이 짝수면 n/2 홀수면 n*3+1
        /// </summary>
        public static void MakeOne(int n){
            int time = 0;
            Console.WriteLine("{0}에서 1이 되가는 과정", n);

            while (n != 1) {//1아니면 반복한다.
                if (n % 2 == 0){
                    n /= 2;
                }
                else{
                    n = n * 3 + 1;
                }
                Console.Write("{0} ", n);
                time++;
            }
            Console.WriteLine("\n몇번 거쳤나? {0}", time);
        }
    }
}

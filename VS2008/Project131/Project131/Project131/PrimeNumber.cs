using System;
//for break
namespace Com.JungBo.Logic{
    public class PrimeNumber{
        public static bool IsPrime(int n){
            bool isP = true;
            for (int i = 2; i <= (int)(Math.Sqrt(n)); i++){
                if (n % i == 0){
                    isP = false;
                    break;
                }
            }
            return isP;
        }//
        public static void PrintPrime(int n){
            int count = 0;
            for (int i = 2; i <= n; i++){
                if (IsPrime(i)){//IsPrime(i)==true 동일
                    Console.Write("{0}\t", i);
                    count++; //count=count+1과 동일
                    if (count % 10 == 0) { Console.WriteLine(); }
                }
            }
            Console.WriteLine();
            Console.WriteLine("2부터 {0}까지 약수: {1}개",
                n,count);
        }
    }
}

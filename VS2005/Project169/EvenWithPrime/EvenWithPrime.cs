using System;
namespace Com.JungBo.Logic{
 public class EvenWithPrime{
    private int count;
    private int originNum;
    //소수의 합이 짝수를 이룰 경우
    public void PrintNums(int num){
        count = 0;  //멤버필드로 0으로 초기화
        this.originNum = num;
        int startNum = 2;
        int endNum=0;
        String st = String.Empty;
        if ((num %2!= 0)||PrimeNumber.IsPrime(num/2)){
            endNum = num / 2;
        }
        else{
            endNum = (num / 2) - 1;
        }
        for (int i = startNum; i <= endNum; i++){
            if (PrimeNumber.IsPrime(i)) {
                st = i.ToString();
                PrintNumsCheck(i, num, st);
            }
        }
        Console.WriteLine("갯수 :" + count);
    }//
    //PrintNums을 호출
    private void PrintNumsCheck(int startNum,int num,string st){
        int n = num - startNum;
        if (PrimeNumber.IsPrime(n)){
            count++;
            Console.WriteLine("{0}= {1} + {2}",
                         originNum, st, n.ToString());
            PrintNums(startNum, n, st);
            st = String.Empty;
        }
        else{
            PrintNums(startNum, n, st);
        }
    }//
    //PrintNumsCheck을 호출
    private void PrintNums(int startNum, int num, string st){
        int endNum = num;
        String st_keep = st;
        if ((num % 2 != 0)||PrimeNumber.IsPrime(num / 2)){
            endNum = num / 2;
        }
        else{
            endNum = (num / 2) - 1;
        }
        for (int i = startNum; i <= endNum; i++){
            if (PrimeNumber.IsPrime(i)){
                st += " + " + i.ToString();
                PrintNumsCheck(i, num, st);
                st = st_keep;
            }
        }
    }//
    //2개의 소수의 합으로 이루어 질 경우를 출력
    public void Print2Num(int num){
        int startNum = 2;
        int endNum;
        if ((num % 2 != 0) ||PrimeNumber.IsPrime(num / 2)){
            endNum = num / 2;
        }
        else{
            endNum = (num / 2) - 1;
        }
        for (int i = startNum; i <= endNum; i++){
            if (PrimeNumber.IsPrime(i)
                  && PrimeNumber.IsPrime(num - i)){
                Console.Write("{0}= ", num);
                Console.Write(i);
                Console.WriteLine(" + " + (num - i));
            }
        }
    }//
 }
}

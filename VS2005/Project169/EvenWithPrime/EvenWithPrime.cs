using System;
namespace Com.JungBo.Logic{
 public class EvenWithPrime{
    private int count;
    private int originNum;
    //�Ҽ��� ���� ¦���� �̷� ���
    public void PrintNums(int num){
        count = 0;  //����ʵ�� 0���� �ʱ�ȭ
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
        Console.WriteLine("���� :" + count);
    }//
    //PrintNums�� ȣ��
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
    //PrintNumsCheck�� ȣ��
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
    //2���� �Ҽ��� ������ �̷�� �� ��츦 ���
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

using System;
//continue
namespace Com.JungBo.Basic{
    public class Numbers{
        //¦���� ��
        public static int SumOfEven(int num){
            int total = 0;
            for (int i = 2; i <=num; i=i+2){
                //if(i%2==0){//¦���� 
                    total = total + i;//������
                //}
            }
            return total;
        }
        //Ȧ������
        public static int SumOfOdd(int num){
            int total = 0;
            for (int i = 1; i <= num; i++){
                if (i % 2 == 1) {//i%2!=0 ����,Ȧ���� 
                    total = total + i;//������
                }
                else { //¦����
                    continue; //i �������ܿ��� ���
                }
            }
            return total;
        }
    }
}

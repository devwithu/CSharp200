using System;
namespace Com.Jungbo.Logic{
   public class EratosTenesChe{
       int[] era10 = { 2};  //2 �⺻ �Ҽ�
  //int[] era10 = { 2, 3, 5, 7 };//2~10������ �⺻�Ҽ�
        int[] eratemp;
        int[] era;
        int n;   //10^2n������ �Ҽ�
        //10^2n�� n�� 1�̸� 100, 2�� 10000
       public EratosTenesChe(int n){
           this.n = n;
       }
      
        //1~10^2n ä��(1, 2, 3, 4, ...10^2n)
        public void Fill(int m) {
         //era = new int[(int)(Math.Pow(10, (int)(Math.Pow(10, m))))];
         era = new int[(int)(Math.Pow(2,(int)(Math.Pow(2,m))))];
            for (int i = 0; i < era.Length; i++ ) {
                era[i] = i + 1;//1~10^2n
            }
        }//
       public void ReMake() {
           for (int i = 0; i < n; i++){
               Make(i+1);
           }
       }
       private void Make(int m) {
            Fill(m);
            int count = 0;
            for (int i = 0; i < era10.Length; i++){
                for (int j = 0; j < era.Length; j++) {
                    //������ �������� �� ����
                    if (era[j] % era10[i] == 0 ) {
          //���� 1�̰ų� ������ �������� ���� 1�� �ٲ�
                        era[j] = 1; 
                        count++;
                    }
                }
            }
   //��ü��-1(1�� �Ҽ��� �ƴ�)-count(������ �������¼�)
            eratemp = new int[era.Length - count -1];
            int te = 0;
            for (int j = 0; j < era.Length; j++){
                if (era[j] != 1){
                    //1�μ��� �����ϰ� �ƴѼ���
                    eratemp[te++] = era[j];
                }
            }
    //�ӽ� �迭 -> �⺻ �Ҽ�+�⺻�Ҽ����� ���� �Ҽ�
    int[] era10Twice = new int[eratemp.Length+era10.Length];
    //�⺻�Ҽ��� ä��
    Array.Copy(era10,0,era10Twice,0,era10.Length);
    //�⺻ �Ҽ����� ���� �Ҽ��� ä��
    Array.Copy(eratemp,0, era10Twice, era10.Length, eratemp.Length);
    //�߰��� �Ҽ��� �⺻�Ҽ��� ����
    era10 = new int[era10Twice.Length];
    //
    Array.Copy(era10Twice, 0, era10, 0, era10Twice.Length);
            
        }//Make

       public void PrintErotos() {
           for (int i = 0; i < era10.Length; i++){
               Console.Write("{0}\t", era10[i]);
               if ((i + 1) % 10 == 0){
                   Console.WriteLine();
               }
           }
           Console.WriteLine("\n2���� {0}���� ���: {1}��",
               era.Length, era10.Length);
       }
    }
}

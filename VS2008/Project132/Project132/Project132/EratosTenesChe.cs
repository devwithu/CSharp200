using System;
namespace Com.Jungbo.Logic{
   public class EratosTenesChe{
       int[] era10 = { 2};  //2 기본 소수
  //int[] era10 = { 2, 3, 5, 7 };//2~10까지의 기본소수
        int[] eratemp;
        int[] era;
        int n;   //10^2n까지의 소수
        //10^2n승 n이 1이면 100, 2면 10000
       public EratosTenesChe(int n){
           this.n = n;
       }
      
        //1~10^2n 채움(1, 2, 3, 4, ...10^2n)
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
                    //나누어 떨어지는 수 제거
                    if (era[j] % era10[i] == 0 ) {
          //원래 1이거나 나누어 떨어지는 수를 1로 바꿈
                        era[j] = 1; 
                        count++;
                    }
                }
            }
   //전체수-1(1은 소수가 아님)-count(나누어 떨어지는수)
            eratemp = new int[era.Length - count -1];
            int te = 0;
            for (int j = 0; j < era.Length; j++){
                if (era[j] != 1){
                    //1인수를 제거하고 아닌수만
                    eratemp[te++] = era[j];
                }
            }
    //임시 배열 -> 기본 소수+기본소수에서 얻은 소수
    int[] era10Twice = new int[eratemp.Length+era10.Length];
    //기본소수를 채움
    Array.Copy(era10,0,era10Twice,0,era10.Length);
    //기본 소수에서 얻은 소수를 채움
    Array.Copy(eratemp,0, era10Twice, era10.Length, eratemp.Length);
    //추가된 소수를 기본소수로 만듬
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
           Console.WriteLine("\n2부터 {0}까지 약수: {1}개",
               era.Length, era10.Length);
       }
    }
}

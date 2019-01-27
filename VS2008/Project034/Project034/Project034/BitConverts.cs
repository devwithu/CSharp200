using System;
namespace Com.JungBo.Logics {
    //--, ++
    public class BitOperator {
        int PIVOT = 1;  //2진수 비트마스크
        public void MakeTo2(int m){

            int [] twoBit=new int [32];//생성(자동초기화)
            int count = twoBit.Length;  //32, 배열의 크기
            int nums = 0;
            while (m != 0 && count > 0){
                twoBit[--count] = m & PIVOT;
                m >>= 1;  //부호관계없는 한자리 버리기
                nums++;
            }
            for (int i = twoBit.Length - nums; i < twoBit.Length; i++){
                Console.Write("{0}",twoBit[i]);
            }
            Console.WriteLine();
        }
        public int[] MakeTo2es(int m){

            int[] twoBit = new int[32];//생성(자동초기화)
            int count = twoBit.Length;  //32, 배열의 크기
            int nums = 0;
            while (m != 0 && count > 0)
            {
                twoBit[--count] = m & PIVOT;
                m >>= 1;  //부호관계없는 한자리 버리기
                nums++;
            }
            int[] results = new int[nums];
            Array.Copy(twoBit, twoBit.Length - nums,results,0,nums);
            return results;
        }
        public static void Print(int[]m) {
            for (int i = 0; i < m.Length; i++){
                Console.Write(m[i]);
            }
            Console.WriteLine();
        }
    }//class
}

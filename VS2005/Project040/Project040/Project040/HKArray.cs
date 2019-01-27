using System;
namespace Com.JungBo.Maths{
    public class HKArray{
        //같은 크기의 m,n 배열을 서로 바꾸기
        public static void SwapArray(int[]m,int []n) {
            int count = m.Length;
            int[] temp = new int[count];//0으로 초기화
            //m->temp
            Array.Copy(m, temp, count);
            //n->m
            Array.Copy(n, m, count);
            //temp->n
            Array.Copy(temp,n, count);
        }//SwapArray
        public static void PrintArray(int[]m) {
            foreach (int num in m){
                Console.Write("{0}  ",num);
            }
            Console.WriteLine();
        }//PrintArray
		
        public static void Clear(int []m, int n) {
            if (n == 0){
                //0으로 만들기
                Array.Clear(m, 0, m.Length);
            }
            else {
                for (int i = 0; i < m.Length; i++){
                    m[i] = n;//n으로 모두 만들기
                }
            }//else
        }//Clear
    }
}

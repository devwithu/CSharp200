using System;
namespace Com.JungBo.Logics {
    //params
    public class Bubble {
        public static void DescSort(params int[] m){
            int count = m.Length;
            for (int i = 0; i < count - 1; i++){
                for (int j = 0; j < count - 1 - i; j++){
                    if (m[j] < m[j + 1]){ 
                        //swapping
                        Swap(ref m[j], ref m[j + 1]);
                    }//if
                }//inner for
            }//outter for

            Print(m);
        }//
        //swapping 
        public static void Swap(ref int a, ref int b){
            int temp = a;
            a = b;
            b = temp;
        }
        public static void Print(params int[] m){
            foreach (int num in m){
                 Console.Write("{0}\t",num);  
            }
            Console.WriteLine();
        }
    }
}

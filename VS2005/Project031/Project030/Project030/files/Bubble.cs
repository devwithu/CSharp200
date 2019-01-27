using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logics {
    //ref
    public class Bubble {

        public static void AscSort(int[] m){
            int count = m.Length;
            for (int i = 0; i < count - 1; i++){
                for (int j = 0; j < count - 1 - i; j++){
                    if (m[j] > m[j + 1]){ 
                        //swapping
                        Swap(ref m[j], ref m[j + 1]);
                    }//if
                }//inner for
            }//outter for
        }
        //swapping 
        public static void Swap(ref int a, ref int b){
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Print(int [] m) {
            for (int i = 0; i < m.Length; i++){
                Console.Write("{0}\t",m[i]);  
            }
            Console.WriteLine();
        }
    }
}

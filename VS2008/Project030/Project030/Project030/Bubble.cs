using System;
namespace Com.JungBo.Logics {
    //1차원배열
    public class Bubble {

        public static void AscSort(int[] m){
            int count = m.Length;
            for (int i = 0; i < count - 1; i++){
                for (int j = 0; j < count - 1 - i; j++){
                    if (m[j] > m[j + 1]){ 
                        //swapping
                        int temp = m[j];
                        m[j] = m[j + 1];
                        m[j + 1] = temp;
                      
                    }//if
                }//inner for
            }//outter for
        }

        public static void Print(int [] m) {
            for (int i = 0; i < m.Length; i++){
                Console.Write("{0}\t",m[i]);  
            }
            Console.WriteLine();
        }
    }
}

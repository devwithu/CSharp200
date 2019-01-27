using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logics {
    //foreach
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
        //for-->foreach
        public static void Print(int [] m) {
            foreach (int num in m){
                 //num = 5;  �ݺ������� ���� �Ұ���
                 Console.Write("{0}\t",num);  
            }
            Console.WriteLine();
        }//
    }
}

using System;
namespace Com.JungBo.Sorts{
    public class SortUtil{
        public static void Swap(ref int m, ref int n) {
            int temp = m;
            m = n;
            n = temp;
        }
        public static void Print(int[] select){
            for (int i = 0; i < select.Length; i++){
                Console.Write("{0} ", select[i]);
            }
            Console.WriteLine();
        }//
        public static void Swap<T>(ref T m, ref T n){
            T temp = m;
            m = n;
            n = temp;
        }//
        public static void Print<T>(T[] select){
            for (int i = 0; i < select.Length; i++){
                Console.Write("{0} ", select[i]);
            }
            Console.WriteLine();
        }//
    }
}

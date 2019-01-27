using System;
namespace Com.JungBo.Game{
    public class BaseBallUtil{
        public static void Fill(int[] m, int n){
            int count = m.Length;
            for (int i = 0; i < count; i++){
                m[i] = n;
            }
        }//
        public static void Print(int[] lott) {
            Console.Write("[");
            foreach (int m in lott){
                Console.Write("{0}\t", m);
            }
            Console.WriteLine("]");
        }//
    }
}

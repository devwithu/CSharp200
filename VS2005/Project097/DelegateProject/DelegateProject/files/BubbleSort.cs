using System;
namespace Com.JunBo.Logic {
    public class BubbleSort{
        //Generic Method+ where
        public static void SortByBubble<T>(T[] t)
            where T : IComparable{
            int count = t.Length;
            for (int i = 0; i < count - 1; i++){
                for (int j = 0; j < count - 1 - i; j++) {
                    //Áõ°¡¼ø
                    if (t[j].CompareTo(t[j + 1])>0){
                        T temp = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = temp;
                    }//
                }//
            }//
        }//Bubble
        public static void Reverse<T>(T[] t){
            int count = t.Length;
            for (int i = 0; i < count / 2; i++){
                T temp = t[i];
                t[i] = t[count - 1 - i];
                t[count - 1 - i] = temp;
            }
        }
        public static void Print<T>(T[] n){
            foreach (T tvar in n){
                Console.Write("{0}\t", tvar);
            }
            Console.WriteLine();
        }
    }//BubbleSort class
}

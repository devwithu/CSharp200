using System;
namespace Com.JungBo.Logic {
    //섹션 94,97 제네릭 참고 
    public class NumberGen<T>{
        private static int SEED = 17;
        //Generic Method
        public static void Shuffle(T[]cards){
            Random r = new Random(SEED++ 
                +System.DateTime.Now.Millisecond);
            int count = cards.Length;
            for (int i = 0; i < count; i++){
                T t = cards[i];
                int next = r.Next(count);
                cards[i] = cards[next];
                cards[next] = t;
            }
        }//
        public static void Reverse(T[] t){
            int count = t.Length;
            for (int i = 0; i < count / 2; i++){
                T temp = t[i];
                t[i] = t[count - 1 - i];
                t[count - 1 - i] = temp;
            }
        }
        public static void Print(T[] n){
            foreach (T tvar in n){
                Console.Write("{0}\t", tvar);
            }
            Console.WriteLine();
        }
    }//NumberGen class
}

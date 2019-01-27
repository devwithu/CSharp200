using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic {
    public class NumberGen{

        //Generic Method
        public static void Shuffle<T>(T[]cards){
            Random r = new Random();
            int count = cards.Length;
            for (int i = 0; i < count; i++){
                T t = cards[i];
                int next = r.Next(count);
                cards[i] = cards[next];
                cards[next] = t;
            }
        }//
        public static void Print<T>(T[] n){
            foreach (T tvar in n){
                Console.Write("{0}\t", tvar);
            }
            Console.WriteLine();
        }
    }//CardSort class
}

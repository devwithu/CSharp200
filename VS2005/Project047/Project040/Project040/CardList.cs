using System;
//using System.Collections.Generic;
//using System.Text;
using System.Collections;   //ArrayList 때문에 using
namespace Com.JungBo.Logic{
    //IEnumerator 과 static 메서드, static 변수
    public class CardList{
        // 카드 순서 (♠ > ◆ > ♥ > ♣)
        public  static string[] DECK ={ "S","D","H","C"};
        public  static string[] SUIT 
        ={ "A","2","3","4","5","6","7","8","9","T","J","Q","K" };

        //중요한 데이터 멤버
        ArrayList list = new ArrayList(10);//처음 Capacity 10

        public void MakeCard() {
            list.Clear();//list 비우기
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //SA,S2, S3, .... 대입
                    //list에 채우기
                    list.Add(string.Concat(deck,suit));
                }
            }
        }//
        public void PrintCard(){
            int i = 0;
            IEnumerator iters = list.GetEnumerator();
            while(iters.MoveNext()){
                string cards = iters.Current as string;
                Console.Write("{0}  ", cards);
                if ((i++ + 1) % SUIT.Length == 0)
                {
                    Console.WriteLine();
                }
            }
        }//

        public string[] ToArray(){

            object[] objs = list.ToArray();

            string[] strs = new string[objs.Length];

            for (int i = 0; i < objs.Length; i++){
                strs[i] = objs[i] as string;
            }
            return strs;
        }
    }//class
}

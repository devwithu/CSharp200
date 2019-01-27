using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
    public class CardQueue{
        Queue<Card> que = new Queue<Card>();

        public void MakeCards(){
            que.Clear();//큐청소
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.Suffle();
            //dic.PrintCards();  //만들어진 카드 보이기
            for (int i = 0; i < dic.Count; i++){
                //인덱서를 이용하여 Card를 얻고
                //큐에 넣는다.
                que.Enqueue(dic[i]);
            }
        }//
        public Card NextCard() {
            if (que.Count == 0){
                throw new Exception("Card가 더이상 존재하지 않습니다.");
            }
            else {
                return que.Dequeue();
            }
        }//
        //큐에 있던 카드 출력
        public void PrintCards() {
            if(que.Count==0){
                Console.Write("더이상 카드가 없습니다. ");
                Console.WriteLine("카드를 새로 만드세요.-------");
                return;
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("현재 카드개수{0}",que.Count);
            Console.Write(" You: {0},",que.Dequeue());//빼내기
            Console.Write(" Me: {0},", que.Dequeue());
            Console.Write(" You: {0},", que.Dequeue());
            Console.WriteLine(" Me: {0}", que.Dequeue());
        }
    }
}

using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
    public class CardStack{
        Stack<Card> stack = new Stack<Card>();

        public void MakeCards(){
            stack.Clear();//큐청소
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.Suffle();
            dic.PrintCards();  //만들어진 카드 보이기
            for (int i = 0; i < dic.Count; i++){
                //인덱서를 이용하여 Card를 얻고
                //스택에 넣는다.
                stack.Push(dic[i]);
            }
        }//
        //큐에 있던 카드 출력
        public void PrintCards(){
            if (stack.Count == 0){
                Console.Write("더이상 카드가 없습니다. ");
                Console.WriteLine("카드를 새로 만드세요.-------");
                return;
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("현재 카드개수{0}", stack.Count);
            Console.Write(" You: {0},", stack.Pop());//빼내기
            Console.Write(" Me: {0},", stack.Pop());
            Console.Write(" You: {0},", stack.Pop());
            Console.WriteLine(" Me: {0}", stack.Pop());
        }
    }
}

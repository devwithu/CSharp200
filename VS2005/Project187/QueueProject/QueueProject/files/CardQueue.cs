using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
    public class CardQueue{
        Queue<Card> que = new Queue<Card>();

        public void MakeCards(){
            que.Clear();//ťû��
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.Suffle();
            //dic.PrintCards();  //������� ī�� ���̱�
            for (int i = 0; i < dic.Count; i++){
                //�ε����� �̿��Ͽ� Card�� ���
                //ť�� �ִ´�.
                que.Enqueue(dic[i]);
            }
        }//
        //ť�� �ִ� ī�� ���
        public void PrintCards() {
            if(que.Count==0){
                Console.Write("���̻� ī�尡 �����ϴ�. ");
                Console.WriteLine("ī�带 ���� ���弼��.-------");
                return;
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("���� ī�尳��{0}",que.Count);
            Console.Write(" You: {0},",que.Dequeue());//������
            Console.Write(" Me: {0},", que.Dequeue());
            Console.Write(" You: {0},", que.Dequeue());
            Console.WriteLine(" Me: {0}", que.Dequeue());
        }
    }
}

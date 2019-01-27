using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
    public class CardStack{
        Stack<Card> stack = new Stack<Card>();

        public void MakeCards(){
            stack.Clear();//ťû��
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.Suffle();
            dic.PrintCards();  //������� ī�� ���̱�
            for (int i = 0; i < dic.Count; i++){
                //�ε����� �̿��Ͽ� Card�� ���
                //���ÿ� �ִ´�.
                stack.Push(dic[i]);
            }
        }//
        //ť�� �ִ� ī�� ���
        public void PrintCards(){
            if (stack.Count == 0){
                Console.Write("���̻� ī�尡 �����ϴ�. ");
                Console.WriteLine("ī�带 ���� ���弼��.-------");
                return;
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("���� ī�尳��{0}", stack.Count);
            Console.Write(" You: {0},", stack.Pop());//������
            Console.Write(" Me: {0},", stack.Pop());
            Console.Write(" You: {0},", stack.Pop());
            Console.WriteLine(" Me: {0}", stack.Pop());
        }
    }
}

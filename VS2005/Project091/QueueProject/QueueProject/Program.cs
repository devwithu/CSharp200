using System;
using Com.JungBo.Logic;
namespace QueueProject{
    public class Program{
        public static void Main(string[] args){
            CardQueue que = new CardQueue();
            que.MakeCards();
            for (int i = 0; i < 20;i++ ) {
                que.PrintCards();
            }
            que.MakeCards();  //���� ť�� ī��ֱ�
            Console.WriteLine("===================");
            for (int i = 0; i < 20; i++){
                que.PrintCards();
            }
        }
    }
}

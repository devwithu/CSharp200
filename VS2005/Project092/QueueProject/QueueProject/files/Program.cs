using System;
using Com.JungBo.Logic;
namespace QueueProject{
    public class Program{
        public static void Main(string[] args){
            CardStack stacks = new CardStack();
            stacks.MakeCards();//���ÿ� ä���
            for (int i = 0; i < 20; i++){
                stacks.PrintCards();
            }
            stacks.MakeCards();//�ٽ� ���ÿ� ä���
            for (int i = 0; i < 20; i++){
                stacks.PrintCards();
            }
        }
    }
}

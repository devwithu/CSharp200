using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            Card cc = "H8";        //�Ͻ��� ����ȯ
            Console.WriteLine(cc);
 
            CardList cl = new CardList();
            cl.MakeCards();   //���� �ٸ� ī�� �����
            cl.PrintCards();//���
        }
    }
}

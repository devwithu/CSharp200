using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            Card cc = "H8";        //�Ͻ��� ����ȯ
            string cs = (string)cc;//����� ����ȯ
            Console.WriteLine(cc);
            Console.WriteLine(cs);

            CardList cl = new CardList();
            cl.MakeCards();   //���� �ٸ� ī�� �����
            cl.PrintCards();//���
        }
    }
}

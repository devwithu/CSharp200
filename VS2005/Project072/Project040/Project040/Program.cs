using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            CardList cl = new CardList();

            //�迭�� readonly �ᵵ ���� �����
            //CardList.SUIT[3] = "kk";  //4->kk�� �����
            //Console.WriteLine(CardList.SUIT[3]);


            //�迭�� �ƴϸ� �ܺο��� ���ο� ���� �Ұ�
            //CardList.CARDMAX = 10000000; 
            //cl.MAXVALUE = 100000;
            //CardList.MINVALUE = -30000;


            cl.MakeCard();   //���� �ٸ� ī�� �����
            cl.PrintCard1();//���
            Console.WriteLine("----------------------");

            //����ũ��*��Ʈ�� ũ��=4*13
            int count = CardList.CARDMAX;

            for (int i = 0; i < count; i++){
                //cl[i] indexer �̿�
                Console.Write("{0}  ",cl[i]);  
                //if ((i + 1) % (cl.MAXVALUE / 4) == 0){
                if((i+1)% (CardList.CARDMAX/4)==0){
                    Console.WriteLine();
                }
            }//
        }
    }
}

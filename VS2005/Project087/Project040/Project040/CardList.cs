using System;
using System.Collections;   //ArrayList ������ using
using System.Collections.Generic; //List
namespace Com.JungBo.Logic{

    //readonly ����, static ������
    public class CardList{

         //�߿��� ������ ���
        ArrayList list = new ArrayList(10);//ó�� Capacity 10

        // ī�� ���� (�� > �� > �� > ��)
        public static readonly string[] DECK ={ "S", "D", "H", "C" };
        public static readonly string[] SUIT 
        ={ "A","2","3","4","5","6","7","8","9","T","J","Q","K" };
        public static readonly int CARDMAX = 40;
        public readonly int MAXVALUE = 2000;
        public const int MINVALUE = -2000;

        //������
        public CardList() {
           MAXVALUE = DECK.Length*SUIT.Length;//readonly ����
           //MINVALUE = -8000;   //const�� ���� �Ұ�
        }
        //static ������
        static CardList(){
            CARDMAX = DECK.Length * SUIT.Length; //  static readonly ����
        }

        public void MakeCard() {
            list.Clear();//list ����
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //SA,S2, S3, .... ����
                    //list�� ä���
                    list.Add(string.Concat(deck,suit));
                }
            }
        }//

        public void PrintCard() {
            //list�� �ִ� string ���� Count
            for (int i = 0; i < list.Count; i++){
                //list�ȿ� ���� object�� ���θ��
                //�׷��Ƿ� ĳ���� �ʿ� as
                string cards = list[i] as string;

                Console.Write("{0}  ",cards);
                if((i+1)%SUIT.Length==0){
                    Console.WriteLine();
                }
            }
        }
        //get indexer
        public string this[int index]{
            get{
                if (index < 0 || index >= list.Count){
                    //���ܹ߻���Ű��
                    throw
                 new IndexOutOfRangeException("������ �Ѿ���ϴ�.");
                }
                else{
                    return list[index] as string;
                }
            }
        }//indexer
        //
        List<Card> cclist = new List<Card>(10);
        public void MakeCards(){
            cclist.Clear();//list ����
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //SA,S2, S3, .... ����
                    //cclist�� ä���
                    //string --> Card�� �Ͻ��� ����ȯ
                    cclist.Add(string.Concat(deck, suit));
                    //�Ʒ��� ����
                    //cclist.Add(new Card(string.Concat(deck, suit)));
                }
            }
        }//
        public void PrintCards(){
            //list�� �ִ� string ���� Count
            for (int i = 0; i < cclist.Count; i++){
                string cards = (string)cclist[i];
                //���������ȯ���� ���ܹ߻�
                //string cards = cclist[i] as string;
                Console.Write("{0}  ", cards);
                if ((i + 1) % SUIT.Length == 0){
                    Console.WriteLine();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
    public class CardDictionary{
        
        public static readonly string[] DECK ={ "S", "D", "H", "C" };
        public static readonly string[] SUIT =
{ "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };

        Dictionary<int, Card> dic
            = new Dictionary<int, Card>(10);

        public int Count{
            get { return dic.Count; }
        }
        public Card this[int index] {
            get{
                if (index >= 0 && index < Count){
                    return dic[index];
                }
                else {
                    throw new IndexOutOfRangeException(
                        "ī�� ������ ������ϴ�.");
                }
            }
        }
        public void MakeCards(){
            dic.Clear();
            int i = 0;
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //string --> Card�� �Ͻ��� ����ȯ
                    dic.Add(i++,string.Concat(deck, suit));
                }
            }
        }//
        public void PrintCards(){
            for (int i = 0; i < dic.Count; i++){
                Card cards = dic[i];//�ε���

                Console.Write("{0}  ", cards);
                if ((i + 1) % SUIT.Length == 0){
                    Console.WriteLine();
                }
            }
        }
        //�������� ����  : ī�带 ���´�.
        public void Suffle(){
            Random r = new Random();
            for (int i = 0; i < dic.Count; i++){
                int temp = r.Next(0, dic.Count);
                Card cTemp = dic[temp];
                dic[temp] = dic[i];
                dic[i] = cTemp;
            }
        }//Suffle()
    }
}

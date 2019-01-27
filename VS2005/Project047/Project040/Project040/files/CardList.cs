using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;   //ArrayList ������ using
namespace Com.JungBo.Logic{
    //IEnumerator �� static �޼���, static ����
    public class CardList{
        // ī�� ���� (�� > �� > �� > ��)
        public  static string[] DECK ={ "S","D","H","C"};
        public  static string[] SUIT 
        ={ "A","2","3","4","5","6","7","8","9","T","J","Q","K" };

        //�߿��� ������ ���
        ArrayList list = new ArrayList(10);//ó�� Capacity 10

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
        public void PrintCard(){
            int i = 0;
            IEnumerator iters = list.GetEnumerator();
            while(iters.MoveNext()){
                string cards = iters.Current as string;
                Console.Write("{0}  ", cards);
                if ((i++ + 1) % SUIT.Length == 0)
                {
                    Console.WriteLine();
                }
            }
        }//

        public string[] ToArray(){

            object[] objs = list.ToArray();

            string[] strs = new string[objs.Length];

            for (int i = 0; i < objs.Length; i++){
                strs[i] = objs[i] as string;
            }
            return strs;
        }

    }//class
}

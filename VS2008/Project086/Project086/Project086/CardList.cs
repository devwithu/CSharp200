using System;
using System.Collections;   //ArrayList 때문에 using
using System.Collections.Generic; //List
namespace Com.JungBo.Logic{

    //readonly 사용법, static 생성자
    public class CardList{

         //중요한 데이터 멤버
        ArrayList list = new ArrayList(10);//처음 Capacity 10

        // 카드 순서 (♠ > ◆ > ♥ > ♣)
        public static readonly string[] DECK ={ "S", "D", "H", "C" };
        public static readonly string[] SUIT 
        ={ "A","2","3","4","5","6","7","8","9","T","J","Q","K" };
        public static readonly int CARDMAX = 40;
        public readonly int MAXVALUE = 2000;
        public const int MINVALUE = -2000;

        //생성자
        public CardList() {
           MAXVALUE = DECK.Length*SUIT.Length;//readonly 대입
           //MINVALUE = -8000;   //const는 대입 불가
        }
        //static 생성자
        static CardList(){
            CARDMAX = DECK.Length * SUIT.Length; //  static readonly 대입
        }

        public void MakeCard() {
            list.Clear();//list 비우기
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //SA,S2, S3, .... 대입
                    //list에 채우기
                    list.Add(string.Concat(deck,suit));
                }
            }
        }//

        public void PrintCard() {
            //list에 있는 string 개수 Count
            for (int i = 0; i < list.Count; i++){
                //list안에 들어가면 object로 프로모션
                //그러므로 캐스팅 필요 as
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
                    //예외발생시키기
                    throw
                 new IndexOutOfRangeException("범위를 넘어섰습니다.");
                }
                else{
                    return list[index] as string;
                }
            }
        }//indexer
        //
        List<Card> cclist = new List<Card>(10);
        public void MakeCards(){
            cclist.Clear();//list 비우기
            foreach (string deck in DECK){
                foreach (string suit in SUIT){
                    //SA,S2, S3, .... 대입
                    //cclist에 채우기
                    //string --> Card로 암시적 형변환
                    cclist.Add(string.Concat(deck, suit));
                    //아래와 동일
                    //cclist.Add(new Card(string.Concat(deck, suit)));
                }
            }
        }//
        public void PrintCards(){
            //list에 있는 string 개수 Count
            for (int i = 0; i < cclist.Count; i++){
                Card cards = cclist[i];
                Console.Write("{0}  ", cards);
                if ((i + 1) % SUIT.Length == 0){
                    Console.WriteLine();
                }
            }
        }
    }
}

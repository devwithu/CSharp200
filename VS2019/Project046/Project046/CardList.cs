using System;
using System.Collections;   //ArrayList 때문에 using
namespace Com.JungBo.Logic
{
    public class CardList
    {
        // 카드 순서 (♠ > ◆ > ♥ > ♣)
        public string[] DECK = { "S", "D", "H", "C" };
        public string[] SUIT
     = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };

        //중요한 데이터 멤버
        ArrayList list = new ArrayList(10);//Capacity 10
        public void MakeCard()
        {
            list.Clear();//list 비우기
            foreach (string deck in DECK)
            {
                foreach (string suit in SUIT)
                {
                    //SA,S2, S3, .... 대입
                    //list에 채우기
                    list.Add(string.Concat(deck, suit));
                }
            }
        }//
         //12개씩 출력 12개씩 4줄
        public void PrintCard()
        {
            //list에 있는 string 개수 Count
            for (int i = 0; i < list.Count; i++)
            {
                //list안에 들어가면 object로 프로모션
                //그러므로 캐스팅 필요 as
                string cards = list[i] as string;
                Console.Write("{0}  ", cards);
                if ((i + 1) % SUIT.Length == 0)
                {//12개씩
                    Console.WriteLine();
                }
            }
        }
        //list 앞뒤로 바꾸기
        public void ReverseCard()
        {
            list.Reverse();
        }
        public string[] ToArray()
        {
            //ArrayList 엘리먼트를 object[]로 
            object[] objs = list.ToArray();
            //배열의 크기 objs.Length
            string[] strs = new string[objs.Length];
            //ArrayList 순서대로 string으로 캐스팅
            for (int i = 0; i < objs.Length; i++)
            {
                strs[i] = objs[i] as string;
            }
            return strs;
        }
        public int IndexOf(string str)
        {
            return list.IndexOf(str);
        }
        public void Sort()
        {
            //알파벳-숫자로 정렬
            list.Sort();
        }
    }//class
}//namespace

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace WinBlackJack
{
    public class CardList
    {
        private ArrayList list = new ArrayList();
        private Random r;
        //private static int SEED = 5;

        public CardList() {
            ListInit();
            r = new Random(System.DateTime.Now.Millisecond);
        }

        // 52���� ī�带 �����.
        private void ListInit() {
            list.Clear();
            for (int i = 0; i < CardUtil.SUIT.Length; i++) {
                for (int j = 0; j < CardUtil.DECK.Length; j++) {
                    list.Add(new Card(CardUtil.SUIT[i], CardUtil.DECK[j]));
                }
            }
        }
        // �� ���ӽ� ī�带 �ٽ� �����Ѵ�.
        public void ReSet() { ListInit(); }
        // ������ ī�� ������ ����.
        public Card GetCard() {
            int idx = r.Next(list.Count);
            Card card = new Card(list[idx] as Card);
            list.RemoveAt(idx);
            return card;
        }
    } // class
}

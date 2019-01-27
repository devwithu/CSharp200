using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Poker
{
    public enum SUITS : byte { SPADE = 3, DIAMOND = 2, HEART = 1, CLUB = 0 }
    public enum TITLE { TOP, ONEPAIR, TWOPAIR, TRIPLE, STRAIGHT, FLUSH, FULLHOUSE, FOURCARD, STRAIGHTFLUSH }

    public class Card
    {
        int number;
        SUITS suit;
        int order;
        int id;

        public Card() {}

        public Card(int tid)
        {
            this.id = tid;

            this.number = (tid % 13) + 2;

            if (tid / 13 == 0)
            {
                this.Suit = SUITS.SPADE;
                this.order = (this.number -1 ) * 4 - 1;
            }
            if (tid / 13 == 1)
            {
                this.Suit = SUITS.DIAMOND;
                this.order = (this.number - 1) * 4 - 2;
            }
            if (tid / 13 == 2)
            {
                this.Suit = SUITS.HEART;
                this.order = (this.number - 1) * 4 - 3;
            }
            if (tid / 13 == 3)
            {
                this.Suit = SUITS.CLUB;
                this.order = (this.number - 1) * 4 - 4;
            }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public SUITS Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string ImgName
        {
            get { return Number.ToString() + suit.ToString().Substring(0,1); }
        }

    }

    public static class SearchCard
    {
        public static SUITS suit;
        public static int number;

        public static bool SuitSearch(Card c)
        {
            return suit == c.Suit;
        }
        public static bool NumberSearch(Card c)
        {
            return number == c.Number;
        }
    }

    public enum SortDirection { Ascending, Descending }

    public class CardComparer : IComparer<Card>
    {
        private SortDirection m_direction = SortDirection.Descending;

        public CardComparer() : base() { }

        public CardComparer(SortDirection direction)
        {
            this.m_direction = direction;
        }

        public int Compare(Card x, Card y)
        {
            Card cardX = (Card)x;
            Card cardY = (Card)y;

            if (cardX == null && cardY == null)
                return 0;
            else if (cardX == null && cardY != null)
                return (this.m_direction == SortDirection.Ascending) ? -1 : 1;
            else if (cardX != null && cardY == null)
                return (this.m_direction == SortDirection.Ascending) ? 1 : -1;
            else
            {
                return (this.m_direction == SortDirection.Ascending) ?
                    cardX.Order.CompareTo(cardY.Order) : cardY.Order.CompareTo(cardX.Order);
            }
        }
    }

    // 딜러
    public class Dealer
    {
        private static Dealer dealer = new Dealer();

        public Queue<Card> shuffledCards = new Queue<Card>();
        private List<Card> cardList = new List<Card>();
        private SevenOrdinary so = new SevenOrdinary();
        private Card[] newCards = new Card[52];

        private Dealer()
        {
            newCards = so.Card;
            Shuffle();
        }

        public static Dealer getDealer()
        {
            return dealer;
        }

        // 카드 섞기
        public void Shuffle()
        {
            Random r = new Random();

            for (int i = 0; i < 52; i++)
                cardList.Add(newCards[i]);

            while (cardList.Count != 0)
            {
                int index = r.Next(0, cardList.Count);

                shuffledCards.Enqueue(cardList[index]);
                cardList.RemoveAt(index);
            }
        }

        public Card PutCard()
        {
            return shuffledCards.Dequeue();
        }

        //
        public void Winner(ref Player p1, ref Player p2)
        {
            so.DecideWinner(ref p1, ref p2);
        }
    }

    public enum BETTING : int { DIE, CHECK, CALL, BBING, DOUBLE, QUARTER, HALF, FULL } 

    public class Bet
    {
        public readonly int BBING = 100;
        public int totalMoney = 200; //BBING*2;
        public int callMoney = 0;
        public int bettingMoney = 0;
        public bool noMoreBetting = false;
        public int round = 0;

        public void Go(BETTING betting)
        {
            if (betting == BETTING.DOUBLE)
            {
                bettingMoney = callMoney * 2;
            }
            else if (betting == BETTING.QUARTER)
            {
                bettingMoney = (totalMoney + callMoney) / 4;
            }
            else if (betting == BETTING.HALF)
            {
                bettingMoney = (totalMoney + callMoney) / 2;
            }
            else if (betting == BETTING.FULL)
            {
                bettingMoney = totalMoney + callMoney;
            }
            else if (betting == BETTING.CHECK)
            {
                noMoreBetting = false;
                bettingMoney = 0;
            }
            else if (betting == BETTING.CALL)
            {
                bettingMoney = callMoney;
            }
            else if (betting == BETTING.BBING)
            {
                bettingMoney = callMoney + BBING;
            }
            else
            {
                //bettingMoney = -1;
                //bettingMoney = 0;
            }

            NextMoney();

            if (round == 2)
            {
                noMoreBetting = true;
            }
        }
    
        public void NextMoney()
        {
            totalMoney = totalMoney + bettingMoney;
            callMoney = bettingMoney - callMoney;
        }
    }

    // 플레이어
    public class Player
    {
        public List<Card> cards;
        public int level;   // 점수
        public string title; // 족보
        public bool isBoss;
        public int money = 100000000;

        public Player()
        {
            cards = new List<Card>();
            level = 0;
            title = ""; // TITLE.TOP;
            isBoss = false;
            money = 100000000;
        }
    }
    // 세븐오디 규칙
    public class SevenOrdinary
    {
        const int ROYAL_SF      = 9900000;
        const int BACK_SF       = 9500000;
        const int STRAIGHTFLUSH = 9000000;
        const int FOURCARD      = 8000000;
        const int FULLHOUSE     = 7000000;
        const int FLUSH         = 6000000;
        const int MOUNTAIN      = 5900000;
        const int BACK_ST       = 5500000;
        const int STRAIGHT      = 5000000;
        const int TRIPLE        = 4000000;
        const int TWOPAIR       = 10000;
        const int ONEPAIR       = 1000;
        const int LEVELWEIGHT   = 100;

        Card[] card = new Card[52];

        public Card[] Card
        {
            get { return card; }
        }

        // 카드 순서 (♠ > ◆ > ♥ > ♣)
        // ID(0~12  = ♠2~A)
        // ID(13~25 = ◆2~A)
        // ID(26~38 = ♥2~A)
        // ID(39~51 = ♣2~A)
        public SevenOrdinary()
        {
            int tid;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 13; j++)
                {
                    tid = i * 13 + j;
                    card[tid] = new Card();
                    card[tid].ID = tid;

                    card[tid].Number = j + 2;

                    if (i == 0)
                    {
                        card[tid].Suit = SUITS.SPADE;
                        card[tid].Order = 4 * (j + 1) - 1;
                    }
                    if (i == 1)
                    {
                        card[tid].Suit = SUITS.DIAMOND;
                        card[tid].Order = 4 * (j + 1) - 2;
                    }
                    if (i == 2)
                    {
                        card[tid].Suit = SUITS.HEART;
                        card[tid].Order = 4 * (j + 1) - 3;
                    }
                    if (i == 3)
                    {
                        card[tid].Suit = SUITS.CLUB;
                        card[tid].Order = 4 * (j + 1) - 4;
                    }

                }
        }

        // Number를 카드 숫자로...
        private string ToCardNumber(int num)
        {
            if (num <= 10) return num.ToString();
            else if (num == 11) return "J";
            else if (num == 12) return "Q";
            else if (num == 13) return "K";
            else return "A";
        }

        // 승리자 판별
        public void DecideWinner(ref Player p1, ref Player p2)
        {
            p1.isBoss = false;
            p2.isBoss = false;

            List<Card> subCards1 = new List<Card>();
            List<Card> subCards2 = new List<Card>();

            // 7장의 카드를 모두 받았을때
            if (p1.cards.Count == 7 && p2.cards.Count == 7)
            {
                foreach (Card c in p1.cards)
                    subCards1.Add(c);
                foreach (Card c in p2.cards)
                    subCards2.Add(c);
            }
            // 4,5,6구 보스 정결
            else
            {
                for (int i = 2; i < p1.cards.Count; i++)
                {
                    subCards1.Add(p1.cards[i]);
                    subCards2.Add(p2.cards[i]);
                }
            }
            p1.level = CalcLevel(subCards1);
            p2.level = CalcLevel(subCards2);

            if (subCards1.Count == 7)
            {
                // 먼저 Sorting
                if (subCards1.Count >= 2)
                {
                    subCards1.Sort(new CardComparer(SortDirection.Descending));
                    subCards2.Sort(new CardComparer(SortDirection.Descending));

                    while (subCards1.Count > 5)
                    {
                        subCards1.RemoveAt(subCards1.Count - 1);
                        subCards2.RemoveAt(subCards2.Count - 1);
                    }
                }

                // Title
                // p1
                p1.title = "";
                if (p1.level >= STRAIGHTFLUSH)
                {
                    foreach (Card c in subCards1)
                    {
                        p1.title += ToCardNumber(c.Number) + ", ";
                    }
                    p1.title += "스트레이트플러시";
                }
                else if (p1.level >= FOURCARD)
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", 포카드";
                }
                else if (p1.level >= FULLHOUSE)
                {
                    p1.title += ToCardNumber(subCards1[2].Number) + ", 풀하우스";
                }
                else if (p1.level >= FLUSH)
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", 플러시";
                }
                else if (p1.level >= STRAIGHT)
                {
                    foreach (Card c in subCards1)
                    {
                        p1.title += ToCardNumber(c.Number) + ", ";
                    }
                    p1.title += "스트레이트";
                }
                else if (p1.level >= TRIPLE)
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", 트리플";
                }
                else if (p1.level >= TWOPAIR)
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", " 
                        + ToCardNumber(subCards1[2].Number) + ", 투페어";
                }
                else if (p1.level >= ONEPAIR)
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", 원페어";
                }
                else
                {
                    p1.title = ToCardNumber(subCards1[0].Number) + ", 탑";
                }

                // p2
                p2.title = "";
                if (p2.level >= STRAIGHTFLUSH)
                {
                    foreach (Card c in subCards2)
                    {
                        p2.title += ToCardNumber(c.Number) + ", ";
                    }
                    p2.title += "스트레이트플러시";
                }
                else if (p2.level >= FOURCARD)
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", 포카드";
                }
                else if (p2.level >= FULLHOUSE)
                {
                    p2.title += ToCardNumber(subCards2[2].Number) + ", 풀하우스";
                }
                else if (p2.level >= FLUSH)
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", 플러시";
                }
                else if (p2.level >= STRAIGHT)
                {
                    foreach (Card c in subCards2)
                    {
                        p2.title += ToCardNumber(c.Number) + ", ";
                    }
                    p2.title += "스트레이트";
                }
                else if (p2.level >= TRIPLE)
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", 트리플";
                }
                else if (p2.level >= TWOPAIR)
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", "
                        + ToCardNumber(subCards2[2].Number) + ", 투페어";
                }
                else if (p2.level >= ONEPAIR)
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", 원페어";
                }
                else
                {
                    p2.title = ToCardNumber(subCards2[0].Number) + ", 탑";
                }
            }

            // 다음 탑카드 비교
            if (p1.level == p2.level)
            {
                int compareCardIndex = 0;

                if (p1.level >= STRAIGHT)
                    compareCardIndex = 5;
                else if (p1.level >= TRIPLE)
                    compareCardIndex = 3;
                else if (p1.level >= TWOPAIR)
                    compareCardIndex = 4;
                else if (p1.level >= ONEPAIR)
                    compareCardIndex = 2;
                else
                    compareCardIndex = 0;

                for (int i = compareCardIndex; i < subCards1.Count; i++)
                {
                    if (subCards1[i].Number > subCards2[i].Number)
                    {
                        p1.isBoss = true;
                        break;
                    }
                    else if (subCards1[i].Number < subCards2[i].Number)
                    {
                        p2.isBoss = true;
                        break;
                    }
                }

                if (p1.isBoss == false && p2.isBoss == false)
                {
                    if (subCards1[0].Order > subCards2[0].Order)
                        p1.isBoss = true;
                    else
                        p2.isBoss = true;
                }
            }

            else if (p1.level > p2.level)
            {
                p1.isBoss = true;
            }

            else
            {
                p2.isBoss = true;
            }
        }

        // 족보
        int CalcLevel(List<Card> playCard)
        {

            int level;

            level = CheckStraightFlush(playCard);
            if (level != 0) return level;

            level = CheckFourCard(ref playCard);
            if (level != 0) return level;

            level = CheckFullHouse(playCard);
            if (level != 0) return level;

            level = CheckFlush(ref playCard);
            if (level != 0) return level;

            level = CheckStraight(ref playCard);
            if (level != 0) return level;

            level = CheckTriple(ref playCard);
            if (level != 0) return level;

            level = CheckTwoPair(ref playCard);
            if (level != 0) return level;

            level = CheckOnePair(ref playCard);
            if (level != 0) return level;

            level = CheckTop(playCard);
            return level;

        }

        // 같은 무늬 카운트
        int[] CountSuit(List<Card> playCard)
        {
            int[] count = new int[4];
            for (int i = 0; i < 4; i++)
                count[i] = 0;

            foreach (Card c in playCard)
            {
                if (c.Suit == SUITS.CLUB)
                    count[0]++;
                if (c.Suit == SUITS.HEART)
                    count[1]++;
                if (c.Suit == SUITS.DIAMOND)
                    count[2]++;
                if (c.Suit == SUITS.SPADE)
                    count[3]++;
            }
            return count;
        }

        // 스트레이트플러시
        int CheckStraightFlush(List<Card> playCard)
        {
            if (playCard.Count < 5)
                return 0;

            int[] count = CountSuit(playCard);
            int suitIndex = 0;

            for (int i = 1; i < 4; i++)
                if (count[i] > count[suitIndex])
                    suitIndex = i;

            if (count[suitIndex] >= 5)
            {
                List<Card> tempCard = new List<Card>();
                SearchCard.suit = (SUITS)suitIndex;

                tempCard = playCard.FindAll(SearchCard.SuitSearch);

                // 로티플
                SearchCard.number = 14;
                if (tempCard.Exists(SearchCard.NumberSearch))
                {
                    SearchCard.number = 13;
                    if (tempCard.Exists(SearchCard.NumberSearch))
                    {
                        SearchCard.number = 12;
                        if (tempCard.Exists(SearchCard.NumberSearch))
                        {
                            SearchCard.number = 11;
                            if (tempCard.Exists(SearchCard.NumberSearch))
                            {
                                SearchCard.number = 10;
                                if (tempCard.Exists(SearchCard.NumberSearch))
                                {
                                    return ROYAL_SF + suitIndex;
                                }
                            }
                        }
                    }
                }

                // A2345
                SearchCard.number = 14;
                if (tempCard.Exists(SearchCard.NumberSearch))
                {
                    SearchCard.number = 2;
                    if (tempCard.Exists(SearchCard.NumberSearch))
                    {
                        SearchCard.number = 3;
                        if (tempCard.Exists(SearchCard.NumberSearch))
                        {
                            SearchCard.number = 4;
                            if (tempCard.Exists(SearchCard.NumberSearch))
                            {
                                SearchCard.number = 5;
                                if (tempCard.Exists(SearchCard.NumberSearch))
                                {
                                    return BACK_SF + suitIndex;
                                }
                            }
                        }
                    }
                }

                // 일반 스티플
                for (int i = 13; i >= 6; i--)
                {
                    SearchCard.number = i;
                    if (tempCard.Exists(SearchCard.NumberSearch))
                    {
                        SearchCard.number = i - 1;
                        if (tempCard.Exists(SearchCard.NumberSearch))
                        {
                            SearchCard.number = i - 2;
                            if (tempCard.Exists(SearchCard.NumberSearch))
                            {
                                SearchCard.number = i - 3;
                                if (tempCard.Exists(SearchCard.NumberSearch))
                                {
                                    SearchCard.number = i - 4;
                                    if (tempCard.Exists(SearchCard.NumberSearch))
                                    {
                                        return STRAIGHTFLUSH + i*10 + suitIndex;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return 0;
        }

        // 포카드
        int CheckFourCard(ref List<Card> playCard)
        {
            if (playCard.Count < 4)
                return 0;

            List<Card> tempCard = new List<Card>();

            for (int i = 14; i >= 2; i--)
            {
                SearchCard.number = i;
                tempCard = playCard.FindAll(SearchCard.NumberSearch);
                if (tempCard.Count == 4)
                {
                    foreach (Card tc in tempCard)
                        foreach(Card pc in playCard)
                            if(tc.ID == pc.ID)
                                pc.Order += LEVELWEIGHT;

                    return FOURCARD + i;
                }
            }
            return 0;
        }

        // 풀하우스
        int CheckFullHouse(List<Card> playCard)
        {
            if (playCard.Count < 5)
                return 0;

            int level = CheckTriple(ref playCard);
            if (level != 0)
            {
                if (CheckAfterOnePair(ref playCard) != 0)
                {
                    return level - TRIPLE + FULLHOUSE;
                }
            }
            return 0;
        }

        // 플러시
        int CheckFlush(ref List<Card> playCard)
        {
            if (playCard.Count < 5)
                return 0;

            int[] count = CountSuit(playCard);
            int suitIndex = 0;

            // 어떤 무늬가 가장 많은가? suitIndex
            for (int i = 1; i < 4; i++)
                if (count[i] > count[suitIndex])
                    suitIndex = i;

            if (count[suitIndex] >= 5)
            {
                List<Card> tempCard = new List<Card>();
                SearchCard.suit = (SUITS)suitIndex;
                tempCard = playCard.FindAll(SearchCard.SuitSearch);

                foreach (Card tc in tempCard)
                    foreach (Card pc in playCard)
                        if (tc.ID == pc.ID)
                            pc.Order += LEVELWEIGHT;

                for (int i = 14; i >= 6; i--)
                {
                    SearchCard.number = i;
                    if (tempCard.Exists(SearchCard.NumberSearch))
                    {
                        return FLUSH + i;
                    }
                }
            }
            return 0;
        }

        // 스트레이트
        int CheckStraight(ref List<Card> playCard)
        {
            if (playCard.Count < 5)
                return 0;
            
            List<Card> tempCard = new List<Card>();
            List<Card> temp = new List<Card>();

            // 마운틴
            SearchCard.number = 14;
            temp = playCard.FindAll(SearchCard.NumberSearch);
            if (temp.Count != 0) 
            {
                if(temp.Count >= 2) temp.Sort(new CardComparer());
                tempCard.Add(temp[0]);

                SearchCard.number = 13;
                temp = playCard.FindAll(SearchCard.NumberSearch);
                if (temp.Count != 0) 
                {
                    if(temp.Count >= 2) temp.Sort(new CardComparer());
                    tempCard.Add(temp[0]);

                    SearchCard.number = 12;
                    temp = playCard.FindAll(SearchCard.NumberSearch);
                    if (temp.Count != 0) 
                    {
                        if(temp.Count >= 2) temp.Sort(new CardComparer());
                        tempCard.Add(temp[0]);

                        SearchCard.number = 11;
                        temp = playCard.FindAll(SearchCard.NumberSearch);
                        if (temp.Count != 0)
                        {
                            if(temp.Count >= 2) temp.Sort(new CardComparer());
                            tempCard.Add(temp[0]);

                            SearchCard.number = 10;
                            temp = playCard.FindAll(SearchCard.NumberSearch);
                            if (temp.Count != 0) 
                            {
                                if(temp.Count >= 2) temp.Sort(new CardComparer());
                                tempCard.Add(temp[0]);

                                foreach (Card tc in tempCard)
                                    foreach (Card pc in playCard)
                                        if (tc.ID == pc.ID)
                                            pc.Order += LEVELWEIGHT;

                                return MOUNTAIN;
                            }
                        }
                    }
                }
            }

            tempCard.Clear();

            // A2345
            SearchCard.number = 14;
            temp = playCard.FindAll(SearchCard.NumberSearch);
            if (temp.Count != 0) 
            {
                if(temp.Count >= 2) temp.Sort(new CardComparer());
                tempCard.Add(temp[0]);

                SearchCard.number = 2;
                temp = playCard.FindAll(SearchCard.NumberSearch);
                if (temp.Count != 0)
                {
                    if(temp.Count >= 2) temp.Sort(new CardComparer());
                    tempCard.Add(temp[0]);

                    SearchCard.number = 3;
                    temp = playCard.FindAll(SearchCard.NumberSearch);
                    if (temp.Count != 0) 
                    {
                        if(temp.Count >= 2) temp.Sort(new CardComparer());
                        tempCard.Add(temp[0]);

                        SearchCard.number = 4;
                        temp = playCard.FindAll(SearchCard.NumberSearch);
                        if (temp.Count != 0) 
                        {
                            if(temp.Count >= 2) temp.Sort(new CardComparer());
                            tempCard.Add(temp[0]);

                            SearchCard.number = 5;
                            temp = playCard.FindAll(SearchCard.NumberSearch);
                            if (temp.Count != 0) 
                            {
                                if(temp.Count >= 2) temp.Sort(new CardComparer());
                                tempCard.Add(temp[0]);

                                foreach (Card tc in tempCard)
                                    foreach (Card pc in playCard)
                                        if (tc.ID == pc.ID)
                                            pc.Order += LEVELWEIGHT;

                                return BACK_ST;
                            }
                        }
                    }
                }
            }

            tempCard.Clear();

            // 일반 스트레이트
            for (int i = 13; i >= 6; i--)
            {
                SearchCard.number = i;
                temp = playCard.FindAll(SearchCard.NumberSearch);
                if (temp.Count != 0) 
                {
                    if(temp.Count >= 2) temp.Sort(new CardComparer());
                    tempCard.Add(temp[0]);

                    SearchCard.number = i - 1;
                    temp = playCard.FindAll(SearchCard.NumberSearch);
                    if (temp.Count != 0) 
                    {
                        if(temp.Count >= 2) temp.Sort(new CardComparer());
                        tempCard.Add(temp[0]);

                        SearchCard.number = i - 2;
                        temp = playCard.FindAll(SearchCard.NumberSearch);
                        if (temp.Count != 0) 
                        {
                            if(temp.Count >= 2) temp.Sort(new CardComparer());
                            tempCard.Add(temp[0]);

                            SearchCard.number = i - 3;
                            temp = playCard.FindAll(SearchCard.NumberSearch);
                            if (temp.Count != 0) 
                            {
                                if(temp.Count >= 2) temp.Sort(new CardComparer());
                                tempCard.Add(temp[0]);

                                SearchCard.number = i - 4;
                                temp = playCard.FindAll(SearchCard.NumberSearch);
                                if (temp.Count != 0) 
                                {
                                    if(temp.Count >= 2) temp.Sort(new CardComparer());
                                    tempCard.Add(temp[0]);

                                    foreach (Card tc in tempCard)
                                        foreach (Card pc in playCard)
                                            if (tc.ID == pc.ID)
                                                pc.Order += LEVELWEIGHT;

                                    return STRAIGHT + i;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        // 트리플
        int CheckTriple(ref List<Card> playCard)
        {
            if (playCard.Count < 3)
                return 0;

            List<Card> tempCard = new List<Card>();

            for (int i = 14; i >= 2; i--)
            {
                SearchCard.number = i;
                tempCard = playCard.FindAll(SearchCard.NumberSearch);
                if (tempCard.Count == 3)
                {
                    foreach(Card tc in tempCard)
                        foreach(Card pc in playCard)
                            if(tc.ID == pc.ID)
                                pc.Order += LEVELWEIGHT;

                    return TRIPLE + i;
                }
            }
            return 0;
        }

        // 투페어
        int CheckTwoPair(ref List<Card> playCard)
        {
            if (playCard.Count < 4)
                return 0;

            List<Card> tempCard = new List<Card>();
            List<Card> tempCard2 = new List<Card>();
            for (int i = 14; i >= 3; i--)
            {
                SearchCard.number = i;
                tempCard = playCard.FindAll(SearchCard.NumberSearch);
                if (tempCard.Count == 2)
                {
                    for (int j = i - 1; j >= 2; j--)
                    {
                        SearchCard.number = j;
                        tempCard2 = playCard.FindAll(SearchCard.NumberSearch);
                        if (tempCard2.Count == 2)
                        {
                            tempCard.AddRange(tempCard2);

                            foreach (Card tc in tempCard)
                                foreach (Card pc in playCard)
                                    if (tc.ID == pc.ID)
                                        pc.Order += LEVELWEIGHT;

                            return TWOPAIR * i + j;
                        }
                    }
                    return 0;
                }
            }
            return 0;
        }

        // 원페어
        int CheckOnePair(ref List<Card> playCard)
        {
            if (playCard.Count < 2)
                return 0;
            List<Card> tempCard = new List<Card>();

            for (int i = 14; i >= 2; i--)
            {
                SearchCard.number = i;
                tempCard = playCard.FindAll(SearchCard.NumberSearch);
                if (tempCard.Count == 2)
                {
                    foreach (Card tc in tempCard)
                        foreach (Card pc in playCard)
                            if (tc.ID == pc.ID)
                                pc.Order += LEVELWEIGHT;

                    return ONEPAIR + i;
                }
            }
            return 0;
        }

        // 트리플 후 원페어 체크
        int CheckAfterOnePair(ref List<Card> playCard)
        {
            if (playCard.Count < 2)
                return 0;
            List<Card> tempCard = new List<Card>();

            for (int i = 14; i >= 2; i--)
            {
                SearchCard.number = i;
                tempCard = playCard.FindAll(SearchCard.NumberSearch);
                if (tempCard.Count >= 2)
                {
                    foreach (Card tc in tempCard)
                        foreach (Card pc in playCard)
                            if (tc.ID == pc.ID)
                                pc.Order += LEVELWEIGHT;

                    return ONEPAIR + i;
                }
            }
            return 0;
        }

        // 탑
        int CheckTop(List<Card> playCard)
        {
            for (int i = 14; i >= 2; i--)
            {
                SearchCard.number = i;
                if (playCard.Exists(SearchCard.NumberSearch))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}

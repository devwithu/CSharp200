using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace WinGodori
{
    class PointBoard
    {
        public List<int> light = new List<int>();
        public List<int> animal = new List<int>();
        public List<int> band = new List<int>();
        public List<int> pi = new List<int>();
    }

    class Gamer
    {
        //private int mePoint = 0;
        //private int guestPoint = 0;
        //private int meMulti = 0;
        //private int guestMulti = 0;

        private int[] cards;     // 카드 48장
        private int[] mhcards = new int[10];  // 손에 든 카드 10장
        private int[] ghcards = new int[10];  // 상대방이 든 카드 10장

        private List<int> deckcards = new List<int>();
        private List<int>[] boardcards = new List<int>[12];  // 보드에 그려질 12개의 위치 , 최대 4장
        private List<int> selectcards = new List<int>();      // 선택된 카드들 보관

        private PointBoard mepBoard = new PointBoard();
        private PointBoard guestpBoard = new PointBoard();

        private CardInfo cinfo;

        public Gamer(ref CardInfo c)
        {
            cinfo = c;
            Init_BoardCards();
        }

        // 보드에 있는 카드 초기화
        private void Init_BoardCards()
        {
            for (int i = 0; i < 12; i++)
                boardcards[i] = new List<int>();
        }

        // 카드를 랜덤으로 섞는다.
        public void MixCard()
        {
            List<int> temp_card = new List<int>();
            Random r = new Random();
            cards = new int[48];

            for (int i = 0; i < 48; i++)
                temp_card.Add(i);

            for (int i = 0; i < 48; i++)
            {
                int index = r.Next(0, temp_card.Count); // 인덱스 랜덤하게 생성
                cards[i] = temp_card[index];             // 카드를 저장
                temp_card.RemoveAt(index);              // 사용한 카드는 삭제
            }
        }
        // 카드를 분배한다.
        public void Distribution(int[] buffer)
        {
            int[] tmp = new int[8];
            Array.Copy(buffer, 0, mhcards, 0, 10);   // 내카드
            Array.Sort(mhcards);
            Array.Copy(buffer, 10, ghcards, 0, 10);  // 상대 카드
            Array.Sort(ghcards);
            Array.Copy(buffer, 20, tmp, 0, 8);    // 보드 카드
            // Array.Copy(buffer, 28, deckcards, 0, 22);    // 덱카드
            for (int i = 28; i < 48; i++)   // 덱카드
                deckcards.Add(buffer[i]);
            MakeBoard(tmp);
        }
        // 보드에 그려질 모양을 잡는다
        public void MakeBoard(int[] buffer)
        {
            foreach (int cnum in buffer)
                ReturnBoardPoint(cnum, false);
        }

        // 보드에 그려질 포인트저장하고 인덱스를 리턴한다.
        public int ReturnBoardPoint(int cnum, bool flag)
        {
            int index = -1;
            for (int i = 0; i < 12; i++)
            {
                if (boardcards[i].Count != 0 && cinfo.IsSameCardKind(boardcards[i][0], cnum))
                {
                    if (boardcards[i].Count == 3)   // 쌓것을 먹는다.
                    {
                        foreach (int tmp in boardcards[i])
                            selectcards.Add(tmp);
                        selectcards.Add(cnum);
                    }
                    else if (flag && !IsExist(boardcards[i][0])) // 만약 선택된 카드에 존재하지 않는다면 추가
                    {
                        selectcards.Add(boardcards[i][0]);
                        selectcards.Add(cnum);
                    }

                    else if (IsExist(boardcards[i][0]) && selectcards.Count == 2) // 쌓다
                        selectcards.Clear();

                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                for (int i = 0; i < 12; i++)
                    if (boardcards[i].Count == 0)
                    {
                        index = i;
                        break;
                    }
            }
            boardcards[index].Add(cnum);
            return index;
        }
        // 이미존재하는지 검사
        public bool IsExist(int num)
        {
            foreach (int cnum in selectcards)
                if (num == cnum) return true;
            return false;
        }

        //  선택된 카드를 보드에서 없애 준다
        public void ClearSelectCard()
        {
            for (int i = 0; i < selectcards.Count; i++)
            {
                Point sindex = ReturnBoardIndex(selectcards[i]);
                if (sindex == new Point(-1, -1))
                    continue;
                //   MessageBox.Show("ERROR");
                boardcards[sindex.X].RemoveAt(sindex.Y);
            }

        }
        // 보드에 위치를 찾는다 ... 음 이함수는 마지막에 (-1-,1)이 리턴되면 에러다
        public Point ReturnBoardIndex(int cnum)
        {
            Point index = new Point();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < boardcards[i].Count; j++)
                    if (cnum == boardcards[i][j])
                    {
                        index.X = i;
                        index.Y = j;
                        return index;
                    }
            }
            return new Point(-1, -1);
        }


        // 포인트 보드 갱신
        public void RenewPointBoard(PointBoard pb)
        {
            while (selectcards.Count != 0)
            {
                if (cinfo.GetCardKind(selectcards[0]) == CardKind.LIGHT)
                    pb.light.Add(selectcards[0]);
                else if (cinfo.GetCardKind(selectcards[0]) == CardKind.ANIMAL)
                    pb.animal.Add(selectcards[0]);
                else if (cinfo.GetCardKind(selectcards[0]) == CardKind.BAND)
                    pb.band.Add(selectcards[0]);
                else
                    pb.pi.Add(selectcards[0]);

                selectcards.RemoveAt(0);
            }

        }


        // 카드를 친다.
        public void HitCard(int hindex)
        {
            mhcards[hindex] = 100; // 카드를 치고 나면 100으로 셋팅한다.
        }
        // 뽑은 덱카드를 지운다.
        public void RemoveDeck()
        {
            deckcards.RemoveAt(0);
        }

        public int[] Cards { get { return cards; } } // 섞여진 카드 리턴
        public int[] MyCards { get { return mhcards; } } // 내카드 리턴
        public int[] GuestCards { get { return ghcards; } }  // 상대방 카드리턴
        public List<int>[] BoardCards { get { return boardcards; } }    // 보드에 깔릴 카드들 
        public int OpenDeck { get { return deckcards[0]; } }    // 오픈할 덱카드
        public PointBoard MePointBoard { get { return mepBoard; } } // 내포인트 보드
        public PointBoard GPBoard { get { return guestpBoard; } }   // 상대방 포인트 보드

    }


}
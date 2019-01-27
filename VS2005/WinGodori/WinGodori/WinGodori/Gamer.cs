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

        private int[] cards;     // ī�� 48��
        private int[] mhcards = new int[10];  // �տ� �� ī�� 10��
        private int[] ghcards = new int[10];  // ������ �� ī�� 10��

        private List<int> deckcards = new List<int>();
        private List<int>[] boardcards = new List<int>[12];  // ���忡 �׷��� 12���� ��ġ , �ִ� 4��
        private List<int> selectcards = new List<int>();      // ���õ� ī��� ����

        private PointBoard mepBoard = new PointBoard();
        private PointBoard guestpBoard = new PointBoard();

        private CardInfo cinfo;

        public Gamer(ref CardInfo c)
        {
            cinfo = c;
            Init_BoardCards();
        }

        // ���忡 �ִ� ī�� �ʱ�ȭ
        private void Init_BoardCards()
        {
            for (int i = 0; i < 12; i++)
                boardcards[i] = new List<int>();
        }

        // ī�带 �������� ���´�.
        public void MixCard()
        {
            List<int> temp_card = new List<int>();
            Random r = new Random();
            cards = new int[48];

            for (int i = 0; i < 48; i++)
                temp_card.Add(i);

            for (int i = 0; i < 48; i++)
            {
                int index = r.Next(0, temp_card.Count); // �ε��� �����ϰ� ����
                cards[i] = temp_card[index];             // ī�带 ����
                temp_card.RemoveAt(index);              // ����� ī��� ����
            }
        }
        // ī�带 �й��Ѵ�.
        public void Distribution(int[] buffer)
        {
            int[] tmp = new int[8];
            Array.Copy(buffer, 0, mhcards, 0, 10);   // ��ī��
            Array.Sort(mhcards);
            Array.Copy(buffer, 10, ghcards, 0, 10);  // ��� ī��
            Array.Sort(ghcards);
            Array.Copy(buffer, 20, tmp, 0, 8);    // ���� ī��
            // Array.Copy(buffer, 28, deckcards, 0, 22);    // ��ī��
            for (int i = 28; i < 48; i++)   // ��ī��
                deckcards.Add(buffer[i]);
            MakeBoard(tmp);
        }
        // ���忡 �׷��� ����� ��´�
        public void MakeBoard(int[] buffer)
        {
            foreach (int cnum in buffer)
                ReturnBoardPoint(cnum, false);
        }

        // ���忡 �׷��� ����Ʈ�����ϰ� �ε����� �����Ѵ�.
        public int ReturnBoardPoint(int cnum, bool flag)
        {
            int index = -1;
            for (int i = 0; i < 12; i++)
            {
                if (boardcards[i].Count != 0 && cinfo.IsSameCardKind(boardcards[i][0], cnum))
                {
                    if (boardcards[i].Count == 3)   // �װ��� �Դ´�.
                    {
                        foreach (int tmp in boardcards[i])
                            selectcards.Add(tmp);
                        selectcards.Add(cnum);
                    }
                    else if (flag && !IsExist(boardcards[i][0])) // ���� ���õ� ī�忡 �������� �ʴ´ٸ� �߰�
                    {
                        selectcards.Add(boardcards[i][0]);
                        selectcards.Add(cnum);
                    }

                    else if (IsExist(boardcards[i][0]) && selectcards.Count == 2) // �״�
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
        // �̹������ϴ��� �˻�
        public bool IsExist(int num)
        {
            foreach (int cnum in selectcards)
                if (num == cnum) return true;
            return false;
        }

        //  ���õ� ī�带 ���忡�� ���� �ش�
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
        // ���忡 ��ġ�� ã�´� ... �� ���Լ��� �������� (-1-,1)�� ���ϵǸ� ������
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


        // ����Ʈ ���� ����
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


        // ī�带 ģ��.
        public void HitCard(int hindex)
        {
            mhcards[hindex] = 100; // ī�带 ġ�� ���� 100���� �����Ѵ�.
        }
        // ���� ��ī�带 �����.
        public void RemoveDeck()
        {
            deckcards.RemoveAt(0);
        }

        public int[] Cards { get { return cards; } } // ������ ī�� ����
        public int[] MyCards { get { return mhcards; } } // ��ī�� ����
        public int[] GuestCards { get { return ghcards; } }  // ���� ī�帮��
        public List<int>[] BoardCards { get { return boardcards; } }    // ���忡 �� ī��� 
        public int OpenDeck { get { return deckcards[0]; } }    // ������ ��ī��
        public PointBoard MePointBoard { get { return mepBoard; } } // ������Ʈ ����
        public PointBoard GPBoard { get { return guestpBoard; } }   // ���� ����Ʈ ����

    }


}
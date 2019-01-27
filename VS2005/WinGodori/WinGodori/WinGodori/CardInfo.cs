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
    enum CardKind { LIGHT = 1, ANIMAL = 2, BAND = 3, THREE = 4, TWO = 5, ONE = 6 } // ��, ����,  ��, 3��, 2��, 1��

    struct Card
    {
        public int num;
        public CardKind cKind;
    }

    class CardInfo
    {
        private Card[] card = new Card[50];

        public CardInfo()
        {
            Init_CardNumber();    // ī�� ��ȣ    
            Init_CardKind();   // ī�� ����
        }
        // ī�� ���� �ʱ�ȭ
        private void Init_CardNumber()
        {
            for (int i = 0; i < 50; i++)    // 1, 2, ......, 12
                card[i].num = i / 4 + 1;
            // ���߿� ��Ŀ �߰�
            //   card[48].num = 13; // 3��
            //   card[49].num = 14; // 2��
        }
        // ī������ʱ�ȭ
        private void Init_CardKind()
        {
            for (int i = 0; i < 50; i++)    // 1�� 
                SetCardKind(CardKind.ONE, i);
            SetCardKind(CardKind.LIGHT, 0, 8, 28, 40, 44);    // �� 5
            SetCardKind(CardKind.ANIMAL, 4, 12, 16, 20, 24, 29, 32, 36, 45);  // ���� 9
            SetCardKind(CardKind.BAND, 1, 5, 9, 13, 17, 21, 25, 33, 37, 46);  // �� 10
            SetCardKind(CardKind.THREE, 48);  // 3�� 1
            SetCardKind(CardKind.TWO, 41, 47, 49); // 2�� 3 

        }
        // params
        private void SetCardKind(CardKind cs, params int[] index1)
        {
            foreach (int index2 in index1)
                card[index2].cKind = cs;
        }

        // ���� ������ ī���̸� true
        public bool IsSameCardKind(int index1, int index2)
        {
            if (card[index1].num == card[index2].num) return true;
            return false;
        }
        //ī�� ��ȣ�� ������ ī�� ���¸� �����Ѵ�
        public CardKind GetCardKind(int cnum)
        {
            return card[cnum].cKind;
        }

    }
}

//           // ī�������� �����Ѵ�.
//           public Card GetCardInfo(int index)
//           {
//               return card[index];
//           }
//           // �� ī�尡 ���� ��ȣ�̸�  true
//           public bool IsSameKindCard(int index1, int index2)
//           {
//               if (card[index1].kind == card[index2].kind)
//                   return true;
//               else
//                   return false;
//           }
//       }


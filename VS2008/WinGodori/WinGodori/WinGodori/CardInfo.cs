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
    enum CardKind { LIGHT = 1, ANIMAL = 2, BAND = 3, THREE = 4, TWO = 5, ONE = 6 } // 광, 동물,  띠, 3피, 2피, 1피

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
            Init_CardNumber();    // 카드 번호    
            Init_CardKind();   // 카드 상태
        }
        // 카드 종류 초기화
        private void Init_CardNumber()
        {
            for (int i = 0; i < 50; i++)    // 1, 2, ......, 12
                card[i].num = i / 4 + 1;
            // 나중에 조커 추가
            //   card[48].num = 13; // 3피
            //   card[49].num = 14; // 2피
        }
        // 카드상태초기화
        private void Init_CardKind()
        {
            for (int i = 0; i < 50; i++)    // 1피 
                SetCardKind(CardKind.ONE, i);
            SetCardKind(CardKind.LIGHT, 0, 8, 28, 40, 44);    // 광 5
            SetCardKind(CardKind.ANIMAL, 4, 12, 16, 20, 24, 29, 32, 36, 45);  // 동물 9
            SetCardKind(CardKind.BAND, 1, 5, 9, 13, 17, 21, 25, 33, 37, 46);  // 띠 10
            SetCardKind(CardKind.THREE, 48);  // 3피 1
            SetCardKind(CardKind.TWO, 41, 47, 49); // 2피 3 

        }
        // params
        private void SetCardKind(CardKind cs, params int[] index1)
        {
            foreach (int index2 in index1)
                card[index2].cKind = cs;
        }

        // 같은 종류에 카드이면 true
        public bool IsSameCardKind(int index1, int index2)
        {
            if (card[index1].num == card[index2].num) return true;
            return false;
        }
        //카드 번호를 가지고 카드 상태를 리턴한다
        public CardKind GetCardKind(int cnum)
        {
            return card[cnum].cKind;
        }

    }
}

//           // 카드정보를 리턴한다.
//           public Card GetCardInfo(int index)
//           {
//               return card[index];
//           }
//           // 두 카드가 같은 번호이면  true
//           public bool IsSameKindCard(int index1, int index2)
//           {
//               if (card[index1].kind == card[index2].kind)
//                   return true;
//               else
//                   return false;
//           }
//       }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

// 이미지 위치 정보를 저장하고 있는 클래스
// 음................시간돼면 포인트로 바꿔주장???^^;; 

namespace WinGodori
{
    class ImagePoint
    {
        public Rectangle backRect = new Rectangle(0, 24, 800, 624);    // 백그라운드 
        public Rectangle bgdeckRect = new Rectangle(492, 294, 49, 67);    // 덱카드 
        public Rectangle ghRect = new Rectangle(598, 65, 20, 30);           // 상대방카드
        public Rectangle gvRect = new Rectangle(598, 127, 36, 55);      // 상대방 보여질 카드 위치

        public Rectangle mpLightRect = new Rectangle(196, 555, 36, 55); // 내 포인트에 광이 찍일 지점
        public Rectangle mpAnimalRect = new Rectangle(290, 494, 36, 55); // 내 포인트에 동물이 찍일 지점
        public Rectangle mpBandRect = new Rectangle(290, 555, 36, 55); // 내 포인트에 띠이 찍일 지점
        public Rectangle mpPiRect = new Rectangle(432, 555, 36, 55); // 내 포인트에 피이 찍일 지점

        public Rectangle gpLightRect = new Rectangle(196, 56, 36, 55); // 상대방 포인트에 광이 찍일 지점
        public Rectangle gpAnimalRect = new Rectangle(290, 56, 36, 55); // 상대방 포인트에 동물이 찍일 지점
        public Rectangle gpBandRect = new Rectangle(290, 117, 36, 55); // 상대방 포인트에 띠이 찍일 지점
        public Rectangle gpPiRect = new Rectangle(432, 117, 36, 55); // 상대방 포인트에 피이 찍일 지점

        public Rectangle mpboardRect = new Rectangle(196, 494, 398, 116);   // 내 점수 카드
        public Rectangle gpboardRect = new Rectangle(196, 56, 398, 116);    // 상대방 점수 카드 
        public Rectangle[] mhRect = new Rectangle[10];  // 내가 손에 든 카드
        public Rectangle[] boardRect = new Rectangle[12];   // 보드에 그려줄 카드 위치

        public ImagePoint()
        {
            SetMyHandCardRect();
            SetBoardCardRect();
        }

        // 내가 손에든 카드에 위치 지정
        private void SetMyHandCardRect()
        {
            for (int i = 0; i < 10; i++)
                mhRect[i] = new Rectangle(598 + (i % 5) * 39, 494 + (i / 5) * 61, 36, 55);
        }
        // 보드에 지정할 카드 위치
        private void SetBoardCardRect()
        {
            boardRect[0] = new Rectangle(340, 220, 36, 55);
            boardRect[1] = new Rectangle(432, 220, 36, 55);
            boardRect[2] = new Rectangle(524, 220, 36, 55);
            boardRect[3] = new Rectangle(382, 298, 36, 55);
            boardRect[4] = new Rectangle(566, 298, 36, 55);
            boardRect[5] = new Rectangle(407, 376, 36, 55);
            boardRect[6] = new Rectangle(499, 376, 36, 55);
            boardRect[7] = new Rectangle(591, 376, 36, 55);
            boardRect[8] = new Rectangle(290, 298, 36, 55);
            boardRect[9] = new Rectangle(315, 376, 36, 55);
            boardRect[10] = new Rectangle(616, 220, 36, 55);
            boardRect[11] = new Rectangle(658, 298, 36, 55);
        }
        // 만약 클릭이 유효하다면 해당 인덱스를 리턴한다. 아니면 -1
        public int Isvalidclick(int x, int y)
        {
            for (int i = 0; i < 10; i++)
                if (mhRect[i].Contains(x, y)) return i;

            return -1;
        }
    }

}
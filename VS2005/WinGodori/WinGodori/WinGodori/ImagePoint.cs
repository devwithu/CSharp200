using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

// �̹��� ��ġ ������ �����ϰ� �ִ� Ŭ����
// ��................�ð��Ÿ� ����Ʈ�� �ٲ�����???^^;; 

namespace WinGodori
{
    class ImagePoint
    {
        public Rectangle backRect = new Rectangle(0, 24, 800, 624);    // ��׶��� 
        public Rectangle bgdeckRect = new Rectangle(492, 294, 49, 67);    // ��ī�� 
        public Rectangle ghRect = new Rectangle(598, 65, 20, 30);           // ����ī��
        public Rectangle gvRect = new Rectangle(598, 127, 36, 55);      // ���� ������ ī�� ��ġ

        public Rectangle mpLightRect = new Rectangle(196, 555, 36, 55); // �� ����Ʈ�� ���� ���� ����
        public Rectangle mpAnimalRect = new Rectangle(290, 494, 36, 55); // �� ����Ʈ�� ������ ���� ����
        public Rectangle mpBandRect = new Rectangle(290, 555, 36, 55); // �� ����Ʈ�� ���� ���� ����
        public Rectangle mpPiRect = new Rectangle(432, 555, 36, 55); // �� ����Ʈ�� ���� ���� ����

        public Rectangle gpLightRect = new Rectangle(196, 56, 36, 55); // ���� ����Ʈ�� ���� ���� ����
        public Rectangle gpAnimalRect = new Rectangle(290, 56, 36, 55); // ���� ����Ʈ�� ������ ���� ����
        public Rectangle gpBandRect = new Rectangle(290, 117, 36, 55); // ���� ����Ʈ�� ���� ���� ����
        public Rectangle gpPiRect = new Rectangle(432, 117, 36, 55); // ���� ����Ʈ�� ���� ���� ����

        public Rectangle mpboardRect = new Rectangle(196, 494, 398, 116);   // �� ���� ī��
        public Rectangle gpboardRect = new Rectangle(196, 56, 398, 116);    // ���� ���� ī�� 
        public Rectangle[] mhRect = new Rectangle[10];  // ���� �տ� �� ī��
        public Rectangle[] boardRect = new Rectangle[12];   // ���忡 �׷��� ī�� ��ġ

        public ImagePoint()
        {
            SetMyHandCardRect();
            SetBoardCardRect();
        }

        // ���� �տ��� ī�忡 ��ġ ����
        private void SetMyHandCardRect()
        {
            for (int i = 0; i < 10; i++)
                mhRect[i] = new Rectangle(598 + (i % 5) * 39, 494 + (i / 5) * 61, 36, 55);
        }
        // ���忡 ������ ī�� ��ġ
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
        // ���� Ŭ���� ��ȿ�ϴٸ� �ش� �ε����� �����Ѵ�. �ƴϸ� -1
        public int Isvalidclick(int x, int y)
        {
            for (int i = 0; i < 10; i++)
                if (mhRect[i].Contains(x, y)) return i;

            return -1;
        }
    }

}
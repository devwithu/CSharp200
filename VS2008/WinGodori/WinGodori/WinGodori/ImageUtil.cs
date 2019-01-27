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
     struct Order
    {
        public int first;
        public int second;
        public int third;
    }


     class ImageUtil
    {
        private Image bg_img;     // 백이미지
        private Image small_img;
        private ImageList bgdeck_imgList; // 덱 카드 이미지 리스트
        private ImageList card_imgList; // 카드 이미지 리스트
        private ImagePoint imgp;    // 이미지포인트
        private ImageList notify_imgList;
        private ImageList score_imgList;    // 점수 이미지
        private Image avatar;

        // 생성자를 사용해서 이미지를 로드한다.
        public ImageUtil(ref ImagePoint ip)
        {
            imgp = ip;
            bg_img = Image.FromFile("./images/bg_gostop.bmp");      // 백그라운드
            small_img = Image.FromFile("./images/scard.bmp");       // 상대방 카드
            card_imgList = GetHeightLongImage("./images/card.bmp", 51);    // 카드
            bgdeck_imgList = GetWidthLongImage("./images/bdeck.bmp", 2);      // 덱배경
            bgdeck_imgList.TransparentColor = Color.FromArgb(1, 255, 0, 255);   //투명색
            notify_imgList = GetHeightLongImage("./images/notify.bmp", 2);
            notify_imgList.TransparentColor = Color.FromArgb(1, 255, 0, 255);
            score_imgList = GetWidthLongImage("./images/score.bmp", 10);
            score_imgList.TransparentColor = Color.FromArgb(1, 255, 0, 255);
            avatar = Image.FromFile("./images/robot_avatar.gif");
        }

        public void DrawAvatar(Graphics g, int x, int y)
        {
            g.DrawImage(avatar, x, y);
        }

        // 자리수에 맞는 숫자를 그리기 위해 숫자그리기 함수를 콜한다.
        public void DrawMyScore(Graphics g, int score)
        {
            Order so = new Order();
            so = CalOrder(score);

            g.DrawImage(score_imgList.Images[so.third], 208, 495);
            g.DrawImage(score_imgList.Images[so.second], 224, 495);
            g.DrawImage(score_imgList.Images[so.first], 240, 495);

        }

        public void DrawGuestScore(Graphics g, int score)
        {
            Order so = new Order();
            so = CalOrder(score);

            g.DrawImage(score_imgList.Images[so.third], 208, 152);
            g.DrawImage(score_imgList.Images[so.second], 224, 152);
            g.DrawImage(score_imgList.Images[so.first], 240, 152);
        }

        // 자리수 계산 (음수 처리 가능)
        public Order CalOrder(int value)
        {
            Order temp = new Order();
            bool minus = false;
            if (value < 0)
            {
                value *= -1;
                minus = true;
            }
            temp.first = value % 10;
            temp.second = value / 10 % 10;
            temp.third = value / 100;

            if (minus)
            { // 마이너스일 경우 
                if (temp.third == 0)
                {
                    if (temp.second == 0)
                    {
                        temp.second = 11;
                    }
                    else temp.third = 11;
                }
            }
            return temp;
        }
        public void DrawNotify(Graphics g, int x, int y)
        {
            g.DrawImage(notify_imgList.Images[0], x, y);
        }
        // 배경을 그린다
        public void DrawBackGround(Graphics g)
        {
            g.DrawImage(bg_img, imgp.backRect);
        }
        // 카드 위치 테스트용
        public void DrawTestCard(Graphics g, int i, Rectangle r)
        {
            g.DrawImage(card_imgList.Images[i], r);
        }
        // 열린 덱 카드를 그린다.
        public void DrawOpenDeck(Graphics g, int index)
        {
            Rectangle tmp = imgp.bgdeckRect;
            tmp.Width = 36;
            tmp.Height = 55;
            g.DrawImage(card_imgList.Images[index], tmp);
        }

        // 내가 손에 든 카드를 그린다
        public void DrawMyHandCard(Graphics g, int[] mhcard)
        {
            Console.WriteLine();
            int cnt = 0;
            foreach (int cardnum in mhcard)
            {
                if (cardnum != 100)
                    g.DrawImage(card_imgList.Images[cardnum], imgp.mhRect[cnt]);
                cnt++;
            }
        }

        // 보드를 그린다 
        public void DrawBoardCard(Graphics g, List<int>[] bcards)
        {
            for (int i = 0; i < bcards.Length; i++)
                for (int j = 0; j < bcards[i].Count; j++)
                    g.DrawImage(card_imgList.Images[bcards[i][j]], imgp.boardRect[i].X + (18 * j), imgp.boardRect[i].Y);
        }
        // 덱을 그린다
        public void DrawBGDeck(Graphics g)
        {
            g.DrawImage(bgdeck_imgList.Images[1], imgp.bgdeckRect);
            for (int i = 0; i < 8; i++)
                g.DrawImage(card_imgList.Images[50], imgp.bgdeckRect.X - i + 6, imgp.bgdeckRect.Y - i + 6);
        }
        // 상대방 카드를 그린다
        public void DrawGuestCard(Graphics g, int num)
        {
            for (int i = 0; i < num; i++)
                g.DrawImage(small_img, imgp.ghRect.X + ((i % 5) * 13), imgp.ghRect.Y + (i / 5) * 32, small_img.Width, small_img.Height);
        }

        // 점수보드에 있는 그림을 그린다
        public void DrawMePointBoard(Graphics g, PointBoard p)
        {

            for (int i = 0; i < p.light.Count; i++)     // 광
                g.DrawImage(card_imgList.Images[p.light[i]], imgp.mpLightRect.X + (i * 18), imgp.mpLightRect.Y);

            for (int i = 0; i < p.animal.Count; i++)    // 동물
                g.DrawImage(card_imgList.Images[p.animal[i]], imgp.mpAnimalRect.X + (i * 18), imgp.mpAnimalRect.Y);

            for (int i = 0; i < p.band.Count; i++)  // 띠
                g.DrawImage(card_imgList.Images[p.band[i]], imgp.mpBandRect.X + (i * 18), imgp.mpBandRect.Y);

            for (int i = 0; i < p.pi.Count; i++)
                g.DrawImage(card_imgList.Images[p.pi[i]], imgp.mpPiRect.X + (i % 8) * 18, imgp.mpPiRect.Y - (i / 8) * 23);
        }

        public void DrawGuestPointBoard(Graphics g, PointBoard p)
        {

            for (int i = 0; i < p.light.Count; i++)     // 광
                g.DrawImage(card_imgList.Images[p.light[i]], imgp.gpLightRect.X + (i * 18), imgp.gpLightRect.Y);

            for (int i = 0; i < p.animal.Count; i++)    // 동물
                g.DrawImage(card_imgList.Images[p.animal[i]], imgp.gpAnimalRect.X + (i * 18), imgp.gpAnimalRect.Y);

            for (int i = 0; i < p.band.Count; i++)  // 띠
                g.DrawImage(card_imgList.Images[p.band[i]], imgp.gpBandRect.X + (i * 18), imgp.gpBandRect.Y);

            for (int i = 0; i < p.pi.Count; i++)
                g.DrawImage(card_imgList.Images[p.pi[i]], imgp.gpPiRect.X + (i % 8) * 18, imgp.gpPiRect.Y - (i / 8) * 23);
        }




        public void DrawCard(Graphics g, int cnum, Rectangle r)
        {
            g.DrawImage(card_imgList.Images[cnum], r);
        }


        // 세로가 긴 이미지 로드
        public ImageList GetHeightLongImage(string FileName, int ItemValue)
        {
            ImageList imgList1 = new ImageList();
            ImageList imgList2 = new ImageList();

            Image img = Image.FromFile(FileName);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            imgList1.ImageSize = new Size(img.Width / ItemValue, img.Height);
            imgList1.Images.AddStrip(img);

            imgList2.ImageSize = new Size(img.Height, img.Width / ItemValue);

            for (int i = 0; i < imgList1.Images.Count; i++)
            {
                Image tempImg = imgList1.Images[ItemValue - 1 - i];  // 그림 숫자에 맞게 집어 넣기
                tempImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
                imgList2.Images.Add(tempImg);
            }

            imgList1.Dispose();
            img.Dispose();
            imgList2.Dispose();

            return imgList2;
        }

        // 가로가 긴 이미지 로드
        public ImageList GetWidthLongImage(string FileName, int ItemValue)
        {
            ImageList imgList = new ImageList();
            Image img = Image.FromFile(FileName);
            imgList.ImageSize = new Size(img.Width / ItemValue, img.Height);
            imgList.Images.AddStrip(img);
            imgList.Dispose();

            return imgList;
        }
        public ImageList CardsImage { get { return card_imgList; } }
    }
}
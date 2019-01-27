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
    // 점수 계산하는 함수

    class GoStopPoint
    {
        private int multi = 1;   // 곱하기
        private bool pflag = true;  // 피박
        private bool lflag = true; // 광박
        private int total = 0;    // 총점

        public GoStopPoint()
        {
            // CalTotal(pb);

        }
        // 총합계산 // 곱하기는 계산 안함
        public int CalTotal(PointBoard pb)
        {
            int total = 0;
            total += CalLight(pb.light);
            total += CalAnimal(pb.animal);
            total += CalBand(pb.band);
            total += CalPi(pb.pi);
            return total;
        }

        // 광을 계산한다
        private int CalLight(List<int> lList)
        {
            int point = 0;

            if (lList.Count == 5)   // 5광이면
            {
                multi *= 2;
                point = 15;
            }
            else                   // 비광이 포함되면 -1점 44
            {
                if (lList.Count > 2) point = lList.Count;
                Searcher.num = 44;
                if (point != 0 && lList.Exists(Searcher.NumberSearcher)) point -= 1;
            }

            if (lList.Count > 0) lflag = false; // 광박 체크
            return point;
        }


        // 동물을 계산한다.
        private int CalAnimal(List<int> aniList)
        {
            int point = 0;

            if (aniList.Count > 4) point += (aniList.Count - 4);    // 5장부터 1점
            if (IsGoDori(aniList)) point += 5;                      // 고도리 5점
            if (aniList.Count >= 7) multi *= 2;                     // 동물 2배

            return point;
        }

        // 고도리 인가? 4 12 29
        private bool IsGoDori(List<int> ani)
        {
            return SearchNum(ani, 4, 12, 29);
        }

        // 띠를 계산한다.
        private int CalBand(List<int> bList)
        {
            int point = 0;

            if (bList.Count > 4) point += (bList.Count - 4);    // 5장부터 1점
            if (IsRedDan(bList)) point += 3;                    // 홍단 3점
            if (IsBlueDan(bList)) point += 3;                   // 청단 3점
            if (IsChoDan(bList)) point += 3;                    // 초단 3점

            return point;
        }

        // 홍단인가  1 5 9
        private bool IsRedDan(List<int> band)
        {
            return SearchNum(band, 1, 5, 9);
        }
        // 초단인가 13  17 25
        private bool IsChoDan(List<int> band)
        {
            return SearchNum(band, 13, 17, 25);
        }

        // 청단인가 21 33 37
        private bool IsBlueDan(List<int> band)
        {
            return SearchNum(band, 21, 33, 37);
        }
        // list 에서 3개에 번호가 존재하는지를 리턴한다.
        private bool SearchNum(List<int> list, int cnum1, int cnum2, int cnum3)
        {
            Searcher.num = cnum1;
            bool r1 = list.Exists(Searcher.NumberSearcher);
            Searcher.num = cnum2;
            bool r2 = list.Exists(Searcher.NumberSearcher);
            Searcher.num = cnum3;
            bool r3 = list.Exists(Searcher.NumberSearcher);

            return (r1 && r2 && r3);
        }

        // 피에 모든합을 더한 후 10장부터 1점으로 계산한다. 
        private int CalPi(List<int> piList)
        {
            int point = 0;

            foreach (int cnum in piList)
            {
                if (cnum == 41 || cnum == 47) point += 2;   // 2피
                else point += 1;
            }

            if (point > 5) pflag = false;   // 피박체크
            if (point < 10) return 0;
            return (point - 9);
        }

        public int Total { get { return total; } }  // 총합
        public int Multi { get { return multi; } }  // 배수
    }

    class Searcher
    {
        public static int num = -1;

        public static bool NumberSearcher(int cnum)
        {
            return cnum == num;
        }
    }
}
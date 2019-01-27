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
    // ���� ����ϴ� �Լ�

    class GoStopPoint
    {
        private int multi = 1;   // ���ϱ�
        private bool pflag = true;  // �ǹ�
        private bool lflag = true; // ����
        private int total = 0;    // ����

        public GoStopPoint()
        {
            // CalTotal(pb);

        }
        // ���հ�� // ���ϱ�� ��� ����
        public int CalTotal(PointBoard pb)
        {
            int total = 0;
            total += CalLight(pb.light);
            total += CalAnimal(pb.animal);
            total += CalBand(pb.band);
            total += CalPi(pb.pi);
            return total;
        }

        // ���� ����Ѵ�
        private int CalLight(List<int> lList)
        {
            int point = 0;

            if (lList.Count == 5)   // 5���̸�
            {
                multi *= 2;
                point = 15;
            }
            else                   // ���� ���ԵǸ� -1�� 44
            {
                if (lList.Count > 2) point = lList.Count;
                Searcher.num = 44;
                if (point != 0 && lList.Exists(Searcher.NumberSearcher)) point -= 1;
            }

            if (lList.Count > 0) lflag = false; // ���� üũ
            return point;
        }


        // ������ ����Ѵ�.
        private int CalAnimal(List<int> aniList)
        {
            int point = 0;

            if (aniList.Count > 4) point += (aniList.Count - 4);    // 5����� 1��
            if (IsGoDori(aniList)) point += 5;                      // ���� 5��
            if (aniList.Count >= 7) multi *= 2;                     // ���� 2��

            return point;
        }

        // ���� �ΰ�? 4 12 29
        private bool IsGoDori(List<int> ani)
        {
            return SearchNum(ani, 4, 12, 29);
        }

        // �츦 ����Ѵ�.
        private int CalBand(List<int> bList)
        {
            int point = 0;

            if (bList.Count > 4) point += (bList.Count - 4);    // 5����� 1��
            if (IsRedDan(bList)) point += 3;                    // ȫ�� 3��
            if (IsBlueDan(bList)) point += 3;                   // û�� 3��
            if (IsChoDan(bList)) point += 3;                    // �ʴ� 3��

            return point;
        }

        // ȫ���ΰ�  1 5 9
        private bool IsRedDan(List<int> band)
        {
            return SearchNum(band, 1, 5, 9);
        }
        // �ʴ��ΰ� 13  17 25
        private bool IsChoDan(List<int> band)
        {
            return SearchNum(band, 13, 17, 25);
        }

        // û���ΰ� 21 33 37
        private bool IsBlueDan(List<int> band)
        {
            return SearchNum(band, 21, 33, 37);
        }
        // list ���� 3���� ��ȣ�� �����ϴ����� �����Ѵ�.
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

        // �ǿ� ������� ���� �� 10����� 1������ ����Ѵ�. 
        private int CalPi(List<int> piList)
        {
            int point = 0;

            foreach (int cnum in piList)
            {
                if (cnum == 41 || cnum == 47) point += 2;   // 2��
                else point += 1;
            }

            if (point > 5) pflag = false;   // �ǹ�üũ
            if (point < 10) return 0;
            return (point - 9);
        }

        public int Total { get { return total; } }  // ����
        public int Multi { get { return multi; } }  // ���
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
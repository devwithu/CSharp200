using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
namespace WinBomb
{
/*************************************************************************************************/
//       프로그램명 : 지뢰 찾기 v1 
//       작성 날짜 : 20070610
//       작성자 : 김일곤
//       프로그램 내용 : 윈도우게임인 지뢰 찾기를 구현하였다. 기본적인 메뉴를 구현하였으며
//                       초급,중급,고급 단계 그리고 소리기능이 가능하다. 기본 설정은 중급 , 소리 ON
//                       상태이다.
//
/*************************************************************************************************/
public enum BombState { EMPTY = 0, ONE = 1, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, END = 10, FLAGEND = 11, BOMB = 12 };
public enum OpenState { CLOSE = 0, OPEN, FLAG, QUESTION };

public struct Block
{
    public BombState bState;
    public OpenState oState;
    public bool down;
};

public struct Position
{
    public int row;
    public int col;
};

public struct Order
{
    public int first;
    public int second;
    public int third;
};

public static class DrawUtil
{   // 3차원 사각형을 그리는 함수
    //Graphics 객체를 얻는 방법은 상황에 따라 다르므로 범용적인 그리기 함수를 위해서는  직접 Graphics를 구하지말고 인자로 
    // 받도록 한다.
    public static void Draw3DRect(Graphics g, int x, int y, int xx, int yy, bool bDown, int width)
    {
        // Pen과 Brush를 만들어서 3차원 사각형을 그리는 코드
        Pen pen1, pen2;

        if (bDown)
        {
            pen2 = new Pen(Color.White);
            pen1 = new Pen(Color.Gray);
        }
        else
        {
            pen1 = new Pen(Color.White);
            pen2 = new Pen(Color.Gray);
        }
        SolidBrush brush = new SolidBrush(Color.FromArgb(192, 192, 192));

        int w = xx - x;
        int h = yy - y;
        g.FillRectangle(brush, x, y, w + 1, h + 1);

        for (int i = 0; i < width; i++)
        {
            g.DrawLine(pen1, xx - 1, y, x, y);
            g.DrawLine(pen1, x, y, x, yy - 1);

            g.DrawLine(pen2, x, yy, xx, yy);
            g.DrawLine(pen2, xx, yy, xx, y);

            x++; y++; xx--; yy--;
        }
        // 자동으로는 pen 객체가 언제 사라질지 모르므로 즉시 사라지기 위해 Dispose()호츨 , 메모리 관리가 편하다.
        //
        pen1.Dispose();
        pen2.Dispose();
        brush.Dispose();

    }
}

}
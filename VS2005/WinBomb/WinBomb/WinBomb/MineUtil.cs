using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
namespace WinBomb
{
/*************************************************************************************************/
//       ���α׷��� : ���� ã�� v1 
//       �ۼ� ��¥ : 20070610
//       �ۼ��� : ���ϰ�
//       ���α׷� ���� : ����������� ���� ã�⸦ �����Ͽ���. �⺻���� �޴��� �����Ͽ�����
//                       �ʱ�,�߱�,��� �ܰ� �׸��� �Ҹ������ �����ϴ�. �⺻ ������ �߱� , �Ҹ� ON
//                       �����̴�.
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
{   // 3���� �簢���� �׸��� �Լ�
    //Graphics ��ü�� ��� ����� ��Ȳ�� ���� �ٸ��Ƿ� �������� �׸��� �Լ��� ���ؼ���  ���� Graphics�� ���������� ���ڷ� 
    // �޵��� �Ѵ�.
    public static void Draw3DRect(Graphics g, int x, int y, int xx, int yy, bool bDown, int width)
    {
        // Pen�� Brush�� ���� 3���� �簢���� �׸��� �ڵ�
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
        // �ڵ����δ� pen ��ü�� ���� ������� �𸣹Ƿ� ��� ������� ���� Dispose()ȣ�� , �޸� ������ ���ϴ�.
        //
        pen1.Dispose();
        pen2.Dispose();
        brush.Dispose();

    }
}

}
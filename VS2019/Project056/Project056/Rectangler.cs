using System;
using System.Drawing;
namespace Com.JungBo.Drawings
{
    public class Rectangler : Shape
    {
        public Rectangler(float x, float y, float width,
            float height, Color color)
            : base(x, y, width, height, color) { }

        public Rectangler(float x, float y, float width,
            float height) : base(x, y, width, height) { }

        public void DrawRectangler(Graphics g)
        {
            Pen xPen = new Pen(color, 1);
            g.DrawRectangle(xPen, x, y, width, height);
            xPen.Dispose();
        }
    }
}

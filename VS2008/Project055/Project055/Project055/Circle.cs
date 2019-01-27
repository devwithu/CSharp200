using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class Circle:Shape{
        public Circle(float x, float y,
            float width, float height, Color color){
            this.x = x;
            this.y = y;
            this.color = color;
            this.width = width;
            this.height = height;
        }
        public  void DrawCircle(Graphics g){
            Pen xPen = new Pen(color, 1);
            g.DrawArc(xPen,
              new RectangleF(x, y, 
              width, height), 0.0f, 360.0f);
            xPen.Dispose();
        }
    }
}

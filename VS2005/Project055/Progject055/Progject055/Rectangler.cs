using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class Rectangler:Shape{
        public Rectangler(float x, float y, 
            float width, float height, Color color){
            this.x = x;
            this.y = y;
            this.color = color;
            this.width = width;
            this.height = height;
        }
        public void DrawRectangler(Graphics g){
            Pen xPen = new Pen(color, 1);
            g.DrawRectangle(xPen, x, y, width, height);
            xPen.Dispose();
        }
    }
}

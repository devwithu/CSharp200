using System;
using System.Drawing;

namespace Com.JungBo.Drawings{
    public class DoubleCricle:Shape{
        public DoubleCricle(float x, float y, float width, 
            float height, Color color)
            :base(x,y,width,height,color){}
        public DoubleCricle(float x, float y, float width,
            float height): base(x, y, width, height) { }
        public override void Draw(Graphics g){
            Pen xPen = new Pen(color, 1);
            g.DrawArc(xPen,
              new RectangleF(x, y, 
              width, height), 0.0f, 360.0f);
            g.DrawArc(xPen,
              new RectangleF(x-5, y-5,
              width+10, height+10), 0.0f, 360.0f);
            xPen.Dispose();
        }
    }
}

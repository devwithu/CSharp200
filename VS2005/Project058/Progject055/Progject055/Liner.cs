using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class Liner:Shape{
        public Liner(float x, float y, float width, 
            float height, Color color)
            :base(x,y,width,height,color){}

        public Liner(float x, float y, float width,
            float height): base(x, y, width, height) { }
        public override void Draw(Graphics g){
            Pen xPen = new Pen(color, 2);
            g.DrawLine(xPen, x, y, width, height);
            xPen.Dispose();
        }
    }
}

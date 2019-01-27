using System;
using System.Collections.Generic;
using System.Drawing;
namespace Com.JungBo.Logic{
    public class PointFs{
        //���׸�(���׸�)
        private List<PointF> pointList = new List<PointF>();
        //����ü--> value
        private Color colors;
        public PointFs(Color c) {
            this.colors = c;
        }
        public Color Colors{
            get { return colors; }
            set { colors = value; }
        }
        private int penWidth;
        public int PenWidth{
            get { return penWidth; }
            set { penWidth = value; }
        }
        public List<PointF> PointList{
            get { return pointList; }
        }
        public void Add(PointF c) {
            pointList.Add(c);
        }
        public PointF this[int index]{
            get { return pointList[index] ; }
        }
        public void Draw(Graphics g){
            int count=pointList.Count;
            Pen xPen = new Pen(colors, penWidth);
            for (int i = 0; i < count - 1; i++){
                g.DrawLine(xPen, pointList[i], pointList[i + 1]);
            }
            xPen.Dispose();
        }
        public void Remove() {
            pointList.Clear();
        }
    }
}

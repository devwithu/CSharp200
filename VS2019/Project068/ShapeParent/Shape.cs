using System;
using System.Drawing;
namespace Com.JungBo.Drawings
{
    public class Shape
    {
        //--��Ӱ��谡 �ƴϸ� privateó���ȴ�.
        //protected Color color;
        //protected float x;
        //protected float y;
        //protected float width;
        //protected float height;
        //--��Ӱ����� protected�� �����ϴ�.
        protected internal Color color;
        protected internal float x;
        protected internal float y;
        protected internal float width;
        protected internal float height;
        //--�ٸ� ������� �ִ� �ڽĵ� ����� �� ����.
        // internal Color color;
        // internal float x;
        // internal float y;
        // internal float width;
        // internal float height;
        public Shape() : this(0.0f, 0.0f, 10f, 10f, Color.Black) { }
        public Shape(float x, float y, float width, float height)
            : this(x, y, width, height, Color.Black) { }
        public Shape(float x, float y,
            float width, float height, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
        }
        public virtual void Draw(Graphics g)
        {
            SolidBrush axisXBrush = new SolidBrush(color);
            g.FillEllipse(axisXBrush, x, y, width, height);
        }
        public Color ShapeColor
        {
            get { return color; }
            set { color = value; }
        }
        //(mx,my)�� �̵��Ѵ�.
        public virtual void Move(float mx, float my)
        {
            this.x += mx;
            this.y += my;
        }
    }
}

using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class Shape{
        protected Color color;  //�ڽ��� ����� �� �ִ�.
        protected float x;     //�ڽ��� ����� �� �ִ�.
        protected float y;     //�ڽ��� ����� �� �ִ�.
        protected float width; //�ڽ��� ����� �� �ִ�.
        protected float height;//�ڽ��� ����� �� �ִ�.
        //�ڽİ�ü�� ������ �� �ڵ����� ȣ��Ǵ� ������
        //base��this�� ������� ������ �ݵ�� �ʿ�
        public Shape() { } //�⺻������
        public Shape(float x, float y,
            float width, float height,Color color){
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
        }
        public void DrawShape(Graphics g){
            SolidBrush axisXBrush = new SolidBrush(color);
            g.FillEllipse(axisXBrush,x,y,width,height);
        }
        public Color ShapeColor
        {
            get { return color; }
            set { color = value; }
        }
        //(mx,my)�� �̵��Ѵ�.
        public void Move(float mx, float my){
            this.x += mx;
            this.y += my;
        }
    }
}

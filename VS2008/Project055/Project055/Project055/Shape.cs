using System;
using System.Drawing;
namespace Com.JungBo.Drawings{
    public class Shape{
        protected Color color;  //자식이 사용할 수 있다.
        protected float x;     //자식이 사용할 수 있다.
        protected float y;     //자식이 사용할 수 있다.
        protected float width; //자식이 사용할 수 있다.
        protected float height;//자식이 사용할 수 있다.
        //자식개체가 생성될 때 자동으로 호출되는 생성자
        //base나this를 사용하지 않으면 반드시 필요
        public Shape() { } //기본생성자
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
        //(mx,my)씩 이동한다.
        public void Move(float mx, float my){
            this.x += mx;
            this.y += my;
        }
    }
}

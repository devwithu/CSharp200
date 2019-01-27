using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//SmoothingMode
namespace Project181
{
    public partial class Form1 : Form
    {
        PointF[] sf = new PointF[4];//초침 모양

        Matrix matrix = new Matrix();

        public Form1()
        {
            InitializeComponent();
            //-------- 아래에 쓸것.
            Init();
        }

        private void Init() {
            sf[0] = new PointF(0, -190);
            sf[1] = new PointF(-2, -160);
            sf[2] = new PointF(0, 0);
            sf[3] = new PointF(2, -160);

            float startS = DateTime.Now.Second;
            matrix.Reset();
            matrix.Rotate((float)((startS - 1) * 6.0f),
                MatrixOrder.Append);
            matrix.TransformPoints(sf);
        }
        protected override void OnPaint(PaintEventArgs pe){
            Graphics g = pe.Graphics;
            //선 연결을 깨끗하게
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(200f,200f);//상대원점0,0

            DrawCircle(g);//원 그리기
            DrawSecond(g);//초침 그리기
            //-------건들지마 위에다 써
            base.OnPaint(pe);
        }

        private void timer1_Tick(object sender, EventArgs e){
            string s = "     Kaoni Clock ver 0.1";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            string ss = string.Format("{0}시 {1}분 {2}초",
                hour,min,sec);
            s += "             " + ss;
            this.Text = s;
            this.Invalidate();//새로 갱신->OnPaint호출
        }//

        private void DrawCircle(Graphics g) {
            Pen xPen = new Pen(Color.Blue, 2);
            g.DrawArc(xPen,
                new Rectangle(-200, -200, 400, 400), 
                0.0f, 360.0f);//원 그리기
            xPen.Dispose();
        }
        private void DrawSecond(Graphics g){
            matrix.Reset();
            matrix.Rotate(6.0f);
            matrix.TransformPoints(sf);
            g.FillPolygon(new SolidBrush(Color.BlueViolet), sf);
        }
    }
}
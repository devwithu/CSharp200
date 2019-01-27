using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace ClockWin {
    public partial class Form1 : Form {
        byte[,] colors =  {{255, 0, 0}, {0, 255, 0}, {0, 0, 255},
							{255, 255, 0}, {255, 0, 255}, {0, 255, 255},
							{0, 128, 255}, {0, 255, 128}, {255, 0, 128}, 
							{128, 0, 255}, {255, 128, 0}, {128, 255, 0}};
        Random r = new Random(DateTime.Now.Millisecond);
        //��ħ, ��ħ, ��ħ
        PointF[] hf = new PointF[4];
        PointF[] sf = new PointF[4];
        PointF[] mf = new PointF[4];
        Matrix matrix = new Matrix();//ȸ����
        //�ð� �ð�ǥ�ÿ�
        Matrix rotateMatrix = new Matrix();   
        public Form1(){
            InitializeComponent();
            //-------------------
            Init();
        }
        private void Init() {
            //��ħ
            hf[0] = new PointF(0, -120);
            hf[1] = new PointF(-7, -100);
            hf[2] = new PointF(0, 0);
            hf[3] = new PointF(7, -100);
            //��ħ
            mf[0] = new PointF(0, -170);
            mf[1] = new PointF(-5, -150);
            mf[2] = new PointF(0, 0);
            mf[3] = new PointF(5, -150);
            //��ħ
            sf[0] = new PointF(0, -190);
            sf[1] = new PointF(-2, -160);
            sf[2] = new PointF(0, 0);
            sf[3] = new PointF(2, -160);
            float startH = DateTime.Now.Hour;
            float startM = DateTime.Now.Minute;
            float startS = DateTime.Now.Second;
            //---��ħ �ʱ�ȭ
            matrix.Reset();
            matrix.Rotate((float)((startH * 60f * 60f) /
                                   120.0f + startM * 0.5f),
                MatrixOrder.Append);
            matrix.TransformPoints(hf);
            //---��ħ �ʱ�ȭ
            matrix.Reset();
            matrix.Rotate((float)((startM * 60f) / 10.0f ), 
                MatrixOrder.Append);
            matrix.TransformPoints(mf);
            matrix.Reset();
            //---��ħ �ʱ�ȭ
            matrix.Rotate((float)((startS-1) * 6.0f), 
                MatrixOrder.Append);
            matrix.TransformPoints(sf);
        }
        protected override void OnPaint(PaintEventArgs pe){
            Graphics g = pe.Graphics;
            g.SmoothingMode =SmoothingMode.HighQuality;
            //������ 200,200->0,0���� �����
            g.TranslateTransform(200f,200f);
            //-------------------------------
            Render(g);
            DrawOutterCircle(g);
            DrawHour(g);
            DrawMinute(g);
            DrawSecond(g);
            //---------------------
            base.OnPaint(pe);
        }
        //1�ʸ��� ��ħ �̵���Ű�� �׸���
        private void DrawHour(Graphics g){
            matrix.Reset();
            matrix.Rotate(1.0f/120.0f);
            matrix.TransformPoints(hf);
            g.FillPolygon(new SolidBrush(Color.Red), hf);
        }
        //1�ʸ��� ��ħ �̵���Ű�� �׸���
        private void DrawMinute(Graphics g){
            matrix.Reset();
            matrix.Rotate(1.0f / 10.0f);
            matrix.TransformPoints(mf);
            g.FillPolygon(new SolidBrush(Color.DarkRed), mf);
        }
        //1�ʸ��� ��ħ �̵���Ű�� �׸���
        private void DrawSecond(Graphics g){
            matrix.Reset();
            matrix.Rotate(6.0f);
            matrix.TransformPoints(sf);
            g.FillPolygon(new SolidBrush(Color.BlueViolet), sf);
        }
        private void DrawOutterCircle(Graphics g){
            //�� �׸���)
            Pen xPen2 = new Pen(
               // Color.Blue, 2);
              FromRGB(r.Next(0, colors.GetLength(0))), 2);
            g.DrawArc(xPen2,
               new Rectangle(-195, -195, 390, 390), 0.0f, 360.0f);
            xPen2.Dispose();
            //�� �׸���
            Pen xPen = new Pen(
                Color.Blue, 2);
            g.DrawArc(xPen,
                new Rectangle(-200, -200, 400, 400), 0.0f, 360.0f);
            xPen.Dispose();
            //------------
            GraphicsPath path = new GraphicsPath();
            for (int i = 1; i <= 12; i++){
                rotateMatrix.Reset();//ȸ�� �ʱ�ȭ
                path.Reset();
                path.AddString(i.ToString(), 
                    this.Font.FontFamily, 1, 20,
                    new PointF(10.0F, -190.0F),  
                    //���� ���̸�ŭ ������ �����.
                    //0.0F, -190.0F-->10.0F, -190.0F                         
                    new StringFormat(
                    StringFormatFlags.DirectionRightToLeft));
                //30�� �� ������ 12, 1, 2, ~11 ǥ��
                rotateMatrix.RotateAt(30.0F*i,new PointF(0f, 0.0F));
                path.Transform(rotateMatrix);
                g.FillPath(new SolidBrush(
                    FromRGB(r.Next(0, colors.GetLength(0)))), path);
            }
            path.Dispose();
        }
        //�迭���� �� ����
        private Color FromRGB(int m ){ 
            Color col=Color.FromArgb(colors[m,0],
                colors[m,1],colors[m,2]);
            return col;
        }
        //������� �ð踦 ����� û��
        private void Render(Graphics g) {
             g.FillRectangle(
              new SolidBrush(Color.White),
              -200f, -200f, this.Width, this.Height);
        }
        //1�ʸ��� �� �ú�ħ�ʸ� �̵���Ű�� �׸���.
        private void timer1_Tick(object sender, EventArgs e){
            string s = "    JungBo Clock ver 0.3";
            this.Text = s + "                       "
                +DateTime.Now.Hour+"�� "+DateTime.Now.Minute
                +"�� "+DateTime.Now.Second+"��";
            this.Invalidate();//�̺�Ʈ�� �Ͼ�� �ڵ����� OnPaint
        }//
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.JungBo.Maths;
using System.Drawing.Drawing2D;
namespace Com.JungBo.Maths
{
    public partial class Form1 : Form
    {

        float originX;
        float originY;
        PointF[] hf = new PointF[4];
        PointF[] sf = new PointF[4];
        PointF[] mf = new PointF[4];

        Matrix matrix = new Matrix();
        Matrix rotateMatrix = new Matrix();
        int n = 3;
        double ra = 100.0;
        double k = 1;
        double real = 1;
        double imaz = Math.Sqrt(3);
        public Form1()
        {
            InitializeComponent();
            //-------------------
            Init();
        }

        private void Init()
        {
            this.originX = this.Width / 2.0f - 200f;
            this.originY = this.Height / 2.0f;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //상대원점  만들기
            g.TranslateTransform(originX, originY);

            Render(g);
            DrawCircle(g);
            DrawX(g);
            DrawY(g);
            //DrawZ(g);
            DrawZAlpha(g);
            //-----------------
            base.OnPaint(pe);
        }

        public void DrawX(Graphics g)
        {
            Pen xPen = new Pen(Color.Brown, 1);
            float stX = -150.0f;
            float stY = 0;
            float endX = 150.0f;
            float endY = 0;

            g.DrawLine(xPen, new PointF(stX, stY), new PointF(endX, endY));
            g.DrawLine(xPen, new PointF(endX - 10, endY - 5), new PointF(endX, endY)); //>
            g.DrawLine(xPen, new PointF(endX - 10, endY + 5), new PointF(endX, endY));//>
            Pen axisXPen = new Pen(Color.DarkSlateGray, 1);
            Font axisXFont = new Font("Arial", 15);
            SolidBrush axisXBrush = new SolidBrush(Color.SteelBlue);

            g.DrawString("X", axisXFont, axisXBrush, endX - 10, endY + 10);

            xPen.Dispose();
            axisXBrush.Dispose();
            axisXFont.Dispose();
            axisXPen.Dispose();

        }
        public void DrawY(Graphics g)
        {
            Pen xPen = new Pen(Color.Brown, 1);
            float stX = 0f;
            float stY = -150.0f;
            float endX = 0f;
            float endY = 150.0f;
            g.DrawLine(xPen, new PointF(stX, stY), new PointF(endX, endY));


            g.DrawLine(xPen, new PointF(endX - 5, stY + 10), new PointF(endX, stY)); //>
            g.DrawLine(xPen, new PointF(endX + 5, stY + 10), new PointF(endX, stY)); //>
            xPen.Dispose();
            //Pen axisXPen = new Pen(Color.DarkSlateGray, 1);
            Font axisXFont = new Font("Arial", 15);
            SolidBrush axisXBrush = new SolidBrush(Color.SteelBlue);

            g.DrawString("Y", axisXFont, axisXBrush, stX - 30, stY);

            axisXBrush.Dispose();
            axisXFont.Dispose();
            //axisXPen.Dispose();
        }
        private void DrawCircle(Graphics g)
        {
            //원 그리기)
            Pen xPen = new Pen(
                Color.Blue, 2);
            //FromRGB(r.Next(0, colors.GetLength(0))), 2);
            g.DrawArc(xPen,
               new RectangleF(-100, -100, 200, 200), 0.0f, 360.0f);
            xPen.Dispose();

        }
        //만능으로 바꿀 것.
        private void DrawZAlpha(Graphics g)
        {

            Z zval = k * new Z(real, imaz);

            double zabs = Z.ZAbs(zval);

            double rabs = Math.Pow(zabs, 1.0 / n);


            Z[] zz = DeMoivre.CompRoot(n, zval);

            for (int i = 0; i < zz.Length; i++)
            {
                Pen xPen = new Pen(
               Color.Blue, 2);
                //FromRGB(r.Next(0, colors.GetLength(0))), 2);
                SolidBrush axisXBrush = new SolidBrush(Color.Red);
                g.FillEllipse(axisXBrush,
                    (float)((zz[i].X * ra / rabs) - 5f),
                    (float)((-zz[i].Y * ra / rabs) - 5f), 10f, 10f);
                xPen.Dispose();

                Font zFont = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                SolidBrush zBrush = new SolidBrush(Color.Red);

                g.DrawString("Z" + i, zFont, zBrush, (float)((zz[i].X * ra / rabs) + 5f), (float)((-zz[i].Y * ra / rabs) - 5f));

                g.DrawString(("Z" + i + ": ") + (zz[i]).ToString(), zFont, zBrush, (float)(200.0f), (float)(-200.0f + 20.0f * i));

                zFont.Dispose();
                zBrush.Dispose();
            }
        }
        private void Render(Graphics g)
        {
            g.FillRectangle(
              new SolidBrush(Color.White),
             -200f, -200f, this.Width, this.Height);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.n = (int)this.numericUpDown1.Value;
            this.k = int.Parse(this.txtK.Text);
            if (this.radioButton1.Checked)
            {
                this.real = double.Parse(this.txtReal.Text);
            }
            else if (this.radioButton2.Checked)
            {
                this.real = Math.Sqrt(double.Parse(this.txtReal.Text));
            }


            if (this.radioButton3.Checked)
            {
                this.imaz = double.Parse(this.txtImaz.Text);
            }
            else if (this.radioButton4.Checked)
            {
                this.imaz = Math.Sqrt(double.Parse(this.txtImaz.Text));
            }
            if (this.cbOpp.SelectedIndex == 1)
            {
                this.imaz *= -1;
            }
            this.Invalidate();
        }
    }
}
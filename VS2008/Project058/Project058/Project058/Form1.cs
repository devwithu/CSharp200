using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Com.JungBo.Drawings;
namespace Project058
{
    public partial class Form1 : Form
    {
        CableCar car;
        public Form1()
        {
            InitializeComponent();
            //------------------아래에 소스놓을 것.
            car = new CableCar(30, this.Height / 2, Color.Black);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //상대원점  만들기
            g.TranslateTransform(0, 0);
            //-----------------
            Render(g);
            DrawShape(g);
            //-----------------
            base.OnPaint(pe);
        }
        public void DrawShape(Graphics g)
        {
            car.Draw(g);
            car.Go(10, 0);
        }
        private void Render(Graphics g)
        {

            g.FillRectangle(
              new SolidBrush(Color.Wheat),
             0, 0, this.Width, this.Height);
            Liner liner = new Liner(30, this.Height / 2 - 16,
              this.Width - 20, this.Height / 2 - 16, Color.Red);
            liner.Draw(g);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }
}
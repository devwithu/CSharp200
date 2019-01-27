using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Com.JungBo.Drawings;
namespace ClockWin {
    public partial class Form1 : Form {

        bool isNew = false;
        public Form1(){
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe){
            Graphics g = pe.Graphics;
            g.SmoothingMode =SmoothingMode.HighQuality;
            //������  �����
            g.TranslateTransform(0,0);
            //-----------------
            Render(g);
            DrawShape(g);
            //-----------------
            base.OnPaint(pe);
        }

        public void DrawShape(Graphics g){
            MakeShapes ms = new MakeShapes(this.Width, this.Height);
            ms.Make(isNew);
            ms.ShapeList.PrintShape(g);
        }
        private void Render(Graphics g) {
            
             g.FillRectangle(
               new SolidBrush(Color.White),
              //new SolidBrush(FromRGB(r.Next(0,colors.GetLength(0)))),
              0, 0, this.Width, this.Height);
        }

        private void btnReDraw_Click(object sender, EventArgs e){
            isNew = false;
            this.Invalidate();
        }

        private void btnDrawNew_Click(object sender, EventArgs e){
            isNew = true;
            this.Invalidate();
        }
       
    }
}
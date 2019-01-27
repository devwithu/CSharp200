using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D; //SmoothingMode
using Com.JungBo.Drawings;
namespace Progject055{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe){
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //상대원점  만들기
            g.TranslateTransform(0, 0);
            //------------여기서
            DrawShape(g);
            //------------여기만 건들 것.
            base.OnPaint(pe);
        }
        public void DrawShape(Graphics g) {
            Shape[] shs = new Shape[3];
            shs[0] = new Shape(10, 20, 30, 40, Color.Blue);
            shs[1] = new Circle(30, 80, 60, 30, Color.Black);
            shs[2] = new Rectangler(20, 80, 50, 50, Color.Brown);
            foreach (Shape var in shs){
               var.Draw(g);
            }
            foreach (Shape var in shs){
                var.Move(50, 50);
            }
            foreach (Shape var in shs){
                var.Draw(g);
            }
        }
    }
}
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
            Shape sh1 = new Shape(100, 200, 30,40, Color.Blue);
            Circle cir1 = new Circle(30, 80, 60, 30, Color.Black);
            Rectangler rec1 = new Rectangler(20, 80, 50, 50, Color.Brown);
            sh1.DrawShape(g);
            cir1.DrawCircle(g);
            rec1.DrawRectangler(g);
            rec1.Move(50, 50);  //사작형(50,50) 이동
            rec1.DrawRectangler(g);
            rec1.Move(50, 50);  //사작형(50,50) 이동
            rec1.DrawRectangler(g);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinGodori
{
    public partial class notifyform : Form
    {
        private Image img1;
        private Image img2;

        public notifyform()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

           // g.DrawImage(img1, new Rectangle(10,10,32,50));
          //  g.DrawImage(img2, new Rectangle(10, 10, 32, 50));
        }

        public Image SetImage1
        {
            set { img1 = value; }
        }

        public Image SetImage2
        {
            set { img2 = value; }
        }

    }
}
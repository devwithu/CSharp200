using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SixTeenWindows
{
    /// <summary>
    /// SButton�� ���� ��� �����Դϴ�.
    /// </summary>
    public class SButton : System.Windows.Forms.Button, ICloneable
    {
        /// <summary>
        /// �ʼ� �����̳� �����Դϴ�.
        /// </summary>
        private System.ComponentModel.Container components = null;
        //---------------------------------------------------
        int x = 0;				//x��ǥ
        int y = 0;				//y��ǥ
        int xcenter = 0;	//�߾�
        int ycenter = 0;	//�߾�
        bool amIBack = false;		//
        int myNum;              //

        public SButton(int x, int y, int z)
        {
            //
            // Windows Form �����̳� ������ �ʿ��մϴ�.
            //
            InitializeComponent();
            //-----------------------------------------------
            this.x = x;
            this.y = y;
            this.myNum = z;
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(50, 50);
            this.Font = new System.Drawing.Font("����", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
            this.Text = (myNum == 0 ? "" : this.myNum.ToString());//���׿�����
            xcenter = (50 / 2 + x);
            ycenter = (50 / 2 + y);
            if (myNum == 0)
            {//
                amIBack = true;
            }
        }

        /// <summary>
        /// ��� ���� ��� ���ҽ��� �����մϴ�.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form �����̳ʿ��� ������ �ڵ�
        /// <summary>
        /// �����̳� ������ �ʿ��� �޼����Դϴ�.
        /// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "SButton";
        }
        #endregion

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public int MyNum
        {
            get { return this.myNum; }
            set { this.myNum = value; }
        }
        public int XCenter
        {
            get { return this.xcenter; }
            //set{this.x=value;}
        }
        public int YCenter
        {
            get { return this.ycenter; }
            //set{this.x=value;}
        }
        public int Length(SButton sb)
        {
            int ax = (sb.XCenter - this.XCenter);
            int ay = (sb.YCenter - this.YCenter);

            int min = (int)Math.Sqrt(ax * ax + ay * ay);
            return min;
        }
        public bool AmIBack
        {
            get { return this.amIBack; }
            set { this.amIBack = value; }
        }
        public void Flips()
        {

            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(50, 50);
            this.Font = new System.Drawing.Font("����", 
                15F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));

            this.Text = (myNum == 0 ? "" : this.myNum.ToString());//���׿�����
            xcenter = (50 / 2 + x);
            ycenter = (50 / 2 + y);
            if (myNum == 0)
            {
                amIBack = true;
            }
            else
            {
                amIBack = false;
            }
        }//
        public object Clone()
        {

            try
            {
                return new SButton(x, y, this.myNum);
            }
            catch 
            {
                return this;
            }
        }

    }
}

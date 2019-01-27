using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SixTeenWindows
{
    /// <summary>
    /// SButton에 대한 요약 설명입니다.
    /// </summary>
    public class SButton : System.Windows.Forms.Button, ICloneable
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        //---------------------------------------------------
        int x = 0;				//x좌표
        int y = 0;				//y좌표
        int xcenter = 0;	//중앙
        int ycenter = 0;	//중앙
        bool amIBack = false;		//
        int myNum;              //

        public SButton(int x, int y, int z)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();
            //-----------------------------------------------
            this.x = x;
            this.y = y;
            this.myNum = z;
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(50, 50);
            this.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
            this.Text = (myNum == 0 ? "" : this.myNum.ToString());//삼항연산자
            xcenter = (50 / 2 + x);
            ycenter = (50 / 2 + y);
            if (myNum == 0)
            {//
                amIBack = true;
            }
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
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

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
            this.Font = new System.Drawing.Font("굴림", 
                15F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));

            this.Text = (myNum == 0 ? "" : this.myNum.ToString());//삼항연산자
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

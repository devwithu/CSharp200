namespace Poker
{
    partial class frmDesk
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesk));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnectServer = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCard1 = new System.Windows.Forms.PictureBox();
            this.mCard2 = new System.Windows.Forms.PictureBox();
            this.mCard3 = new System.Windows.Forms.PictureBox();
            this.mCard4 = new System.Windows.Forms.PictureBox();
            this.mCard5 = new System.Windows.Forms.PictureBox();
            this.mCard6 = new System.Windows.Forms.PictureBox();
            this.mCard7 = new System.Windows.Forms.PictureBox();
            this.uCard7 = new System.Windows.Forms.PictureBox();
            this.uCard6 = new System.Windows.Forms.PictureBox();
            this.uCard5 = new System.Windows.Forms.PictureBox();
            this.uCard4 = new System.Windows.Forms.PictureBox();
            this.uCard3 = new System.Windows.Forms.PictureBox();
            this.uCard2 = new System.Windows.Forms.PictureBox();
            this.uCard1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDie = new System.Windows.Forms.Button();
            this.btnFull = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnHalf = new System.Windows.Forms.Button();
            this.btnBBing = new System.Windows.Forms.Button();
            this.btnQuarter = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnDouble = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblCall = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblMyMoney = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblYourMoney = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartServer,
            this.mnuConnectServer,
            this.mnuExit});
            this.gameToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // mnuStartServer
            // 
            this.mnuStartServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuStartServer.Name = "mnuStartServer";
            this.mnuStartServer.Size = new System.Drawing.Size(163, 22);
            this.mnuStartServer.Text = "Start Server";
            this.mnuStartServer.Click += new System.EventHandler(this.mnuStartServer_Click);
            // 
            // mnuConnectServer
            // 
            this.mnuConnectServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuConnectServer.Name = "mnuConnectServer";
            this.mnuConnectServer.Size = new System.Drawing.Size(163, 22);
            this.mnuConnectServer.Text = "Connect Server";
            this.mnuConnectServer.Click += new System.EventHandler(this.mnuConnectServer_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // mCard1
            // 
            this.mCard1.BackColor = System.Drawing.Color.Transparent;
            this.mCard1.Location = new System.Drawing.Point(29, 304);
            this.mCard1.Name = "mCard1";
            this.mCard1.Size = new System.Drawing.Size(72, 96);
            this.mCard1.TabIndex = 1;
            this.mCard1.TabStop = false;
            this.mCard1.Click += new System.EventHandler(this.mCard1_Click);
            // 
            // mCard2
            // 
            this.mCard2.BackColor = System.Drawing.Color.Transparent;
            this.mCard2.Location = new System.Drawing.Point(107, 304);
            this.mCard2.Name = "mCard2";
            this.mCard2.Size = new System.Drawing.Size(72, 96);
            this.mCard2.TabIndex = 15;
            this.mCard2.TabStop = false;
            this.mCard2.Click += new System.EventHandler(this.mCard2_Click);
            // 
            // mCard3
            // 
            this.mCard3.BackColor = System.Drawing.Color.Transparent;
            this.mCard3.Location = new System.Drawing.Point(185, 304);
            this.mCard3.Name = "mCard3";
            this.mCard3.Size = new System.Drawing.Size(72, 96);
            this.mCard3.TabIndex = 16;
            this.mCard3.TabStop = false;
            this.mCard3.Click += new System.EventHandler(this.mCard3_Click);
            // 
            // mCard4
            // 
            this.mCard4.BackColor = System.Drawing.Color.Transparent;
            this.mCard4.Location = new System.Drawing.Point(263, 304);
            this.mCard4.Name = "mCard4";
            this.mCard4.Size = new System.Drawing.Size(72, 96);
            this.mCard4.TabIndex = 17;
            this.mCard4.TabStop = false;
            // 
            // mCard5
            // 
            this.mCard5.BackColor = System.Drawing.Color.Transparent;
            this.mCard5.Location = new System.Drawing.Point(341, 304);
            this.mCard5.Name = "mCard5";
            this.mCard5.Size = new System.Drawing.Size(72, 96);
            this.mCard5.TabIndex = 18;
            this.mCard5.TabStop = false;
            // 
            // mCard6
            // 
            this.mCard6.BackColor = System.Drawing.Color.Transparent;
            this.mCard6.Location = new System.Drawing.Point(419, 304);
            this.mCard6.Name = "mCard6";
            this.mCard6.Size = new System.Drawing.Size(72, 96);
            this.mCard6.TabIndex = 19;
            this.mCard6.TabStop = false;
            // 
            // mCard7
            // 
            this.mCard7.BackColor = System.Drawing.Color.Transparent;
            this.mCard7.Location = new System.Drawing.Point(497, 304);
            this.mCard7.Name = "mCard7";
            this.mCard7.Size = new System.Drawing.Size(72, 96);
            this.mCard7.TabIndex = 20;
            this.mCard7.TabStop = false;
            // 
            // uCard7
            // 
            this.uCard7.BackColor = System.Drawing.Color.Transparent;
            this.uCard7.Location = new System.Drawing.Point(497, 76);
            this.uCard7.Name = "uCard7";
            this.uCard7.Size = new System.Drawing.Size(72, 96);
            this.uCard7.TabIndex = 27;
            this.uCard7.TabStop = false;
            // 
            // uCard6
            // 
            this.uCard6.BackColor = System.Drawing.Color.Transparent;
            this.uCard6.Location = new System.Drawing.Point(419, 76);
            this.uCard6.Name = "uCard6";
            this.uCard6.Size = new System.Drawing.Size(72, 96);
            this.uCard6.TabIndex = 26;
            this.uCard6.TabStop = false;
            // 
            // uCard5
            // 
            this.uCard5.BackColor = System.Drawing.Color.Transparent;
            this.uCard5.Location = new System.Drawing.Point(341, 76);
            this.uCard5.Name = "uCard5";
            this.uCard5.Size = new System.Drawing.Size(72, 96);
            this.uCard5.TabIndex = 25;
            this.uCard5.TabStop = false;
            // 
            // uCard4
            // 
            this.uCard4.BackColor = System.Drawing.Color.Transparent;
            this.uCard4.Location = new System.Drawing.Point(263, 76);
            this.uCard4.Name = "uCard4";
            this.uCard4.Size = new System.Drawing.Size(72, 96);
            this.uCard4.TabIndex = 24;
            this.uCard4.TabStop = false;
            // 
            // uCard3
            // 
            this.uCard3.BackColor = System.Drawing.Color.Transparent;
            this.uCard3.Location = new System.Drawing.Point(185, 76);
            this.uCard3.Name = "uCard3";
            this.uCard3.Size = new System.Drawing.Size(72, 96);
            this.uCard3.TabIndex = 23;
            this.uCard3.TabStop = false;
            // 
            // uCard2
            // 
            this.uCard2.BackColor = System.Drawing.Color.Transparent;
            this.uCard2.Location = new System.Drawing.Point(107, 76);
            this.uCard2.Name = "uCard2";
            this.uCard2.Size = new System.Drawing.Size(72, 96);
            this.uCard2.TabIndex = 22;
            this.uCard2.TabStop = false;
            // 
            // uCard1
            // 
            this.uCard1.BackColor = System.Drawing.Color.Transparent;
            this.uCard1.Location = new System.Drawing.Point(29, 76);
            this.uCard1.Name = "uCard1";
            this.uCard1.Size = new System.Drawing.Size(72, 96);
            this.uCard1.TabIndex = 21;
            this.uCard1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnDie);
            this.groupBox2.Controls.Add(this.btnFull);
            this.groupBox2.Controls.Add(this.btnCall);
            this.groupBox2.Controls.Add(this.btnHalf);
            this.groupBox2.Controls.Add(this.btnBBing);
            this.groupBox2.Controls.Add(this.btnQuarter);
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Controls.Add(this.btnDouble);
            this.groupBox2.Location = new System.Drawing.Point(590, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 143);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // btnDie
            // 
            this.btnDie.BackColor = System.Drawing.Color.White;
            this.btnDie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDie.Location = new System.Drawing.Point(67, 106);
            this.btnDie.Name = "btnDie";
            this.btnDie.Size = new System.Drawing.Size(46, 23);
            this.btnDie.TabIndex = 7;
            this.btnDie.Text = "다이";
            this.btnDie.UseVisualStyleBackColor = false;
            this.btnDie.Click += new System.EventHandler(this.btnDie_Click);
            // 
            // btnFull
            // 
            this.btnFull.BackColor = System.Drawing.Color.White;
            this.btnFull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFull.Location = new System.Drawing.Point(15, 107);
            this.btnFull.Name = "btnFull";
            this.btnFull.Size = new System.Drawing.Size(46, 23);
            this.btnFull.TabIndex = 6;
            this.btnFull.Text = "풀";
            this.btnFull.UseVisualStyleBackColor = false;
            this.btnFull.Click += new System.EventHandler(this.btnFull_Click);
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.White;
            this.btnCall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCall.Location = new System.Drawing.Point(67, 78);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(46, 23);
            this.btnCall.TabIndex = 5;
            this.btnCall.Text = "콜";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnHalf
            // 
            this.btnHalf.BackColor = System.Drawing.Color.White;
            this.btnHalf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHalf.Location = new System.Drawing.Point(15, 78);
            this.btnHalf.Name = "btnHalf";
            this.btnHalf.Size = new System.Drawing.Size(46, 23);
            this.btnHalf.TabIndex = 4;
            this.btnHalf.Text = "하프";
            this.btnHalf.UseVisualStyleBackColor = false;
            this.btnHalf.Click += new System.EventHandler(this.btnHalf_Click);
            // 
            // btnBBing
            // 
            this.btnBBing.BackColor = System.Drawing.Color.White;
            this.btnBBing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBBing.Location = new System.Drawing.Point(67, 48);
            this.btnBBing.Name = "btnBBing";
            this.btnBBing.Size = new System.Drawing.Size(46, 23);
            this.btnBBing.TabIndex = 3;
            this.btnBBing.Text = "삥";
            this.btnBBing.UseVisualStyleBackColor = false;
            this.btnBBing.Click += new System.EventHandler(this.btnBBing_Click);
            // 
            // btnQuarter
            // 
            this.btnQuarter.BackColor = System.Drawing.Color.White;
            this.btnQuarter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuarter.Location = new System.Drawing.Point(15, 49);
            this.btnQuarter.Name = "btnQuarter";
            this.btnQuarter.Size = new System.Drawing.Size(46, 23);
            this.btnQuarter.TabIndex = 2;
            this.btnQuarter.Text = "쿼터";
            this.btnQuarter.UseVisualStyleBackColor = false;
            this.btnQuarter.Click += new System.EventHandler(this.btnQuarter_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheck.Location = new System.Drawing.Point(67, 19);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(46, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "체크";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnDouble
            // 
            this.btnDouble.BackColor = System.Drawing.Color.White;
            this.btnDouble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDouble.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDouble.Location = new System.Drawing.Point(15, 20);
            this.btnDouble.Name = "btnDouble";
            this.btnDouble.Size = new System.Drawing.Size(46, 23);
            this.btnDouble.TabIndex = 0;
            this.btnDouble.Text = "따당";
            this.btnDouble.UseVisualStyleBackColor = false;
            this.btnDouble.Click += new System.EventHandler(this.btnDouble_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(628, 94);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(44, 59);
            this.btnStart.TabIndex = 30;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalMoney.Font = new System.Drawing.Font("Old English Text MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoney.ForeColor = System.Drawing.Color.White;
            this.lblTotalMoney.Location = new System.Drawing.Point(185, 205);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalMoney.Size = new System.Drawing.Size(228, 30);
            this.lblTotalMoney.TabIndex = 31;
            this.lblTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCall
            // 
            this.lblCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblCall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCall.Font = new System.Drawing.Font("Old English Text MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCall.ForeColor = System.Drawing.Color.White;
            this.lblCall.Location = new System.Drawing.Point(185, 244);
            this.lblCall.Name = "lblCall";
            this.lblCall.Size = new System.Drawing.Size(228, 30);
            this.lblCall.TabIndex = 2;
            this.lblCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(185, 205);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(62, 30);
            this.lbl1.TabIndex = 32;
            this.lbl1.Text = "판돈";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(185, 244);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(62, 30);
            this.lbl2.TabIndex = 33;
            this.lbl2.Text = "콜";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMyMoney
            // 
            this.lblMyMoney.BackColor = System.Drawing.Color.White;
            this.lblMyMoney.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMyMoney.Location = new System.Drawing.Point(419, 403);
            this.lblMyMoney.Name = "lblMyMoney";
            this.lblMyMoney.Size = new System.Drawing.Size(150, 20);
            this.lblMyMoney.TabIndex = 34;
            this.lblMyMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbl4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl4.Location = new System.Drawing.Point(419, 403);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(58, 20);
            this.lbl4.TabIndex = 35;
            this.lbl4.Text = "내 머니";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbl3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Location = new System.Drawing.Point(29, 53);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(58, 20);
            this.lbl3.TabIndex = 37;
            this.lbl3.Text = "니 머니";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYourMoney
            // 
            this.lblYourMoney.BackColor = System.Drawing.Color.White;
            this.lblYourMoney.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblYourMoney.Location = new System.Drawing.Point(29, 53);
            this.lblYourMoney.Name = "lblYourMoney";
            this.lblYourMoney.Size = new System.Drawing.Size(150, 20);
            this.lblYourMoney.TabIndex = 36;
            this.lblYourMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblMsg.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblMsg.Location = new System.Drawing.Point(590, 217);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(131, 37);
            this.lblMsg.TabIndex = 39;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(163, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(738, 432);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lblYourMoney);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lblMyMoney);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblCall);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.uCard7);
            this.Controls.Add(this.uCard6);
            this.Controls.Add(this.uCard5);
            this.Controls.Add(this.uCard4);
            this.Controls.Add(this.uCard3);
            this.Controls.Add(this.uCard2);
            this.Controls.Add(this.uCard1);
            this.Controls.Add(this.mCard7);
            this.Controls.Add(this.mCard6);
            this.Controls.Add(this.mCard5);
            this.Controls.Add(this.mCard4);
            this.Controls.Add(this.mCard3);
            this.Controls.Add(this.mCard2);
            this.Controls.Add(this.mCard1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDesk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poker";
            this.Load += new System.EventHandler(this.frmDesk_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCard7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCard1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStartServer;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectServer;
        private System.Windows.Forms.PictureBox mCard1;
        private System.Windows.Forms.PictureBox mCard2;
        private System.Windows.Forms.PictureBox mCard3;
        private System.Windows.Forms.PictureBox mCard4;
        private System.Windows.Forms.PictureBox mCard5;
        private System.Windows.Forms.PictureBox mCard6;
        private System.Windows.Forms.PictureBox mCard7;
        private System.Windows.Forms.PictureBox uCard7;
        private System.Windows.Forms.PictureBox uCard6;
        private System.Windows.Forms.PictureBox uCard5;
        private System.Windows.Forms.PictureBox uCard4;
        private System.Windows.Forms.PictureBox uCard3;
        private System.Windows.Forms.PictureBox uCard2;
        private System.Windows.Forms.PictureBox uCard1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnDouble;
        private System.Windows.Forms.Button btnDie;
        private System.Windows.Forms.Button btnFull;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnHalf;
        private System.Windows.Forms.Button btnBBing;
        private System.Windows.Forms.Button btnQuarter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblCall;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblMyMoney;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblYourMoney;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}


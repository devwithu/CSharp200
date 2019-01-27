namespace WinBlackJack
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새게임ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDealerScore = new System.Windows.Forms.TextBox();
            this.txtPlayerScore = new System.Windows.Forms.TextBox();
            this.buttonHit = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonDouble = new System.Windows.Forms.Button();
            this.txtBetting = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDeal = new System.Windows.Forms.Panel();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.buttonBetting = new System.Windows.Forms.Button();
            this.labelLose = new System.Windows.Forms.Label();
            this.labelWin = new System.Windows.Forms.Label();
            this.labelPush = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblinit = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1066, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새게임ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.시작ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 새게임ToolStripMenuItem
            // 
            this.새게임ToolStripMenuItem.Name = "새게임ToolStripMenuItem";
            this.새게임ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.새게임ToolStripMenuItem.Text = "새게임";
            this.새게임ToolStripMenuItem.Click += new System.EventHandler(this.새게임ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // 시작ToolStripMenuItem
            // 
            this.시작ToolStripMenuItem.Name = "시작ToolStripMenuItem";
            this.시작ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.시작ToolStripMenuItem.Text = "시작";
            this.시작ToolStripMenuItem.Click += new System.EventHandler(this.시작ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("HY헤드라인M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "딜러점수";
            // 
            // txtDealerScore
            // 
            this.txtDealerScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDealerScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDealerScore.Cursor = System.Windows.Forms.Cursors.No;
            this.txtDealerScore.Font = new System.Drawing.Font("HY헤드라인M", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDealerScore.Location = new System.Drawing.Point(91, 39);
            this.txtDealerScore.Name = "txtDealerScore";
            this.txtDealerScore.ReadOnly = true;
            this.txtDealerScore.Size = new System.Drawing.Size(55, 32);
            this.txtDealerScore.TabIndex = 100;
            // 
            // txtPlayerScore
            // 
            this.txtPlayerScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPlayerScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlayerScore.Cursor = System.Windows.Forms.Cursors.No;
            this.txtPlayerScore.Font = new System.Drawing.Font("HY헤드라인M", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPlayerScore.Location = new System.Drawing.Point(87, 42);
            this.txtPlayerScore.Name = "txtPlayerScore";
            this.txtPlayerScore.ReadOnly = true;
            this.txtPlayerScore.Size = new System.Drawing.Size(53, 32);
            this.txtPlayerScore.TabIndex = 101;
            // 
            // buttonHit
            // 
            this.buttonHit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonHit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHit.Font = new System.Drawing.Font("HY중고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonHit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonHit.Location = new System.Drawing.Point(564, 706);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(97, 60);
            this.buttonHit.TabIndex = 30;
            this.buttonHit.Text = "한장더";
            this.buttonHit.UseVisualStyleBackColor = false;
            this.buttonHit.Click += new System.EventHandler(this.buttonHit_Click);
            // 
            // buttonStand
            // 
            this.buttonStand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonStand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStand.Font = new System.Drawing.Font("HY중고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonStand.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonStand.Location = new System.Drawing.Point(675, 706);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(97, 60);
            this.buttonStand.TabIndex = 6;
            this.buttonStand.Text = "그만";
            this.buttonStand.UseVisualStyleBackColor = false;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click);
            // 
            // buttonDouble
            // 
            this.buttonDouble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonDouble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDouble.Font = new System.Drawing.Font("HY중고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDouble.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonDouble.Location = new System.Drawing.Point(785, 706);
            this.buttonDouble.Name = "buttonDouble";
            this.buttonDouble.Size = new System.Drawing.Size(97, 60);
            this.buttonDouble.TabIndex = 8;
            this.buttonDouble.Text = "두배로배팅";
            this.buttonDouble.UseVisualStyleBackColor = false;
            this.buttonDouble.Click += new System.EventHandler(this.buttonDouble_Click);
            // 
            // txtBetting
            // 
            this.txtBetting.BackColor = System.Drawing.Color.LightBlue;
            this.txtBetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBetting.Font = new System.Drawing.Font("굴림", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBetting.Location = new System.Drawing.Point(102, 11);
            this.txtBetting.Name = "txtBetting";
            this.txtBetting.Size = new System.Drawing.Size(131, 20);
            this.txtBetting.TabIndex = 7;
            this.txtBetting.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Orchid;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(26, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "         ";
            // 
            // panelDeal
            // 
            this.panelDeal.BackColor = System.Drawing.Color.Transparent;
            this.panelDeal.Location = new System.Drawing.Point(335, 55);
            this.panelDeal.Name = "panelDeal";
            this.panelDeal.Size = new System.Drawing.Size(677, 186);
            this.panelDeal.TabIndex = 11;
            this.panelDeal.Tag = "";
            // 
            // panelPlay
            // 
            this.panelPlay.BackColor = System.Drawing.Color.Transparent;
            this.panelPlay.Location = new System.Drawing.Point(40, 451);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(758, 173);
            this.panelPlay.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Orchid;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(25, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "         ";
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.Color.LightBlue;
            this.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCash.Cursor = System.Windows.Forms.Cursors.No;
            this.txtCash.Font = new System.Drawing.Font("굴림", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCash.Location = new System.Drawing.Point(102, 40);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(131, 20);
            this.txtCash.TabIndex = 14;
            // 
            // buttonBetting
            // 
            this.buttonBetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonBetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBetting.Font = new System.Drawing.Font("HY헤드라인M", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonBetting.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBetting.Location = new System.Drawing.Point(418, 666);
            this.buttonBetting.Name = "buttonBetting";
            this.buttonBetting.Size = new System.Drawing.Size(115, 99);
            this.buttonBetting.TabIndex = 15;
            this.buttonBetting.Text = "배팅";
            this.buttonBetting.UseVisualStyleBackColor = false;
            this.buttonBetting.Click += new System.EventHandler(this.buttonBetting_Click);
            // 
            // labelLose
            // 
            this.labelLose.AutoSize = true;
            this.labelLose.BackColor = System.Drawing.Color.Transparent;
            this.labelLose.Font = new System.Drawing.Font("휴먼편지체", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelLose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelLose.Location = new System.Drawing.Point(12, 262);
            this.labelLose.Name = "labelLose";
            this.labelLose.Size = new System.Drawing.Size(371, 155);
            this.labelLose.TabIndex = 16;
            this.labelLose.Text = "LOSE!";
            this.labelLose.Visible = false;
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.BackColor = System.Drawing.Color.Transparent;
            this.labelWin.Font = new System.Drawing.Font("휴먼편지체", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelWin.Location = new System.Drawing.Point(335, 262);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(362, 155);
            this.labelWin.TabIndex = 17;
            this.labelWin.Text = "WIN!!";
            this.labelWin.Visible = false;
            // 
            // labelPush
            // 
            this.labelPush.AutoSize = true;
            this.labelPush.BackColor = System.Drawing.Color.Transparent;
            this.labelPush.Font = new System.Drawing.Font("휴먼편지체", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPush.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelPush.Location = new System.Drawing.Point(155, 262);
            this.labelPush.Name = "labelPush";
            this.labelPush.Size = new System.Drawing.Size(438, 155);
            this.labelPush.TabIndex = 18;
            this.labelPush.Text = "PUSH!!";
            this.labelPush.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDealerScore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(56, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 89);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(182)))), ((int)(((byte)(251)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtCash);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBetting);
            this.panel2.Location = new System.Drawing.Point(564, 630);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 70);
            this.panel2.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WinBlackJack.Properties.Resources.back;
            this.pictureBox1.Location = new System.Drawing.Point(840, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 168);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WinBlackJack.Properties.Resources.back;
            this.pictureBox2.Location = new System.Drawing.Point(863, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 168);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::WinBlackJack.Properties.Resources.back;
            this.pictureBox3.Location = new System.Drawing.Point(886, 262);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(112, 168);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtPlayerScore);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(813, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 89);
            this.panel3.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("HY헤드라인M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(22, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "내 점수";
            // 
            // lblinit
            // 
            this.lblinit.AutoSize = true;
            this.lblinit.BackColor = System.Drawing.Color.Transparent;
            this.lblinit.Font = new System.Drawing.Font("휴먼편지체", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblinit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblinit.Location = new System.Drawing.Point(79, 244);
            this.lblinit.Name = "lblinit";
            this.lblinit.Size = new System.Drawing.Size(680, 310);
            this.lblinit.TabIndex = 31;
            this.lblinit.Text = "한경 블랙잭\r\n 인생한방!!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinBlackJack.Properties.Resources.연금술사2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1066, 814);
            this.Controls.Add(this.lblinit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelWin);
            this.Controls.Add(this.labelPush);
            this.Controls.Add(this.labelLose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonBetting);
            this.Controls.Add(this.panelPlay);
            this.Controls.Add(this.panelDeal);
            this.Controls.Add(this.buttonDouble);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.buttonHit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "한경 블랙잭";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDealerScore;
        private System.Windows.Forms.TextBox txtPlayerScore;
        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonDouble;
        private System.Windows.Forms.TextBox txtBetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelDeal;
        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Button buttonBetting;
        private System.Windows.Forms.ToolStripMenuItem 새게임ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label labelLose;
        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.Label labelPush;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblinit;
    }
}


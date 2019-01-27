namespace WinBomb
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.게임GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새게임NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초급BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.중급IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.고급EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.소리SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.끝내기XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.게임GToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 227);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 게임GToolStripMenuItem
            // 
            this.게임GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새게임NToolStripMenuItem,
            this.초급BToolStripMenuItem,
            this.중급IToolStripMenuItem,
            this.고급EToolStripMenuItem,
            this.소리SToolStripMenuItem,
            this.끝내기XToolStripMenuItem});
            this.게임GToolStripMenuItem.Name = "게임GToolStripMenuItem";
            this.게임GToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.게임GToolStripMenuItem.Text = "게임(&G)";
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            this.도움말HToolStripMenuItem.Click += new System.EventHandler(this.Mineinfo_Clicked);
            // 
            // 새게임NToolStripMenuItem
            // 
            this.새게임NToolStripMenuItem.Name = "새게임NToolStripMenuItem";
            this.새게임NToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.새게임NToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.새게임NToolStripMenuItem.Text = "새게임(&N)";
            this.새게임NToolStripMenuItem.Click += new System.EventHandler(this.NewGame_Clicked);
            // 
            // 초급BToolStripMenuItem
            // 
            this.초급BToolStripMenuItem.Name = "초급BToolStripMenuItem";
            this.초급BToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.초급BToolStripMenuItem.Text = "초급(&B)";
            this.초급BToolStripMenuItem.Click += new System.EventHandler(this.Grade1_Clicked);
            // 
            // 중급IToolStripMenuItem
            // 
            this.중급IToolStripMenuItem.Checked = true;
            this.중급IToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.중급IToolStripMenuItem.Name = "중급IToolStripMenuItem";
            this.중급IToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.중급IToolStripMenuItem.Text = "중급(&I)";
            this.중급IToolStripMenuItem.Click += new System.EventHandler(this.Grade2_Clicked);
            // 
            // 고급EToolStripMenuItem
            // 
            this.고급EToolStripMenuItem.Name = "고급EToolStripMenuItem";
            this.고급EToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.고급EToolStripMenuItem.Text = "고급(&E)";
            this.고급EToolStripMenuItem.Click += new System.EventHandler(this.Grade3_Clicked);
            // 
            // 소리SToolStripMenuItem
            // 
            this.소리SToolStripMenuItem.Checked = true;
            this.소리SToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.소리SToolStripMenuItem.Name = "소리SToolStripMenuItem";
            this.소리SToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.소리SToolStripMenuItem.Text = "소리(&S)";
            this.소리SToolStripMenuItem.Click += new System.EventHandler(this.Sound_Clicked);
            // 
            // 끝내기XToolStripMenuItem
            // 
            this.끝내기XToolStripMenuItem.Name = "끝내기XToolStripMenuItem";
            this.끝내기XToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.끝내기XToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.끝내기XToolStripMenuItem.Text = "끝내기(&X)";
            this.끝내기XToolStripMenuItem.Click += new System.EventHandler(this.EndGame_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 251);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "JungBo Bomb ver0.9";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 게임GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새게임NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초급BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 중급IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 고급EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 소리SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 끝내기XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
    }
}


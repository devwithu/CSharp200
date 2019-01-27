namespace SixTeenWindows
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSeconds = new System.Windows.Forms.Label();
            this.lbTimes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbInvert = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(50, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 304);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.stBtn);
            this.panel2.Location = new System.Drawing.Point(458, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 304);
            this.panel2.TabIndex = 1;
            // 
            // stBtn
            // 
            this.stBtn.Location = new System.Drawing.Point(14, 34);
            this.stBtn.Name = "stBtn";
            this.stBtn.Size = new System.Drawing.Size(115, 61);
            this.stBtn.TabIndex = 0;
            this.stBtn.Text = "Start";
            this.stBtn.UseVisualStyleBackColor = true;
            this.stBtn.Click += new System.EventHandler(this.stBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(48, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "                                                            ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(106, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seconds";
            // 
            // lbSeconds
            // 
            this.lbSeconds.AutoSize = true;
            this.lbSeconds.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbSeconds.Location = new System.Drawing.Point(49, 9);
            this.lbSeconds.Name = "lbSeconds";
            this.lbSeconds.Size = new System.Drawing.Size(28, 27);
            this.lbSeconds.TabIndex = 4;
            this.lbSeconds.Text = "0";
            // 
            // lbTimes
            // 
            this.lbTimes.AutoSize = true;
            this.lbTimes.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTimes.Location = new System.Drawing.Point(303, 9);
            this.lbTimes.Name = "lbTimes";
            this.lbTimes.Size = new System.Drawing.Size(28, 27);
            this.lbTimes.TabIndex = 6;
            this.lbTimes.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(406, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 27);
            this.label5.TabIndex = 5;
            this.label5.Text = "Times";
            // 
            // lbInvert
            // 
            this.lbInvert.AutoSize = true;
            this.lbInvert.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbInvert.Location = new System.Drawing.Point(49, 446);
            this.lbInvert.Name = "lbInvert";
            this.lbInvert.Size = new System.Drawing.Size(0, 27);
            this.lbInvert.TabIndex = 7;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(14, 122);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(115, 61);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New Start";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 550);
            this.Controls.Add(this.lbInvert);
            this.Controls.Add(this.lbTimes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbSeconds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "15 Puzzle Ver 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button stBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSeconds;
        private System.Windows.Forms.Label lbTimes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbInvert;
        private System.Windows.Forms.Button btnNew;
    }
}


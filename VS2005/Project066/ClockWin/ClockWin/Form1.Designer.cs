namespace ClockWin {
    partial class Form1 {
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
            this.btnReDraw = new System.Windows.Forms.Button();
            this.btnDrawNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReDraw
            // 
            this.btnReDraw.Location = new System.Drawing.Point(656, 338);
            this.btnReDraw.Name = "btnReDraw";
            this.btnReDraw.Size = new System.Drawing.Size(132, 23);
            this.btnReDraw.TabIndex = 0;
            this.btnReDraw.Text = "ReDraw Override";
            this.btnReDraw.UseVisualStyleBackColor = true;
            this.btnReDraw.Click += new System.EventHandler(this.btnReDraw_Click);
            // 
            // btnDrawNew
            // 
            this.btnDrawNew.Location = new System.Drawing.Point(504, 338);
            this.btnDrawNew.Name = "btnDrawNew";
            this.btnDrawNew.Size = new System.Drawing.Size(132, 23);
            this.btnDrawNew.TabIndex = 1;
            this.btnDrawNew.Text = "ReDraw New";
            this.btnDrawNew.UseVisualStyleBackColor = true;
            this.btnDrawNew.Click += new System.EventHandler(this.btnDrawNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 373);
            this.Controls.Add(this.btnDrawNew);
            this.Controls.Add(this.btnReDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw ver0.3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReDraw;
        private System.Windows.Forms.Button btnDrawNew;

    }
}


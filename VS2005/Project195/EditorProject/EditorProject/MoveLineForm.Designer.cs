﻿namespace EditorProject {
    partial class MoveLineForm {
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
            this.btnWantLine = new System.Windows.Forms.Button();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWantLine
            // 
            this.btnWantLine.Location = new System.Drawing.Point(269, 26);
            this.btnWantLine.Name = "btnWantLine";
            this.btnWantLine.Size = new System.Drawing.Size(182, 23);
            this.btnWantLine.TabIndex = 0;
            this.btnWantLine.Text = "원하는 줄번호로 가기";
            this.btnWantLine.UseVisualStyleBackColor = true;
            this.btnWantLine.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(23, 28);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(223, 21);
            this.txtLine.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MoveLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 102);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.btnWantLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoveLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "찾기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWantLine;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Button button2;
    }
}
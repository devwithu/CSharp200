namespace VidioShop2007
{
    partial class PassChangeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNowPass = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtChangePass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReCheckPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "현재 비밀번호";
            // 
            // txtNowPass
            // 
            this.txtNowPass.Font = new System.Drawing.Font("굴림", 10F);
            this.txtNowPass.Location = new System.Drawing.Point(143, 20);
            this.txtNowPass.Name = "txtNowPass";
            this.txtNowPass.PasswordChar = '*';
            this.txtNowPass.Size = new System.Drawing.Size(128, 23);
            this.txtNowPass.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(114, 141);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "확  인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtChangePass
            // 
            this.txtChangePass.Font = new System.Drawing.Font("굴림", 10F);
            this.txtChangePass.Location = new System.Drawing.Point(143, 53);
            this.txtChangePass.Name = "txtChangePass";
            this.txtChangePass.PasswordChar = '*';
            this.txtChangePass.Size = new System.Drawing.Size(128, 23);
            this.txtChangePass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "변경할 비밀번호";
            // 
            // txtReCheckPass
            // 
            this.txtReCheckPass.Font = new System.Drawing.Font("굴림", 10F);
            this.txtReCheckPass.Location = new System.Drawing.Point(143, 86);
            this.txtReCheckPass.Name = "txtReCheckPass";
            this.txtReCheckPass.PasswordChar = '*';
            this.txtReCheckPass.Size = new System.Drawing.Size(128, 23);
            this.txtReCheckPass.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "비밀번호 재확인";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(195, 141);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "취  소";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(-1, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 5);
            this.panel1.TabIndex = 8;
            // 
            // PassChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 176);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.txtReCheckPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChangePass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNowPass);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PassChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비밀번호 변경";
            this.Load += new System.EventHandler(this.PassChangeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNowPass;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtChangePass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReCheckPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Panel panel1;
    }
}
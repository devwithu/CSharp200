namespace ReadingBitMap {
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
            this.txtRead = new System.Windows.Forms.TextBox();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnMyImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(26, 31);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(345, 21);
            this.txtRead.TabIndex = 1;
            this.txtRead.Text = "http://www.infopub.co.kr/img/logo.gif";
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(26, 72);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(593, 21);
            this.txtSave.TabIndex = 2;
            this.txtSave.Text = "C:\\\\Documents and Settings\\\\Administrator\\\\My Documents\\\\My Pictures\\\\aa.gif";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(593, 368);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(377, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(121, 23);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read Web Image";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(377, 41);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(242, 23);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "Write Web Image";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnMyImage
            // 
            this.btnMyImage.Location = new System.Drawing.Point(504, 12);
            this.btnMyImage.Name = "btnMyImage";
            this.btnMyImage.Size = new System.Drawing.Size(115, 23);
            this.btnMyImage.TabIndex = 7;
            this.btnMyImage.Text = "Read My Image";
            this.btnMyImage.UseVisualStyleBackColor = true;
            this.btnMyImage.Click += new System.EventHandler(this.btnMyImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 514);
            this.Controls.Add(this.btnMyImage);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.txtRead);
            this.Name = "Form1";
            this.Text = "ImageReader ver0.1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnMyImage;
    }
}


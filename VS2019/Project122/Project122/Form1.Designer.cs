namespace Project122
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRead = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnMyImage = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(35, 30);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(345, 21);
            this.txtRead.TabIndex = 2;
            this.txtRead.Text = "https://www.studying.kr/thema/Basic/colorset/Basic-Left/header.jpg";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(405, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(121, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read Web Image";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // btnMyImage
            // 
            this.btnMyImage.Location = new System.Drawing.Point(532, 12);
            this.btnMyImage.Name = "btnMyImage";
            this.btnMyImage.Size = new System.Drawing.Size(115, 23);
            this.btnMyImage.TabIndex = 8;
            this.btnMyImage.Text = "Read My Image";
            this.btnMyImage.UseVisualStyleBackColor = true;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(405, 41);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(242, 23);
            this.btnWrite.TabIndex = 9;
            this.btnWrite.Text = "Write Web Image";
            this.btnWrite.UseVisualStyleBackColor = true;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(35, 70);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(593, 21);
            this.txtSave.TabIndex = 10;
            this.txtSave.Text = "C:\\\\Documents and Settings\\\\Administrator\\\\My Documents\\\\My Pictures\\\\aa.gif";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(593, 368);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnMyImage);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtRead);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnMyImage;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


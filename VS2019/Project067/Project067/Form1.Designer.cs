namespace Project067
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
            this.btnReDraw = new System.Windows.Forms.Button();
            this.btnDrawNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReDraw
            // 
            this.btnReDraw.Location = new System.Drawing.Point(615, 333);
            this.btnReDraw.Name = "btnReDraw";
            this.btnReDraw.Size = new System.Drawing.Size(132, 23);
            this.btnReDraw.TabIndex = 3;
            this.btnReDraw.Text = "ReDraw Override";
            this.btnReDraw.UseVisualStyleBackColor = true;
            this.btnReDraw.Click += new System.EventHandler(this.BtnReDraw_Click);
            // 
            // btnDrawNew
            // 
            this.btnDrawNew.Location = new System.Drawing.Point(453, 333);
            this.btnDrawNew.Name = "btnDrawNew";
            this.btnDrawNew.Size = new System.Drawing.Size(132, 23);
            this.btnDrawNew.TabIndex = 4;
            this.btnDrawNew.Text = "ReDraw New";
            this.btnDrawNew.UseVisualStyleBackColor = true;
            this.btnDrawNew.Click += new System.EventHandler(this.BtnDrawNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 368);
            this.Controls.Add(this.btnDrawNew);
            this.Controls.Add(this.btnReDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReDraw;
        private System.Windows.Forms.Button btnDrawNew;
    }
}


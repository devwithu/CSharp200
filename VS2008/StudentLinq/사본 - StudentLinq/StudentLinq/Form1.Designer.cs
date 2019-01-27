namespace StudentLinq
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnName = new System.Windows.Forms.Button();
            this.txtNameResult = new System.Windows.Forms.TextBox();
            this.btnId = new System.Windows.Forms.Button();
            this.txtIdSearch = new System.Windows.Forms.TextBox();
            this.txtIndate = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowAll3 = new System.Windows.Forms.Button();
            this.btnShowAll2 = new System.Windows.Forms.Button();
            this.btnShowAll1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnName);
            this.splitContainer1.Panel1.Controls.Add(this.txtNameResult);
            this.splitContainer1.Panel1.Controls.Add(this.btnId);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtIndate);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddress);
            this.splitContainer1.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowAll3);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowAll2);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowAll1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(968, 474);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(12, 159);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(102, 23);
            this.btnName.TabIndex = 14;
            this.btnName.Text = "ID로 이름 찾기";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtNameResult
            // 
            this.txtNameResult.Location = new System.Drawing.Point(12, 200);
            this.txtNameResult.Name = "txtNameResult";
            this.txtNameResult.Size = new System.Drawing.Size(210, 21);
            this.txtNameResult.TabIndex = 13;
            // 
            // btnId
            // 
            this.btnId.Location = new System.Drawing.Point(120, 159);
            this.btnId.Name = "btnId";
            this.btnId.Size = new System.Drawing.Size(102, 23);
            this.btnId.TabIndex = 12;
            this.btnId.Text = "ID로 찾기";
            this.btnId.UseVisualStyleBackColor = true;
            this.btnId.Click += new System.EventHandler(this.btnId_Click);
            // 
            // txtIdSearch
            // 
            this.txtIdSearch.Location = new System.Drawing.Point(12, 123);
            this.txtIdSearch.Name = "txtIdSearch";
            this.txtIdSearch.Size = new System.Drawing.Size(201, 21);
            this.txtIdSearch.TabIndex = 11;
            // 
            // txtIndate
            // 
            this.txtIndate.Location = new System.Drawing.Point(79, 409);
            this.txtIndate.Name = "txtIndate";
            this.txtIndate.Size = new System.Drawing.Size(168, 21);
            this.txtIndate.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(79, 368);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(168, 21);
            this.txtAddress.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(79, 329);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(168, 21);
            this.txtPhone.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 292);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 21);
            this.txtName.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 243);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // btnShowAll3
            // 
            this.btnShowAll3.Location = new System.Drawing.Point(45, 80);
            this.btnShowAll3.Name = "btnShowAll3";
            this.btnShowAll3.Size = new System.Drawing.Size(168, 23);
            this.btnShowAll3.TabIndex = 2;
            this.btnShowAll3.Text = "ShowAll3";
            this.btnShowAll3.UseVisualStyleBackColor = true;
            this.btnShowAll3.Click += new System.EventHandler(this.btnShowAll3_Click);
            // 
            // btnShowAll2
            // 
            this.btnShowAll2.Location = new System.Drawing.Point(45, 51);
            this.btnShowAll2.Name = "btnShowAll2";
            this.btnShowAll2.Size = new System.Drawing.Size(168, 23);
            this.btnShowAll2.TabIndex = 1;
            this.btnShowAll2.Text = "ShowAll2";
            this.btnShowAll2.UseVisualStyleBackColor = true;
            this.btnShowAll2.Click += new System.EventHandler(this.btnShowAll2_Click);
            // 
            // btnShowAll1
            // 
            this.btnShowAll1.Location = new System.Drawing.Point(45, 12);
            this.btnShowAll1.Name = "btnShowAll1";
            this.btnShowAll1.Size = new System.Drawing.Size(168, 23);
            this.btnShowAll1.TabIndex = 0;
            this.btnShowAll1.Text = "ShowAll1";
            this.btnShowAll1.UseVisualStyleBackColor = true;
            this.btnShowAll1.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(668, 474);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 474);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student Linq ver 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShowAll1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowAll3;
        private System.Windows.Forms.Button btnShowAll2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtIndate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnId;
        private System.Windows.Forms.TextBox txtIdSearch;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.TextBox txtNameResult;
    }
}


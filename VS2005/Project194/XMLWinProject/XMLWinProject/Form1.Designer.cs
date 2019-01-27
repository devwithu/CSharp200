namespace XMLWinProject
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnXmlView = new System.Windows.Forms.Button();
            this.btnDataSet = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnView2 = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.treeForXml = new System.Windows.Forms.TreeView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnFold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(427, 486);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnXmlView
            // 
            this.btnXmlView.Location = new System.Drawing.Point(12, 522);
            this.btnXmlView.Name = "btnXmlView";
            this.btnXmlView.Size = new System.Drawing.Size(96, 25);
            this.btnXmlView.TabIndex = 1;
            this.btnXmlView.Text = "XML View";
            this.btnXmlView.UseVisualStyleBackColor = true;
            this.btnXmlView.Click += new System.EventHandler(this.btnXmlView_Click);
            // 
            // btnDataSet
            // 
            this.btnDataSet.Location = new System.Drawing.Point(114, 522);
            this.btnDataSet.Name = "btnDataSet";
            this.btnDataSet.Size = new System.Drawing.Size(96, 25);
            this.btnDataSet.TabIndex = 2;
            this.btnDataSet.Text = "XML DataSet";
            this.btnDataSet.UseVisualStyleBackColor = true;
            this.btnDataSet.Click += new System.EventHandler(this.btnDataSet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "XML Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView2
            // 
            this.btnView2.Location = new System.Drawing.Point(234, 522);
            this.btnView2.Name = "btnView2";
            this.btnView2.Size = new System.Drawing.Size(90, 25);
            this.btnView2.TabIndex = 4;
            this.btnView2.Text = "XML View";
            this.btnView2.UseVisualStyleBackColor = true;
            this.btnView2.Click += new System.EventHandler(this.btnView2_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(639, 524);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(113, 23);
            this.btnExpand.TabIndex = 7;
            this.btnExpand.Text = "모두 펼치기";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // treeForXml
            // 
            this.treeForXml.Location = new System.Drawing.Point(468, 14);
            this.treeForXml.Name = "treeForXml";
            this.treeForXml.Size = new System.Drawing.Size(454, 484);
            this.treeForXml.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 524);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "XML 문서 찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnFold
            // 
            this.btnFold.Location = new System.Drawing.Point(784, 524);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(113, 23);
            this.btnFold.TabIndex = 8;
            this.btnFold.Text = "모두 접기";
            this.btnFold.UseVisualStyleBackColor = true;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 596);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.treeForXml);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnView2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDataSet);
            this.Controls.Add(this.btnXmlView);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "FunXML View ver0.1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnXmlView;
        private System.Windows.Forms.Button btnDataSet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnView2;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.TreeView treeForXml;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnFold;
    }
}


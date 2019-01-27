namespace VidioShop2007
{
    partial class VideoSearchInfoForm
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
            this.btnEnd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tbVcost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbVage = new System.Windows.Forms.TextBox();
            this.tbVdirect = new System.Windows.Forms.TextBox();
            this.tbVact = new System.Windows.Forms.TextBox();
            this.tbVclass = new System.Windows.Forms.TextBox();
            this.tbVtitle = new System.Windows.Forms.TextBox();
            this.tbVcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvVideoList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.tbSearchNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnd.Location = new System.Drawing.Point(682, 11);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(98, 23);
            this.btnEnd.TabIndex = 6;
            this.btnEnd.Text = "종  료";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnEnd);
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.tbSearchName);
            this.splitContainer1.Panel2.Controls.Add(this.tbSearchNo);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 566);
            this.splitContainer1.SplitterDistance = 517;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnOK2);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.tbVcost);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbVage);
            this.groupBox2.Controls.Add(this.tbVdirect);
            this.groupBox2.Controls.Add(this.tbVact);
            this.groupBox2.Controls.Add(this.tbVclass);
            this.groupBox2.Controls.Add(this.tbVtitle);
            this.groupBox2.Controls.Add(this.tbVcode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(399, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 502);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Information";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.Location = new System.Drawing.Point(64, 468);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(78, 23);
            this.btnInsert.TabIndex = 27;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // btnOK2
            // 
            this.btnOK2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK2.Location = new System.Drawing.Point(246, 468);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(78, 23);
            this.btnOK2.TabIndex = 26;
            this.btnOK2.Text = "O  K";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Visible = false;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOk.Location = new System.Drawing.Point(246, 468);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "O  K";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModify.Location = new System.Drawing.Point(155, 468);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(78, 24);
            this.btnModify.TabIndex = 19;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 460);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(375, 39);
            this.splitter1.TabIndex = 28;
            this.splitter1.TabStop = false;
            // 
            // tbVcost
            // 
            this.tbVcost.BackColor = System.Drawing.Color.Wheat;
            this.tbVcost.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVcost.Location = new System.Drawing.Point(128, 235);
            this.tbVcost.Name = "tbVcost";
            this.tbVcost.ReadOnly = true;
            this.tbVcost.Size = new System.Drawing.Size(181, 26);
            this.tbVcost.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("굴림", 12F);
            this.label12.Location = new System.Drawing.Point(24, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "가     격";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbVage
            // 
            this.tbVage.BackColor = System.Drawing.Color.Wheat;
            this.tbVage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVage.Location = new System.Drawing.Point(128, 203);
            this.tbVage.Name = "tbVage";
            this.tbVage.ReadOnly = true;
            this.tbVage.Size = new System.Drawing.Size(181, 26);
            this.tbVage.TabIndex = 17;
            // 
            // tbVdirect
            // 
            this.tbVdirect.BackColor = System.Drawing.Color.Wheat;
            this.tbVdirect.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVdirect.Location = new System.Drawing.Point(128, 171);
            this.tbVdirect.Name = "tbVdirect";
            this.tbVdirect.ReadOnly = true;
            this.tbVdirect.Size = new System.Drawing.Size(181, 26);
            this.tbVdirect.TabIndex = 16;
            // 
            // tbVact
            // 
            this.tbVact.BackColor = System.Drawing.Color.Wheat;
            this.tbVact.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVact.Location = new System.Drawing.Point(128, 139);
            this.tbVact.Name = "tbVact";
            this.tbVact.ReadOnly = true;
            this.tbVact.Size = new System.Drawing.Size(181, 26);
            this.tbVact.TabIndex = 15;
            // 
            // tbVclass
            // 
            this.tbVclass.BackColor = System.Drawing.Color.Wheat;
            this.tbVclass.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVclass.Location = new System.Drawing.Point(128, 107);
            this.tbVclass.Name = "tbVclass";
            this.tbVclass.ReadOnly = true;
            this.tbVclass.Size = new System.Drawing.Size(181, 26);
            this.tbVclass.TabIndex = 14;
            // 
            // tbVtitle
            // 
            this.tbVtitle.BackColor = System.Drawing.Color.Wheat;
            this.tbVtitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVtitle.Location = new System.Drawing.Point(128, 75);
            this.tbVtitle.Name = "tbVtitle";
            this.tbVtitle.ReadOnly = true;
            this.tbVtitle.Size = new System.Drawing.Size(181, 26);
            this.tbVtitle.TabIndex = 13;
            // 
            // tbVcode
            // 
            this.tbVcode.BackColor = System.Drawing.Color.Wheat;
            this.tbVcode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVcode.Location = new System.Drawing.Point(128, 42);
            this.tbVcode.Name = "tbVcode";
            this.tbVcode.ReadOnly = true;
            this.tbVcode.Size = new System.Drawing.Size(181, 26);
            this.tbVcode.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("굴림", 12F);
            this.label9.Location = new System.Drawing.Point(24, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "등     급";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 12F);
            this.label8.Location = new System.Drawing.Point(24, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "감     독";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 12F);
            this.label7.Location = new System.Drawing.Point(24, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "주연배우";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 12F);
            this.label6.Location = new System.Drawing.Point(24, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "장     르";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 12F);
            this.label5.Location = new System.Drawing.Point(24, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "제     목";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(24, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "비디오 번호";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvVideoList);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 502);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video List";
            // 
            // lvVideoList
            // 
            this.lvVideoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvVideoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVideoList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvVideoList.GridLines = true;
            this.lvVideoList.Location = new System.Drawing.Point(3, 25);
            this.lvVideoList.Name = "lvVideoList";
            this.lvVideoList.Size = new System.Drawing.Size(375, 474);
            this.lvVideoList.TabIndex = 0;
            this.lvVideoList.UseCompatibleStateImageBehavior = false;
            this.lvVideoList.View = System.Windows.Forms.View.Details;
            this.lvVideoList.SelectedIndexChanged += new System.EventHandler(this.lvVideoList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "비디오 코드";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "이 름";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "가 격";
            this.columnHeader3.Width = 99;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(577, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(472, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "검  색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearchName
            // 
            this.tbSearchName.BackColor = System.Drawing.Color.Wheat;
            this.tbSearchName.Location = new System.Drawing.Point(338, 12);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(108, 21);
            this.tbSearchName.TabIndex = 3;
            // 
            // tbSearchNo
            // 
            this.tbSearchNo.BackColor = System.Drawing.Color.Wheat;
            this.tbSearchNo.Location = new System.Drawing.Point(112, 12);
            this.tbSearchNo.Name = "tbSearchNo";
            this.tbSearchNo.Size = new System.Drawing.Size(108, 21);
            this.tbSearchNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(251, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "제       목";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "비디오 번호";
            // 
            // VideoSearchInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VideoSearchInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "비디오 정보조회 화면";
            this.Load += new System.EventHandler(this.VideoSearchInfoForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbVcost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox tbVage;
        private System.Windows.Forms.TextBox tbVdirect;
        private System.Windows.Forms.TextBox tbVact;
        private System.Windows.Forms.TextBox tbVclass;
        private System.Windows.Forms.TextBox tbVtitle;
        private System.Windows.Forms.TextBox tbVcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvVideoList;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.TextBox tbSearchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Splitter splitter1;
    }
}
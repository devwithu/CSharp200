namespace VidioShop2007
{
    partial class VLendForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabVLendForm = new System.Windows.Forms.TabControl();
            this.tabLend = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtActor = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtVNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnVSearch = new System.Windows.Forms.Button();
            this.txtVNoSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkUsePoint = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.radioCard = new System.Windows.Forms.RadioButton();
            this.radioCash = new System.Windows.Forms.RadioButton();
            this.lvLend = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLendOk = new System.Windows.Forms.Button();
            this.btnReturnOK = new System.Windows.Forms.Button();
            this.btnLendCancle = new System.Windows.Forms.Button();
            this.tabLendList = new System.Windows.Forms.TabPage();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPayWay = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabVLendForm.SuspendLayout();
            this.tabLend.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabLendList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabVLendForm
            // 
            this.tabVLendForm.Controls.Add(this.tabLend);
            this.tabVLendForm.Controls.Add(this.tabLendList);
            this.tabVLendForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVLendForm.Location = new System.Drawing.Point(0, 0);
            this.tabVLendForm.Name = "tabVLendForm";
            this.tabVLendForm.SelectedIndex = 0;
            this.tabVLendForm.Size = new System.Drawing.Size(792, 566);
            this.tabVLendForm.TabIndex = 0;
            this.tabVLendForm.SelectedIndexChanged += new System.EventHandler(this.tabVLendForm_SelectedIndexChanged);
            // 
            // tabLend
            // 
            this.tabLend.Controls.Add(this.splitContainer1);
            this.tabLend.Location = new System.Drawing.Point(4, 23);
            this.tabLend.Name = "tabLend";
            this.tabLend.Padding = new System.Windows.Forms.Padding(3);
            this.tabLend.Size = new System.Drawing.Size(784, 539);
            this.tabLend.TabIndex = 0;
            this.tabLend.Text = "대여/반납";
            this.tabLend.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.btnLendOk);
            this.splitContainer1.Panel2.Controls.Add(this.btnReturnOK);
            this.splitContainer1.Panel2.Controls.Add(this.btnLendCancle);
            this.splitContainer1.Size = new System.Drawing.Size(778, 533);
            this.splitContainer1.SplitterDistance = 478;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label14);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer2.Panel1.Controls.Add(this.radioButton1);
            this.splitContainer2.Panel1.Controls.Add(this.btnVSearch);
            this.splitContainer2.Panel1.Controls.Add(this.txtVNoSearch);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Panel2.Controls.Add(this.textBox2);
            this.splitContainer2.Panel2.Controls.Add(this.label15);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.lvLend);
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.txtMSearch);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(778, 478);
            this.splitContainer2.SplitterDistance = 342;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 21);
            this.textBox1.TabIndex = 66;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("굴림", 10F);
            this.label14.Location = new System.Drawing.Point(12, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 65;
            this.label14.Text = "고객 No.";
            this.label14.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 5);
            this.panel3.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtGrade);
            this.panel2.Controls.Add(this.txtDirector);
            this.panel2.Controls.Add(this.txtActor);
            this.panel2.Controls.Add(this.txtGenre);
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.txtVNo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(14, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 279);
            this.panel2.TabIndex = 63;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Wheat;
            this.txtPrice.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPrice.Location = new System.Drawing.Point(116, 220);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(181, 26);
            this.txtPrice.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("굴림", 12F);
            this.label12.Location = new System.Drawing.Point(12, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 21);
            this.label12.TabIndex = 69;
            this.label12.Text = "가     격";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGrade
            // 
            this.txtGrade.BackColor = System.Drawing.Color.Wheat;
            this.txtGrade.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGrade.Location = new System.Drawing.Point(116, 154);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.ReadOnly = true;
            this.txtGrade.Size = new System.Drawing.Size(181, 26);
            this.txtGrade.TabIndex = 68;
            // 
            // txtDirector
            // 
            this.txtDirector.BackColor = System.Drawing.Color.Wheat;
            this.txtDirector.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDirector.Location = new System.Drawing.Point(116, 122);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.ReadOnly = true;
            this.txtDirector.Size = new System.Drawing.Size(181, 26);
            this.txtDirector.TabIndex = 67;
            // 
            // txtActor
            // 
            this.txtActor.BackColor = System.Drawing.Color.Wheat;
            this.txtActor.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtActor.Location = new System.Drawing.Point(116, 90);
            this.txtActor.Name = "txtActor";
            this.txtActor.ReadOnly = true;
            this.txtActor.Size = new System.Drawing.Size(181, 26);
            this.txtActor.TabIndex = 66;
            // 
            // txtGenre
            // 
            this.txtGenre.BackColor = System.Drawing.Color.Wheat;
            this.txtGenre.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGenre.Location = new System.Drawing.Point(116, 188);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ReadOnly = true;
            this.txtGenre.Size = new System.Drawing.Size(181, 26);
            this.txtGenre.TabIndex = 65;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Wheat;
            this.txtTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTitle.Location = new System.Drawing.Point(116, 58);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(181, 26);
            this.txtTitle.TabIndex = 64;
            // 
            // txtVNo
            // 
            this.txtVNo.BackColor = System.Drawing.Color.Wheat;
            this.txtVNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVNo.Location = new System.Drawing.Point(116, 25);
            this.txtVNo.Name = "txtVNo";
            this.txtVNo.ReadOnly = true;
            this.txtVNo.Size = new System.Drawing.Size(181, 26);
            this.txtVNo.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 12F);
            this.label6.Location = new System.Drawing.Point(12, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "장     르";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("굴림", 12F);
            this.label9.Location = new System.Drawing.Point(12, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 21);
            this.label9.TabIndex = 62;
            this.label9.Text = "등     급";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 12F);
            this.label8.Location = new System.Drawing.Point(12, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 21);
            this.label8.TabIndex = 61;
            this.label8.Text = "감     독";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 12F);
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 21);
            this.label7.TabIndex = 60;
            this.label7.Text = "주연배우";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 12F);
            this.label5.Location = new System.Drawing.Point(12, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 58;
            this.label5.Text = "제     목";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "비디오 No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(285, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 58;
            this.radioButton2.Text = "반납";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(232, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 57;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "대여";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnVSearch
            // 
            this.btnVSearch.Location = new System.Drawing.Point(185, 70);
            this.btnVSearch.Name = "btnVSearch";
            this.btnVSearch.Size = new System.Drawing.Size(58, 23);
            this.btnVSearch.TabIndex = 42;
            this.btnVSearch.Text = "검색";
            this.btnVSearch.UseVisualStyleBackColor = true;
            this.btnVSearch.Click += new System.EventHandler(this.btnVSearch_Click);
            // 
            // txtVNoSearch
            // 
            this.txtVNoSearch.Location = new System.Drawing.Point(95, 70);
            this.txtVNoSearch.Name = "txtVNoSearch";
            this.txtVNoSearch.Size = new System.Drawing.Size(78, 21);
            this.txtVNoSearch.TabIndex = 41;
            this.txtVNoSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "비디오 No.";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 268);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 21);
            this.textBox2.TabIndex = 64;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 10F);
            this.label15.Location = new System.Drawing.Point(15, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 63;
            this.label15.Text = "반납일자";
            this.label15.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkUsePoint);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtPoint);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.radioCard);
            this.panel1.Controls.Add(this.radioCash);
            this.panel1.Location = new System.Drawing.Point(16, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 136);
            this.panel1.TabIndex = 62;
            // 
            // checkUsePoint
            // 
            this.checkUsePoint.AutoSize = true;
            this.checkUsePoint.Location = new System.Drawing.Point(172, 22);
            this.checkUsePoint.Name = "checkUsePoint";
            this.checkUsePoint.Size = new System.Drawing.Size(48, 16);
            this.checkUsePoint.TabIndex = 65;
            this.checkUsePoint.Text = "사용";
            this.checkUsePoint.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 10F);
            this.label13.Location = new System.Drawing.Point(21, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 14);
            this.label13.TabIndex = 64;
            this.label13.Text = "마일리지 사용 불가";
            this.label13.Visible = false;
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(87, 17);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.ReadOnly = true;
            this.txtPoint.Size = new System.Drawing.Size(78, 21);
            this.txtPoint.TabIndex = 63;
            this.txtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 10F);
            this.label11.Location = new System.Drawing.Point(18, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 62;
            this.label11.Text = "마일리지";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(17, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 47;
            this.label3.Text = "금     액";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 10F);
            this.label10.Location = new System.Drawing.Point(15, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 61;
            this.label10.Text = "지불수단";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(88, 49);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(78, 21);
            this.txtAmount.TabIndex = 48;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioCard
            // 
            this.radioCard.AutoSize = true;
            this.radioCard.Location = new System.Drawing.Point(141, 91);
            this.radioCard.Name = "radioCard";
            this.radioCard.Size = new System.Drawing.Size(47, 16);
            this.radioCard.TabIndex = 60;
            this.radioCard.Text = "카드";
            this.radioCard.UseVisualStyleBackColor = true;
            this.radioCard.CheckedChanged += new System.EventHandler(this.radioCard_CheckedChanged);
            // 
            // radioCash
            // 
            this.radioCash.AutoSize = true;
            this.radioCash.Checked = true;
            this.radioCash.Location = new System.Drawing.Point(88, 91);
            this.radioCash.Name = "radioCash";
            this.radioCash.Size = new System.Drawing.Size(47, 16);
            this.radioCash.TabIndex = 59;
            this.radioCash.TabStop = true;
            this.radioCash.Text = "현금";
            this.radioCash.UseVisualStyleBackColor = true;
            this.radioCash.CheckedChanged += new System.EventHandler(this.radioCash_CheckedChanged);
            // 
            // lvLend
            // 
            this.lvLend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvLend.Font = new System.Drawing.Font("굴림", 10F);
            this.lvLend.GridLines = true;
            this.lvLend.Location = new System.Drawing.Point(16, 115);
            this.lvLend.Name = "lvLend";
            this.lvLend.Size = new System.Drawing.Size(398, 137);
            this.lvLend.TabIndex = 46;
            this.lvLend.UseCompatibleStateImageBehavior = false;
            this.lvLend.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "비디오 NO";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "제   목";
            this.columnHeader5.Width = 139;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "대여일자";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "반납일자";
            this.columnHeader7.Width = 86;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMSearch
            // 
            this.txtMSearch.Location = new System.Drawing.Point(86, 70);
            this.txtMSearch.Name = "txtMSearch";
            this.txtMSearch.Size = new System.Drawing.Size(78, 21);
            this.txtMSearch.TabIndex = 44;
            this.txtMSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 43;
            this.label2.Text = "회원 No.";
            // 
            // btnLendOk
            // 
            this.btnLendOk.Font = new System.Drawing.Font("굴림", 10F);
            this.btnLendOk.Location = new System.Drawing.Point(512, 11);
            this.btnLendOk.Name = "btnLendOk";
            this.btnLendOk.Size = new System.Drawing.Size(78, 28);
            this.btnLendOk.TabIndex = 43;
            this.btnLendOk.Text = "대   여";
            this.btnLendOk.UseVisualStyleBackColor = true;
            this.btnLendOk.Click += new System.EventHandler(this.btnLendOk_Click);
            // 
            // btnReturnOK
            // 
            this.btnReturnOK.Font = new System.Drawing.Font("굴림", 10F);
            this.btnReturnOK.Location = new System.Drawing.Point(596, 11);
            this.btnReturnOK.Name = "btnReturnOK";
            this.btnReturnOK.Size = new System.Drawing.Size(78, 28);
            this.btnReturnOK.TabIndex = 45;
            this.btnReturnOK.Text = "반   납";
            this.btnReturnOK.UseVisualStyleBackColor = true;
            this.btnReturnOK.Visible = false;
            this.btnReturnOK.Click += new System.EventHandler(this.btnReturnOK_Click);
            // 
            // btnLendCancle
            // 
            this.btnLendCancle.Font = new System.Drawing.Font("굴림", 10F);
            this.btnLendCancle.Location = new System.Drawing.Point(680, 11);
            this.btnLendCancle.Name = "btnLendCancle";
            this.btnLendCancle.Size = new System.Drawing.Size(78, 28);
            this.btnLendCancle.TabIndex = 44;
            this.btnLendCancle.Text = "취   소";
            this.btnLendCancle.UseVisualStyleBackColor = true;
            this.btnLendCancle.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabLendList
            // 
            this.tabLendList.Controls.Add(this.btnclose);
            this.tabLendList.Controls.Add(this.txtPayAmount);
            this.tabLendList.Controls.Add(this.label17);
            this.tabLendList.Controls.Add(this.txtPayWay);
            this.tabLendList.Controls.Add(this.label16);
            this.tabLendList.Controls.Add(this.dataGridView1);
            this.tabLendList.Location = new System.Drawing.Point(4, 23);
            this.tabLendList.Name = "tabLendList";
            this.tabLendList.Padding = new System.Windows.Forms.Padding(3);
            this.tabLendList.Size = new System.Drawing.Size(784, 539);
            this.tabLendList.TabIndex = 1;
            this.tabLendList.Text = "대여목록";
            this.tabLendList.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(701, 494);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 6;
            this.btnclose.Text = "닫  기";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(290, 496);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(100, 21);
            this.txtPayAmount.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 499);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "결제금액";
            // 
            // txtPayWay
            // 
            this.txtPayWay.Location = new System.Drawing.Point(104, 496);
            this.txtPayWay.Name = "txtPayWay";
            this.txtPayWay.Size = new System.Drawing.Size(100, 21);
            this.txtPayWay.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 499);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "결제방법";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(778, 472);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // VLendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.ControlBox = false;
            this.Controls.Add(this.tabVLendForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VLendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "대   여";
            this.Load += new System.EventHandler(this.VLendForm_Load);
            this.tabVLendForm.ResumeLayout(false);
            this.tabLend.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabLendList.ResumeLayout(false);
            this.tabLendList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVLendForm;
        private System.Windows.Forms.TabPage tabLend;
        private System.Windows.Forms.TabPage tabLendList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnVSearch;
        private System.Windows.Forms.TextBox txtVNoSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvLend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioCard;
        private System.Windows.Forms.RadioButton radioCash;
        private System.Windows.Forms.Button btnLendOk;
        private System.Windows.Forms.Button btnReturnOK;
        private System.Windows.Forms.Button btnLendCancle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtActor;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtVNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkUsePoint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPayWay;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnclose;
    }
}
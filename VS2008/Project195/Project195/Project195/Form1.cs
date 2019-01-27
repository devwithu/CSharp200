using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
namespace Project195
{
    public partial class Form1 : Form
    {
        bool isModified = false;
        StringReader streamToPrint;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ToolbarHide(true);
        }
        private void 툴바숨기기HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolbarHide(false);
        }
        private void ToolbarHide(bool b)
        {
            this.툴바숨기기HToolStripMenuItem.Visible = b;
            this.툴바보이기SToolStripMenuItem.Visible = !b;
            this.toolStrip1.Visible = b;
        }
        private void 툴바보이기SToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            ToolbarHide(true);
        }
        private void 새로만들기NToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            DoNew();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            DoNew();
        }//
        private void DoNew()
        {
            //파일을 찾아서 불러올때 isModified=true
            if (this.isModified)
            {
                string message = "이 문서(" + this.Text + ")"
                          + "는 변경되었습니다. 저장하시겠습니까?";
                switch (MessageBox.Show(message, "JungBo Editor ver 0.1",
                          MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        this.richTb.Text = "";
                        break;
                    case DialogResult.No:
                        this.richTb.Text = "";
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                richTb.Text = "";
            }
            this.Text = "JungBo Editor ver 0.1";
        }
        public void DoSaveAs(bool showDialog)
        {
            bool canWrite = false;
            string fname = "";
            if (showDialog)
            {
                if (DialogResult.OK ==
                       this.saveFileDialog1.ShowDialog())
                {
                    fname = saveFileDialog1.FileName;
                    canWrite = true;
                }
            }
            else
            {
                fname = this.Text;
                canWrite = true;
            }
            if (canWrite)
            {
                try
                {
                    using (FileStream fs =
                      new FileStream(fname, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter sw =
                            new StreamWriter(fs, Encoding.Default))
                        {
                            sw.Write(this.richTb.Text);
                            sw.Flush();
                            sw.Close();
                        }
                        fs.Close();
                    }
                    this.Text = fname;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }//
        private void DoSave()
        {
            if (this.Text == "JungBo Editor ver 0.1")
            {
                DoSaveAs(true);
            }
            DoSaveAs(false);
            this.isModified = false;
        }//
        private void DoOpen()
        {
            string fname = "";
            this.richTb.Clear();//청소
            this.openFileDialog1.Filter =
 "모든 파일(*.*)|*.*|Text 문서(*.txt)|*.txt|XML 문서 (*.xml)|*.xml";
            if (DialogResult.OK == this.openFileDialog1.ShowDialog())
            {
                fname = this.openFileDialog1.FileName.ToString();
                try
                {
                    StreamReader sr =
                        new StreamReader(fname, Encoding.Default, true);
                    int totalLine = 0;
                    string strLine = "";
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        this.richTb.AppendText(strLine + "\n");
                        totalLine++;
                    }
                    this.Text = fname;//머릿말이 달라진다.
                    richTb.SelectionStart = 0;//
                    richTb.SelectionLength = 0;//
                    sr.Close();
                    int totalStringLength = this.richTb.TextLength;
                    this.toolStripStatusLabel1.Text =
               string.Format("총 [{0}줄 {1}자]", totalLine, totalStringLength);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
        private void DoEnd()
        {
            DialogResult dr =
                MessageBox.Show("작업하시던 것 저장하시겠습니까?",
                "저장?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DoSave();
            }

        }
        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpen();
        }
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            DoOpen();
        }
        //--------------------------------------------------------------------
        private void tbsSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoSaveAs(true);
        }
        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoEnd();
            this.Close();
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.DoEnd();
            this.Close();
        }

        private void 실행취소UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTb.CanUndo)
            {
                this.richTb.Undo();
            }
        }

        private void 잘라내기TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.Cut();
        }

        private void 복사CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.Copy();
        }

        private void 삭제LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.Clear();
        }

        private void 붙이기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.Paste();
        }

        private void 자동줄바꿈WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (자동줄바꿈WToolStripMenuItem.Checked == true)
            {
                this.richTb.WordWrap = false;
                자동줄바꿈WToolStripMenuItem.Checked = false;
            }
            else if (자동줄바꿈WToolStripMenuItem.Checked == false)
            {
                this.richTb.WordWrap = true;
                자동줄바꿈WToolStripMenuItem.Checked = true;
            }
        }

        private void 글꼴FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.fontDialog1.ShowDialog())
            {
                this.richTb.Font = this.fontDialog1.Font;
            }
            this.richTb.Update();
        }

        private void 색깔CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.colorDialog1.ShowDialog())
            {
                this.richTb.ForeColor = this.colorDialog1.Color;
            }
            this.richTb.Update();
        }

        private void 모두선택AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.SelectAll();
        }

        private void 찾기FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 시간날짜DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string times = System.DateTime.Now.ToLongDateString();
            this.richTb.Text += String.Format("{0}\t", times);
        }

        private void 선택SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTb.Select();
        }

        private void 상태표시줄SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.상태표시줄SToolStripMenuItem.Checked == true)
            {
                this.statusStrip1.Visible = false;
                this.상태표시줄SToolStripMenuItem.Checked = false;
            }
            else if (this.상태표시줄SToolStripMenuItem.Checked == false)
            {
                statusStrip1.Visible = true;
                this.상태표시줄SToolStripMenuItem.Checked = true;
            }
        }

        private void 메모장정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxes about = new AboutBoxes();
            about.Show();
        }

        private void tsbBold_Click(object sender, EventArgs e)
        {
            FontStyle styles = this.richTb.Font.Style;
            if (richTb.SelectionFont.Bold)
            {
                styles &= ~FontStyle.Bold;
            }
            else
            {
                styles |= FontStyle.Bold;
            }
            SetFontStyle(styles);
        }

        private void tsbItalic_Click(object sender, EventArgs e)
        {
            FontStyle styles = this.richTb.Font.Style;
            if (richTb.SelectionFont.Italic)
            {
                styles &= ~FontStyle.Italic;
            }
            else
            {
                styles |= FontStyle.Italic;
            }
            SetFontStyle(styles);
        }
        private void tsbUnderLine_Click(object sender, EventArgs e)
        {
            FontStyle styles = this.richTb.Font.Style;
            if (richTb.SelectionFont.Underline)
            {
                styles &= ~FontStyle.Underline;
            }
            else
            {
                styles |= FontStyle.Underline;
            }
            SetFontStyle(styles);
        }
        private void SetFontStyle(FontStyle styles)
        {
            Font f = new Font(this.richTb.Font.FontFamily, this.richTb.Font.Size, styles);
            this.richTb.Font = f;
            this.richTb.Update();
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            AboutBoxes about = new AboutBoxes();
            about.Show();
        }

        private void tsbLine_Click(object sender, EventArgs e)
        {

        }

        private void 이동GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveLineForm search = new MoveLineForm();
            search.Show(this);//owner
        }


        public void MoveToWantedLine(int lines)
        {
            int currentPos = this.richTb.Text.IndexOf("\n");
            int movingLine = 0;
            bool IsMoved = false;
            while (currentPos > -1 && !IsMoved)
            {
                movingLine++;
                if (lines == movingLine)
                {
                    richTb.SelectionStart = currentPos - 1;
                    KeyLocation();
                    IsMoved = true;
                }
                currentPos = richTb.Text.IndexOf("\n", currentPos + 1);
            }
            if (!IsMoved)
            {
                if (lines == movingLine + 1)
                    richTb.SelectionStart = richTb.Text.Length;
                else
                    MessageBox.Show("전체 줄 수보다 큰 수를 입력했습니다.");
            }
            richTb.Focus();//이것을 해줘야함.....
            //richTb.Update();
        }

        private void KeyLocation()
        {
            try
            {
                int ColCount = 1;
                int RowCount = 1;
                int Pos;
                //To Set Column 
                if (richTb.SelectionStart > -1)
                {
                    Pos = richTb.Text.LastIndexOf("\n", richTb.SelectionStart);
                    if (Pos > -1)
                    {
                        //If the cursor is at CRLF
                        if (Pos != richTb.SelectionStart)
                            ColCount = richTb.SelectionStart - Pos;
                        else
                        {
                            //Col position is diff between PrevEnter and CurPos
                            Pos = richTb.Text.LastIndexOf("\n", richTb.SelectionStart - 1);
                            ColCount = richTb.SelectionStart - Pos;
                        }
                    }
                    else
                    {
                        ColCount = richTb.SelectionStart + 1;
                    }
                    while (Pos > -1)
                    {
                        RowCount++;
                        Pos = richTb.Text.LastIndexOf("\n", Pos - 1);
                    }
                }
                this.toolStripStatusLabel2.Text = string.Format("현재 [{0}줄 {1}번째]", RowCount, ColCount);
            }
            catch (Exception)
            {
            }
        }

        private void richTb_MouseClick(object sender, MouseEventArgs e)
        {
            KeyLocation();
        }

        private void richTb_KeyUp(object sender, KeyEventArgs e)
        {
            KeyLocation();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("정말끝내시겠습니까?", "끝", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 페이지설정UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = this.Text == "JungBo Editor ver 0.1" ? "Untitle.txt" : this.Text;
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        private void 인쇄PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.AllowPrintToFile = true;
            printDocument1.DocumentName = this.Text == "JungBo Editor ver 0.1" ? "Untitle.txt" : this.Text;
            try
            {
                streamToPrint = new StringReader(this.richTb.Text);

                try
                {

                    printDocument1.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 페이지미리보기VToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            printDialog1.AllowPrintToFile = true;
            printDocument1.DocumentName =
           this.Text == "JungBo Editor ver 0.1" ? "Untitle.txt" : this.Text;
            printPreviewDialog1.Document = printDocument1;
            streamToPrint = new StringReader(this.richTb.Text);
            printPreviewDialog1.ShowDialog();
        }

        private void document_PrintPage(object sender,
    System.Drawing.Printing.PrintPageEventArgs ev)
        {
            //MSDN 소스 이용
            Font printFont = this.Font;

            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            //페이지당 라인수 계산
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            //한 줄씩 출력
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));

                ev.Graphics.DrawString(line, printFont,
       Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            //출력할 페이지가 더 있는가
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
        private void tbsPageSetting_Click(object sender, EventArgs e)
        {
            페이지미리보기VToolStripMenuItem_Click(null, null);
        }
        private void tbsPrint_Click(object sender, EventArgs e)
        {
            인쇄PToolStripMenuItem_Click(null, null);
        }
    }
}
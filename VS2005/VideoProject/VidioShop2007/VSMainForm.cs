using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class VSMainForm : Form
    {
        VideoSearchInfoForm vsf;
        MemberFindForm mff;
        VLendForm vlf;
        LoginForm lf;

        public VSMainForm()
        {
            InitializeComponent();
        }
                
        private void VSMainForm_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'videoshopDataSet.video' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
            
            lf = new LoginForm();
            lf.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {            
            mff = new MemberFindForm();       
            mff.MdiParent = this;
            mff.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            vsf = new VideoSearchInfoForm();
            vsf.MdiParent = this;
            vsf.Show();
        }       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.SelectedImageIndex == 2)
            {
                vsf = new VideoSearchInfoForm();
                vsf.MdiParent = this;
                vsf.Show();
            }
            else if (e.Node.SelectedImageIndex ==  3)
            {
                mff = new MemberFindForm();
                mff.MdiParent = this;
                mff.Show();
            }
            else if (e.Node.SelectedImageIndex ==  4)
            {
                vlf = new VLendForm();
                vlf.MdiParent = this;
                vlf.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            vlf = new VLendForm();
            vlf.MdiParent = this;
            vlf.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            PassChangeForm pcf = new PassChangeForm();
            pcf.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
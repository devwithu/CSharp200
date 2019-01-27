using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
namespace Project194
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet("FundXML");
        public Form1()
        {
            InitializeComponent();
        }
        private void btnXmlView_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                XmlDataDocument doc = new XmlDataDocument();
                MessageBox.Show(this.openFileDialog1.FileName);
                doc.DataSet.ReadXml(this.openFileDialog1.FileName);
                ds = doc.DataSet;
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }
        private void btnDataSet_Click(object sender, EventArgs e)
        {
            ds = new DataSet("FundXML");//새로 준비
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show(this.openFileDialog1.FileName);
                ds.ReadXml(this.openFileDialog1.FileName);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }
        //DataSet을 이용하여 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show(this.saveFileDialog1.FileName);
                ds.WriteXml(this.saveFileDialog1.FileName);
            }
        }
        private void btnView2_Click(object sender, EventArgs e)
        {
            ds = new DataSet("FundXML");//새로 준비
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show(this.openFileDialog1.FileName);
                using (XmlTextReader xtr
              = new XmlTextReader(this.openFileDialog1.FileName))
                {
                    ds.ReadXml(xtr);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }
        //재귀를 이용하여 트리를 만든다.
        private void TreeXML(string msg, XmlNode node,
            TreeNodeCollection treenode)
        {
            //노드를 붙여서 트리모양의 노드로 만들기
            TreeNode newTreeNode = treenode.Add(node.Name);
            //노드는 엘리먼트, 어트리뷰트, 텍스트, PI, XML선언, 코멘트
            //등 모든 것이 노드다. 노드의 종류를 확인한다. 
            switch (node.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + node.Name + " " + node.Value + "?>";
                    break;
                case XmlNodeType.Document:
                    newTreeNode.Text = msg;
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + node.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "(속성 :" + node.Name + ")";
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = node.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + node.Value + "-->";
                    break;
            }
            //속성이 있다면 속성을 ()에 붙인다.
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    TreeXML("", attribute, newTreeNode.Nodes);
                }
            }
            //엘리먼트
            foreach (XmlNode childNode in node.ChildNodes)
            {
                TreeXML("", childNode, newTreeNode.Nodes);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "xml문서(*.xml)|*.xml";
            string fname = "";
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                fname = this.openFileDialog2.FileName;
            }
            //XML 트리를 청소
            treeForXml.Nodes.Clear();
            MessageBox.Show(fname);
            //Dom으로 XML문서 읽기
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fname);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            //Dom을 넘김
            TreeXML("<KOSDAQ Fund>", doc, treeForXml.Nodes);
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeForXml.Nodes[0].ExpandAll();
        }
        private void btnFold_Click(object sender, EventArgs e)
        {
            treeForXml.Nodes[0].Collapse();
        }
    }
}
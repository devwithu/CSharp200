using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
namespace XMLWinProject{
 public partial class Form1 : Form{
    DataSet ds = new DataSet("FundXML");
    public Form1(){
        InitializeComponent();
    }
    private void btnXmlView_Click(object sender, EventArgs e){
        DialogResult dr = this.openFileDialog1.ShowDialog();
        if(dr==DialogResult.OK){
            XmlDataDocument doc = new XmlDataDocument();
            MessageBox.Show(this.openFileDialog1.FileName);
            doc.DataSet.ReadXml(this.openFileDialog1.FileName);
            ds = doc.DataSet;
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
    private void btnDataSet_Click(object sender, EventArgs e){
        ds = new DataSet("FundXML");//���� �غ�
        DialogResult dr = this.openFileDialog1.ShowDialog();
        if (dr == DialogResult.OK) {
            MessageBox.Show(this.openFileDialog1.FileName);
            ds.ReadXml(this.openFileDialog1.FileName);
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
    //DataSet�� �̿��Ͽ� ����
     private void btnSave_Click(object sender, EventArgs e){
        DialogResult dr = this.saveFileDialog1.ShowDialog();
        if (dr == DialogResult.OK){
            MessageBox.Show(this.saveFileDialog1.FileName);
            ds.WriteXml(this.saveFileDialog1.FileName);
        }
    }
     private void btnView2_Click(object sender, EventArgs e){
        ds = new DataSet("FundXML");//���� �غ�
        DialogResult dr = this.openFileDialog1.ShowDialog();
        if (dr == DialogResult.OK){
            MessageBox.Show(this.openFileDialog1.FileName);
            using (XmlTextReader xtr
          = new XmlTextReader(this.openFileDialog1.FileName)){
               ds.ReadXml(xtr);
               this.dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
    //��͸� �̿��Ͽ� Ʈ���� �����.
    private void TreeXML(string msg, XmlNode node,
        TreeNodeCollection treenode){
        //��带 �ٿ��� Ʈ������� ���� �����
        TreeNode newTreeNode = treenode.Add(node.Name);
        //���� ������Ʈ, ��Ʈ����Ʈ, �ؽ�Ʈ, PI, XML����, �ڸ�Ʈ
        //�� ��� ���� ����. ����� ������ Ȯ���Ѵ�. 
        switch (node.NodeType) {
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
                newTreeNode.Text = "(�Ӽ� :" + node.Name + ")";
                break;
            case XmlNodeType.Text:
            case XmlNodeType.CDATA:
                newTreeNode.Text = node.Value;
                break;
            case XmlNodeType.Comment:
                newTreeNode.Text = "<!--" + node.Value + "-->";
                break;
        }
        //�Ӽ��� �ִٸ� �Ӽ��� ()�� ���δ�.
        if (node.Attributes != null){
            foreach (XmlAttribute attribute in node.Attributes){
                TreeXML("", attribute, newTreeNode.Nodes);
            }
        }
        //������Ʈ
        foreach (XmlNode childNode in node.ChildNodes){
            TreeXML("", childNode, newTreeNode.Nodes);
        }
    }
    private void btnSearch_Click(object sender, EventArgs e){
        openFileDialog2.Filter = "xml����(*.xml)|*.xml";
        string fname = "";
    if (this.openFileDialog2.ShowDialog() == DialogResult.OK){
        fname = this.openFileDialog2.FileName;
    }
        //XML Ʈ���� û��
        treeForXml.Nodes.Clear();
        MessageBox.Show(fname);
        //Dom���� XML���� �б�
        XmlDocument doc = new XmlDocument();
        try{
            doc.Load(fname);
        }
        catch (Exception err){
            MessageBox.Show(err.Message);
            return;
        }
        //Dom�� �ѱ�
        TreeXML("<KOSDAQ Fund>", doc, treeForXml.Nodes);
    }
    private void btnExpand_Click(object sender, EventArgs e){
        treeForXml.Nodes[0].ExpandAll();
    }
    private void btnFold_Click(object sender, EventArgs e){
        treeForXml.Nodes[0].Collapse();
    }
 }
}
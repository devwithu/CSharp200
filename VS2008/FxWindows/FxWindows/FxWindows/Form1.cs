using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace FxWindows
{
    public partial class Form1 : Form
    {
        //--------------------------------------------------------
        private char[] slash = { '\\' };
        private string[] pathsep;
        private TreeNode c;
        private string curPos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            treeView1.ImageList = imageList2;
            c = treeView1.Nodes.Add("C 드라이브");// 트리노드에 삽입 
            c.ImageIndex = 2;
            c.SelectedImageIndex = 2;
            foreach (string folder in Directory.GetDirectories("C:\\"))
            {
                TreeNode newfolder = c.Nodes.Add(folder.Remove(0, 3));
                newfolder.ImageIndex = 0;
                newfolder.SelectedImageIndex = 1;
            }

            listView1.LargeImageList = imageList1;
            listView1.SmallImageList = imageList1;

            radioButton1.Checked = true;
        }
        public void PopulateTreeView(string dir, TreeNode parent)
        {
            curPos = dir;
            string[] dir_arr;
            string fullpath = parent.FullPath.Remove(0, 6);
            string realfullpath = "C:\\" + fullpath;
            try
            {
                dir_arr = Directory.GetDirectories(realfullpath);
            }
            catch
            {
                MessageBox.Show("드라이버 없음");
                return;
            }
            if (parent == null)
                return;
            parent.Nodes.Clear();
            try
            {
                if (dir_arr.Length != 0)
                {
                    foreach (string folder in Directory.GetDirectories(realfullpath))
                    {
                        pathsep = folder.Split(slash);
                        int pathleng = pathsep.GetLength(0);
                        TreeNode T = treeView1.SelectedNode.Nodes.Add(pathsep[pathleng - 1]);
                        T.ImageIndex = 0;
                        T.SelectedImageIndex = 1;
                        treeView1.SelectedNode.Expand();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                parent.Nodes.Add("Access denied");
            }
        }
        private void LoadfilesDirectory(string curdir)
        {
            DirectoryInfo[] dirArr;
            try
            {
                DirectoryInfo dirobj = new DirectoryInfo(curdir);
                try
                {
                    dirArr = dirobj.GetDirectories();
                }
                catch
                {
                    return;
                }
                listView1.Items.Clear();
                listView1.Items.Add("Up One Level");
                curPos = curdir;
                FileInfo[] fileArr = dirobj.GetFiles();

                foreach (DirectoryInfo dir in dirArr)
                {
                    string[] temp = new string[] { dir.Name, "", dir.LastAccessTime.ToString() };
                    ListViewItem newDirItem = listView1.Items.Add(new ListViewItem(temp));
                    newDirItem.ImageIndex = 0;
                }
                foreach (FileInfo file in fileArr)
                {
                    string[] temp = new string[] { file.Name, file.Length.ToString(), file.LastAccessTime.ToString() };
                    ListViewItem newFileItem = listView1.Items.Add(new ListViewItem(temp));
                    newFileItem.ImageIndex = 1;
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("dd");
            }
        }
        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            string fullpath = treeView1.SelectedNode.FullPath.Remove(0, 6);
            string realfullpath = "C:\\" + fullpath;

            PopulateTreeView(realfullpath, e.Node);
            DirectoryInfo dirobj = new DirectoryInfo(realfullpath);
            LoadfilesDirectory(realfullpath);
        }

        private void resize()
        {
            treeView1.Height = this.Height - 88;
            listView1.Height = this.Height - 88;
            listView1.Width = this.Width - 176;
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            resize();
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            resize();
        }

        private void radioButton2_Click(object sender, System.EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void radioButton1_Click(object sender, System.EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void radioButton4_Click(object sender, System.EventArgs e)
        {
            listView1.View = View.List;
        }

        private void radioButton3_Click(object sender, System.EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.Items[0].Selected)
                {
                    DirectoryInfo dirobj = new DirectoryInfo(curPos);

                    if (dirobj.Parent != null)
                    {
                        LoadfilesDirectory(dirobj.Parent.FullName);

                        treeView1.SelectedNode = treeView1.SelectedNode.Parent;
                    }
                }
                else
                {
                    string chosen = listView1.SelectedItems[0].Text;

                    foreach (string s in Directory.GetFiles(curPos))
                    {
                        if (s == curPos + @"\" + chosen)
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = curPos + @"\" + chosen;
                            p.Start();
                        }

                    }
                    if (Directory.Exists(curPos + @"\" + chosen))
                    {
                        if (!(curPos.Substring(curPos.Length - 2, 2) == "\\"))
                            curPos += @"\";
                        LoadfilesDirectory(curPos + chosen);

                        TreeNodeCollection NodeList = treeView1.SelectedNode.Nodes;
                        foreach (TreeNode aNode in NodeList)
                        {
                            string fullpath = aNode.FullPath.Remove(0, 6);
                            string realfullpath = "C:\\" + fullpath;
                            if (realfullpath.ToUpper() == curPos.ToUpper())
                            {
                                treeView1.SelectedNode = aNode;
                            }
                        }
                        if (Directory.Exists(curPos + chosen))
                            curPos += chosen;

                        PopulateTreeView(curPos, treeView1.SelectedNode);
                        treeView1.SelectedNode.Expand();

                    }
                }
            }
        }
    }
}

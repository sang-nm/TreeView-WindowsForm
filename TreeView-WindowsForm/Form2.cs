using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Adds new node as a child node of the currently selected node.
            TreeNode newNode = new TreeNode("Text for new node");
            treeView1.Nodes.Add(newNode);
            TreeNode newNode1 = new TreeNode("Text for new node 1");
            treeView1.Nodes.Add(newNode1);
            TreeNode newNode2 = new TreeNode("Welcome to TreeView Control Tutorial");
            treeView1.Nodes.Add(newNode2);

            TreeNode node1 = new TreeNode("C#");
            TreeNode node2 = new TreeNode("VB.NET");
            TreeNode node3 = new TreeNode("C++");
            TreeNode[] array = new TreeNode[] { node1, node2, node3 };
            TreeNode programmingLanguage = new TreeNode("Programming Language", array);
            treeView1.Nodes.Add(programmingLanguage);
            treeView1.Nodes.Remove(newNode1);
            treeView1.Nodes.Add(new myTreeNode(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\TextFile.txt"));

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            myTreeNode myNode = (myTreeNode)e.Node;
            MessageBox.Show("Node selected is " + myNode.FilePath);
        }

        private void PrintRecursive(TreeNode treeNode)
        {
            // in ra các node.
            listBox1.Items.Add(treeNode.Text);
            MessageBox.Show(treeNode.Text);
            // Sử dụng đệ quy để in ra từng node. 
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }

        // Gọi thủ tục sử dụng TreeView
        private void CallRecursive(TreeView treeView)
        {
            // IN ra từng node sử dụng đệ quy. 
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintRecursive(treeView1.SelectedNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Text);
        }
    }
    class myTreeNode : TreeNode
    {
        public string FilePath;

        public myTreeNode(string fp)
        {
            FilePath = fp;
            this.Text = fp.Substring(fp.LastIndexOf("\\"));

        }
    }
}

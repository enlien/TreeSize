using System;
using System.ComponentModel;
using System.Windows.Forms;

using System.Threading.Tasks;

namespace TreeSize
{
    public partial class MainForm : Form
    {
        private const string DefaultStartupDirectory = @"C:\";

        private DirectoryItem SelectedDirectory { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            HideProcessing();
            SetDefaultSelectedDirectory();
        }

        private void HideProcessing()
        {
            lblProcessing.Visible = false;
            btnCalculate.Enabled = true;
        }

        private void SetDefaultSelectedDirectory()
        {
            SelectedDirectory = new DirectoryItem(DefaultStartupDirectory, DefaultStartupDirectory);
            txtSelectedDirectory.Text = SelectedDirectory.FullPathName;            
        }        

        private void btnDirectoryBrowser_Click(object sender, EventArgs e)
        {
            directoryPickerDialog.SelectedPath = SelectedDirectory.FullPathName;
            if (directoryPickerDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetSelectedDirectory(directoryPickerDialog.SelectedPath);
            }
        }

        private void SetSelectedDirectory(string fullPath)
        {
            SelectedDirectory = new DirectoryItem(fullPath, fullPath);
            txtSelectedDirectory.Text = SelectedDirectory.FullPathName;            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            RunCalculation();
        }

        private void RunCalculation()
        {
            ClearDirectoryTreeView();
            SelectedDirectory.Clear();
            ShowProcessing();
            ShowSubdirectories(SelectedDirectory);
            HideProcessing();
        }        

        private void ClearDirectoryTreeView()
        {
            directoryTreeView.Nodes.Clear();            
        }

        private void ShowProcessing()
        {
            lblProcessing.Visible = true;            
        }

        async private void ShowSubdirectories(DirectoryItem selectedDirectory)
        {
            TreeNode rootNode = CreateNewNode(selectedDirectory);
            directoryTreeView.Nodes.Add(rootNode);
            rootNode.Expand();
            var directories = selectedDirectory.GetDirectories();
            
            long totalSize = 0;
            long size = 0;
            foreach (var subDirectory in directories)
            {
                TreeNode node = CreateNewNode(subDirectory);
                rootNode.Nodes.Add(node);
                size = await subDirectory.GetSize();
                node.Text = node.Text + " " + FormatFileSize(size);
                totalSize = UpdateTotalSize(totalSize, size);
            }
            size = await selectedDirectory.GetSize();
            rootNode.Text = rootNode.Text + " " + FormatFileSize(size);            
        }

        private long UpdateTotalSize(long totalSize, long size)
        {
            totalSize += size;
            lblTotalSize.Text = "Total size: " + FormatFileSize(totalSize);
            return totalSize;
        }

        
        private TreeNode CreateNewNode(DirectoryItem subDirectory)
        {
            var node = new TreeNode(subDirectory.Name);
            node.Tag = subDirectory;
            return node;
        }

        private static string FormatFileSize(long size)
        {
            return (size / 1000000).ToString("0,0") + " MB";
        }

        private void directoryTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.GetType() != typeof(DirectoryItem))
            {
                return;
            }

            SelectedDirectory = (DirectoryItem) e.Node.Tag;
            txtSelectedDirectory.Text = SelectedDirectory.FullPathName;
            ClearDirectoryTreeView();            
            ShowProcessing();
            ShowSubdirectories(SelectedDirectory);
            HideProcessing();
        }                 
    }
}
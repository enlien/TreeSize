namespace TreeSize
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryPickerDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectedDirectory = new System.Windows.Forms.TextBox();
            this.btnDirectoryBrowser = new System.Windows.Forms.Button();
            this.directoryTreeView = new System.Windows.Forms.TreeView();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected directory:";
            // 
            // txtSelectedDirectory
            // 
            this.txtSelectedDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedDirectory.Location = new System.Drawing.Point(114, 10);
            this.txtSelectedDirectory.Name = "txtSelectedDirectory";
            this.txtSelectedDirectory.ReadOnly = true;
            this.txtSelectedDirectory.Size = new System.Drawing.Size(325, 20);
            this.txtSelectedDirectory.TabIndex = 1;
            // 
            // btnDirectoryBrowser
            // 
            this.btnDirectoryBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectoryBrowser.Location = new System.Drawing.Point(445, 8);
            this.btnDirectoryBrowser.Name = "btnDirectoryBrowser";
            this.btnDirectoryBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnDirectoryBrowser.TabIndex = 2;
            this.btnDirectoryBrowser.Text = "...";
            this.btnDirectoryBrowser.UseVisualStyleBackColor = true;
            this.btnDirectoryBrowser.Click += new System.EventHandler(this.btnDirectoryBrowser_Click);
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTreeView.Location = new System.Drawing.Point(16, 37);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.Size = new System.Drawing.Size(559, 342);
            this.directoryTreeView.TabIndex = 4;
            this.directoryTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.directoryTreeView_NodeMouseDoubleClick);
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.Location = new System.Drawing.Point(442, 382);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(85, 13);
            this.lblTotalSize.TabIndex = 6;
            this.lblTotalSize.Text = "Total Size: 0 MB";
            this.lblTotalSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(16, 381);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(128, 13);
            this.lblProcessing.TabIndex = 5;
            this.lblProcessing.Text = "Processing. Please wait...";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(500, 8);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 410);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.directoryTreeView);
            this.Controls.Add(this.btnDirectoryBrowser);
            this.Controls.Add(this.txtSelectedDirectory);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Tree Size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog directoryPickerDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSelectedDirectory;
        private System.Windows.Forms.Button btnDirectoryBrowser;
        private System.Windows.Forms.TreeView directoryTreeView;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Button btnCalculate;
    }
}


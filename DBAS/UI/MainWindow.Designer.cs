namespace DBAS
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("DBAS");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbKPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPRBnewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbC2InewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主邻小区C2I干扰分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询重叠覆盖干扰三元组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.CMSTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新CMSTree = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CMSTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开CMSTreeNode = new System.Windows.Forms.ToolStripMenuItem();
            this.删除CMSTreeNode = new System.Windows.Forms.ToolStripMenuItem();
            this.清空该表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.CMSTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.CMSTreeNode.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据管理ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据导入ToolStripMenuItem,
            this.数据导出ToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 数据导入ToolStripMenuItem
            // 
            this.数据导入ToolStripMenuItem.Name = "数据导入ToolStripMenuItem";
            this.数据导入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.数据导入ToolStripMenuItem.Text = "导入";
            this.数据导入ToolStripMenuItem.Click += new System.EventHandler(this.数据导入ToolStripMenuItem_Click);
            // 
            // 数据导出ToolStripMenuItem
            // 
            this.数据导出ToolStripMenuItem.Name = "数据导出ToolStripMenuItem";
            this.数据导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.数据导出ToolStripMenuItem.Text = "导出";
            this.数据导出ToolStripMenuItem.Click += new System.EventHandler(this.数据导出ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbCellToolStripMenuItem,
            this.tbKPIToolStripMenuItem,
            this.tbPRBnewToolStripMenuItem,
            this.tbC2InewToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // tbCellToolStripMenuItem
            // 
            this.tbCellToolStripMenuItem.Name = "tbCellToolStripMenuItem";
            this.tbCellToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tbCellToolStripMenuItem.Text = "tbCell";
            this.tbCellToolStripMenuItem.Click += new System.EventHandler(this.tbCellToolStripMenuItem_Click);
            // 
            // tbKPIToolStripMenuItem
            // 
            this.tbKPIToolStripMenuItem.Name = "tbKPIToolStripMenuItem";
            this.tbKPIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tbKPIToolStripMenuItem.Text = "tbKPI";
            this.tbKPIToolStripMenuItem.Click += new System.EventHandler(this.tbKPIToolStripMenuItem_Click);
            // 
            // tbPRBnewToolStripMenuItem
            // 
            this.tbPRBnewToolStripMenuItem.Name = "tbPRBnewToolStripMenuItem";
            this.tbPRBnewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tbPRBnewToolStripMenuItem.Text = "tbPRB";
            this.tbPRBnewToolStripMenuItem.Click += new System.EventHandler(this.tbPRBnewToolStripMenuItem_Click);
            // 
            // tbC2InewToolStripMenuItem
            // 
            this.tbC2InewToolStripMenuItem.Name = "tbC2InewToolStripMenuItem";
            this.tbC2InewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tbC2InewToolStripMenuItem.Text = "tbC2Inew";
            this.tbC2InewToolStripMenuItem.Click += new System.EventHandler(this.tbC2InewToolStripMenuItem_Click);
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主邻小区C2I干扰分析ToolStripMenuItem,
            this.查询重叠覆盖干扰三元组ToolStripMenuItem});
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.分析ToolStripMenuItem.Text = "分析";
            // 
            // 主邻小区C2I干扰分析ToolStripMenuItem
            // 
            this.主邻小区C2I干扰分析ToolStripMenuItem.Name = "主邻小区C2I干扰分析ToolStripMenuItem";
            this.主邻小区C2I干扰分析ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.主邻小区C2I干扰分析ToolStripMenuItem.Text = "主邻小区C2I干扰分析";
            this.主邻小区C2I干扰分析ToolStripMenuItem.Click += new System.EventHandler(this.主邻小区C2I干扰分析ToolStripMenuItem_Click);
            // 
            // 查询重叠覆盖干扰三元组ToolStripMenuItem
            // 
            this.查询重叠覆盖干扰三元组ToolStripMenuItem.Name = "查询重叠覆盖干扰三元组ToolStripMenuItem";
            this.查询重叠覆盖干扰三元组ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.查询重叠覆盖干扰三元组ToolStripMenuItem.Text = "查询重叠覆盖干扰三元组";
            this.查询重叠覆盖干扰三元组ToolStripMenuItem.Click += new System.EventHandler(this.查询重叠覆盖干扰三元组ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(782, 367);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.CMSTree;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "DBAS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(142, 367);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // CMSTree
            // 
            this.CMSTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新CMSTree});
            this.CMSTree.Name = "CMSTree";
            this.CMSTree.Size = new System.Drawing.Size(101, 26);
            // 
            // 刷新CMSTree
            // 
            this.刷新CMSTree.Name = "刷新CMSTree";
            this.刷新CMSTree.Size = new System.Drawing.Size(100, 22);
            this.刷新CMSTree.Text = "刷新";
            this.刷新CMSTree.Click += new System.EventHandler(this.刷新CMSTree_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(636, 367);
            this.splitContainer2.SplitterDistance = 98;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.CMSTreeNode;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(636, 98);
            this.textBox1.TabIndex = 0;
            // 
            // CMSTreeNode
            // 
            this.CMSTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开CMSTreeNode,
            this.删除CMSTreeNode,
            this.清空该表ToolStripMenuItem});
            this.CMSTreeNode.Name = "CMSTreeNode";
            this.CMSTreeNode.Size = new System.Drawing.Size(153, 70);
            // 
            // 打开CMSTreeNode
            // 
            this.打开CMSTreeNode.Name = "打开CMSTreeNode";
            this.打开CMSTreeNode.Size = new System.Drawing.Size(152, 22);
            this.打开CMSTreeNode.Text = "选择前1000行";
            this.打开CMSTreeNode.Click += new System.EventHandler(this.打开CMSTreeNode_Click);
            // 
            // 删除CMSTreeNode
            // 
            this.删除CMSTreeNode.Name = "删除CMSTreeNode";
            this.删除CMSTreeNode.Size = new System.Drawing.Size(152, 22);
            this.删除CMSTreeNode.Text = "删除该表";
            this.删除CMSTreeNode.Click += new System.EventHandler(this.删除CMSTreeNode_Click);
            // 
            // 清空该表ToolStripMenuItem
            // 
            this.清空该表ToolStripMenuItem.Name = "清空该表ToolStripMenuItem";
            this.清空该表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空该表ToolStripMenuItem.Text = "清空该表";
            this.清空该表ToolStripMenuItem.Click += new System.EventHandler(this.清空该表CMSTreeNode_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 265);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(622, 233);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripProgressBar1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton3.Text = "执行脚本 F5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 367);
            this.panel1.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 439);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TD-LTE网络干扰分析系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.CMSTree.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.CMSTreeNode.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip CMSTreeNode;
        private System.Windows.Forms.ToolStripMenuItem 打开CMSTreeNode;
        private System.Windows.Forms.ToolStripMenuItem 删除CMSTreeNode;
        private System.Windows.Forms.ToolStripMenuItem 清空该表ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem 主邻小区C2I干扰分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询重叠覆盖干扰三元组ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip CMSTree;
        private System.Windows.Forms.ToolStripMenuItem 刷新CMSTree;
        private System.Windows.Forms.ToolStripMenuItem tbCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbKPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbPRBnewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbC2InewToolStripMenuItem;
    }
}


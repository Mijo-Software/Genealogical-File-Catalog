namespace GenealogicalFileCatalog
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup1 = new ListViewGroup("GEDCOM files", HorizontalAlignment.Left);
            checkedListBoxDrives = new CheckedListBox();
            listViewResults = new BufferedListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderPath = new ColumnHeader();
            columnHeaderFileSize = new ColumnHeader();
            columnHeaderFileDateChanged = new ColumnHeader();
            checkedListBoxExtensions = new CheckedListBox();
            groupBoxDrives = new GroupBox();
            groupBoxExtensions = new GroupBox();
            statusStripMain = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            toolStripContainer = new ToolStripContainer();
            splitContainerMain = new SplitContainer();
            splitContainerDrivesAndExtensions = new SplitContainer();
            panelResults = new Panel();
            toolStrip = new ToolStrip();
            toolStripSplitButtonStart = new ToolStripSplitButton();
            toolStripMenuItemIncludeHiddenFolders = new ToolStripMenuItem();
            toolStripButtonStop = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonInfo = new ToolStripButton();
            groupBoxDrives.SuspendLayout();
            groupBoxExtensions.SuspendLayout();
            statusStripMain.SuspendLayout();
            toolStripContainer.BottomToolStripPanel.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerDrivesAndExtensions).BeginInit();
            splitContainerDrivesAndExtensions.Panel1.SuspendLayout();
            splitContainerDrivesAndExtensions.Panel2.SuspendLayout();
            splitContainerDrivesAndExtensions.SuspendLayout();
            panelResults.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // checkedListBoxDrives
            // 
            checkedListBoxDrives.CheckOnClick = true;
            checkedListBoxDrives.Dock = DockStyle.Fill;
            checkedListBoxDrives.FormattingEnabled = true;
            checkedListBoxDrives.HorizontalScrollbar = true;
            checkedListBoxDrives.Location = new Point(3, 19);
            checkedListBoxDrives.Name = "checkedListBoxDrives";
            checkedListBoxDrives.Size = new Size(144, 123);
            checkedListBoxDrives.Sorted = true;
            checkedListBoxDrives.TabIndex = 0;
            checkedListBoxDrives.ItemCheck += CheckedListBoxDrives_ItemCheck;
            // 
            // listViewResults
            // 
            listViewResults.Activation = ItemActivation.OneClick;
            listViewResults.AllowColumnReorder = true;
            listViewResults.CheckBoxes = true;
            listViewResults.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderPath, columnHeaderFileSize, columnHeaderFileDateChanged });
            listViewResults.Dock = DockStyle.Fill;
            listViewResults.FullRowSelect = true;
            listViewResults.GridLines = true;
            listViewGroup1.Footer = "a footer";
            listViewGroup1.Header = "GEDCOM files";
            listViewGroup1.Name = "listViewGroupGed";
            listViewGroup1.Subtitle = "a subtitle";
            listViewGroup1.TaskLink = "a tasklink";
            listViewResults.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            listViewResults.HotTracking = true;
            listViewResults.HoverSelection = true;
            listViewResults.Location = new Point(0, 0);
            listViewResults.MultiSelect = false;
            listViewResults.Name = "listViewResults";
            listViewResults.ShowItemToolTips = true;
            listViewResults.Size = new Size(625, 418);
            listViewResults.TabIndex = 5;
            listViewResults.UseCompatibleStateImageBehavior = false;
            listViewResults.View = View.Details;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "file name";
            columnHeaderFileName.Width = 170;
            // 
            // columnHeaderPath
            // 
            columnHeaderPath.Text = "path";
            columnHeaderPath.Width = 320;
            // 
            // columnHeaderFileSize
            // 
            columnHeaderFileSize.Text = "size (Bytes)";
            columnHeaderFileSize.TextAlign = HorizontalAlignment.Center;
            columnHeaderFileSize.Width = 100;
            // 
            // columnHeaderFileDateChanged
            // 
            columnHeaderFileDateChanged.Text = "change date";
            columnHeaderFileDateChanged.Width = 140;
            // 
            // checkedListBoxExtensions
            // 
            checkedListBoxExtensions.CheckOnClick = true;
            checkedListBoxExtensions.Dock = DockStyle.Fill;
            checkedListBoxExtensions.FormattingEnabled = true;
            checkedListBoxExtensions.HorizontalScrollbar = true;
            checkedListBoxExtensions.Location = new Point(3, 19);
            checkedListBoxExtensions.Name = "checkedListBoxExtensions";
            checkedListBoxExtensions.Size = new Size(144, 247);
            checkedListBoxExtensions.TabIndex = 0;
            checkedListBoxExtensions.ItemCheck += CheckedListBoxExtensions_ItemCheck;
            // 
            // groupBoxDrives
            // 
            groupBoxDrives.Controls.Add(checkedListBoxDrives);
            groupBoxDrives.Dock = DockStyle.Fill;
            groupBoxDrives.Location = new Point(0, 0);
            groupBoxDrives.Name = "groupBoxDrives";
            groupBoxDrives.Size = new Size(150, 145);
            groupBoxDrives.TabIndex = 0;
            groupBoxDrives.TabStop = false;
            groupBoxDrives.Text = "&drives";
            // 
            // groupBoxExtensions
            // 
            groupBoxExtensions.Controls.Add(checkedListBoxExtensions);
            groupBoxExtensions.Dock = DockStyle.Fill;
            groupBoxExtensions.Location = new Point(0, 0);
            groupBoxExtensions.Name = "groupBoxExtensions";
            groupBoxExtensions.Size = new Size(150, 269);
            groupBoxExtensions.TabIndex = 1;
            groupBoxExtensions.TabStop = false;
            groupBoxExtensions.Text = "&extensions";
            // 
            // statusStripMain
            // 
            statusStripMain.Dock = DockStyle.None;
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
            statusStripMain.Location = new Point(0, 0);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.ShowItemToolTips = true;
            statusStripMain.Size = new Size(779, 22);
            statusStripMain.TabIndex = 6;
            statusStripMain.TabStop = true;
            statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            toolStripStatusLabelInfo.Size = new Size(28, 17);
            toolStripStatusLabelInfo.Text = "info";
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            toolStripContainer.BottomToolStripPanel.Controls.Add(statusStripMain);
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.Controls.Add(splitContainerMain);
            toolStripContainer.ContentPanel.Size = new Size(779, 418);
            toolStripContainer.Dock = DockStyle.Fill;
            toolStripContainer.Location = new Point(0, 0);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new Size(779, 479);
            toolStripContainer.TabIndex = 7;
            toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerDrivesAndExtensions);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelResults);
            splitContainerMain.Size = new Size(779, 418);
            splitContainerMain.SplitterDistance = 150;
            splitContainerMain.TabIndex = 6;
            // 
            // splitContainerDrivesAndExtensions
            // 
            splitContainerDrivesAndExtensions.Dock = DockStyle.Fill;
            splitContainerDrivesAndExtensions.Location = new Point(0, 0);
            splitContainerDrivesAndExtensions.Name = "splitContainerDrivesAndExtensions";
            splitContainerDrivesAndExtensions.Orientation = Orientation.Horizontal;
            // 
            // splitContainerDrivesAndExtensions.Panel1
            // 
            splitContainerDrivesAndExtensions.Panel1.Controls.Add(groupBoxDrives);
            // 
            // splitContainerDrivesAndExtensions.Panel2
            // 
            splitContainerDrivesAndExtensions.Panel2.Controls.Add(groupBoxExtensions);
            splitContainerDrivesAndExtensions.Size = new Size(150, 418);
            splitContainerDrivesAndExtensions.SplitterDistance = 145;
            splitContainerDrivesAndExtensions.TabIndex = 0;
            // 
            // panelResults
            // 
            panelResults.Controls.Add(listViewResults);
            panelResults.Dock = DockStyle.Fill;
            panelResults.Location = new Point(0, 0);
            panelResults.Name = "panelResults";
            panelResults.Size = new Size(625, 418);
            panelResults.TabIndex = 6;
            // 
            // toolStrip
            // 
            toolStrip.AllowClickThrough = true;
            toolStrip.AllowItemReorder = true;
            toolStrip.Dock = DockStyle.None;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripSplitButtonStart, toolStripButtonStop, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonInfo });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(779, 39);
            toolStrip.Stretch = true;
            toolStrip.TabIndex = 0;
            toolStrip.TabStop = true;
            // 
            // toolStripSplitButtonStart
            // 
            toolStripSplitButtonStart.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemIncludeHiddenFolders });
            toolStripSplitButtonStart.Image = Properties.Resources.control_play_blue_32;
            toolStripSplitButtonStart.ImageScaling = ToolStripItemImageScaling.None;
            toolStripSplitButtonStart.ImageTransparentColor = Color.Magenta;
            toolStripSplitButtonStart.Name = "toolStripSplitButtonStart";
            toolStripSplitButtonStart.Size = new Size(79, 36);
            toolStripSplitButtonStart.Text = "&Start";
            toolStripSplitButtonStart.ButtonClick += ButtonSearch_Click;
            // 
            // toolStripMenuItemIncludeHiddenFolders
            // 
            toolStripMenuItemIncludeHiddenFolders.AutoToolTip = true;
            toolStripMenuItemIncludeHiddenFolders.CheckOnClick = true;
            toolStripMenuItemIncludeHiddenFolders.Name = "toolStripMenuItemIncludeHiddenFolders";
            toolStripMenuItemIncludeHiddenFolders.Size = new Size(192, 22);
            toolStripMenuItemIncludeHiddenFolders.Text = "Include &hidden folders";
            // 
            // toolStripButtonStop
            // 
            toolStripButtonStop.Image = Properties.Resources.control_stop_blue_32;
            toolStripButtonStop.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonStop.ImageTransparentColor = Color.Magenta;
            toolStripButtonStop.Name = "toolStripButtonStop";
            toolStripButtonStop.Size = new Size(67, 36);
            toolStripButtonStop.Text = "Sto&p";
            toolStripButtonStop.Click += ButtonStop_Click;
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Image = Properties.Resources.arrow_refresh_32;
            toolStripButtonRefresh.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(82, 36);
            toolStripButtonRefresh.Text = "&Refresh";
            toolStripButtonRefresh.Click += ButtonRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripButtonInfo
            // 
            toolStripButtonInfo.Image = Properties.Resources.information_32;
            toolStripButtonInfo.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonInfo.ImageTransparentColor = Color.Magenta;
            toolStripButtonInfo.Name = "toolStripButtonInfo";
            toolStripButtonInfo.Size = new Size(64, 36);
            toolStripButtonInfo.Text = "&Info";
            toolStripButtonInfo.Click += ToolStripButtonInfo_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 479);
            Controls.Add(toolStripContainer);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Genealogical File Catalog";
            groupBoxDrives.ResumeLayout(false);
            groupBoxExtensions.ResumeLayout(false);
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer.BottomToolStripPanel.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerDrivesAndExtensions.Panel1.ResumeLayout(false);
            splitContainerDrivesAndExtensions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerDrivesAndExtensions).EndInit();
            splitContainerDrivesAndExtensions.ResumeLayout(false);
            panelResults.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBoxDrives;
		private GenealogicalFileCatalog.BufferedListView listViewResults;
		private ColumnHeader columnHeaderFileName;
		private ColumnHeader columnHeaderPath;
		private ColumnHeader columnHeaderFileSize;
		private ColumnHeader columnHeaderFileDateChanged;
		private CheckedListBox checkedListBoxExtensions;
		private GroupBox groupBoxDrives;
		private GroupBox groupBoxExtensions;
		private StatusStrip statusStripMain;
		private ToolStripContainer toolStripContainer;
		private ToolStripStatusLabel toolStripStatusLabelInfo;
		private ToolStrip toolStrip;
		private ToolStripSplitButton toolStripSplitButtonStart;
		private ToolStripButton toolStripButtonRefresh;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerDrivesAndExtensions;
        private ToolStripMenuItem toolStripMenuItemIncludeHiddenFolders;
        private Panel panelResults;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonInfo;
        private ToolStripButton toolStripButtonStop;
    }
}

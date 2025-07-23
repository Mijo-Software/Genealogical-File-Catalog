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
            checkBoxIncludeHidden = new CheckBox();
            listViewResults = new BufferedListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderPath = new ColumnHeader();
            columnHeaderFileSize = new ColumnHeader();
            columnHeaderFileDateChanged = new ColumnHeader();
            checkedListBoxExtensions = new CheckedListBox();
            groupBoxDrives = new GroupBox();
            groupBoxExtensions = new GroupBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            toolStripContainer = new ToolStripContainer();
            toolStrip = new ToolStrip();
            toolStripSplitButtonStart = new ToolStripSplitButton();
            startToolStripMenuItemStart = new ToolStripMenuItem();
            toolStripMenuItemStartIncludeHiddenFolders = new ToolStripMenuItem();
            toolStripButtonStop = new ToolStripButton();
            groupBoxDrives.SuspendLayout();
            groupBoxExtensions.SuspendLayout();
            statusStrip.SuspendLayout();
            toolStripContainer.BottomToolStripPanel.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
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
            checkedListBoxDrives.Size = new Size(75, 71);
            checkedListBoxDrives.Sorted = true;
            checkedListBoxDrives.TabIndex = 0;
            // 
            // checkBoxIncludeHidden
            // 
            checkBoxIncludeHidden.AutoSize = true;
            checkBoxIncludeHidden.Location = new Point(90, 13);
            checkBoxIncludeHidden.Name = "checkBoxIncludeHidden";
            checkBoxIncludeHidden.Size = new Size(144, 19);
            checkBoxIncludeHidden.TabIndex = 4;
            checkBoxIncludeHidden.Text = "Include &hidden folders";
            checkBoxIncludeHidden.UseVisualStyleBackColor = true;
            // 
            // listViewResults
            // 
            listViewResults.Activation = ItemActivation.OneClick;
            listViewResults.AllowColumnReorder = true;
            listViewResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewResults.CheckBoxes = true;
            listViewResults.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderPath, columnHeaderFileSize, columnHeaderFileDateChanged });
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
            listViewResults.Location = new Point(90, 38);
            listViewResults.MultiSelect = false;
            listViewResults.Name = "listViewResults";
            listViewResults.ShowItemToolTips = true;
            listViewResults.Size = new Size(676, 370);
            listViewResults.TabIndex = 5;
            listViewResults.UseCompatibleStateImageBehavior = false;
            listViewResults.View = View.Details;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "file name";
            columnHeaderFileName.Width = 150;
            // 
            // columnHeaderPath
            // 
            columnHeaderPath.Text = "path";
            columnHeaderPath.Width = 300;
            // 
            // columnHeaderFileSize
            // 
            columnHeaderFileSize.Text = "size (Bytes)";
            columnHeaderFileSize.TextAlign = HorizontalAlignment.Center;
            columnHeaderFileSize.Width = 75;
            // 
            // columnHeaderFileDateChanged
            // 
            columnHeaderFileDateChanged.Text = "change date";
            columnHeaderFileDateChanged.Width = 120;
            // 
            // checkedListBoxExtensions
            // 
            checkedListBoxExtensions.CheckOnClick = true;
            checkedListBoxExtensions.Dock = DockStyle.Fill;
            checkedListBoxExtensions.FormattingEnabled = true;
            checkedListBoxExtensions.HorizontalScrollbar = true;
            checkedListBoxExtensions.Location = new Point(3, 19);
            checkedListBoxExtensions.Name = "checkedListBoxExtensions";
            checkedListBoxExtensions.Size = new Size(75, 112);
            checkedListBoxExtensions.TabIndex = 0;
            // 
            // groupBoxDrives
            // 
            groupBoxDrives.Controls.Add(checkedListBoxDrives);
            groupBoxDrives.Location = new Point(3, 3);
            groupBoxDrives.Name = "groupBoxDrives";
            groupBoxDrives.Size = new Size(81, 93);
            groupBoxDrives.TabIndex = 0;
            groupBoxDrives.TabStop = false;
            groupBoxDrives.Text = "&drives";
            // 
            // groupBoxExtensions
            // 
            groupBoxExtensions.Controls.Add(checkedListBoxExtensions);
            groupBoxExtensions.Location = new Point(3, 102);
            groupBoxExtensions.Name = "groupBoxExtensions";
            groupBoxExtensions.Size = new Size(81, 134);
            groupBoxExtensions.TabIndex = 1;
            groupBoxExtensions.TabStop = false;
            groupBoxExtensions.Text = "&extensions";
            // 
            // statusStrip
            // 
            statusStrip.Dock = DockStyle.None;
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
            statusStrip.Location = new Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.ShowItemToolTips = true;
            statusStrip.Size = new Size(779, 22);
            statusStrip.TabIndex = 6;
            statusStrip.TabStop = true;
            statusStrip.Text = "statusStrip";
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
            toolStripContainer.BottomToolStripPanel.Controls.Add(statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.Controls.Add(groupBoxDrives);
            toolStripContainer.ContentPanel.Controls.Add(groupBoxExtensions);
            toolStripContainer.ContentPanel.Controls.Add(checkBoxIncludeHidden);
            toolStripContainer.ContentPanel.Controls.Add(listViewResults);
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
            // toolStrip
            // 
            toolStrip.AllowClickThrough = true;
            toolStrip.AllowItemReorder = true;
            toolStrip.Dock = DockStyle.None;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripSplitButtonStart, toolStripButtonStop });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(779, 39);
            toolStrip.Stretch = true;
            toolStrip.TabIndex = 0;
            toolStrip.TabStop = true;
            // 
            // toolStripSplitButtonStart
            // 
            toolStripSplitButtonStart.DropDownItems.AddRange(new ToolStripItem[] { startToolStripMenuItemStart, toolStripMenuItemStartIncludeHiddenFolders });
            toolStripSplitButtonStart.Image = Properties.Resources.control_play_blue;
            toolStripSplitButtonStart.ImageScaling = ToolStripItemImageScaling.None;
            toolStripSplitButtonStart.ImageTransparentColor = Color.Magenta;
            toolStripSplitButtonStart.Name = "toolStripSplitButtonStart";
            toolStripSplitButtonStart.Size = new Size(79, 36);
            toolStripSplitButtonStart.Text = "&Start";
            toolStripSplitButtonStart.ButtonClick += ButtonSearch_Click;
            // 
            // startToolStripMenuItemStart
            // 
            startToolStripMenuItemStart.AutoToolTip = true;
            startToolStripMenuItemStart.Image = Properties.Resources.control_play_blue;
            startToolStripMenuItemStart.Name = "startToolStripMenuItemStart";
            startToolStripMenuItemStart.Size = new Size(227, 22);
            startToolStripMenuItemStart.Text = "&Start";
            startToolStripMenuItemStart.Click += ButtonSearch_Click;
            // 
            // toolStripMenuItemStartIncludeHiddenFolders
            // 
            toolStripMenuItemStartIncludeHiddenFolders.AutoToolTip = true;
            toolStripMenuItemStartIncludeHiddenFolders.Enabled = false;
            toolStripMenuItemStartIncludeHiddenFolders.Name = "toolStripMenuItemStartIncludeHiddenFolders";
            toolStripMenuItemStartIncludeHiddenFolders.Size = new Size(227, 22);
            toolStripMenuItemStartIncludeHiddenFolders.Text = "Start (include &hidden folders)";
            // 
            // toolStripButtonStop
            // 
            toolStripButtonStop.Image = Properties.Resources.control_stop_blue;
            toolStripButtonStop.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonStop.ImageTransparentColor = Color.Magenta;
            toolStripButtonStop.Name = "toolStripButtonStop";
            toolStripButtonStop.Size = new Size(67, 36);
            toolStripButtonStop.Text = "Sto&p";
            toolStripButtonStop.Click += ButtonStop_Click;
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
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer.BottomToolStripPanel.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.ContentPanel.PerformLayout();
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBoxDrives;
		private CheckBox checkBoxIncludeHidden;
		private GenealogicalFileCatalog.BufferedListView listViewResults;
		private ColumnHeader columnHeaderFileName;
		private ColumnHeader columnHeaderPath;
		private ColumnHeader columnHeaderFileSize;
		private ColumnHeader columnHeaderFileDateChanged;
		private CheckedListBox checkedListBoxExtensions;
		private GroupBox groupBoxDrives;
		private GroupBox groupBoxExtensions;
		private StatusStrip statusStrip;
		private ToolStripContainer toolStripContainer;
		private ToolStripStatusLabel toolStripStatusLabelInfo;
		private ToolStrip toolStrip;
		private ToolStripSplitButton toolStripSplitButtonStart;
		private ToolStripMenuItem startToolStripMenuItemStart;
		private ToolStripMenuItem toolStripMenuItemStartIncludeHiddenFolders;
		private ToolStripButton toolStripButtonStop;
	}
}

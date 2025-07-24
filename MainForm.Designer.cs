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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStripContainer = new ToolStripContainer();
            statusStripMain = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            splitContainerMain = new SplitContainer();
            splitContainerDrivesAndExtensions = new SplitContainer();
            groupBoxDrives = new GroupBox();
            checkedListBoxDrives = new CheckedListBox();
            groupBoxExtensions = new GroupBox();
            checkedListBoxExtensions = new CheckedListBox();
            panelResults = new Panel();
            splitContainerResultsAndRightSide = new SplitContainer();
            groupBoxResults = new GroupBox();
            listViewResults = new BufferedListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderPath = new ColumnHeader();
            columnHeaderFileSize = new ColumnHeader();
            columnHeaderFileDateChanged = new ColumnHeader();
            splitContainerStatsAndTasks = new SplitContainer();
            groupBoxStatistics = new GroupBox();
            labelTimeElapsed = new Label();
            labelFilesFound = new Label();
            groupBoxTasks = new GroupBox();
            toolStrip = new ToolStrip();
            toolStripButtonStart = new ToolStripButton();
            toolStripButtonPause = new ToolStripButton();
            toolStripButtonStop = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonSaveToCsv = new ToolStripButton();
            toolStripButtonShowProperties = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripDropDownButtonSettings = new ToolStripDropDownButton();
            toolStripMenuItemIncludeHiddenFiles = new ToolStripMenuItem();
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch = new ToolStripMenuItem();
            toolStripMenuItemAutoResizeColumns = new ToolStripMenuItem();
            toolStripMenuItemDisplayTheSearchedDirectory = new ToolStripMenuItem();
            toolStripMenuItemDisplaySearchComplete = new ToolStripMenuItem();
            toolStripMenuItemAskToCloseDuringSearch = new ToolStripMenuItem();
            toolStripButtonInfo = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonExit = new ToolStripButton();
            toolStripContainer.BottomToolStripPanel.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerDrivesAndExtensions).BeginInit();
            splitContainerDrivesAndExtensions.Panel1.SuspendLayout();
            splitContainerDrivesAndExtensions.Panel2.SuspendLayout();
            splitContainerDrivesAndExtensions.SuspendLayout();
            groupBoxDrives.SuspendLayout();
            groupBoxExtensions.SuspendLayout();
            panelResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerResultsAndRightSide).BeginInit();
            splitContainerResultsAndRightSide.Panel1.SuspendLayout();
            splitContainerResultsAndRightSide.Panel2.SuspendLayout();
            splitContainerResultsAndRightSide.SuspendLayout();
            groupBoxResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerStatsAndTasks).BeginInit();
            splitContainerStatsAndTasks.Panel1.SuspendLayout();
            splitContainerStatsAndTasks.Panel2.SuspendLayout();
            splitContainerStatsAndTasks.SuspendLayout();
            groupBoxStatistics.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
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
            resources.ApplyResources(toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            resources.ApplyResources(toolStripContainer, "toolStripContainer");
            toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // statusStripMain
            // 
            resources.ApplyResources(statusStripMain, "statusStripMain");
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
            statusStripMain.Name = "statusStripMain";
            statusStripMain.ShowItemToolTips = true;
            statusStripMain.TabStop = true;
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            resources.ApplyResources(toolStripStatusLabelInfo, "toolStripStatusLabelInfo");
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(splitContainerMain, "splitContainerMain");
            splitContainerMain.FixedPanel = FixedPanel.Panel1;
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerDrivesAndExtensions);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelResults);
            // 
            // splitContainerDrivesAndExtensions
            // 
            resources.ApplyResources(splitContainerDrivesAndExtensions, "splitContainerDrivesAndExtensions");
            splitContainerDrivesAndExtensions.Name = "splitContainerDrivesAndExtensions";
            // 
            // splitContainerDrivesAndExtensions.Panel1
            // 
            splitContainerDrivesAndExtensions.Panel1.Controls.Add(groupBoxDrives);
            // 
            // splitContainerDrivesAndExtensions.Panel2
            // 
            splitContainerDrivesAndExtensions.Panel2.Controls.Add(groupBoxExtensions);
            // 
            // groupBoxDrives
            // 
            groupBoxDrives.Controls.Add(checkedListBoxDrives);
            resources.ApplyResources(groupBoxDrives, "groupBoxDrives");
            groupBoxDrives.Name = "groupBoxDrives";
            groupBoxDrives.TabStop = false;
            // 
            // checkedListBoxDrives
            // 
            checkedListBoxDrives.CheckOnClick = true;
            resources.ApplyResources(checkedListBoxDrives, "checkedListBoxDrives");
            checkedListBoxDrives.FormattingEnabled = true;
            checkedListBoxDrives.Name = "checkedListBoxDrives";
            checkedListBoxDrives.Sorted = true;
            checkedListBoxDrives.ItemCheck += CheckedListBoxDrives_ItemCheck;
            // 
            // groupBoxExtensions
            // 
            groupBoxExtensions.Controls.Add(checkedListBoxExtensions);
            resources.ApplyResources(groupBoxExtensions, "groupBoxExtensions");
            groupBoxExtensions.Name = "groupBoxExtensions";
            groupBoxExtensions.TabStop = false;
            // 
            // checkedListBoxExtensions
            // 
            checkedListBoxExtensions.CheckOnClick = true;
            resources.ApplyResources(checkedListBoxExtensions, "checkedListBoxExtensions");
            checkedListBoxExtensions.FormattingEnabled = true;
            checkedListBoxExtensions.Name = "checkedListBoxExtensions";
            checkedListBoxExtensions.ItemCheck += CheckedListBoxExtensions_ItemCheck;
            // 
            // panelResults
            // 
            panelResults.Controls.Add(splitContainerResultsAndRightSide);
            resources.ApplyResources(panelResults, "panelResults");
            panelResults.Name = "panelResults";
            // 
            // splitContainerResultsAndRightSide
            // 
            resources.ApplyResources(splitContainerResultsAndRightSide, "splitContainerResultsAndRightSide");
            splitContainerResultsAndRightSide.FixedPanel = FixedPanel.Panel2;
            splitContainerResultsAndRightSide.Name = "splitContainerResultsAndRightSide";
            // 
            // splitContainerResultsAndRightSide.Panel1
            // 
            splitContainerResultsAndRightSide.Panel1.Controls.Add(groupBoxResults);
            // 
            // splitContainerResultsAndRightSide.Panel2
            // 
            splitContainerResultsAndRightSide.Panel2.Controls.Add(splitContainerStatsAndTasks);
            // 
            // groupBoxResults
            // 
            groupBoxResults.Controls.Add(listViewResults);
            resources.ApplyResources(groupBoxResults, "groupBoxResults");
            groupBoxResults.Name = "groupBoxResults";
            groupBoxResults.TabStop = false;
            // 
            // listViewResults
            // 
            listViewResults.Activation = ItemActivation.OneClick;
            listViewResults.AllowColumnReorder = true;
            listViewResults.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderPath, columnHeaderFileSize, columnHeaderFileDateChanged });
            resources.ApplyResources(listViewResults, "listViewResults");
            listViewResults.FullRowSelect = true;
            listViewResults.GridLines = true;
            listViewResults.Groups.AddRange(new ListViewGroup[] { (ListViewGroup)resources.GetObject("listViewResults.Groups") });
            listViewResults.HotTracking = true;
            listViewResults.HoverSelection = true;
            listViewResults.MultiSelect = false;
            listViewResults.Name = "listViewResults";
            listViewResults.ShowItemToolTips = true;
            listViewResults.UseCompatibleStateImageBehavior = false;
            listViewResults.View = View.Details;
            listViewResults.ColumnClick += ListViewResults_ColumnClick;
            // 
            // columnHeaderFileName
            // 
            resources.ApplyResources(columnHeaderFileName, "columnHeaderFileName");
            // 
            // columnHeaderPath
            // 
            resources.ApplyResources(columnHeaderPath, "columnHeaderPath");
            // 
            // columnHeaderFileSize
            // 
            resources.ApplyResources(columnHeaderFileSize, "columnHeaderFileSize");
            // 
            // columnHeaderFileDateChanged
            // 
            resources.ApplyResources(columnHeaderFileDateChanged, "columnHeaderFileDateChanged");
            // 
            // splitContainerStatsAndTasks
            // 
            resources.ApplyResources(splitContainerStatsAndTasks, "splitContainerStatsAndTasks");
            splitContainerStatsAndTasks.FixedPanel = FixedPanel.Panel1;
            splitContainerStatsAndTasks.Name = "splitContainerStatsAndTasks";
            // 
            // splitContainerStatsAndTasks.Panel1
            // 
            splitContainerStatsAndTasks.Panel1.Controls.Add(groupBoxStatistics);
            // 
            // splitContainerStatsAndTasks.Panel2
            // 
            splitContainerStatsAndTasks.Panel2.Controls.Add(groupBoxTasks);
            // 
            // groupBoxStatistics
            // 
            groupBoxStatistics.Controls.Add(labelTimeElapsed);
            groupBoxStatistics.Controls.Add(labelFilesFound);
            resources.ApplyResources(groupBoxStatistics, "groupBoxStatistics");
            groupBoxStatistics.Name = "groupBoxStatistics";
            groupBoxStatistics.TabStop = false;
            // 
            // labelTimeElapsed
            // 
            labelTimeElapsed.AutoEllipsis = true;
            resources.ApplyResources(labelTimeElapsed, "labelTimeElapsed");
            labelTimeElapsed.Name = "labelTimeElapsed";
            // 
            // labelFilesFound
            // 
            labelFilesFound.AutoEllipsis = true;
            resources.ApplyResources(labelFilesFound, "labelFilesFound");
            labelFilesFound.Name = "labelFilesFound";
            // 
            // groupBoxTasks
            // 
            resources.ApplyResources(groupBoxTasks, "groupBoxTasks");
            groupBoxTasks.Name = "groupBoxTasks";
            groupBoxTasks.TabStop = false;
            // 
            // toolStrip
            // 
            toolStrip.AllowClickThrough = true;
            toolStrip.AllowItemReorder = true;
            resources.ApplyResources(toolStrip, "toolStrip");
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonStart, toolStripButtonPause, toolStripButtonStop, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonSaveToCsv, toolStripButtonShowProperties, toolStripSeparator3, toolStripDropDownButtonSettings, toolStripButtonInfo, toolStripSeparator2, toolStripButtonExit });
            toolStrip.Name = "toolStrip";
            toolStrip.Stretch = true;
            toolStrip.TabStop = true;
            // 
            // toolStripButtonStart
            // 
            toolStripButtonStart.Image = Properties.Resources.control_play_blue_32;
            resources.ApplyResources(toolStripButtonStart, "toolStripButtonStart");
            toolStripButtonStart.Name = "toolStripButtonStart";
            toolStripButtonStart.Click += ButtonSearch_Click;
            // 
            // toolStripButtonPause
            // 
            toolStripButtonPause.Image = Properties.Resources.control_pause_blue_32;
            resources.ApplyResources(toolStripButtonPause, "toolStripButtonPause");
            toolStripButtonPause.Name = "toolStripButtonPause";
            toolStripButtonPause.Click += ToolStripButtonPause_Click;
            // 
            // toolStripButtonStop
            // 
            toolStripButtonStop.Image = Properties.Resources.control_stop_blue_32;
            resources.ApplyResources(toolStripButtonStop, "toolStripButtonStop");
            toolStripButtonStop.Name = "toolStripButtonStop";
            toolStripButtonStop.Click += ButtonStop_Click;
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Image = Properties.Resources.arrow_refresh_32;
            resources.ApplyResources(toolStripButtonRefresh, "toolStripButtonRefresh");
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Click += ButtonRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonSaveToCsv
            // 
            toolStripButtonSaveToCsv.Image = Properties.Resources.diskette_32;
            resources.ApplyResources(toolStripButtonSaveToCsv, "toolStripButtonSaveToCsv");
            toolStripButtonSaveToCsv.Name = "toolStripButtonSaveToCsv";
            toolStripButtonSaveToCsv.Click += ToolStripButtonSaveToCsv_Click;
            // 
            // toolStripButtonShowProperties
            // 
            toolStripButtonShowProperties.Image = Properties.Resources.preferences_32;
            resources.ApplyResources(toolStripButtonShowProperties, "toolStripButtonShowProperties");
            toolStripButtonShowProperties.Name = "toolStripButtonShowProperties";
            toolStripButtonShowProperties.Click += ToolStripButtonShowProperties_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripDropDownButtonSettings
            // 
            toolStripDropDownButtonSettings.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemIncludeHiddenFiles, toolStripMenuItemSuppressWarningsAndErrorsOnSearch, toolStripMenuItemAutoResizeColumns, toolStripMenuItemDisplayTheSearchedDirectory, toolStripMenuItemDisplaySearchComplete, toolStripMenuItemAskToCloseDuringSearch });
            toolStripDropDownButtonSettings.Image = Properties.Resources.wrench_orange_32;
            resources.ApplyResources(toolStripDropDownButtonSettings, "toolStripDropDownButtonSettings");
            toolStripDropDownButtonSettings.Name = "toolStripDropDownButtonSettings";
            // 
            // toolStripMenuItemIncludeHiddenFiles
            // 
            toolStripMenuItemIncludeHiddenFiles.AutoToolTip = true;
            toolStripMenuItemIncludeHiddenFiles.Checked = true;
            toolStripMenuItemIncludeHiddenFiles.CheckOnClick = true;
            toolStripMenuItemIncludeHiddenFiles.CheckState = CheckState.Checked;
            toolStripMenuItemIncludeHiddenFiles.Name = "toolStripMenuItemIncludeHiddenFiles";
            resources.ApplyResources(toolStripMenuItemIncludeHiddenFiles, "toolStripMenuItemIncludeHiddenFiles");
            // 
            // toolStripMenuItemSuppressWarningsAndErrorsOnSearch
            // 
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch.AutoToolTip = true;
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked = true;
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch.CheckOnClick = true;
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch.CheckState = CheckState.Checked;
            toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Name = "toolStripMenuItemSuppressWarningsAndErrorsOnSearch";
            resources.ApplyResources(toolStripMenuItemSuppressWarningsAndErrorsOnSearch, "toolStripMenuItemSuppressWarningsAndErrorsOnSearch");
            // 
            // toolStripMenuItemAutoResizeColumns
            // 
            toolStripMenuItemAutoResizeColumns.AutoToolTip = true;
            toolStripMenuItemAutoResizeColumns.Checked = true;
            toolStripMenuItemAutoResizeColumns.CheckOnClick = true;
            toolStripMenuItemAutoResizeColumns.CheckState = CheckState.Checked;
            toolStripMenuItemAutoResizeColumns.Name = "toolStripMenuItemAutoResizeColumns";
            resources.ApplyResources(toolStripMenuItemAutoResizeColumns, "toolStripMenuItemAutoResizeColumns");
            // 
            // toolStripMenuItemDisplayTheSearchedDirectory
            // 
            toolStripMenuItemDisplayTheSearchedDirectory.AutoToolTip = true;
            toolStripMenuItemDisplayTheSearchedDirectory.Checked = true;
            toolStripMenuItemDisplayTheSearchedDirectory.CheckOnClick = true;
            toolStripMenuItemDisplayTheSearchedDirectory.CheckState = CheckState.Checked;
            toolStripMenuItemDisplayTheSearchedDirectory.Name = "toolStripMenuItemDisplayTheSearchedDirectory";
            resources.ApplyResources(toolStripMenuItemDisplayTheSearchedDirectory, "toolStripMenuItemDisplayTheSearchedDirectory");
            // 
            // toolStripMenuItemDisplaySearchComplete
            // 
            toolStripMenuItemDisplaySearchComplete.AutoToolTip = true;
            toolStripMenuItemDisplaySearchComplete.Checked = true;
            toolStripMenuItemDisplaySearchComplete.CheckOnClick = true;
            toolStripMenuItemDisplaySearchComplete.CheckState = CheckState.Checked;
            toolStripMenuItemDisplaySearchComplete.Name = "toolStripMenuItemDisplaySearchComplete";
            resources.ApplyResources(toolStripMenuItemDisplaySearchComplete, "toolStripMenuItemDisplaySearchComplete");
            // 
            // toolStripMenuItemAskToCloseDuringSearch
            // 
            toolStripMenuItemAskToCloseDuringSearch.AutoToolTip = true;
            toolStripMenuItemAskToCloseDuringSearch.Checked = true;
            toolStripMenuItemAskToCloseDuringSearch.CheckOnClick = true;
            toolStripMenuItemAskToCloseDuringSearch.CheckState = CheckState.Checked;
            toolStripMenuItemAskToCloseDuringSearch.Name = "toolStripMenuItemAskToCloseDuringSearch";
            resources.ApplyResources(toolStripMenuItemAskToCloseDuringSearch, "toolStripMenuItemAskToCloseDuringSearch");
            // 
            // toolStripButtonInfo
            // 
            toolStripButtonInfo.Image = Properties.Resources.information_32;
            resources.ApplyResources(toolStripButtonInfo, "toolStripButtonInfo");
            toolStripButtonInfo.Name = "toolStripButtonInfo";
            toolStripButtonInfo.Click += ToolStripButtonInfo_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonExit
            // 
            toolStripButtonExit.Image = Properties.Resources.door_32;
            resources.ApplyResources(toolStripButtonExit, "toolStripButtonExit");
            toolStripButtonExit.Name = "toolStripButtonExit";
            toolStripButtonExit.Click += ToolStripButtonExit_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStripContainer);
            Name = "MainForm";
            toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer.BottomToolStripPanel.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerDrivesAndExtensions.Panel1.ResumeLayout(false);
            splitContainerDrivesAndExtensions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerDrivesAndExtensions).EndInit();
            splitContainerDrivesAndExtensions.ResumeLayout(false);
            groupBoxDrives.ResumeLayout(false);
            groupBoxExtensions.ResumeLayout(false);
            panelResults.ResumeLayout(false);
            splitContainerResultsAndRightSide.Panel1.ResumeLayout(false);
            splitContainerResultsAndRightSide.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerResultsAndRightSide).EndInit();
            splitContainerResultsAndRightSide.ResumeLayout(false);
            groupBoxResults.ResumeLayout(false);
            splitContainerStatsAndTasks.Panel1.ResumeLayout(false);
            splitContainerStatsAndTasks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerStatsAndTasks).EndInit();
            splitContainerStatsAndTasks.ResumeLayout(false);
            groupBoxStatistics.ResumeLayout(false);
            groupBoxStatistics.PerformLayout();
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
		private ToolStripButton toolStripButtonRefresh;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerDrivesAndExtensions;
        private Panel panelResults;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonInfo;
        private ToolStripButton toolStripButtonStop;
		private ToolStripDropDownButton toolStripDropDownButtonSettings;
		private ToolStripMenuItem toolStripMenuItemSuppressWarningsAndErrorsOnSearch;
		private ToolStripMenuItem toolStripMenuItemAutoResizeColumns;
		private GroupBox groupBoxResults;
		private SplitContainer splitContainerResultsAndRightSide;
		private SplitContainer splitContainerStatsAndTasks;
		private GroupBox groupBoxStatistics;
		private GroupBox groupBoxTasks;
		private Label labelFilesFound;
		private ToolStripMenuItem toolStripMenuItemDisplayTheSearchedDirectory;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton toolStripButtonExit;
        private Label labelTimeElapsed;
        private ToolStripMenuItem toolStripMenuItemDisplaySearchComplete;
        private ToolStripButton toolStripButtonPause;
        private ToolStripMenuItem toolStripMenuItemAskToCloseDuringSearch;
        private ToolStripMenuItem toolStripMenuItemIncludeHiddenFiles;
        private ToolStripButton toolStripButtonStart;
        private ToolStripButton toolStripButtonSaveToCsv;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButtonShowProperties;
    }
}

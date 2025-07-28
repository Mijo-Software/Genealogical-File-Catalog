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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			toolStripContainer = new ToolStripContainer();
			statusStripMain = new StatusStrip();
			toolStripStatusLabelInfo = new ToolStripStatusLabel();
			splitContainerMain = new SplitContainer();
			splitContainerDrivesAndExtensions = new SplitContainer();
			groupBoxDrives = new GroupBox();
			checkedListBoxDrives = new CheckedListBox();
			contextMenuStripDrives = new ContextMenuStrip(components);
			toolStripMenuItemDrivesRefreshList = new ToolStripMenuItem();
			toolStripMenuItemDrivesMarkAllItems = new ToolStripMenuItem();
			groupBoxExtensions = new GroupBox();
			checkedListBoxExtensions = new CheckedListBox();
			contextMenuStripExtensions = new ContextMenuStrip(components);
			toolStripMenuItemExtensionsRefreshList = new ToolStripMenuItem();
			toolStripMenuItemExtensionsMarkAllItems = new ToolStripMenuItem();
			panelResults = new Panel();
			splitContainerResultsAndRightSide = new SplitContainer();
			groupBoxResults = new GroupBox();
			listViewResults = new BufferedListView();
			columnHeaderFileName = new ColumnHeader();
			columnHeaderPath = new ColumnHeader();
			columnHeaderFileSize = new ColumnHeader();
			columnHeaderFileDateChanged = new ColumnHeader();
			contextMenuStripResults = new ContextMenuStrip(components);
			toolStripMenuItemOpenFile = new ToolStripMenuItem();
			toolStripMenuItemOpenFolder = new ToolStripMenuItem();
			toolStripMenuItemShowProperties = new ToolStripMenuItem();
			toolStripMenuItemCopyFile = new ToolStripMenuItem();
			toolStripMenuItemMoveFile = new ToolStripMenuItem();
			toolStripMenuItemDeleteFile = new ToolStripMenuItem();
			toolStripMenuItemBackupFile = new ToolStripMenuItem();
			splitContainerStatsAndActions = new SplitContainer();
			groupBoxActions = new GroupBox();
			buttonBackupFile = new Button();
			buttonDeleteFile = new Button();
			buttonMoveFile = new Button();
			buttonCopyFile = new Button();
			buttonOpenFile = new Button();
			buttonOpenFolder = new Button();
			buttonShowProperties = new Button();
			groupBoxStatistics = new GroupBox();
			listViewStatistics = new BufferedListView();
			columnHeaderDesc = new ColumnHeader();
			columnHeaderValue = new ColumnHeader();
			contextMenuStripStatistics = new ContextMenuStrip(components);
			toolStripMenuItemStatisticsSaveAsCsv = new ToolStripMenuItem();
			toolStrip = new ToolStrip();
			toolStripButtonStart = new ToolStripButton();
			toolStripButtonPause = new ToolStripButton();
			toolStripButtonStop = new ToolStripButton();
			toolStripButtonRefresh = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripButtonSaveToCsv = new ToolStripButton();
			toolStripSeparator3 = new ToolStripSeparator();
			toolStripDropDownButtonSettings = new ToolStripDropDownButton();
			toolStripMenuItemIncludeHiddenFiles = new ToolStripMenuItem();
			toolStripMenuItemSuppressWarningsAndErrorsOnSearch = new ToolStripMenuItem();
			toolStripMenuItemAutoResizeColumns = new ToolStripMenuItem();
			toolStripMenuItemDisplayTheSearchedDirectory = new ToolStripMenuItem();
			toolStripMenuItemDisplaySearchComplete = new ToolStripMenuItem();
			toolStripMenuItemAskToCloseDuringSearch = new ToolStripMenuItem();
			toolStripMenuItemEnableStatistics = new ToolStripMenuItem();
			toolStripSeparator4 = new ToolStripSeparator();
			toolStripMenuItemIconThemes = new ToolStripMenuItem();
			toolStripMenuItemIconThemeFatcow = new ToolStripMenuItem();
			toolStripMenuItemIconThemeXCollection = new ToolStripMenuItem();
			toolStripMenuItemIconThemeOCollection = new ToolStripMenuItem();
			toolStripMenuItemIconThemeICollection = new ToolStripMenuItem();
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
			contextMenuStripDrives.SuspendLayout();
			groupBoxExtensions.SuspendLayout();
			contextMenuStripExtensions.SuspendLayout();
			panelResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainerResultsAndRightSide).BeginInit();
			splitContainerResultsAndRightSide.Panel1.SuspendLayout();
			splitContainerResultsAndRightSide.Panel2.SuspendLayout();
			splitContainerResultsAndRightSide.SuspendLayout();
			groupBoxResults.SuspendLayout();
			contextMenuStripResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainerStatsAndActions).BeginInit();
			splitContainerStatsAndActions.Panel1.SuspendLayout();
			splitContainerStatsAndActions.Panel2.SuspendLayout();
			splitContainerStatsAndActions.SuspendLayout();
			groupBoxActions.SuspendLayout();
			groupBoxStatistics.SuspendLayout();
			contextMenuStripStatistics.SuspendLayout();
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
			statusStripMain.AllowClickThrough = true;
			statusStripMain.AllowItemReorder = true;
			resources.ApplyResources(statusStripMain, "statusStripMain");
			statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
			statusStripMain.Name = "statusStripMain";
			statusStripMain.ShowItemToolTips = true;
			statusStripMain.TabStop = true;
			// 
			// toolStripStatusLabelInfo
			// 
			toolStripStatusLabelInfo.AutoToolTip = true;
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
			checkedListBoxDrives.ContextMenuStrip = contextMenuStripDrives;
			resources.ApplyResources(checkedListBoxDrives, "checkedListBoxDrives");
			checkedListBoxDrives.FormattingEnabled = true;
			checkedListBoxDrives.Name = "checkedListBoxDrives";
			checkedListBoxDrives.Sorted = true;
			checkedListBoxDrives.ItemCheck += CheckedListBoxDrives_ItemCheck;
			// 
			// contextMenuStripDrives
			// 
			contextMenuStripDrives.AllowClickThrough = true;
			contextMenuStripDrives.Items.AddRange(new ToolStripItem[] { toolStripMenuItemDrivesRefreshList, toolStripMenuItemDrivesMarkAllItems });
			contextMenuStripDrives.Name = "contextMenuStripDrives";
			resources.ApplyResources(contextMenuStripDrives, "contextMenuStripDrives");
			contextMenuStripDrives.TabStop = true;
			// 
			// toolStripMenuItemDrivesRefreshList
			// 
			toolStripMenuItemDrivesRefreshList.AutoToolTip = true;
			toolStripMenuItemDrivesRefreshList.Image = Properties.Resources.fatcow_arrow_refresh_16;
			toolStripMenuItemDrivesRefreshList.Name = "toolStripMenuItemDrivesRefreshList";
			resources.ApplyResources(toolStripMenuItemDrivesRefreshList, "toolStripMenuItemDrivesRefreshList");
			toolStripMenuItemDrivesRefreshList.Click += ToolStripMenuItemDrivesRefresh_Click;
			// 
			// toolStripMenuItemDrivesMarkAllItems
			// 
			toolStripMenuItemDrivesMarkAllItems.AutoToolTip = true;
			toolStripMenuItemDrivesMarkAllItems.Image = Properties.Resources.fatcow_check_box_16;
			toolStripMenuItemDrivesMarkAllItems.Name = "toolStripMenuItemDrivesMarkAllItems";
			resources.ApplyResources(toolStripMenuItemDrivesMarkAllItems, "toolStripMenuItemDrivesMarkAllItems");
			toolStripMenuItemDrivesMarkAllItems.Click += ToolStripMenuItemDrivesMarkAll_Click;
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
			checkedListBoxExtensions.ContextMenuStrip = contextMenuStripExtensions;
			resources.ApplyResources(checkedListBoxExtensions, "checkedListBoxExtensions");
			checkedListBoxExtensions.FormattingEnabled = true;
			checkedListBoxExtensions.Name = "checkedListBoxExtensions";
			checkedListBoxExtensions.ItemCheck += CheckedListBoxExtensions_ItemCheck;
			// 
			// contextMenuStripExtensions
			// 
			contextMenuStripExtensions.AllowClickThrough = true;
			contextMenuStripExtensions.Items.AddRange(new ToolStripItem[] { toolStripMenuItemExtensionsRefreshList, toolStripMenuItemExtensionsMarkAllItems });
			contextMenuStripExtensions.Name = "contextMenuStripExtensions";
			resources.ApplyResources(contextMenuStripExtensions, "contextMenuStripExtensions");
			contextMenuStripExtensions.TabStop = true;
			// 
			// toolStripMenuItemExtensionsRefreshList
			// 
			toolStripMenuItemExtensionsRefreshList.AutoToolTip = true;
			toolStripMenuItemExtensionsRefreshList.Image = Properties.Resources.fatcow_arrow_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Name = "toolStripMenuItemExtensionsRefreshList";
			resources.ApplyResources(toolStripMenuItemExtensionsRefreshList, "toolStripMenuItemExtensionsRefreshList");
			toolStripMenuItemExtensionsRefreshList.Click += ToolStripMenuItemExtensionsRefreshList_Click;
			// 
			// toolStripMenuItemExtensionsMarkAllItems
			// 
			toolStripMenuItemExtensionsMarkAllItems.AutoToolTip = true;
			toolStripMenuItemExtensionsMarkAllItems.Image = Properties.Resources.fatcow_check_box_16;
			toolStripMenuItemExtensionsMarkAllItems.Name = "toolStripMenuItemExtensionsMarkAllItems";
			resources.ApplyResources(toolStripMenuItemExtensionsMarkAllItems, "toolStripMenuItemExtensionsMarkAllItems");
			toolStripMenuItemExtensionsMarkAllItems.Click += ToolStripMenuItemExtensionsMarkAll_Click;
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
			splitContainerResultsAndRightSide.Panel2.Controls.Add(splitContainerStatsAndActions);
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
			listViewResults.ContextMenuStrip = contextMenuStripResults;
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
			listViewResults.ItemActivate += ListViewResults_ItemActivate;
			listViewResults.DoubleClick += ListViewResults_DoubleClick;
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
			// contextMenuStripResults
			// 
			contextMenuStripResults.AllowClickThrough = true;
			contextMenuStripResults.Items.AddRange(new ToolStripItem[] { toolStripMenuItemOpenFile, toolStripMenuItemOpenFolder, toolStripMenuItemShowProperties, toolStripMenuItemCopyFile, toolStripMenuItemMoveFile, toolStripMenuItemDeleteFile, toolStripMenuItemBackupFile });
			contextMenuStripResults.Name = "contextMenuStripResults";
			resources.ApplyResources(contextMenuStripResults, "contextMenuStripResults");
			contextMenuStripResults.TabStop = true;
			// 
			// toolStripMenuItemOpenFile
			// 
			toolStripMenuItemOpenFile.AutoToolTip = true;
			toolStripMenuItemOpenFile.Image = Properties.Resources.fatcow_page_white_16;
			toolStripMenuItemOpenFile.Name = "toolStripMenuItemOpenFile";
			resources.ApplyResources(toolStripMenuItemOpenFile, "toolStripMenuItemOpenFile");
			toolStripMenuItemOpenFile.Click += ToolStripMenuItemOpenFile_Click;
			// 
			// toolStripMenuItemOpenFolder
			// 
			toolStripMenuItemOpenFolder.AutoToolTip = true;
			toolStripMenuItemOpenFolder.Image = Properties.Resources.fatcow_folder_16;
			toolStripMenuItemOpenFolder.Name = "toolStripMenuItemOpenFolder";
			resources.ApplyResources(toolStripMenuItemOpenFolder, "toolStripMenuItemOpenFolder");
			toolStripMenuItemOpenFolder.Click += ToolStripMenuItemOpenFolder_Click;
			// 
			// toolStripMenuItemShowProperties
			// 
			toolStripMenuItemShowProperties.AutoToolTip = true;
			toolStripMenuItemShowProperties.Image = Properties.Resources.fatcow_preferences_16;
			toolStripMenuItemShowProperties.Name = "toolStripMenuItemShowProperties";
			resources.ApplyResources(toolStripMenuItemShowProperties, "toolStripMenuItemShowProperties");
			toolStripMenuItemShowProperties.Click += ToolStripMenuItemShowProperties_Click;
			// 
			// toolStripMenuItemCopyFile
			// 
			toolStripMenuItemCopyFile.AutoToolTip = true;
			toolStripMenuItemCopyFile.Image = Properties.Resources.fatcow_page_white_copy_16;
			toolStripMenuItemCopyFile.Name = "toolStripMenuItemCopyFile";
			resources.ApplyResources(toolStripMenuItemCopyFile, "toolStripMenuItemCopyFile");
			toolStripMenuItemCopyFile.Click += ToolStripMenuItemCopyFile_Click;
			// 
			// toolStripMenuItemMoveFile
			// 
			toolStripMenuItemMoveFile.AutoToolTip = true;
			toolStripMenuItemMoveFile.Image = Properties.Resources.fatcow_move_to_folder_16;
			toolStripMenuItemMoveFile.Name = "toolStripMenuItemMoveFile";
			resources.ApplyResources(toolStripMenuItemMoveFile, "toolStripMenuItemMoveFile");
			toolStripMenuItemMoveFile.Click += ToolStripMenuItemMoveFile_Click;
			// 
			// toolStripMenuItemDeleteFile
			// 
			toolStripMenuItemDeleteFile.AutoToolTip = true;
			toolStripMenuItemDeleteFile.Image = Properties.Resources.fatcow_cross_16;
			toolStripMenuItemDeleteFile.Name = "toolStripMenuItemDeleteFile";
			resources.ApplyResources(toolStripMenuItemDeleteFile, "toolStripMenuItemDeleteFile");
			toolStripMenuItemDeleteFile.Click += ToolStripMenuItemDeleteFile_Click;
			// 
			// toolStripMenuItemBackupFile
			// 
			toolStripMenuItemBackupFile.AutoToolTip = true;
			toolStripMenuItemBackupFile.Image = Properties.Resources.fatcow_compress_16;
			toolStripMenuItemBackupFile.Name = "toolStripMenuItemBackupFile";
			resources.ApplyResources(toolStripMenuItemBackupFile, "toolStripMenuItemBackupFile");
			toolStripMenuItemBackupFile.Click += ToolStripMenuItemBackupFile_Click;
			// 
			// splitContainerStatsAndActions
			// 
			resources.ApplyResources(splitContainerStatsAndActions, "splitContainerStatsAndActions");
			splitContainerStatsAndActions.FixedPanel = FixedPanel.Panel1;
			splitContainerStatsAndActions.Name = "splitContainerStatsAndActions";
			// 
			// splitContainerStatsAndActions.Panel1
			// 
			splitContainerStatsAndActions.Panel1.Controls.Add(groupBoxActions);
			// 
			// splitContainerStatsAndActions.Panel2
			// 
			splitContainerStatsAndActions.Panel2.Controls.Add(groupBoxStatistics);
			// 
			// groupBoxActions
			// 
			groupBoxActions.Controls.Add(buttonBackupFile);
			groupBoxActions.Controls.Add(buttonDeleteFile);
			groupBoxActions.Controls.Add(buttonMoveFile);
			groupBoxActions.Controls.Add(buttonCopyFile);
			groupBoxActions.Controls.Add(buttonOpenFile);
			groupBoxActions.Controls.Add(buttonOpenFolder);
			groupBoxActions.Controls.Add(buttonShowProperties);
			resources.ApplyResources(groupBoxActions, "groupBoxActions");
			groupBoxActions.Name = "groupBoxActions";
			groupBoxActions.TabStop = false;
			// 
			// buttonBackupFile
			// 
			resources.ApplyResources(buttonBackupFile, "buttonBackupFile");
			buttonBackupFile.AutoEllipsis = true;
			buttonBackupFile.Image = Properties.Resources.fatcow_compress_16;
			buttonBackupFile.Name = "buttonBackupFile";
			buttonBackupFile.UseVisualStyleBackColor = true;
			buttonBackupFile.Click += ButtonBackupFile_Click;
			// 
			// buttonDeleteFile
			// 
			resources.ApplyResources(buttonDeleteFile, "buttonDeleteFile");
			buttonDeleteFile.AutoEllipsis = true;
			buttonDeleteFile.Image = Properties.Resources.fatcow_cross_16;
			buttonDeleteFile.Name = "buttonDeleteFile";
			buttonDeleteFile.UseVisualStyleBackColor = true;
			buttonDeleteFile.Click += ButtonDeleteFile_Click;
			// 
			// buttonMoveFile
			// 
			resources.ApplyResources(buttonMoveFile, "buttonMoveFile");
			buttonMoveFile.AutoEllipsis = true;
			buttonMoveFile.Image = Properties.Resources.fatcow_move_to_folder_16;
			buttonMoveFile.Name = "buttonMoveFile";
			buttonMoveFile.UseVisualStyleBackColor = true;
			buttonMoveFile.Click += ButtonMoveFile_Click;
			// 
			// buttonCopyFile
			// 
			resources.ApplyResources(buttonCopyFile, "buttonCopyFile");
			buttonCopyFile.AutoEllipsis = true;
			buttonCopyFile.Image = Properties.Resources.fatcow_page_white_copy_16;
			buttonCopyFile.Name = "buttonCopyFile";
			buttonCopyFile.UseVisualStyleBackColor = true;
			buttonCopyFile.Click += ButtonCopyFile_Click;
			// 
			// buttonOpenFile
			// 
			resources.ApplyResources(buttonOpenFile, "buttonOpenFile");
			buttonOpenFile.AutoEllipsis = true;
			buttonOpenFile.Image = Properties.Resources.fatcow_page_white_16;
			buttonOpenFile.Name = "buttonOpenFile";
			buttonOpenFile.UseVisualStyleBackColor = true;
			buttonOpenFile.Click += ButtonOpenFile_Click;
			// 
			// buttonOpenFolder
			// 
			resources.ApplyResources(buttonOpenFolder, "buttonOpenFolder");
			buttonOpenFolder.AutoEllipsis = true;
			buttonOpenFolder.Image = Properties.Resources.fatcow_folder_16;
			buttonOpenFolder.Name = "buttonOpenFolder";
			buttonOpenFolder.UseVisualStyleBackColor = true;
			buttonOpenFolder.Click += ButtonOpenFolder_Click;
			// 
			// buttonShowProperties
			// 
			resources.ApplyResources(buttonShowProperties, "buttonShowProperties");
			buttonShowProperties.AutoEllipsis = true;
			buttonShowProperties.Image = Properties.Resources.fatcow_preferences_16;
			buttonShowProperties.Name = "buttonShowProperties";
			buttonShowProperties.UseVisualStyleBackColor = true;
			buttonShowProperties.Click += ButtonShowProperties_Click;
			// 
			// groupBoxStatistics
			// 
			groupBoxStatistics.Controls.Add(listViewStatistics);
			resources.ApplyResources(groupBoxStatistics, "groupBoxStatistics");
			groupBoxStatistics.Name = "groupBoxStatistics";
			groupBoxStatistics.TabStop = false;
			// 
			// listViewStatistics
			// 
			listViewStatistics.Activation = ItemActivation.OneClick;
			listViewStatistics.AllowColumnReorder = true;
			listViewStatistics.Columns.AddRange(new ColumnHeader[] { columnHeaderDesc, columnHeaderValue });
			listViewStatistics.ContextMenuStrip = contextMenuStripStatistics;
			resources.ApplyResources(listViewStatistics, "listViewStatistics");
			listViewStatistics.FullRowSelect = true;
			listViewStatistics.HotTracking = true;
			listViewStatistics.HoverSelection = true;
			listViewStatistics.Items.AddRange(new ListViewItem[] { (ListViewItem)resources.GetObject("listViewStatistics.Items"), (ListViewItem)resources.GetObject("listViewStatistics.Items1"), (ListViewItem)resources.GetObject("listViewStatistics.Items2"), (ListViewItem)resources.GetObject("listViewStatistics.Items3"), (ListViewItem)resources.GetObject("listViewStatistics.Items4") });
			listViewStatistics.MultiSelect = false;
			listViewStatistics.Name = "listViewStatistics";
			listViewStatistics.ShowItemToolTips = true;
			listViewStatistics.UseCompatibleStateImageBehavior = false;
			listViewStatistics.View = View.Details;
			// 
			// columnHeaderDesc
			// 
			resources.ApplyResources(columnHeaderDesc, "columnHeaderDesc");
			// 
			// columnHeaderValue
			// 
			resources.ApplyResources(columnHeaderValue, "columnHeaderValue");
			// 
			// contextMenuStripStatistics
			// 
			contextMenuStripStatistics.AllowClickThrough = true;
			contextMenuStripStatistics.Items.AddRange(new ToolStripItem[] { toolStripMenuItemStatisticsSaveAsCsv });
			contextMenuStripStatistics.Name = "contextMenuStripStatistics";
			resources.ApplyResources(contextMenuStripStatistics, "contextMenuStripStatistics");
			contextMenuStripStatistics.TabStop = true;
			// 
			// toolStripMenuItemStatisticsSaveAsCsv
			// 
			toolStripMenuItemStatisticsSaveAsCsv.AutoToolTip = true;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Properties.Resources.fatcow_diskette_16;
			toolStripMenuItemStatisticsSaveAsCsv.Name = "toolStripMenuItemStatisticsSaveAsCsv";
			resources.ApplyResources(toolStripMenuItemStatisticsSaveAsCsv, "toolStripMenuItemStatisticsSaveAsCsv");
			toolStripMenuItemStatisticsSaveAsCsv.Click += ToolStripMenuItemStatisticsSaveAsCsv_Click;
			// 
			// toolStrip
			// 
			toolStrip.AllowClickThrough = true;
			toolStrip.AllowItemReorder = true;
			resources.ApplyResources(toolStrip, "toolStrip");
			toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonStart, toolStripButtonPause, toolStripButtonStop, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonSaveToCsv, toolStripSeparator3, toolStripDropDownButtonSettings, toolStripButtonInfo, toolStripSeparator2, toolStripButtonExit });
			toolStrip.Name = "toolStrip";
			toolStrip.Stretch = true;
			toolStrip.TabStop = true;
			// 
			// toolStripButtonStart
			// 
			toolStripButtonStart.Image = Properties.Resources.fatcow_control_play_blue_32;
			resources.ApplyResources(toolStripButtonStart, "toolStripButtonStart");
			toolStripButtonStart.Name = "toolStripButtonStart";
			toolStripButtonStart.Click += ButtonSearch_Click;
			// 
			// toolStripButtonPause
			// 
			toolStripButtonPause.Image = Properties.Resources.fatcow_control_pause_blue_32;
			resources.ApplyResources(toolStripButtonPause, "toolStripButtonPause");
			toolStripButtonPause.Name = "toolStripButtonPause";
			toolStripButtonPause.Click += ToolStripButtonPause_Click;
			// 
			// toolStripButtonStop
			// 
			toolStripButtonStop.Image = Properties.Resources.fatcow_control_stop_blue_32;
			resources.ApplyResources(toolStripButtonStop, "toolStripButtonStop");
			toolStripButtonStop.Name = "toolStripButtonStop";
			toolStripButtonStop.Click += ButtonStop_Click;
			// 
			// toolStripButtonRefresh
			// 
			toolStripButtonRefresh.Image = Properties.Resources.fatcow_arrow_refresh_32;
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
			toolStripButtonSaveToCsv.Image = Properties.Resources.fatcow_diskette_32;
			resources.ApplyResources(toolStripButtonSaveToCsv, "toolStripButtonSaveToCsv");
			toolStripButtonSaveToCsv.Name = "toolStripButtonSaveToCsv";
			toolStripButtonSaveToCsv.Click += ToolStripButtonSaveToCsv_Click;
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
			// 
			// toolStripDropDownButtonSettings
			// 
			toolStripDropDownButtonSettings.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemIncludeHiddenFiles, toolStripMenuItemSuppressWarningsAndErrorsOnSearch, toolStripMenuItemAutoResizeColumns, toolStripMenuItemDisplayTheSearchedDirectory, toolStripMenuItemDisplaySearchComplete, toolStripMenuItemAskToCloseDuringSearch, toolStripMenuItemEnableStatistics, toolStripSeparator4, toolStripMenuItemIconThemes });
			toolStripDropDownButtonSettings.Image = Properties.Resources.fatcow_wrench_32;
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
			// toolStripMenuItemEnableStatistics
			// 
			toolStripMenuItemEnableStatistics.AutoToolTip = true;
			toolStripMenuItemEnableStatistics.Checked = true;
			toolStripMenuItemEnableStatistics.CheckOnClick = true;
			toolStripMenuItemEnableStatistics.CheckState = CheckState.Checked;
			toolStripMenuItemEnableStatistics.Name = "toolStripMenuItemEnableStatistics";
			resources.ApplyResources(toolStripMenuItemEnableStatistics, "toolStripMenuItemEnableStatistics");
			toolStripMenuItemEnableStatistics.Click += ToolStripMenuItemEnableStatistics_Click;
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
			// 
			// toolStripMenuItemIconThemes
			// 
			toolStripMenuItemIconThemes.AutoToolTip = true;
			toolStripMenuItemIconThemes.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemIconThemeFatcow, toolStripMenuItemIconThemeXCollection, toolStripMenuItemIconThemeOCollection, toolStripMenuItemIconThemeICollection });
			toolStripMenuItemIconThemes.Image = Properties.Resources.fatcow_palette_16;
			toolStripMenuItemIconThemes.Name = "toolStripMenuItemIconThemes";
			resources.ApplyResources(toolStripMenuItemIconThemes, "toolStripMenuItemIconThemes");
			// 
			// toolStripMenuItemIconThemeFatcow
			// 
			toolStripMenuItemIconThemeFatcow.AutoToolTip = true;
			toolStripMenuItemIconThemeFatcow.Checked = true;
			toolStripMenuItemIconThemeFatcow.CheckState = CheckState.Checked;
			toolStripMenuItemIconThemeFatcow.Name = "toolStripMenuItemIconThemeFatcow";
			resources.ApplyResources(toolStripMenuItemIconThemeFatcow, "toolStripMenuItemIconThemeFatcow");
			toolStripMenuItemIconThemeFatcow.Click += ToolStripMenuItemIconThemeFatcow_Click;
			// 
			// toolStripMenuItemIconThemeXCollection
			// 
			toolStripMenuItemIconThemeXCollection.AutoToolTip = true;
			toolStripMenuItemIconThemeXCollection.Name = "toolStripMenuItemIconThemeXCollection";
			resources.ApplyResources(toolStripMenuItemIconThemeXCollection, "toolStripMenuItemIconThemeXCollection");
			toolStripMenuItemIconThemeXCollection.Click += ToolStripMenuItemIconThemeXCollection_Click;
			// 
			// toolStripMenuItemIconThemeOCollection
			// 
			toolStripMenuItemIconThemeOCollection.AutoToolTip = true;
			toolStripMenuItemIconThemeOCollection.Name = "toolStripMenuItemIconThemeOCollection";
			resources.ApplyResources(toolStripMenuItemIconThemeOCollection, "toolStripMenuItemIconThemeOCollection");
			toolStripMenuItemIconThemeOCollection.Click += ToolStripMenuItemIconThemeOCollection_Click;
			// 
			// toolStripMenuItemIconThemeICollection
			// 
			toolStripMenuItemIconThemeICollection.AutoToolTip = true;
			toolStripMenuItemIconThemeICollection.Name = "toolStripMenuItemIconThemeICollection";
			resources.ApplyResources(toolStripMenuItemIconThemeICollection, "toolStripMenuItemIconThemeICollection");
			toolStripMenuItemIconThemeICollection.Click += ToolStripMenuItemIconThemeICollection_Click;
			// 
			// toolStripButtonInfo
			// 
			toolStripButtonInfo.Image = Properties.Resources.fatcow_information_32;
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
			toolStripButtonExit.Image = Properties.Resources.fatcow_door_32;
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
			WindowState = FormWindowState.Maximized;
			FormClosing += MainForm_FormClosing;
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
			contextMenuStripDrives.ResumeLayout(false);
			groupBoxExtensions.ResumeLayout(false);
			contextMenuStripExtensions.ResumeLayout(false);
			panelResults.ResumeLayout(false);
			splitContainerResultsAndRightSide.Panel1.ResumeLayout(false);
			splitContainerResultsAndRightSide.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerResultsAndRightSide).EndInit();
			splitContainerResultsAndRightSide.ResumeLayout(false);
			groupBoxResults.ResumeLayout(false);
			contextMenuStripResults.ResumeLayout(false);
			splitContainerStatsAndActions.Panel1.ResumeLayout(false);
			splitContainerStatsAndActions.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerStatsAndActions).EndInit();
			splitContainerStatsAndActions.ResumeLayout(false);
			groupBoxActions.ResumeLayout(false);
			groupBoxStatistics.ResumeLayout(false);
			contextMenuStripStatistics.ResumeLayout(false);
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
		private SplitContainer splitContainerStatsAndActions;
		private GroupBox groupBoxStatistics;
		private GroupBox groupBoxActions;
		private ToolStripMenuItem toolStripMenuItemDisplayTheSearchedDirectory;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton toolStripButtonExit;
        private ToolStripMenuItem toolStripMenuItemDisplaySearchComplete;
        private ToolStripButton toolStripButtonPause;
        private ToolStripMenuItem toolStripMenuItemAskToCloseDuringSearch;
        private ToolStripMenuItem toolStripMenuItemIncludeHiddenFiles;
        private ToolStripButton toolStripButtonStart;
        private ToolStripButton toolStripButtonSaveToCsv;
        private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem toolStripMenuItemEnableStatistics;
		private Button buttonShowProperties;
		private Button buttonOpenFile;
		private Button buttonOpenFolder;
		private Button buttonDeleteFile;
		private Button buttonMoveFile;
		private Button buttonCopyFile;
		private Button buttonBackupFile;
		private GenealogicalFileCatalog.BufferedListView listViewStatistics;
		private ColumnHeader columnHeaderDesc;
		private ColumnHeader columnHeaderValue;
		private ContextMenuStrip contextMenuStripStatistics;
		private ToolStripMenuItem toolStripMenuItemStatisticsSaveAsCsv;
		private ContextMenuStrip contextMenuStripResults;
		private ToolStripMenuItem toolStripMenuItemOpenFile;
		private ToolStripMenuItem toolStripMenuItemOpenFolder;
		private ToolStripMenuItem toolStripMenuItemShowProperties;
		private ToolStripMenuItem toolStripMenuItemCopyFile;
		private ToolStripMenuItem toolStripMenuItemMoveFile;
		private ToolStripMenuItem toolStripMenuItemDeleteFile;
		private ToolStripMenuItem toolStripMenuItemBackupFile;
		private ContextMenuStrip contextMenuStripDrives;
		private ToolStripMenuItem toolStripMenuItemDrivesMarkAllItems;
		private ContextMenuStrip contextMenuStripExtensions;
		private ToolStripMenuItem toolStripMenuItemExtensionsMarkAllItems;
		private ToolStripMenuItem toolStripMenuItemDrivesRefreshList;
		private ToolStripMenuItem toolStripMenuItemExtensionsRefreshList;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripMenuItem toolStripMenuItemIconThemes;
		private ToolStripMenuItem toolStripMenuItemIconThemeFatcow;
		private ToolStripMenuItem toolStripMenuItemIconThemeXCollection;
		private ToolStripMenuItem toolStripMenuItemIconThemeOCollection;
		private ToolStripMenuItem toolStripMenuItemIconThemeICollection;
	}
}

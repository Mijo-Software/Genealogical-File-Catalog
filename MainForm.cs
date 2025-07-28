using System.Diagnostics; // Add this at the top if not already present
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

using GenealogicalFileCatalog.Properties;

namespace GenealogicalFileCatalog
{
	/// <summary>
	/// The main form of the Genealogical File Catalog application.
	/// Provides functionality to search for genealogical files on selected drives.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Indicates whether a stop request has been made for the search operation.
		/// </summary>
		private bool stopRequested;

		/// <summary>
		/// Indicates whether a search operation is currently running.
		/// This flag is set to true when a search starts and set to false when the search completes or is stopped.
		/// Used to control UI state and prevent concurrent searches.
		/// </summary>
		private bool searchRunning;

		/// <summary>
		/// Stores the number of files found during the current search operation.
		/// This value is incremented each time a matching file is found and displayed in the UI.
		/// </summary>
		private int filesFound;

		/// <summary>
		/// Implements sorting for the ListView columns.
		/// </summary>
		private int sortColumn = -1;

		private int numberOfGedFiles;

		private int numberOfAhnFiles;

		private int numberOfFtbFiles;

		/// <summary>
		/// Stopwatch to measure the elapsed search time.
		/// </summary>
		private readonly Stopwatch searchStopwatch = new();

		/// <summary>
		/// Timer to update the elapsed time label during search.
		/// </summary>
		private readonly System.Windows.Forms.Timer searchTimer = new();

		/// <summary>
		/// Indicates whether a pause has been requested for the search operation.
		/// When set to true, the search process will temporarily halt until resumed.
		/// Used to implement the pause and resume functionality during file search.
		/// </summary>
		private volatile bool pauseRequested;

		/// <summary>
		/// Constant for the Show command used in Windows Shell execution.
		/// </summary>
		private const int SW_SHOW = 5;

		/// <summary>
		/// Constant for the ShellExecuteEx mask to invoke the properties dialog.
		/// </summary>
		private const uint SEE_MASK_INVOKEIDLIST = 0x0000000C;

		private readonly ListViewGroup listViewGroupGed = new(
			header: "Gedcom (GED)", headerAlignment: HorizontalAlignment.Left);

		private readonly ListViewGroup listViewGroupAhn = new(
			header: "Ahnenblatt (AHN)", headerAlignment: HorizontalAlignment.Left);

		private readonly ListViewGroup listViewGroupFtb = new(
			header: "Family Tree Builder (FTB)", headerAlignment: HorizontalAlignment.Left);

		[StructLayout(layoutKind: LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct SHELLEXECUTEINFO
		{
			public int cbSize;
			public uint fMask;
			public IntPtr hwnd;
			[MarshalAs(unmanagedType: UnmanagedType.LPTStr)] public string lpVerb;
			[MarshalAs(unmanagedType: UnmanagedType.LPTStr)] public string lpFile;
			[MarshalAs(unmanagedType: UnmanagedType.LPTStr)] public string lpParameters;
			[MarshalAs(unmanagedType: UnmanagedType.LPTStr)] public string lpDirectory;
			public int nShow;
			public IntPtr hInstApp;
			public IntPtr lpIDList;
			[MarshalAs(unmanagedType: UnmanagedType.LPTStr)] public string lpClass;
			public IntPtr hkeyClass;
			public uint dwHotKey;
			public IntPtr hIcon;
			public IntPtr hProcess;
		}

		[DllImport(dllName: "shell32.dll", CharSet = CharSet.Auto)]
#pragma warning disable SYSLIB1054 // Verwenden Sie \"LibraryImportAttribute\" anstelle von \"DllImportAttribute\", um P/Invoke-Marshallingcode zur Kompilierzeit zu generieren.
		private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
#pragma warning restore SYSLIB1054 // Verwenden Sie \"LibraryImportAttribute\" anstelle von \"DllImportAttribute\", um P/Invoke-Marshallingcode zur Kompilierzeit zu generieren.

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// Sets up the UI components and loads available drives and file extensions.
		/// </summary>
		public MainForm()
		{
			// Initialize all UI components and controls defined in the designer.
			InitializeComponent();

			// Load available drives and file extensions into the corresponding UI controls.
			LoadDrives();
			LoadExtensions();
			ClearResultList();

			// Disable the stop button at startup, since no search is running.
			toolStripButtonStop.Enabled = false;

			// Configure the timer for updating the elapsed time label.
			searchTimer.Interval = 200; // Update every 200 ms
			searchTimer.Tick += SearchTimer_Tick;
		}

		#endregion

		#region Helpers

		/// <summary>
		/// Requests the search operation to pause.
		/// Sets the pauseRequested flag to true, causing the search process to temporarily halt until resumed.
		/// </summary>
		private void PauseSearch() => pauseRequested = true;

		/// <summary>
		/// Resumes the search operation if it was previously paused.
		/// Sets the pauseRequested flag to false, allowing the search process to continue.
		/// </summary>
		private void ResumeSearch() => pauseRequested = false;

		private static bool ShowFileProperties(string filePath)
		{
			SHELLEXECUTEINFO info = new();
			info.cbSize = Marshal.SizeOf(structure: info);
			info.lpVerb = "properties";
			info.lpFile = filePath;
			info.nShow = SW_SHOW;
			info.fMask = SEE_MASK_INVOKEIDLIST;

			return ShellExecuteEx(lpExecInfo: ref info);
		}

		private void SetIconThemeFatcow()
		{
			toolStripButtonStart.Image = Resources.fatcow_control_play_blue_32;
			toolStripButtonPause.Image = Resources.fatcow_control_pause_blue_32;
			toolStripButtonStop.Image = Resources.fatcow_control_stop_blue_32;
			toolStripButtonRefresh.Image = Resources.fatcow_arrow_refresh_32;
			toolStripButtonSaveToCsv.Image = Resources.fatcow_diskette_32;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Resources.fatcow_diskette_16;
			toolStripDropDownButtonSettings.Image = Resources.fatcow_wrench_32;
			toolStripButtonInfo.Image = Resources.fatcow_information_32;
			toolStripButtonExit.Image = Resources.fatcow_door_32;
			buttonOpenFile.Image = Resources.fatcow_page_white_16;
			toolStripMenuItemOpenFile.Image = Resources.fatcow_page_white_16;
			buttonOpenFolder.Image = Resources.fatcow_folder_16;
			toolStripMenuItemOpenFolder.Image = Resources.fatcow_folder_16;
			buttonShowProperties.Image = Resources.fatcow_preferences_16;
			toolStripMenuItemShowProperties.Image = Resources.fatcow_preferences_16;
			buttonCopyFile.Image = Resources.fatcow_page_white_copy_16;
			toolStripMenuItemCopyFile.Image = Resources.fatcow_page_white_copy_16;
			buttonMoveFile.Image = Resources.fatcow_move_to_folder_16;
			toolStripMenuItemMoveFile.Image = Resources.fatcow_move_to_folder_16;
			buttonDeleteFile.Image = Resources.fatcow_cross_16;
			toolStripMenuItemDeleteFile.Image = Resources.fatcow_cross_16;
			buttonBackupFile.Image = Resources.fatcow_compress_16;
			toolStripMenuItemBackupFile.Image = Resources.fatcow_compress_16;
			toolStripMenuItemDrivesRefreshList.Image = Resources.fatcow_arrow_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Image = Resources.fatcow_arrow_refresh_16;
			toolStripMenuItemDrivesMarkAllItems.Image = Resources.fatcow_check_box_16;
			toolStripMenuItemExtensionsMarkAllItems.Image = Resources.fatcow_check_box_16;
			toolStripMenuItemIconThemes.Image = Resources.fatcow_palette_16;
		}

		private void SetIconThemeXCollection()
		{
			toolStripButtonStart.Image = Resources.x_collection_media_play_32;
			toolStripButtonPause.Image = Resources.x_collection_media_pause_32;
			toolStripButtonStop.Image = Resources.x_collection_media_stop_32;
			toolStripButtonRefresh.Image = Resources.x_collection_refresh_32;
			toolStripButtonSaveToCsv.Image = Resources.x_collection_disk_blue_32;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Resources.x_collection_disk_blue_16;
			toolStripDropDownButtonSettings.Image = Resources.x_collection_wrench_32;
			toolStripButtonInfo.Image = Resources.x_collection_about_32;
			toolStripButtonExit.Image = Resources.x_collection_exit_32;
			buttonOpenFile.Image = Resources.x_collection_document_16;
			toolStripMenuItemOpenFile.Image = Resources.x_collection_document_16;
			buttonOpenFolder.Image = Resources.x_collection_folder_16;
			toolStripMenuItemOpenFolder.Image = Resources.x_collection_folder_16;
			buttonShowProperties.Image = Resources.x_collection_preferences_16;
			toolStripMenuItemShowProperties.Image = Resources.x_collection_preferences_16;
			buttonCopyFile.Image = Resources.x_collection_documents_16;
			toolStripMenuItemCopyFile.Image = Resources.x_collection_documents_16;
			buttonMoveFile.Image = Resources.x_collection_document_out_16;
			toolStripMenuItemMoveFile.Image = Resources.x_collection_document_out_16;
			buttonDeleteFile.Image = Resources.x_collection_delete_16;
			toolStripMenuItemDeleteFile.Image = Resources.x_collection_delete_16;
			buttonBackupFile.Image = Resources.x_collection_compress_16;
			toolStripMenuItemBackupFile.Image = Resources.x_collection_compress_16;
			toolStripMenuItemDrivesRefreshList.Image = Resources.x_collection_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Image = Resources.x_collection_refresh_16;
			toolStripMenuItemDrivesMarkAllItems.Image = Resources.x_collection_checkbox_16;
			toolStripMenuItemExtensionsMarkAllItems.Image = Resources.x_collection_checkbox_16;
			toolStripMenuItemIconThemes.Image = Resources.x_collection_palette_16;
		}

		private void SetIconThemeOCollection()
		{
			toolStripButtonStart.Image = Resources.o_collection_media_play_32;
			toolStripButtonPause.Image = Resources.o_collection_media_pause_32;
			toolStripButtonStop.Image = Resources.o_collection_media_stop_32;
			toolStripButtonRefresh.Image = Resources.o_collection_refresh_32;
			toolStripButtonSaveToCsv.Image = Resources.o_collection_floppy_disk_32;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Resources.o_collection_floppy_disk_16;
			toolStripDropDownButtonSettings.Image = Resources.o_collection_wrench_32;
			toolStripButtonInfo.Image = Resources.o_collection_about_32;
			toolStripButtonExit.Image = Resources.o_collection_door_exit_32;
			buttonOpenFile.Image = Resources.o_collection_document_empty_16;
			toolStripMenuItemOpenFile.Image = Resources.o_collection_document_empty_16;
			buttonOpenFolder.Image = Resources.o_collection_folder_16;
			toolStripMenuItemOpenFolder.Image = Resources.o_collection_folder_16;
			buttonShowProperties.Image = Resources.o_collection_document_information_16;
			toolStripMenuItemShowProperties.Image = Resources.o_collection_document_information_16;
			buttonCopyFile.Image = Resources.o_collection_documents_empty_16;
			toolStripMenuItemCopyFile.Image = Resources.o_collection_documents_empty_16;
			buttonMoveFile.Image = Resources.o_collection_folder_document2_16;
			toolStripMenuItemMoveFile.Image = Resources.o_collection_folder_document2_16;
			buttonDeleteFile.Image = Resources.o_collection_delete_16;
			toolStripMenuItemDeleteFile.Image = Resources.o_collection_delete_16;
			buttonBackupFile.Image = Resources.o_collection_compress_16;
			toolStripMenuItemBackupFile.Image = Resources.o_collection_compress_16;
			toolStripMenuItemDrivesRefreshList.Image = Resources.o_collection_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Image = Resources.o_collection_refresh_16;
			toolStripMenuItemDrivesMarkAllItems.Image = Resources.o_collection_checkbox_16;
			toolStripMenuItemExtensionsMarkAllItems.Image = Resources.o_collection_checkbox_16;
			toolStripMenuItemIconThemes.Image = Resources.o_collection_painters_palette_16;
		}

		private void SetIconThemeICollectionPlain()
		{
			toolStripButtonStart.Image = Resources.i_collection_plain_media_play_32;
			toolStripButtonPause.Image = Resources.i_collection_plain_media_pause_32;
			toolStripButtonStop.Image = Resources.i_collection_plain_media_stop_32;
			toolStripButtonRefresh.Image = Resources.i_collection_plain_refresh_32;
			toolStripButtonSaveToCsv.Image = Resources.i_collection_plain_floppy_disk_32;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Resources.i_collection_plain_floppy_disk_16;
			toolStripDropDownButtonSettings.Image = Resources.i_collection_plain_wrench_32;
			toolStripButtonInfo.Image = Resources.i_collection_plain_about_32;
			toolStripButtonExit.Image = Resources.i_collection_plain_door_exit_32;
			buttonOpenFile.Image = Resources.i_collection_plain_document_empty_16;
			toolStripMenuItemOpenFile.Image = Resources.i_collection_plain_document_empty_16;
			buttonOpenFolder.Image = Resources.i_collection_plain_folder_16;
			toolStripMenuItemOpenFolder.Image = Resources.i_collection_plain_folder_16;
			buttonShowProperties.Image = Resources.i_collection_plain_document_information_16;
			toolStripMenuItemShowProperties.Image = Resources.i_collection_plain_document_information_16;
			buttonCopyFile.Image = Resources.i_collection_plain_documents_empty_16;
			toolStripMenuItemCopyFile.Image = Resources.i_collection_plain_documents_empty_16;
			buttonMoveFile.Image = Resources.i_collection_plain_folder_document2_16;
			toolStripMenuItemMoveFile.Image = Resources.i_collection_plain_folder_document2_16;
			buttonDeleteFile.Image = Resources.i_collection_plain_delete_16;
			toolStripMenuItemDeleteFile.Image = Resources.i_collection_plain_delete_16;
			buttonBackupFile.Image = Resources.i_collection_plain_compress_16;
			toolStripMenuItemBackupFile.Image = Resources.i_collection_plain_compress_16;
			toolStripMenuItemDrivesRefreshList.Image = Resources.i_collection_plain_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Image = Resources.i_collection_plain_refresh_16;
			toolStripMenuItemDrivesMarkAllItems.Image = Resources.i_collection_plain_checkbox_16;
			toolStripMenuItemExtensionsMarkAllItems.Image = Resources.i_collection_plain_checkbox_16;
			toolStripMenuItemIconThemes.Image = Resources.i_collection_plain_painters_palette_16;
		}

		private void SetIconThemeICollectionSelected()
		{
			toolStripButtonStart.Image = Resources.i_collection_selected_media_play_32;
			toolStripButtonPause.Image = Resources.i_collection_selected_media_pause_32;
			toolStripButtonStop.Image = Resources.i_collection_selected_media_stop_32;
			toolStripButtonRefresh.Image = Resources.i_collection_selected_refresh_32;
			toolStripButtonSaveToCsv.Image = Resources.i_collection_selected_floppy_disk_32;
			toolStripMenuItemStatisticsSaveAsCsv.Image = Resources.i_collection_selected_floppy_disk_16;
			toolStripDropDownButtonSettings.Image = Resources.i_collection_selected_wrench_32;
			toolStripButtonInfo.Image = Resources.i_collection_selected_about_32;
			toolStripButtonExit.Image = Resources.i_collection_selected_door_exit_32;
			buttonOpenFile.Image = Resources.i_collection_selected_document_empty_16;
			toolStripMenuItemOpenFile.Image = Resources.i_collection_selected_document_empty_16;
			buttonOpenFolder.Image = Resources.i_collection_selected_folder_16;
			toolStripMenuItemOpenFolder.Image = Resources.i_collection_selected_folder_16;
			buttonShowProperties.Image = Resources.i_collection_selected_document_information_16;
			toolStripMenuItemShowProperties.Image = Resources.i_collection_selected_document_information_16;
			buttonCopyFile.Image = Resources.i_collection_selected_documents_empty_16;
			toolStripMenuItemCopyFile.Image = Resources.i_collection_selected_documents_empty_16;
			buttonMoveFile.Image = Resources.i_collection_selected_folder_document2_16;
			toolStripMenuItemMoveFile.Image = Resources.i_collection_selected_folder_document2_16;
			buttonDeleteFile.Image = Resources.i_collection_selected_delete_16;
			toolStripMenuItemDeleteFile.Image = Resources.i_collection_selected_delete_16;
			buttonBackupFile.Image = Resources.i_collection_selected_compress_16;
			toolStripMenuItemBackupFile.Image = Resources.i_collection_selected_compress_16;
			toolStripMenuItemDrivesRefreshList.Image = Resources.i_collection_selected_refresh_16;
			toolStripMenuItemExtensionsRefreshList.Image = Resources.i_collection_selected_refresh_16;
			toolStripMenuItemDrivesMarkAllItems.Image = Resources.i_collection_selected_checkbox_16;
			toolStripMenuItemExtensionsMarkAllItems.Image = Resources.i_collection_selected_checkbox_16;
			toolStripMenuItemIconThemes.Image = Resources.i_collection_selected_painters_palette_16;
		}

		private static void ErrorMessage(string caption, string text) =>
			_ = MessageBox.Show(text: text,
				caption: caption,
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Error);

		private void OpenFile()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						// Open the file using the default application associated with its type.
						_ = Process.Start(startInfo: new ProcessStartInfo(fileName: filePath) { UseShellExecute = true });
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void OpenFolder()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? folderPath = selectedItem.SubItems[index: 1].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: folderPath))
				{
					try
					{
						// Open the file using the default application associated with its type.
						_ = Process.Start(startInfo: new ProcessStartInfo(fileName: folderPath) { UseShellExecute = true });
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the folder.
						ErrorMessage(caption: "Error", text: $"Error opening folder: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void ShowProperties()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;

				// If the file path is not empty, show the file properties.
				if (string.IsNullOrEmpty(value: filePath))
				{
					ErrorMessage(caption: "Error", text: "No file selected.");
					return;
				}
				_ = ShowFileProperties(filePath: filePath);
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void CopyFile()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						// Open a SaveFileDialog to let the user choose where to save the file.
						// The dialog allows the user to specify the file name and location for saving the results.
						using SaveFileDialog dialog = new(); // Create a new instance of SaveFileDialog
						dialog.Title = "Copy file"; // Set the title of the dialog
						dialog.Filter = "All files (*.*)|*.*"; // Set the filter to show files and all files
						dialog.DefaultExt = ""; // Set the default file extension
						dialog.AddExtension = true; // Automatically add the extension if the user does not specify one
						dialog.FileName = selectedItem.SubItems[index: 0].Text; // Set the default file name for the saved file
						dialog.InitialDirectory = Environment.GetFolderPath(folder: Environment.SpecialFolder.MyDocuments); // Set the initial directory to the user's Documents folder
						dialog.RestoreDirectory = true; // Restore the directory after the dialog is closed
						dialog.OverwritePrompt = true; // Prompt if the file already exists
						dialog.CheckPathExists = true; // Ensure the path exists
						dialog.CreatePrompt = true; // Prompt to create the file if it doesn't exist
													// Show the dialog and check if the user clicked OK.
													// If the user selects a file and clicks OK, save the copy to that file.
						try
						{
							if (dialog.ShowDialog() == DialogResult.OK)
							{
								File.Copy(sourceFileName: filePath, destFileName: dialog.FileName);
							}
							_ = MessageBox.Show(text: "File successfully copied.", caption: "Copy", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
						}
						catch (Exception ex)
						{
							// Show an error message if there was an issue copying the file.
							ErrorMessage(caption: "Error", text: $"Error copying file: {ex.Message}");
						}
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void MoveFile()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						// Open a SaveFileDialog to let the user choose where to save the file.
						// The dialog allows the user to specify the file name and location for saving the results.
						using SaveFileDialog dialog = new(); // Create a new instance of SaveFileDialog
						dialog.Title = "Move file"; // Set the title of the dialog
						dialog.Filter = "All files (*.*)|*.*"; // Set the filter to show files and all files
						dialog.DefaultExt = ""; // Set the default file extension
						dialog.AddExtension = true; // Automatically add the extension if the user does not specify one
						dialog.FileName = selectedItem.SubItems[index: 0].Text; // Set the default file name for the saved file
						dialog.InitialDirectory = Environment.GetFolderPath(folder: Environment.SpecialFolder.MyDocuments); // Set the initial directory to the user's Documents folder
						dialog.RestoreDirectory = true; // Restore the directory after the dialog is closed
						dialog.OverwritePrompt = true; // Prompt if the file already exists
						dialog.CheckPathExists = true; // Ensure the path exists
						dialog.CreatePrompt = true; // Prompt to create the file if it doesn't exist
													// Show the dialog and check if the user clicked OK.
													// If the user selects a file and clicks OK, move the file to that file.
						try
						{
							if (dialog.ShowDialog() == DialogResult.OK)
							{
								File.Move(sourceFileName: filePath, destFileName: dialog.FileName);
							}
							_ = MessageBox.Show(text: "File successfully moved.", caption: "Move", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
						}
						catch (Exception ex)
						{
							// Show an error message if there was an issue copying the file.
							ErrorMessage(caption: "Error", text: $"Error moving file: {ex.Message}");
						}
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void DeleteFile()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						DialogResult result = MessageBox.Show(
							text: "Are you sure you wan to delete the file?",
							caption: "Confirm delete",
							buttons: MessageBoxButtons.YesNo,
							icon: MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							try
							{
								File.Delete(path: filePath);
								_ = MessageBox.Show(text: "File successfully deleted.", caption: "Delete", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
							}
							catch (Exception ex)
							{
								// Show an error message if there was an issue copying the file.
								ErrorMessage(caption: "Error", text: $"Error deleting file: {ex.Message}");
							}
						}
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		private void BackupFile()
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						// Open a SaveFileDialog to let the user choose where to save the ZIP file.
						// The dialog allows the user to specify the file name and location for saving the results.
						using SaveFileDialog dialog = new(); // Create a new instance of SaveFileDialog
						dialog.Title = "Save file as ZIP"; // Set the title of the dialog
						dialog.Filter = "ZIP files (*.zip)|*.zip"; // Set the filter to show ZIP files
						dialog.DefaultExt = "zip"; // Set the default file extension to ZIP
						dialog.AddExtension = true; // Automatically add the .zip extension if the user does not specify one
						dialog.FileName = $"{selectedItem.SubItems[index: 0].Text}.zip"; // Set the default file name for the saved file
						dialog.InitialDirectory = Environment.GetFolderPath(folder: Environment.SpecialFolder.MyDocuments); // Set the initial directory to the user's Documents folder
						dialog.RestoreDirectory = true; // Restore the directory after the dialog is closed
						dialog.OverwritePrompt = true; // Prompt if the file already exists
						dialog.CheckPathExists = true; // Ensure the path exists
						dialog.CreatePrompt = true; // Prompt to create the file if it doesn't exist
													// Show the dialog and check if the user clicked OK.
													// If the user selects a file and clicks OK, save the results to that file.
						try
						{
							if (dialog.ShowDialog() == DialogResult.OK)
							{
								using FileStream zipToOpen = new(path: dialog.FileName, mode: FileMode.Create);
								using ZipArchive archive = new(stream: zipToOpen, mode: ZipArchiveMode.Create);
								_ = archive.CreateEntryFromFile(sourceFileName: filePath, entryName: Path.GetFileName(path: filePath), compressionLevel: CompressionLevel.Optimal);
							}
							_ = MessageBox.Show(text: "File successfully compressed.", caption: "Compress", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
						}
						catch (Exception ex)
						{
							// Show an error message if there was an issue copying the file.
							ErrorMessage(caption: "Error", text: $"Error compressing file: {ex.Message}");
						}
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
			else
			{
				ErrorMessage(caption: "Error", text: "No file selected.");
			}
		}

		/// <summary>
		/// Increments the count of files found in this search operation.
		/// </summary>
		private void IncrementAndUpdateFoundedFiles()
		{
			// Increment the count of files found in this search operation.
			filesFound++;
			// Update the status label to show the current count of files found.
			if (toolStripMenuItemEnableStatistics.Checked)
			{
				listViewStatistics.Items[index: 0].SubItems[index: 1].Text = $"{filesFound}";
			}
		}

		/// <summary>
		/// Resets the count of files found in the current search operation to zero
		/// and updates the corresponding label in the UI to reflect this reset state.
		/// Should be called before starting a new search to ensure the file count is accurate.
		/// </summary>
		private void ResetAndUpdateFoundedFiles()
		{
			// Set the count of files found to zero in this search operation.
			filesFound = 0;
			// Update the status label to show the current count of files found.
			listViewStatistics.Items[index: 0].SubItems[index: 1].Text = $"{filesFound}";
		}

		/// <summary>
		/// Loads all available drives into the corresponding UI controls.
		/// </summary>
		private void LoadDrives()
		{
			// Clear all items from the drives checklist to prepare for reloading.
			checkedListBoxDrives.Items.Clear();

			// Add all available and ready drives to the checklist, initially unchecked.
			foreach (DriveInfo? drive in DriveInfo.GetDrives().Where(predicate: static d => d.IsReady))
			{
				_ = checkedListBoxDrives.Items.Add(item: drive.Name, isChecked: false);
			}
		}

		/// <summary>
		/// Loads all predefined file extensions into the corresponding UI controls.
		/// </summary>
		private void LoadExtensions()
		{
			// Clear all items from the file extensions checklist.
			checkedListBoxExtensions.Items.Clear();

			// Add predefined genealogical file extensions to the checklist.
			checkedListBoxExtensions.Items.AddRange(items: [".ged", ".ahn", ".ftb"]);

			// Set all file extensions as checked by default.
			for (int i = 0; i < checkedListBoxExtensions.Items.Count; i++)
			{
				checkedListBoxExtensions.SetItemChecked(index: i, value: true);
			}
		}

		/// <summary>
		/// Clear all previous search results from the results list view.
		/// </summary>
		private void ClearResultList()
		{
			listViewResults.Items.Clear();
			for (int i = 0; i < 5; i++)
			{
				listViewStatistics.Items[index: i].SubItems[index: 1].Text = string.Empty;
			}
		}

		/// <summary>
		/// Gets the file extensions selected by the user.
		/// </summary>
		/// <returns>An array of selected file extensions.</returns>
		private string[] GetSelectedExtensions() => [.. checkedListBoxExtensions.CheckedItems.Cast<string>()];

		private void SearchDirectory(string path, bool includeHidden, string[] extensions)
		{
			// Display the current search path in the status bar.
			if (InvokeRequired)
			{
				_ = Invoke(method: () => toolStripStatusLabelInfo.Text = toolStripMenuItemDisplayTheSearchedDirectory.Checked ? path : string.Empty);
			}
			else
			{
				toolStripStatusLabelInfo.Text = toolStripMenuItemDisplayTheSearchedDirectory.Checked ? path : string.Empty;
			}

			while (pauseRequested)
			{
				Thread.Sleep(millisecondsTimeout: 100); // Kurze Pause, damit die UI reagieren kann
				Application.DoEvents(); // Ermöglicht UI-Interaktion während der Pause
			}

			// If a stop request has been made, exit the method immediately.
			if (stopRequested)
			{
				return;
			}
			while (pauseRequested)
			{
				Thread.Sleep(millisecondsTimeout: 100);
				Application.DoEvents();
			}
			try
			{
				// Iterate through all subdirectories in the current path.
				foreach (string dir in Directory.GetDirectories(path: path))
				{
					// If a stop request has been made, exit the method.
					if (stopRequested)
					{
						return;
					}
					while (pauseRequested)
					{
						Thread.Sleep(millisecondsTimeout: 100);
						Application.DoEvents();
					}
					try
					{
						DirectoryInfo dirInfo = new(path: dir);
						// Skip hidden directories if 'includeHidden' is false.
						if (!includeHidden && dirInfo.Attributes.HasFlag(flag: FileAttributes.Hidden))
						{
							continue;
						}
						// Recursively search the subdirectory.
						SearchDirectory(path: dir, includeHidden: includeHidden, extensions: extensions);
					}
					catch (UnauthorizedAccessException ex)
					{
						// Show a warning if access to the directory is denied.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							ErrorMessage(caption: "Warning", text: $"Access denied: {dir}");
						}
						continue;
					}
					catch (Exception ex)
					{
						// Show a warning for any other directory access errors.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							ErrorMessage(caption: "Warning", text: $"Error accessing directory: {dir} ({ex.Message})");
						}
					}
				}

				// Iterate through all selected file extensions.
				foreach (string ext in extensions)
				{
					string[] files;
					try
					{
						// Get all files in the current directory matching the extension.
						files = Directory.GetFiles(path: path, searchPattern: "*" + ext);
					}
					catch (UnauthorizedAccessException ex)
					{
						// Show a warning if access to the files is denied.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							ErrorMessage(caption: "Warning", text: $"Access denied: {path}");
						}
						continue;
					}
					catch (Exception ex)
					{
						// Show a warning for any other file access errors.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							ErrorMessage(caption: "Warning", text: $"Error accessing files in: {path} ({ex.Message})");
						}
						continue;
					}

					// Iterate through all found files.
					foreach (string file in files)
					{
						// If a stop request has been made, exit the method.
						if (stopRequested)
						{
							return;
						}
						while (pauseRequested)
						{
							Thread.Sleep(millisecondsTimeout: 100);
							Application.DoEvents();
						}

						try
						{
							FileInfo fileInfo = new(fileName: file);
							// Skip hidden files if 'includeHidden' is false.
							if (!includeHidden && fileInfo.Attributes.HasFlag(flag: FileAttributes.Hidden))
							{
								continue;
							}

							// Add file details to the results list view on the UI thread.
							Invoke(method: () =>
							{
								IncrementAndUpdateFoundedFiles();
								// Create a new ListViewItem for the file.
								// The item contains the file name, directory, size, and last write time.
								ListViewItem item = new(text: fileInfo.Name);

								if (Path.GetExtension(path: fileInfo.Name).TrimStart(trimChar: '.').Equals(value: "ged", comparisonType: StringComparison.OrdinalIgnoreCase))
								{
									numberOfGedFiles++;
									item.Group = listViewGroupGed;
									if (toolStripMenuItemEnableStatistics.Checked)
									{
										listViewStatistics.Items[index: 2].SubItems[index: 1].Text = $"{numberOfGedFiles}";
									}
								}
								if (Path.GetExtension(path: fileInfo.Name).TrimStart(trimChar: '.').Equals(value: "ahn", comparisonType: StringComparison.OrdinalIgnoreCase))
								{
									numberOfAhnFiles++;
									item.Group = listViewGroupAhn;
									if (toolStripMenuItemEnableStatistics.Checked)
									{
										listViewStatistics.Items[index: 3].SubItems[index: 1].Text = $"{numberOfAhnFiles}";
									}
								}
								if (Path.GetExtension(path: fileInfo.Name).TrimStart(trimChar: '.').Equals(value: "ftb", comparisonType: StringComparison.OrdinalIgnoreCase))
								{
									numberOfFtbFiles++;
									item.Group = listViewGroupFtb;
									if (toolStripMenuItemEnableStatistics.Checked)
									{
										listViewStatistics.Items[index: 4].SubItems[index: 1].Text = $"{numberOfFtbFiles}";
									}
								}

								_ = item.SubItems.Add(text: fileInfo.DirectoryName);
								// Format the file size in bytes with thousands separator (international style).
								_ = item.SubItems.Add(text: fileInfo.Length.ToString(format: "N0", provider: System.Globalization.CultureInfo.InvariantCulture));
								_ = item.SubItems.Add(text: fileInfo.LastWriteTime.ToString());
								_ = listViewResults.Items.Add(value: item);

								// Auto-resize each column to fit the longest item (header or subitem)
								if (toolStripMenuItemAutoResizeColumns.Checked)
								{
									for (int col = 0; col < listViewResults.Columns.Count; col++)
									{
										listViewResults.AutoResizeColumn(columnIndex: col, headerAutoResize: ColumnHeaderAutoResizeStyle.ColumnContent);
									}
								}
							});
						}
						catch (UnauthorizedAccessException ex)
						{
							// Show a warning if access to the file is denied.
							if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
							{
								ErrorMessage(caption: "Warning", text: $"Access denied: {file}");
							}
							continue;
						}
						catch (Exception ex)
						{
							// Show a warning for any other file access errors.
							if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
							{
								ErrorMessage(caption: "Warning", text: $"Error accessing file: {file} ({ex.Message})");
							}
							continue;
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Show a warning a general error message.
				if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
				{
					ErrorMessage(caption: "Warning", text: $"General error: {ex.Message}");
				}
			}
		}

		/// <summary>
		/// Checks if a search operation is currently running and, if so, prompts the user to confirm exiting the application.
		/// If the user confirms, the application is closed; otherwise, the application remains open and the search continues.
		/// This method is typically called before closing the application to prevent accidental termination of an active search.
		/// </summary>
		private void ConfirmExitDuringSearch()
		{
			// If a search is currently running, prompt the user to confirm exit.
			if (searchRunning)
			{
				// Show a confirmation dialog before exiting if a search is in progress.
				DialogResult result = MessageBox.Show(
					text: "A search is currently running. Do you want to stop it and exit?",
					caption: "Confirm Exit",
					buttons: MessageBoxButtons.YesNo,
					icon: MessageBoxIcon.Question
				);
				// If the user confirms, stop the search and close the application.
				// If the user chooses not to stop the search, do not close the application.
				if (result == DialogResult.Yes)
				{
					Close();
				}
				else
				{
					return;
				}
			}
			else
			{
				Close();
			}
		}

		/// <summary>
		/// Opens a SaveFileDialog to let the user choose a file path and saves the contents of listViewStatistics as a CSV file.
		/// </summary>
		private void SaveListViewStatisticsToCsv()
		{
			if (listViewStatistics.Items.Count == 0)
			{
				_ = MessageBox.Show(text: "No results to save.", caption: "Export", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}

			// Open a SaveFileDialog to let the user choose where to save the CSV file.
			// The dialog allows the user to specify the file name and location for saving the results.
			using SaveFileDialog dialog = new(); // Create a new instance of SaveFileDialog
			dialog.Title = "Save Statistics as CSV"; // Set the title of the dialog
			dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Set the filter to show CSV files and all files
			dialog.DefaultExt = "csv"; // Set the default file extension to CSV
			dialog.AddExtension = true; // Automatically add the .csv extension if the user does not specify one
			dialog.FileName = "statistics.csv"; // Set the default file name for the saved file
			dialog.InitialDirectory = Environment.GetFolderPath(folder: Environment.SpecialFolder.MyDocuments); // Set the initial directory to the user's Documents folder
			dialog.RestoreDirectory = true; // Restore the directory after the dialog is closed
			dialog.OverwritePrompt = true; // Prompt if the file already exists
			dialog.CheckPathExists = true; // Ensure the path exists
			dialog.CreatePrompt = true; // Prompt to create the file if it doesn't exist
										// Show the dialog and check if the user clicked OK.
										// If the user selects a file and clicks OK, save the results to that file.
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				using StreamWriter writer = new(path: dialog.FileName, append: false, encoding: System.Text.Encoding.UTF8);

				// Write header row
				IEnumerable<string> headers = listViewStatistics.Columns
					.Cast<ColumnHeader>()
					.Select(selector: static col => EscapeCsv(input: col.Text));
				writer.WriteLine(value: string.Join(separator: ";", values: headers));

				// Write data rows
				foreach (ListViewItem item in listViewStatistics.Items)
				{
					IEnumerable<string> fields = item.SubItems
						.Cast<ListViewItem.ListViewSubItem>()
						.Select(selector: static sub => EscapeCsv(input: sub.Text));
					writer.WriteLine(value: string.Join(separator: ";", values: fields));
				}

				_ = MessageBox.Show(text: "Results successfully saved.", caption: "Export", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Opens a SaveFileDialog to let the user choose a file path and saves the contents of listViewResults as a CSV file.
		/// </summary>
		private void SaveListViewResultsToCsv()
		{
			// Check if there are any results to save.
			if (listViewResults.Items.Count == 0)
			{
				_ = MessageBox.Show(text: "No results to save.", caption: "Export", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}

			// Open a SaveFileDialog to let the user choose where to save the CSV file.
			// The dialog allows the user to specify the file name and location for saving the results.
			using SaveFileDialog dialog = new(); // Create a new instance of SaveFileDialog
			dialog.Title = "Save Results as CSV"; // Set the title of the dialog
			dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Set the filter to show CSV files and all files
			dialog.DefaultExt = "csv"; // Set the default file extension to CSV
			dialog.AddExtension = true; // Automatically add the .csv extension if the user does not specify one
			dialog.FileName = "results.csv"; // Set the default file name for the saved file
			dialog.InitialDirectory = Environment.GetFolderPath(folder: Environment.SpecialFolder.MyDocuments); // Set the initial directory to the user's Documents folder
			dialog.RestoreDirectory = true; // Restore the directory after the dialog is closed
			dialog.OverwritePrompt = true; // Prompt if the file already exists
			dialog.CheckPathExists = true; // Ensure the path exists
			dialog.CreatePrompt = true; // Prompt to create the file if it doesn't exist
										// Show the dialog and check if the user clicked OK.
										// If the user selects a file and clicks OK, save the results to that file.
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				using StreamWriter writer = new(path: dialog.FileName, append: false, encoding: System.Text.Encoding.UTF8);

				// Write header row
				IEnumerable<string> headers = listViewResults.Columns
					.Cast<ColumnHeader>()
					.Select(selector: static col => EscapeCsv(input: col.Text));
				writer.WriteLine(value: string.Join(separator: ";", values: headers));

				// Write data rows
				foreach (ListViewItem item in listViewResults.Items)
				{
					IEnumerable<string> fields = item.SubItems
						.Cast<ListViewItem.ListViewSubItem>()
						.Select(selector: static sub => EscapeCsv(input: sub.Text));
					writer.WriteLine(value: string.Join(separator: ";", values: fields));
				}

				_ = MessageBox.Show(text: "Results successfully saved.", caption: "Export", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Escapes a string for CSV output (encloses in quotes if needed and escapes quotes).
		/// </summary>
		/// <param name="input">The string to escape.</param>
		/// <returns>The escaped string.</returns>
		private static string EscapeCsv(string input)
		{
			return input.Contains(value: ';') || input.Contains(value: '"') || input.Contains(value: '\n')
				? $"\"{input.Replace(oldValue: "\"", newValue: "\"\"")}\""
				: input;
		}

		private void AddGroupsToResultList()
		{
			_ = listViewResults.Groups.Add(group: listViewGroupGed);
			_ = listViewResults.Groups.Add(group: listViewGroupAhn);
			_ = listViewResults.Groups.Add(group: listViewGroupFtb);
		}

		#endregion

		#region Click event handlers

		private void ButtonOpenFile_Click(object sender, EventArgs e) => OpenFile();

		private void ToolStripMenuItemOpenFile_Click(object sender, EventArgs e) => OpenFile();

		private void ButtonOpenFolder_Click(object sender, EventArgs e) => OpenFolder();

		private void ToolStripMenuItemOpenFolder_Click(object sender, EventArgs e) => OpenFolder();

		/// <summary>
		/// Handles the click event for the "Show Properties" button.
		/// If a file is selected in the results ListView, opens the Windows file properties dialog for that file.
		/// If no file is selected, displays an error message.
		/// </summary>
		/// <param name="sender">The event source (toolbar button).</param>
		/// <param name="e">The event data.</param>
		private void ButtonShowProperties_Click(object sender, EventArgs e) => ShowProperties();

		/// <summary>
		/// Handles the click event for the "Show Properties" toolstrip menu item.
		/// If a file is selected in the results ListView, opens the Windows file properties dialog for that file.
		/// If no file is selected, displays an error message.
		/// </summary>
		/// <param name="sender">The event source (toolbar button).</param>
		/// <param name="e">The event data.</param>
		private void ToolStripMenuItemShowProperties_Click(object sender, EventArgs e) => ShowProperties();

		private void ButtonCopyFile_Click(object sender, EventArgs e) => CopyFile();

		private void ToolStripMenuItemCopyFile_Click(object sender, EventArgs e) => CopyFile();

		private void ButtonMoveFile_Click(object sender, EventArgs e) => MoveFile();

		private void ToolStripMenuItemMoveFile_Click(object sender, EventArgs e) => MoveFile();

		private void ButtonDeleteFile_Click(object sender, EventArgs e) => DeleteFile();

		private void ToolStripMenuItemDeleteFile_Click(object sender, EventArgs e) => DeleteFile();

		private void ButtonBackupFile_Click(object sender, EventArgs e) => BackupFile();

		private void ToolStripMenuItemBackupFile_Click(object sender, EventArgs e) => BackupFile();

		/// <summary>
		/// Handles the click event for the search button.
		/// Starts the search operation asynchronously.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private async void ButtonSearch_Click(object sender, EventArgs e)
		{
			numberOfAhnFiles = 0;
			numberOfFtbFiles = 0;
			numberOfGedFiles = 0;

			for (int i = 0; i < 5; i++)
			{
				listViewStatistics.Items[index: i].SubItems[index: 1].Text = string.Empty;
			}

			// Set the searchRunning flag to true to indicate a search is in progress.
			searchRunning = true;

			// Clear previous search results from the list view.
			listViewResults.Items.Clear();

			// Reset the count of files found in this search operation.
			ResetAndUpdateFoundedFiles();

			// Start the stopwatch and timer for elapsed time.
			searchStopwatch.Restart();
			searchTimer.Start();
			listViewStatistics.Items[index: 1].SubItems[index: 1].Text = $"00:00:00";

			// Disable the start button to prevent multiple searches.
			// Enable the stop, pause and refresh buttons during the search operation.
			toolStripButtonStart.Enabled = false;
			toolStripButtonPause.Enabled = true;
			toolStripButtonStop.Enabled = true;
			toolStripButtonRefresh.Enabled = false;

			// Reset the stop request flag.
			stopRequested = false;

			// Determine whether hidden folders should be included in the search.
			bool includeHidden = toolStripMenuItemIncludeHiddenFiles.Checked;

			// Get the list of drives selected by the user.
			List<string> selectedDrives = [.. checkedListBoxDrives.CheckedItems.Cast<string>()];

			// Check if at least one drive is selected; if not, show a warning and abort the search.
			if (selectedDrives.Count == 0)
			{
				_ = MessageBox.Show(
					text: "Please select at least one drive before starting the search.",
					caption: "No Drive Selected",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Warning
				);
				toolStripButtonStart.Enabled = true;
				toolStripButtonPause.Enabled = false;
				toolStripButtonStop.Enabled = false;
				toolStripButtonRefresh.Enabled = true;
				toolStripStatusLabelInfo.Text = "No drive selected.";
				searchTimer.Stop();
				listViewStatistics.Items[index: 1].SubItems[index: 1].Text = $"00:00:00";
				return;
			}

			// Get the list of file extensions selected by the user.
			string[] selectedExtensions = GetSelectedExtensions();

			// Check if at least one extension is selected; if not, show a warning and abort the search.
			if (selectedExtensions.Length == 0)
			{
				_ = MessageBox.Show(
					text: "Please select at least one file extension before starting the search.",
					caption: "No Extension Selected",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Warning
				);
				toolStripButtonStart.Enabled = true;
				toolStripButtonPause.Enabled = true;
				toolStripButtonStop.Enabled = false;
				toolStripButtonRefresh.Enabled = true;
				toolStripStatusLabelInfo.Text = "No extension selected.";
				searchTimer.Stop();
				listViewStatistics.Items[index: 1].SubItems[index: 1].Text = $"00:00:00";
				return;
			}

			AddGroupsToResultList();

			// Perform the search asynchronously for each selected drive.
			foreach (string? drive in selectedDrives)
			{
				await Task.Run(action: () => SearchDirectory(path: drive, includeHidden: includeHidden, extensions: selectedExtensions));
				// If a stop request was made, exit the loop early.
				if (stopRequested)
				{
					break;
				}
			}

			// Stop the stopwatch and timer after the search is complete.
			searchStopwatch.Stop();
			searchTimer.Stop();
			// Update the elapsed time label including milliseconds (format: hh:mm:ss.fff)
			if (toolStripMenuItemEnableStatistics.Checked)
			{
				listViewStatistics.Items[index: 1].SubItems[index: 1].Text = $"{searchStopwatch.Elapsed:hh\\:mm\\:ss\\.fff}";
			}
			// Reset the search running flag to indicate the search has completed.
			searchRunning = false;

			// Re-enable the start button and disable the stop and refresh buttons after the search.
			// Update the status label to indicate whether the search was stopped or completed.
			toolStripButtonStart.Enabled = true;
			toolStripButtonPause.Enabled = false;
			toolStripButtonStop.Enabled = false;
			toolStripButtonRefresh.Enabled = true;
			toolStripStatusLabelInfo.Text = stopRequested ? "Stopped" : "Done";
			// If the display search complete option is checked, show a message box with the search result.
			if (toolStripMenuItemDisplaySearchComplete.Checked)
			{
				// Show a message box indicating the search is complete.
				_ = MessageBox.Show(
					text: stopRequested ? "Search stopped." : "Search completed successfully.",
					caption: "Search Result",
					buttons: MessageBoxButtons.OK,
					icon: stopRequested ? MessageBoxIcon.Information : MessageBoxIcon.Information
				);
			}
		}

		/// <summary>
		/// Handles the click event for the stop button.
		/// Requests the search operation to stop.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonStop_Click(object sender, EventArgs e) => stopRequested = searchRunning = true;

		/// <summary>
		/// Handles the click event for the refresh button.
		/// Reloads the drives and extensions and clears the search results.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			// Reload the list of available drives and file extensions in the UI.
			LoadDrives();
			LoadExtensions();
			ClearResultList();
		}

		/// <summary>
		/// Handles the click event for the info button.
		/// Displays a message box with the program name, version number, and a description of the application.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ToolStripButtonInfo_Click(object sender, EventArgs e)
		{
			// Get assembly information for program name and version
			string? name = AssemblyInfo.AssemblyTitle;
			string version = AssemblyInfo.AssemblyVersion;

			// Program description (customize as needed)
			string description = "Genealogical File Catalog - Search and manage genealogical files on selected drives.";

			// Build the message text
			string message = $"{name} v{version}\n\n{description}";

			// Show the information message box
			_ = MessageBox.Show(
				text: message,
				caption: "Program Information",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Information
			);
		}

		/// <summary>
		/// Handles the click event for the exit button in the toolbar.
		/// If a search operation is currently running, prompts the user to confirm exit and optionally stops the search.
		/// Closes the application window if confirmed or if no search is running.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ToolStripButtonExit_Click(object sender, EventArgs e)
		{
			if (toolStripMenuItemAskToCloseDuringSearch.Checked)
			{
				// If the user has opted to be asked before closing during a search, check if a search is running.
				ConfirmExitDuringSearch();
			}
			else
			{
				Close();
			}
		}

		/// <summary>
		/// Handles the click event for the pause button in the toolbar.
		/// Toggles the search operation between paused and resumed states.
		/// When paused, the search process waits and the stop button is disabled.
		/// When resumed, the search continues and the stop button is enabled again.
		/// The button text is updated to reflect the current action (Pause/Resume).
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ToolStripButtonPause_Click(object sender, EventArgs e)
		{
			if (pauseRequested)
			{
				// If the search is paused, resume it.
				ResumeSearch();
				toolStripButtonPause.Text = "&Pause";
				toolStripButtonStop.Enabled = true;
			}
			else
			{
				// If the search is running, pause it.
				PauseSearch();
				toolStripButtonPause.Text = "&Resume";
				toolStripButtonStop.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the click event for the "Save to CSV" toolbar button.
		/// Opens a SaveFileDialog and saves the contents of the ListView results to a CSV file
		/// if the user selects a file location.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ToolStripButtonSaveToCsv_Click(object sender, EventArgs e) => SaveListViewResultsToCsv();

		private void ToolStripMenuItemEnableStatistics_Click(object sender, EventArgs e) => groupBoxStatistics.Enabled = toolStripMenuItemEnableStatistics.Checked;

		private void ToolStripMenuItemStatisticsSaveAsCsv_Click(object sender, EventArgs e) => SaveListViewStatisticsToCsv();

		private void ToolStripMenuItemDrivesMarkAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBoxDrives.Items.Count; i++)
			{
				checkedListBoxDrives.SetItemChecked(index: i, value: true);
			}
		}

		private void ToolStripMenuItemDrivesRefresh_Click(object sender, EventArgs e) => LoadDrives();

		private void ToolStripMenuItemExtensionsMarkAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBoxExtensions.Items.Count; i++)
			{
				checkedListBoxExtensions.SetItemChecked(index: i, value: true);
			}
		}

		private void ToolStripMenuItemExtensionsRefreshList_Click(object sender, EventArgs e) => LoadExtensions();

		#endregion

		#region DoubleClick event handlers

		private void ListViewResults_DoubleClick(object sender, EventArgs e) => ShowProperties();

		private void ToolStripMenuItemIconThemeFatcow_Click(object sender, EventArgs e)
		{
			toolStripMenuItemIconThemeFatcow.Checked = true;
			toolStripMenuItemIconThemeXCollection.Checked = false;
			toolStripMenuItemIconThemeOCollection.Checked = false;
			toolStripMenuItemIconThemeICollection.Checked = false;
			SetIconThemeFatcow();
		}

		private void ToolStripMenuItemIconThemeXCollection_Click(object sender, EventArgs e)
		{
			toolStripMenuItemIconThemeFatcow.Checked = false;
			toolStripMenuItemIconThemeXCollection.Checked = true;
			toolStripMenuItemIconThemeOCollection.Checked = false;
			toolStripMenuItemIconThemeICollection.Checked = false;
			SetIconThemeXCollection();
		}

		private void ToolStripMenuItemIconThemeOCollection_Click(object sender, EventArgs e)
		{
			toolStripMenuItemIconThemeFatcow.Checked = false;
			toolStripMenuItemIconThemeXCollection.Checked = false;
			toolStripMenuItemIconThemeOCollection.Checked = true;
			toolStripMenuItemIconThemeICollection.Checked = false;
			SetIconThemeOCollection();
		}

		private void ToolStripMenuItemIconThemeICollection_Click(object sender, EventArgs e)
		{
			toolStripMenuItemIconThemeFatcow.Checked = false;
			toolStripMenuItemIconThemeXCollection.Checked = false;
			toolStripMenuItemIconThemeOCollection.Checked = false;
			toolStripMenuItemIconThemeICollection.Checked = true;
			SetIconThemeICollectionPlain();
		}

		#endregion

		#region Tick event handlers

		/// <summary>
		/// Updates the labelTimeElapsed with the current elapsed time.
		/// </summary>
		private void SearchTimer_Tick(object? sender, EventArgs e)
		{
			// Update the elapsed time label including milliseconds (format: hh:mm:ss.fff)
			if (toolStripMenuItemEnableStatistics.Checked)
			{
				listViewStatistics.Items[index: 1].SubItems[index: 1].Text = $"{searchStopwatch.Elapsed:hh\\:mm\\:ss\\.fff}";
			}
		}

		#endregion

		#region ItemCheck event handlers

		/// <summary>
		/// Handles the item check event for the drives checklist.
		/// Prevents the user from unchecking the last remaining drive.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void CheckedListBoxDrives_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// If the user tries to uncheck the last remaining drive, prevent this action.
			if (e.NewValue == CheckState.Unchecked && checkedListBoxDrives.CheckedItems.Count == 1)
			{
				// Force the last drive to remain checked to ensure at least one drive is always selected.
				e.NewValue = CheckState.Checked;
			}
		}

		/// <summary>
		/// Handles the item check event for the extensions checklist.
		/// Prevents the user from unchecking the last remaining extension.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void CheckedListBoxExtensions_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// If the user tries to uncheck the last remaining drive, prevent this action.
			if (e.NewValue == CheckState.Unchecked && checkedListBoxExtensions.CheckedItems.Count == 1)
			{
				// Force the last drive to remain checked to ensure at least one drive is always selected.
				e.NewValue = CheckState.Checked;
			}
		}

		#endregion

		#region ColumnClick event handlers

		/// <summary>
		/// Handles the column click event for the results ListView.
		/// Sorts the ListView items by the clicked column. If the same column is clicked again,
		/// the sort order is toggled between ascending and descending. Otherwise, sorting starts in ascending order.
		/// </summary>
		/// <param name="sender">The event source (ListView).</param>
		/// <param name="e">The event data containing the clicked column index.</param>
		private void ListViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// If the same column is clicked, reverse the sort order.
			if (e.Column == sortColumn)
			{
				// Toggle between ascending and descending sort order.
				listViewResults.Sorting = listViewResults.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Set the new sort column and start with ascending order.
				sortColumn = e.Column;
				listViewResults.Sorting = SortOrder.Ascending;
			}
			// Assign a custom comparer to sort the items based on the selected column and order.
			listViewResults.ListViewItemSorter = new ListViewItemComparer(column: e.Column, sortOrder: listViewResults.Sorting);
			// Perform the sort operation.
			listViewResults.Sort();
		}

		#endregion


		private void ListViewResults_ItemActivate(object sender, EventArgs e)
		{
			// Check if an item is selected in the ListView.
			if (listViewResults.SelectedItems.Count > 0)
			{
				// Get the first selected item.
				ListViewItem selectedItem = listViewResults.SelectedItems[index: 0];
				// Get the file path from the second subitem (directory).
				string? filePath = selectedItem.SubItems[index: 1].Text + "\\" + selectedItem.SubItems[index: 0].Text;
				// If the file path is not empty, open the file in the default application.
				if (!string.IsNullOrEmpty(value: filePath))
				{
					try
					{
						// Open the file using the default application associated with its type.
						//_ = Process.Start(startInfo: new ProcessStartInfo(fileName: filePath) { UseShellExecute = true });
					}
					catch (Exception ex)
					{
						// Show an error message if there was an issue opening the file.
						ErrorMessage(caption: "Error", text: $"Error opening file: {ex.Message}");
					}
				}
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		/// <summary>
		/// Custom comparer for ListView items.
		/// </summary>
		internal class ListViewItemComparer(int column, SortOrder sortOrder) : System.Collections.IComparer
		{
			// Store the column index to be sorted.
			private readonly int col = column;
			// Store the sort order (ascending or descending).
			private readonly SortOrder order = sortOrder;

			/// <summary>
			/// Compares two ListViewItem objects for sorting in a ListView control.
			/// The comparison is performed on the specified column. If both values can be parsed as numbers,
			/// a numeric comparison is used; otherwise, a case-insensitive string comparison is performed.
			/// The result is returned according to the selected sort order (ascending or descending).
			/// </summary>
			/// <param name="x">The first object to compare (should be a ListViewItem).</param>
			/// <param name="y">The second object to compare (should be a ListViewItem).</param>
			/// <returns>
			/// Less than zero if x is less than y, zero if they are equal, greater than zero if x is greater than y,
			/// according to the specified sort order.
			/// </returns>
			public int Compare(object? x, object? y)
			{
				// Ensure both objects are ListViewItem instances.
				if (x is not ListViewItem itemX || y is not ListViewItem itemY)
				{
					return 0;
				}

				// Get the text of the subitem for the specified column.
				string a = itemX.SubItems[index: col].Text;
				string b = itemY.SubItems[index: col].Text;

				// Try to compare as numbers if possible, otherwise compare as strings.
				int result = decimal.TryParse(s: a.Replace(oldValue: ",", newValue: ""), result: out decimal da) && decimal.TryParse(s: b.Replace(oldValue: ",", newValue: ""), result: out decimal db)
					? da.CompareTo(value: db)
					: string.Compare(strA: a, strB: b, comparisonType: StringComparison.CurrentCultureIgnoreCase);

				// Return the result based on the selected sort order.
				return order == SortOrder.Ascending ? result : -result;
			}
		}
	}
}

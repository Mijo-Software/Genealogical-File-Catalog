using System.IO;

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
		private bool stopRequested = false;

		private int filesFound;

		/// <summary>
		/// Implements sorting for the ListView columns.
		/// </summary>
		private int sortColumn = -1;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// Sets up the UI components and loads available drives and file extensions.
		/// </summary>
		public MainForm()
		{
			// Initialize all UI components and controls defined in the designer.
			InitializeComponent();

			// Load available drives and file extensions into the corresponding UI controls.
			LoadDrivesAndExtensions();

			// Disable the stop button at startup, since no search is running.
			toolStripButtonStop.Enabled = false;
		}

		/// <summary>
		/// Increments the count of files found in this search operation.
		/// </summary>
		private void IncrementAndUpdateFoundedFiles()
		{
			// Increment the count of files found in this search operation.
			filesFound++;
			// Update the status label to show the current count of files found.
			labelFilesFound.Text = $"Files Found: {filesFound}";
		}

		/// <summary>
		/// Reset the count of files found in this search operation.
		/// </summary>
		private void ResetAndUpdateFoundedFiles()
		{
			// Set the count of files found to zero in this search operation.
			filesFound = 0;
			// Update the status label to show the current count of files found.
			labelFilesFound.Text = $"Files found: {filesFound}";
		}

		/// <summary>
		/// Loads all available drives and predefined file extensions into the corresponding UI controls.
		/// </summary>
		private void LoadDrivesAndExtensions()
		{
			// Clear all items from the drives checklist to prepare for reloading.
			checkedListBoxDrives.Items.Clear();

			// Add all available and ready drives to the checklist, initially unchecked.
			foreach (DriveInfo? drive in DriveInfo.GetDrives().Where(d => d.IsReady))
			{
				_ = checkedListBoxDrives.Items.Add(item: drive.Name, isChecked: false);
			}

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
		/// Gets the file extensions selected by the user.
		/// </summary>
		/// <returns>An array of selected file extensions.</returns>
		private string[] GetSelectedExtensions() => [.. checkedListBoxExtensions.CheckedItems.Cast<string>()];

		/// <summary>
		/// Recursively searches the specified directory for files matching the given extensions.
		/// Optionally includes hidden files and directories.
		/// Errors are logged to the status bar and skipped.
		/// </summary>
		/// <param name="path">The directory path to search.</param>
		/// <param name="includeHidden">Whether to include hidden files and directories.</param>
		/// <param name="extensions">The file extensions to search for.</param>
		private void SearchDirectory(string path, bool includeHidden, string[] extensions)
		{
			// Display the current search path in the status bar.
			toolStripStatusLabelInfo.Text = toolStripMenuItemDisplayTheSearchedDirectory.Checked ? path : string.Empty;

			// If a stop request has been made, exit the method immediately.
			if (stopRequested)
			{
				return;
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
							_ = MessageBox.Show(text: $"Access denied: {dir}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
						}

						continue;
					}
					catch (Exception ex)
					{
						// Show a warning for any other directory access errors.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							_ = MessageBox.Show(text: $"Error accessing directory: {dir} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
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
							_ = MessageBox.Show(text: $"Access denied: {path}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
						}

						continue;
					}
					catch (Exception ex)
					{
						// Show a warning for any other file access errors.
						if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
						{
							_ = MessageBox.Show(text: $"Error accessing files in: {path} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
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

						try
						{
							FileInfo fileInfo = new(fileName: file);
							// Skip hidden files if 'includeHidden' is false.
							if (!includeHidden && fileInfo.Attributes.HasFlag(flag: FileAttributes.Hidden))
							{
								continue;
							}

							// Add file details to the results list view on the UI thread.
							Invoke(() =>
							{
								IncrementAndUpdateFoundedFiles();
								// Create a new ListViewItem for the file.
								// The item contains the file name, directory, size, and last write time.
								ListViewItem item = new(text: fileInfo.Name);
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
								_ = MessageBox.Show(text: $"Access denied: {file}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
							}

							continue;
						}
						catch (Exception ex)
						{
							// Show a warning for any other file access errors.
							if (!toolStripMenuItemSuppressWarningsAndErrorsOnSearch.Checked)
							{
								_ = MessageBox.Show(text: $"Error accessing file: {file} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
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
					_ = MessageBox.Show(text: $"General error: {ex.Message}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Handles the click event for the search button.
		/// Starts the search operation asynchronously.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private async void ButtonSearch_Click(object sender, EventArgs e)
		{
			// Clear previous search results from the list view.
			listViewResults.Items.Clear();

			ResetAndUpdateFoundedFiles();

			// Disable the start button to prevent multiple searches.
			// Enable the stop and refresh buttons during the search operation.
			toolStripSplitButtonStart.Enabled = false;
			toolStripButtonStop.Enabled = true;
			toolStripButtonRefresh.Enabled = false;

			// Reset the stop request flag.
			stopRequested = false;

			// Determine whether hidden folders should be included in the search.
			bool includeHidden = toolStripMenuItemIncludeHiddenFolders.Checked;

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
				toolStripSplitButtonStart.Enabled = true;
				toolStripButtonStop.Enabled = false;
				toolStripButtonRefresh.Enabled = true;
				toolStripStatusLabelInfo.Text = "No drive selected.";
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
				toolStripSplitButtonStart.Enabled = true;
				toolStripButtonStop.Enabled = false;
				toolStripButtonRefresh.Enabled = true;
				toolStripStatusLabelInfo.Text = "No extension selected.";
				return;
			}

			// Perform the search asynchronously for each selected drive.
			foreach (string? drive in selectedDrives)
			{
				await Task.Run(() => SearchDirectory(path: drive, includeHidden: includeHidden, extensions: selectedExtensions));
				// If a stop request was made, exit the loop early.
				if (stopRequested)
				{
					break;
				}
			}

			// Re-enable the start button and disable the stop and refresh buttons after the search.
			// Update the status label to indicate whether the search was stopped or completed.
			toolStripSplitButtonStart.Enabled = true;
			toolStripButtonStop.Enabled = false;
			toolStripButtonRefresh.Enabled = true;
			toolStripStatusLabelInfo.Text = stopRequested ? "Stopped" : "Done";
		}

		/// <summary>
		/// Handles the click event for the stop button.
		/// Requests the search operation to stop.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonStop_Click(object sender, EventArgs e) => stopRequested = true;

		/// <summary>
		/// Handles the click event for the refresh button.
		/// Reloads the drives and extensions and clears the search results.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonRefresh_Click(object sender, EventArgs e)
		{
			// Reload the list of available drives and file extensions in the UI.
			LoadDrivesAndExtensions();

			// Clear all previous search results from the results list view.
			listViewResults.Items.Clear();
		}

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

		private void ListViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// If the same column is clicked, reverse the sort order.
			if (e.Column == sortColumn)
			{
				listViewResults.Sorting = listViewResults.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				sortColumn = e.Column;
				listViewResults.Sorting = SortOrder.Ascending;
			}
			listViewResults.ListViewItemSorter = new ListViewItemComparer(column: e.Column, sortOrder: listViewResults.Sorting);
			listViewResults.Sort();
		}

		private void ToolStripButtonExit_Click(object sender, EventArgs e) => Close();
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

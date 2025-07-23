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

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// Sets up the UI components and loads available drives and file extensions.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			LoadDrivesAndExtensions();
			toolStripButtonStop.Enabled = false;
		}

		/// <summary>
		/// Loads all available drives and predefined file extensions into the corresponding UI controls.
		/// </summary>
		private void LoadDrivesAndExtensions()
		{
			checkedListBoxDrives.Items.Clear();
			foreach (DriveInfo? drive in DriveInfo.GetDrives().Where(d => d.IsReady))
			{
				_ = checkedListBoxDrives.Items.Add(item: drive.Name, isChecked: false);
			}

			checkedListBoxExtensions.Items.Clear();
			checkedListBoxExtensions.Items.AddRange(items: [".ged", ".ahn", ".ftb"]);
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
			toolStripStatusLabelInfo.Text = path;

			if (stopRequested)
			{
				return;
			}

			try
			{
				foreach (string dir in Directory.GetDirectories(path: path))
				{
					if (stopRequested)
					{
						return;
					}

					try
					{
						DirectoryInfo dirInfo = new(path: dir);
						if (!includeHidden && dirInfo.Attributes.HasFlag(flag: FileAttributes.Hidden))
						{
							continue;
						}

						SearchDirectory(path: dir, includeHidden: includeHidden, extensions: extensions);
					}
					catch (UnauthorizedAccessException ex)
					{
						_ = MessageBox.Show(text: $"Access denied: {dir}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
						continue;
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error accessing directory: {dir} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
					}
				}

				foreach (string ext in extensions)
				{
					string[] files;
					try
					{
						files = Directory.GetFiles(path: path, searchPattern: "*" + ext);
					}
					catch (UnauthorizedAccessException ex)
					{
						_ = MessageBox.Show(text: $"Access denied: {path}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
						continue;
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error accessing files in: {path} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
						continue;
					}

					foreach (string file in files)
					{
						if (stopRequested)
						{
							return;
						}

						try
						{
							FileInfo fileInfo = new(fileName: file);
							if (!includeHidden && fileInfo.Attributes.HasFlag(flag: FileAttributes.Hidden))
							{
								continue;
							}

							Invoke(() =>
							{
								ListViewItem item = new(text: fileInfo.Name);
								_ = item.SubItems.Add(text: fileInfo.DirectoryName);
								_ = item.SubItems.Add(text: fileInfo.Length.ToString());
								_ = item.SubItems.Add(text: fileInfo.LastWriteTime.ToString());
								_ = listViewResults.Items.Add(value: item);
							});
						}
						catch (UnauthorizedAccessException ex)
						{
							_ = MessageBox.Show(text: $"Access denied: {file}", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
							continue;
						}
						catch (Exception ex)
						{
							_ = MessageBox.Show(text: $"Error accessing file: {file} ({ex.Message})", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
							continue;
						}
					}
				}
			}
			catch (Exception ex)
			{
				toolStripStatusLabelInfo.Text = $"General error: {ex.Message}";
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
			listViewResults.Items.Clear();
			toolStripSplitButtonStart.Enabled = false;
			toolStripButtonStop.Enabled = true;
			stopRequested = false;

			bool includeHidden = checkBoxIncludeHidden.Checked;
			List<string> selectedDrives = [.. checkedListBoxDrives.CheckedItems.Cast<string>()];
			string[] selectedExtensions = GetSelectedExtensions();

			foreach (string? drive in selectedDrives)
			{
				await Task.Run(() => SearchDirectory(path: drive, includeHidden: includeHidden, extensions: selectedExtensions));
				if (stopRequested)
				{
					break;
				}
			}

			toolStripSplitButtonStart.Enabled = true;
			toolStripButtonStop.Enabled = false;
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
			LoadDrivesAndExtensions();
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
			if (e.NewValue == CheckState.Unchecked && checkedListBoxDrives.CheckedItems.Count == 1)
			{
				e.NewValue = CheckState.Checked; // Prevent unchecking the last drive
			}
		}
	}
}

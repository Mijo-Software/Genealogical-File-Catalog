namespace GenealogicalFileCatalog
{
	/// <summary>
	/// A ListView control with double buffering enabled to reduce flickering
	/// when adding or updating items.
	/// </summary>
	public class BufferedListView : ListView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BufferedListView"/> class
		/// and enables double buffering for smoother rendering.
		/// </summary>
		public BufferedListView()
		{
			// Enable double buffering to avoid flickering
			SetStyle(flag: ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, value: true);
			UpdateStyles();
		}
	}
}
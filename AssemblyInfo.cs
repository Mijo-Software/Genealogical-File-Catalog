using System.IO;
using System.Reflection;

namespace GenealogicalFileCatalog
{
	/// <summary>
	/// Provide some assembly information
	/// </summary>
	public static class AssemblyInfo
	{
		//private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		#region Assembly attribute accessors

		/// <summary>
		/// Return the title of the assembly
		/// </summary>
		public static string AssemblyTitle
		{
			get
			{
				try
				{
					object[] attributes = Assembly.GetExecutingAssembly()
						.GetCustomAttributes(attributeType: typeof(AssemblyTitleAttribute), inherit: false);
					return attributes.Length > 0 && attributes[0] is AssemblyTitleAttribute titleAttribute
						? !string.IsNullOrEmpty(value: titleAttribute.Title) ? titleAttribute.Title : Path.GetFileNameWithoutExtension(path: Assembly.GetExecutingAssembly().Location)
						: Path.GetFileNameWithoutExtension(path: Assembly.GetExecutingAssembly().Location);
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly title.");
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Return the version of the assembly
		/// </summary>
		public static string AssemblyVersion
		{
			get
			{
				try
				{
					return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly version.");
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Return the description of the assembly
		/// </summary>
		public static string AssemblyDescription
		{
			get
			{
				try
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(attributeType: typeof(AssemblyDescriptionAttribute), inherit: false);
					return attributes.Length == 0 ? string.Empty : ((AssemblyDescriptionAttribute)attributes[0]).Description;
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly description.");
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Return the product name of the assembly
		/// </summary>
		public static string AssemblyProduct
		{
			get
			{
				try
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(attributeType: typeof(AssemblyProductAttribute), inherit: false);
					return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute)attributes[0]).Product;
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly product.");
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Return the copyright of the assembly
		/// </summary>
		public static string AssemblyCopyright
		{
			get
			{
				try
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(attributeType: typeof(AssemblyCopyrightAttribute), inherit: false);
					return attributes.Length == 0 ? string.Empty : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly copyright.");
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Return the company name of the assembly
		/// </summary>
		public static string AssemblyCompany
		{
			get
			{
				try
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(attributeType: typeof(AssemblyCompanyAttribute), inherit: false);
					return attributes.Length == 0 ? string.Empty : ((AssemblyCompanyAttribute)attributes[0]).Company;
				}
				catch (Exception)
				{
					//Logger.Error(exception: ex, message: "An error occurred while retrieving the assembly company.");
					return string.Empty;
				}
			}
		}

		#endregion
	}
}
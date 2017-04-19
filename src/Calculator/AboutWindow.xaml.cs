/**************************************************************
 * Team:      Disassembler
 * 
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Navigation;

namespace Disassembler.Calculator
{
	/// <summary>
	///     Interaction logic for AboutWindow.xaml.
	/// </summary>
	public partial class AboutWindow : Window
	{
		/// Documentation path.
		private const string DocPath = "\\doc\\documentation.pdf";

		/// <summary>
		///     AboutWindow construct.
		/// </summary>
		public AboutWindow()
		{
			this.InitializeComponent();
		}

		/// <summary>
		///     Process GitHub sources hyperlik click.
		///     Redirect to GitHub repository.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RequestNavigateEventArgs.</param>
		private void GitHubSourcesHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		/// <summary>
		///     Process documentation hyperlik click.
		///     Open documentation in PDF format.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void DocumentationHyperlink_Click(object sender, RoutedEventArgs e)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + DocPath;
			if (File.Exists(path))
			{
				Process.Start(path);
			}
		}
	}
}

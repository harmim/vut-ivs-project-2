/**************************************************************
 * Team:      Disassembler
 * 
 * Authors:   Vojtìch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace Calculator
{
	/// <summary>
	///     Interaction logic for AboutWindow.xaml
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			InitializeComponent();
		}

		private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		private void OpenFile(object sender, RoutedEventArgs e)
		{
			var appPath = AppDomain.CurrentDomain.BaseDirectory;
			Process.Start(appPath + "\\doc\\doc.pdf");
		}
	}
}

/**************************************************************
 * Team:      Disassembler
 * 
 * Authors:   Vojtìch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System.Windows;
using System.Windows.Input;

namespace Calculator
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TextLog_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			var Scroll = TextLog.HorizontalOffset;
			if (e.Delta > 0)
			{
				Scroll -= 15;
				TextLog.ScrollToHorizontalOffset(Scroll);
			}
			else
			{
				Scroll += 15;
				TextLog.ScrollToHorizontalOffset(Scroll);
			}
			TextLog.UpdateLayout();
			e.Handled = true;
		}

		private void AboutItem_Click(object sender, RoutedEventArgs e)
		{
			var about = new AboutWindow();
			about.ShowDialog();
		}

		private void Button0_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button2_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button3_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button4_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button5_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button6_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button7_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button8_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Button9_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonComma_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonAns_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonPlus_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMinus_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMul_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonDiv_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCE_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonInv_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonFact_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonExp_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonLog_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMC_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMR_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMPlus_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMMinus_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonMSet_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
		}
	}
}

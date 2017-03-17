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
		private bool IsAnswer;

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
			PrintNumAns("0");
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("1");
		}

		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("2");
		}

		private void Button3_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("3");
		}

		private void Button4_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("4");
		}

		private void Button5_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("5");
		}

		private void Button6_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("6");
		}

		private void Button7_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("7");
		}

		private void Button8_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("8");
		}

		private void Button9_Click(object sender, RoutedEventArgs e)
		{
			PrintNumAns("9");
		}

		private void ButtonComma_Click(object sender, RoutedEventArgs e)
		{
			PrintComma();
		}

		private void ButtonAns_Click(object sender, RoutedEventArgs e)
		{
			Enter();
		}

		private void ButtonPlus_Click(object sender, RoutedEventArgs e)
		{
			PrintLog("+");
		}

		private void ButtonMinus_Click(object sender, RoutedEventArgs e)
		{
			PrintLog("-");
		}

		private void ButtonMul_Click(object sender, RoutedEventArgs e)
		{
			PrintLog("×");
		}

		private void ButtonDiv_Click(object sender, RoutedEventArgs e)
		{
			PrintLog("÷");
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Backspace();
		}

		private void ButtonCE_Click(object sender, RoutedEventArgs e)
		{
			TextAns.Text = "0";
			IsAnswer = false;
		}

		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{
			TextAns.Text = "0";
			TextLog.Text = "";
			IsAnswer = false;
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
			if (e.Key == Key.NumPad0)
				PrintNumAns("0");
			if (e.Key == Key.NumPad1)
				PrintNumAns("1");
			if (e.Key == Key.NumPad2)
				PrintNumAns("2");
			if (e.Key == Key.NumPad3)
				PrintNumAns("3");
			if (e.Key == Key.NumPad4)
				PrintNumAns("4");
			if (e.Key == Key.NumPad5)
				PrintNumAns("5");
			if (e.Key == Key.NumPad6)
				PrintNumAns("6");
			if (e.Key == Key.NumPad7)
				PrintNumAns("7");
			if (e.Key == Key.NumPad8)
				PrintNumAns("8");
			if (e.Key == Key.NumPad9)
				PrintNumAns("9");
			if (e.Key == Key.Decimal)
				PrintComma();
			if (e.Key == Key.Add)
				PrintLog("+");
			if (e.Key == Key.Subtract)
				PrintLog("-");
			if (e.Key == Key.Multiply)
				PrintLog("×");
			if (e.Key == Key.Divide)
				PrintLog("÷");
			if (e.Key == Key.Back)
				Backspace();
			if (e.Key == Key.Enter)
				Enter();
		}

		private void PrintComma()
		{
			if (!TextAns.Text.Contains(",") && !IsAnswer)
				TextAns.Text += ",";
		}

		private void PrintNumAns(string number)
		{
			if (TextAns.Text.Length < 16)
			{
				if (TextAns.Text == "0" || IsAnswer)
					TextAns.Text = number;
				else
					TextAns.Text += number;
				IsAnswer = false;
			}
		}

		private void PrintLog(string operation)
		{
			if (TextLog.Text.EndsWith(" ") && IsAnswer)
			{
				TextLog.Text = TextLog.Text.Remove(TextLog.Text.Length - 2);
				TextLog.Text = TextLog.Text.Insert(TextLog.Text.Length, operation + " ");
				PrintAns("ans");
			}
			if (!IsAnswer)
			{
				TextLog.Text += TextAns.Text + " " + operation + " ";
				PrintAns("ans");
			}
			TextLog.CaretIndex = TextLog.Text.Length;
			var rect = TextLog.GetRectFromCharacterIndex(TextLog.CaretIndex);
			TextLog.ScrollToHorizontalOffset(rect.Right);
		}

		private void PrintAns(string answer)
		{
			TextAns.Text = answer;
			IsAnswer = true;
		}

		private void Backspace()
		{
			if (TextAns.Text.Length > 0 && !IsAnswer)
				if (TextAns.Text.Length == 1)
					TextAns.Text = "0";
				else
					TextAns.Text = TextAns.Text.Remove(TextAns.Text.Length - 1);
		}

		private void Enter()
		{
			TextLog.Text = "";
			PrintAns("ans");
		}
	}
}
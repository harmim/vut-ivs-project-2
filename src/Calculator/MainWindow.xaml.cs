/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Disassembler.Calculator
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml.
	/// </summary>
	public partial class MainWindow : Window
	{
		// TextLog properties
		private const double TextLogScrollOffset = 15.0;

		// math operations processor
		private readonly MathProcessor mathProcessor;

		// output result processor
		private readonly OutputProcessor outputProcessor;

		/// <summary>
		///     MainWindow construct.
		/// </summary>
		public MainWindow()
		{
			this.InitializeComponent();
			this.outputProcessor = new OutputProcessor(this.TextAns, this.TextLog);
			this.mathProcessor = new MathProcessor(this.outputProcessor);
		}

		/// <summary>
		///     Handle and process mouse wheel over TextLog element.
		///     Allows horizontal scrolling.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">MouseWheelEventArgs.</param>
		private void TextLog_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			double scroll = this.TextLog.HorizontalOffset;
			if (e.Delta > 0)
			{
				scroll -= TextLogScrollOffset;
				this.TextLog.ScrollToHorizontalOffset(scroll);
			}
			else
			{
				scroll += TextLogScrollOffset;
				this.TextLog.ScrollToHorizontalOffset(scroll);
			}
			this.TextLog.UpdateLayout();
		}

		/// <summary>
		///     Handle and process about item click.
		///     Open AboutWindow dialog.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void AboutItem_Click(object sender, RoutedEventArgs e)
		{
			AboutWindow about = new AboutWindow();
			about.ShowDialog();
		}

		/// <summary>
		///     Handle numeric button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void NumericButton_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.PrintNumber(((Button) sender).Content.ToString());
		}

		/// <summary>
		///     Handle Comma button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonComma_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.PrintComma();
		}

		/// <summary>
		///     Handle Ans button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonAns_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.CalculateResult(this.GetNumericAns());
			this.outputProcessor.ClearLog();
			MathProcessor.ClearResult();
		}

		/// <summary>
		///     Handle Sum botton click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonSum_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessSum(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Sub button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonSub_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessSub(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Mult button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMult_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessMult(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Div button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonDiv_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessDiv(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Fact button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonFact_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessFact(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Pow button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonPow_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessPow(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Root button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonRoot_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessRoot(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Log button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonLog_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ProcessLog(this.GetNumericAns());
		}

		/// <summary>
		///     Handle Inv button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonInv_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.InvertAns();
		}

		/// <summary>
		///     Handle Back button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.Backspace();
		}

		/// <summary>
		///     Process CE button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonCE_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.ClearAns();
		}

		/// <summary>
		///     Process C button click.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonC_Click(object sender, RoutedEventArgs e)
		{
			this.outputProcessor.ClearAns();
			this.outputProcessor.ClearLog();
			MathProcessor.ClearResult();
		}

		/// <summary>
		///     Handle MC button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMC_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.ClearMemory(this.ButtonMC, this.ButtonMR);
		}

		/// <summary>
		///     Handle MR button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMR_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.PrintMemory();
		}

		/// <summary>
		///     Handle MPlus button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMPlus_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.SumMemory(this.ButtonMC, this.ButtonMR, this.GetNumericAns());
		}

		/// <summary>
		///     Handle MMinus button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMMinus_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.SubMemory(this.ButtonMC, this.ButtonMR, this.GetNumericAns());
		}

		/// <summary>
		///     Handle MSet button click.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">RoutedEventArgs.</param>
		private void ButtonMSet_Click(object sender, RoutedEventArgs e)
		{
			this.mathProcessor.SetMemory(this.ButtonMC, this.ButtonMR, this.GetNumericAns());
		}

		/// <summary>
		///     Process pressed keys.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">KeyEventArgs.</param>
		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			bool shiftPressed = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;

			// print number
			if (!shiftPressed && Utils.IsNumericKey(e.Key))
			{
				KeyConverter keyConverter = new KeyConverter();
				this.outputProcessor.PrintNumber(keyConverter.ConvertToString(e.Key));
			}

			// print decimal separator (comma)
			if (!shiftPressed && (e.Key == Key.Decimal || e.Key == Key.OemComma || e.Key == Key.OemPeriod))
			{
				this.outputProcessor.PrintComma();
			}

			// calculate result
			if (e.Key == Key.Enter || e.Key == Key.Return || !shiftPressed && e.Key == Key.OemPlus)
			{
				this.mathProcessor.CalculateResult(this.GetNumericAns());
			}

			// remove last number
			if (e.Key == Key.Back)
			{
				this.outputProcessor.Backspace();
			}

			// sum
			if (e.Key == Key.Add || shiftPressed && e.Key == Key.OemPlus)
			{
				this.mathProcessor.ProcessSum(this.GetNumericAns());
			}

			// sub
			if (e.Key == Key.Subtract || !shiftPressed && e.Key == Key.OemMinus)
			{
				this.mathProcessor.ProcessSub(this.GetNumericAns());
			}

			// mult
			if (e.Key == Key.Multiply || shiftPressed && e.Key == Key.D8)
			{
				this.mathProcessor.ProcessMult(this.GetNumericAns());
			}

			// div
			if (e.Key == Key.Divide || !shiftPressed && e.Key == Key.OemQuestion)
			{
				this.mathProcessor.ProcessDiv(this.GetNumericAns());
			}

			// fact
			if (shiftPressed && e.Key == Key.D1)
			{
				this.mathProcessor.ProcessFact(this.GetNumericAns());
			}

			// pow
			if (shiftPressed && e.Key == Key.D6)
			{
				this.mathProcessor.ProcessPow(this.GetNumericAns());
			}
		}

		/// <summary>
		///     Get answer parsed double.
		/// </summary>
		/// <returns>Parsed answer to double.</returns>
		private double GetNumericAns()
		{
			double ans;
			double.TryParse(this.TextAns.Text, out ans);

			return ans;
		}
	}
}

/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;
using System.Windows.Controls;

namespace Disassembler.Calculator
{
	/// <summary>
	///     Math operations processor.
	/// </summary>
	public class MathProcessor
	{
		/// Math operators.
		private enum Operator
		{
			None,
			Sum,
			Sub,
			Mult,
			Div,
			Fact,
			Pow,
			Root,
			Log
		}

		/// Result of calculation.
		private static double result;

		/// Selected math operator.
		private static Operator selectedOperator = Operator.None;

		/// Waiting for next number flag (if true, then skip calculation).
		public static bool WaitingForNumber;

		/// Disassembler marh library.
		private readonly Math.Math math;

		/// Output result processor.
		private readonly OutputProcessor outputProcessor;

		/// Memory.
		private double memory;

		/// <summary>
		///     MathProcessor construct.
		/// </summary>
		/// <param name="outputProcessor">Output result processor.</param>
		public MathProcessor(OutputProcessor outputProcessor)
		{
			this.outputProcessor = outputProcessor;
			this.math = new Math.Math();
		}

		/// <summary>
		///     Clear result.
		/// </summary>
		public static void ClearResult()
		{
			result = 0.0;
			selectedOperator = Operator.None;
			WaitingForNumber = false;
		}

		/// <summary>
		///     Clear memory.
		/// </summary>
		/// <param name="clear">Button memory clear.</param>
		/// <param name="reset">Button memory reset.</param>
		public void ClearMemory(Button clear, Button reset)
		{
			this.memory = 0.0;
			clear.IsEnabled = false;
			reset.IsEnabled = false;
		}

		/// <summary>
		///     Print memory.
		/// </summary>
		public void PrintMemory()
		{
			this.outputProcessor.PrintAns(this.memory);
			this.outputProcessor.IsAnswer = false;
		}

		/// <summary>
		///     Sum given value with memory.
		/// </summary>
		/// <param name="clear">Button memory clear.</param>
		/// <param name="reset">Button memory reset.</param>
		/// <param name="value">Value to sum with memory.</param>
		public void SumMemory(Button clear, Button reset, double value)
		{
			this.memory = this.math.Sum(this.memory, value);
			clear.IsEnabled = true;
			reset.IsEnabled = true;
			this.outputProcessor.IsMemoryOperator = true;
		}

		/// <summary>
		///     Subtract given value from memory.
		/// </summary>
		/// <param name="clear">Button memory clear.</param>
		/// <param name="reset">Button memory reset.</param>
		/// <param name="value">Value to subtract from memory.</param>
		public void SubMemory(Button clear, Button reset, double value)
		{
			this.memory = this.math.Sub(this.memory, value);
			clear.IsEnabled = true;
			reset.IsEnabled = true;
			this.outputProcessor.IsMemoryOperator = true;
		}

		/// <summary>
		///     Set given value to memory.
		/// </summary>
		/// <param name="clear">Button memory clear.</param>
		/// <param name="reset">Button memory reset.</param>
		/// <param name="value">Value to set to memory.</param>
		public void SetMemory(Button clear, Button reset, double value)
		{
			this.memory = value;
			clear.IsEnabled = true;
			reset.IsEnabled = true;
			this.outputProcessor.IsMemoryOperator = true;
		}

		/// <summary>
		///     Process Sum operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessSum(double ans)
		{
			this.outputProcessor.PrintLog("+");
			this.CalculateResult(ans);
			selectedOperator = Operator.Sum;
		}

		/// <summary>
		///     Process Sub operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessSub(double ans)
		{
			this.outputProcessor.PrintLog("-");
			this.CalculateResult(ans);
			selectedOperator = Operator.Sub;
		}

		/// <summary>
		///     Process Mult operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessMult(double ans)
		{
			this.outputProcessor.PrintLog("×");
			this.CalculateResult(ans);
			selectedOperator = Operator.Mult;
		}

		/// <summary>
		///     Process Div operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessDiv(double ans)
		{
			this.outputProcessor.PrintLog("÷");
			this.CalculateResult(ans);
			selectedOperator = Operator.Div;
		}

		/// <summary>
		///     Process Fact operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessFact(double ans)
		{
			this.outputProcessor.PrintLog("!");
			this.outputProcessor.ResultInLog = true;
			this.CalculateResult(ans, false);
			selectedOperator = Operator.Fact;
		}

		/// <summary>
		///     Process Pow operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessPow(double ans)
		{
			this.outputProcessor.PrintLog("^");
			this.CalculateResult(ans);
			selectedOperator = Operator.Pow;
		}

		/// <summary>
		///     Process Root operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessRoot(double ans)
		{
			this.outputProcessor.PrintLog("n√");
			this.CalculateResult(ans);
			selectedOperator = Operator.Root;
		}

		/// <summary>
		///     Process Log operation.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		public void ProcessLog(double ans)
		{
			this.outputProcessor.PrintLog("nlog");
			this.CalculateResult(ans);
			selectedOperator = Operator.Log;
		}

		/// <summary>
		///     Calculate result.
		/// </summary>
		/// <param name="ans">Answer in double.</param>
		/// <param name="waitingForNumber">Set to MathProcessor.WaitingForNumber after calculation.</param>
		/// <param name="clear">Clear result and log after calculation.</param>
		public void CalculateResult(double ans, bool waitingForNumber = true, bool clear = false)
		{
			// if waiting for next number, then do not calculate result
			if (WaitingForNumber)
			{
				return;
			}

			try
			{
				switch (selectedOperator)
				{
					case Operator.None:
						result = ans;
						break;

					case Operator.Sum:
						result = this.math.Sum(result, ans);
						break;

					case Operator.Sub:
						result = this.math.Sub(result, ans);
						break;

					case Operator.Mult:
						result = this.math.Mult(result, ans);
						break;

					case Operator.Div:
						result = this.math.Div(result, ans);
						break;

					case Operator.Fact:
						result = this.math.Fact(ans);
						break;

					case Operator.Pow:
						result = this.math.Pow(result, ans);
						break;

					case Operator.Root:
						result = this.math.Root(ans, result);
						break;

					case Operator.Log:
						result = this.math.Log(result, ans);
						break;
				}
			}
			catch (Exception)
			{
				this.outputProcessor.ClearAns();
				this.outputProcessor.ClearLog();
				ClearResult();
				this.outputProcessor.PrintError();

				return;
			}

			this.outputProcessor.PrintAns(result);
			WaitingForNumber = waitingForNumber;

			if (clear)
			{
				this.outputProcessor.ClearLog();
				ClearResult();
			}
		}
	}
}

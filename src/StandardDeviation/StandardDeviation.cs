/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Math = Disassembler.Calculator.Math.Math;

namespace Disassembler
{
	/// <summary>
	///     Calculating the standard deviation of a set of numbers read from STDIN.
	/// </summary>
	internal static class StandardDeviation
	{
		/// <summary>
		///     Read numbers from STDIN and write result to STDOUT.
		/// </summary>
		private static void Main()
		{
			List<double> numbers;

			try
			{
				numbers = ReadNumbers();
			}
			catch (InvalidDataException e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			Console.WriteLine("Result: {0}", CalculateStandardDeviation(numbers));

			// for debugging
			//Console.ReadLine();
		}

		/// <summary>
		///     Read numbers from STDIN.
		/// </summary>
		/// <returns>Parsed numbers in list of double values.</returns>
		private static List<double> ReadNumbers()
		{
			List<double> numbers = new List<double>();
			string line;

			while ((line = Console.ReadLine()) != null)
			{
				double number;
				if (!double.TryParse(line.Replace(".", ","), out number))
				{
					throw new InvalidDataException("Invalid input data (not a number).");
				}
				numbers.Add(number);
			}

			return numbers;
		}

		/// <summary>
		///     Calculating standard deviation.
		/// </summary>
		/// <param name="numbers">List of numbers to calculate standard deviation.</param>
		/// <returns>Standard deviation of given numbers.</returns>
		private static double CalculateStandardDeviation(List<double> numbers)
		{
			//If list is empty, throw an exception
			if (numbers.Count == 0)
			{
				throw new ArgumentNullException();
			}
			//Do the math
			Math math = new Math();
			double n = 0.0;
			double arithmAvg = 0.0;
			double deviation = 0.0;
			//Arithmetical mean & Deviation summary
			foreach (double num in numbers)
			{
				arithmAvg = math.Sum(arithmAvg, num);
				deviation = math.Sum(deviation, math.Pow(num, 2.0));
				n++;
			}
			//Average
			arithmAvg = math.Div(arithmAvg, n);
			//Deviation
			return math.Root(math.Div(math.Sub(deviation, math.Mult(n, math.Pow(arithmAvg, 2))), math.Sub(n, 1)),2);
		}
	}
}

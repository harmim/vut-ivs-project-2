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
			// TODO
			return 0.0;
		}
	}
}

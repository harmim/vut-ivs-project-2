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

			// get random numbers for profiling
			//numbers = GenerateRandomNumbers(1000);

			double result;
			try
			{
				result = CalculateStandardDeviation(numbers);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			Console.WriteLine(@"Result: {0}", result);

			// for debugging
			//Console.ReadLine();
		}

		/// <summary>
		///     Read numbers from STDIN.
		/// </summary>
		/// <returns>Parsed numbers in list of double values.</returns>
		/// <exception cref="InvalidDataException"></exception>
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
		///     Generate random double numbers in range (-1000, 1000).
		/// </summary>
		/// <param name="count">Number of values to generate.</param>
		/// <returns>Generated numbers in list of double values.</returns>
		private static List<double> GenerateRandomNumbers(int count)
		{
			List<double> numbers = new List<double>();
			const double min = -1000, max = 1000;
			Random random = new Random();

			for (int i = 0; i < count; i++)
			{
				numbers.Add(random.NextDouble() * (max - min) + min);
			}

			return numbers;
		}

		/// <summary>
		///     Calculating standard deviation.
		/// </summary>
		/// <param name="numbers">List of numbers to calculate standard deviation.</param>
		/// <returns>Standard deviation of given numbers.</returns>
		/// <exception cref="ArgumentException"></exception>
		private static double CalculateStandardDeviation(List<double> numbers)
		{
			int n = numbers.Count;

			// if numbers count is less than 2, throw an exception
			if (n < 2)
			{
				throw new ArgumentException("Invalid input data (numbers count must be greater than 2).");
			}

			//Do the math
			Math math = new Math();
			double arithmAvg = 0.0;
			double deviation = 0.0;

			//Arithmetical mean & Deviation summary
			foreach (double num in numbers)
			{
				arithmAvg = math.Sum(arithmAvg, num);
				deviation = math.Sum(deviation, math.Pow(num, 2.0));
			}

			//Average
			arithmAvg = math.Div(arithmAvg, n);

			//Deviation
			return math.Root(math.Div(math.Sub(deviation, math.Mult(n, math.Pow(arithmAvg, 2))), math.Sub(n, 1)), 2);
		}
	}
}

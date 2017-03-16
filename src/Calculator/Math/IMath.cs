/**************************************************************
 * Team:      Disassembler
 * 
 * Authors:   Vojtìch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

namespace Disassembler
{
	/// <summary>
	/// Interface for Math library, which is used in calculator.
	/// </summary>
	interface IMath
	{
		/// <summary>
		/// Sums two numbers.
		/// </summary>
		/// <param name="num1">Summand1.</param>
		/// <param name="num2">Summand2.</param>
		/// <returns>The result of the addition.</returns>
		double sum(double num1, double num2);

		/// <summary>
		/// Substracts two numbers.
		/// </summary>
		/// <param name="num1">Minuend.</param>
		/// <param name="num2">Subtrahend.</param>
		/// <returns>The result of the substraction.</returns>
		double sub(double num1, double num2);

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="num1">Divident.</param>
        /// <param name="num2">Divisor. num2 in R-{0}</param>
        /// <returns>The result of the division.</returns>
        double div(double num1, double num2);

		/// <summary>
		/// Multiplies two numbers.
		/// </summary>
		/// <param name="num1">Factor1.</param>
		/// <param name="num2">Factor2.</param>
		/// <returns>The summary of the Multiplication.</returns>
		double mult(double num1, double num2);

		/// <summary>
		/// Cumputes a factorial.
		/// </summary>
		/// <param name="num">Factoriated number. num in N</param>
		/// <returns>Factorial from the number.</returns>
		long fact(long num);

		/// <summary>
		/// Exponentiation with general exponent.
		/// </summary>
		/// <param name="num1">Base. num1 in (0,inf)-{1} </param>
		/// <param name="num2">Exponent. num2 in (0,inf)</param>
		/// <returns>The power.</returns>
		double exp(double num1, double num2);

		/// <summary>
		/// Root with general degree.
		/// </summary>
		/// <param name="num1">Radicand. num1 in (0,inf)</param>
		/// <param name="num2">Degree. num2 in (0,inf)</param>
		/// <returns>The root.</returns>
		double sqrt(double num1, double num2);

		/// <summary>
		/// Logarithm with general base.
		/// </summary>
		/// <param name="num1">Base. num1 in (0,inf)-{1}</param>
		/// <param name="num2">Antilogarthm. num2 in (0,inf)</param>
		/// <returns>The logarithm.</returns>
		double log(double num1, double num2);
	}
}

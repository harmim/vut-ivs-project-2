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
		/// <param name="minuend">Minuend.</param>
		/// <param name="subtrahend">Subtrahend.</param>
		/// <returns>The result of the substraction.</returns>
		double sub(double minuend, double subtrahend);

		/// <summary>
		/// Divides two numbers.
		/// </summary>
		/// <param name="divident">Divident.</param>
		/// <param name="divisor">Divisor.</param>
		/// <returns>The result of the division.</returns>
		double div(double divident, double divisor);

		/// <summary>
		/// Multiplies two numbers.
		/// </summary>
		/// <param name="num1">Factor1.</param>
		/// <param name="num2">Factor2.</param>
		/// <returns>The summary of the Multiplication.</returns>
		double mult(double num1, double num2);

		/// <summary>
		/// Computes a factorial from a number.
		/// </summary>
		/// <param name="num">Factoriated number.</param>
		/// <returns>Factorial from the number.</returns>
		ulong fact(ushort num);

		/// <summary>
		/// Exponentiation with general exponent.
		/// </summary>
		/// <param name="basis">Base.</param>
		/// <param name="exponent">Exponent.</param>
		/// <returns>Returns a specified number raised to the specified power.</returns>
		double pow(double basis, double exponent);

		/// <summary>
		/// Root with general degree.
		/// </summary>
		/// <param name="radicand">Radicand.</param>
		/// <param name="degree">Degree.</param>
		/// <returns>Returns the n-th root of a specified number.</returns>
		double root(double radicand, double degree);

		/// <summary>
		/// Logarithm with general base.
		/// </summary>
		/// <param name="basis">Base.</param>
		/// <param name="antilogarithm">Antilogarithm.</param>
		/// <returns>Returns the logarithm of a specified number in a specified base.</returns>
		double log(double basis, double antilogarithm);
	}
}

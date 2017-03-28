/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;

namespace Disassembler.Calculator.Math
{
	public class Math : IMath
	{
		public double Sum(double num1, double num2)
		{
			throw new NotImplementedException();
		}

		public double Sub(double minuend, double subtrahend)
		{
			throw new NotImplementedException();
		}

		public double Div(double divident, double divisor)
		{
			throw new NotImplementedException();
		}

		public double Mult(double num1, double num2)
		{
			throw new NotImplementedException();
		}

		public ulong Fact(double num)
		{
			throw new NotImplementedException();
		}

		public double Pow(double basis, double exponent)
		{
			double result = System.Math.Pow(basis, exponent);

			if (double.IsInfinity(result) || double.IsNaN(result))
			{
				throw new NotFiniteNumberException();
			}

			return result;
		}

		public double Root(double radicand, double degree)
		{
		    if (degree == 0.0)
		    {
		        throw new DivideByZeroException();
		    }

			double result = this.Pow(radicand, 1.0 / degree);

		    return result;
		}

		public double Log(double basis, double antilogarithm)
		{
			double result = System.Math.Log(antilogarithm, basis);

			if (double.IsInfinity(result) || double.IsNaN(result))
			{
				throw new NotFiniteNumberException();
			}

			return result;
		}
	}
}

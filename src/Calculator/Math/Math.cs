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
            double result = 0;
            result = num1 + num2;
			return result;
		}

		public double Sub(double minuend, double subtrahend)
		{
            double result = 0;
            result = minuend - subtrahend;
            return result;
			throw new NotImplementedException();
		}

		public double Div(double divident, double divisor)
		{
            double result = 0;
            if ( divisor == 0)
            {
                throw new DivideByZeroException();
            } 
            else
            {
                result = divident / divisor;
            }
            return result;
			
		}

		public double Mult(double num1, double num2)
		{
            double result = 0;
            result = num1 * num2;
            return result;
		}

        public double Fact(double num)
        {
            double result = num;

            if (num <0 )
            {
                throw new ArgumentOutOfRangeException();
            }

            else if (num == 0)
            {
                result = 1;
            }
            else if ((num > 0) && (num % 1 == 0))
            {
                
                for (int i = 1; i < num; i++)
                {
                    result = result * (num - i);
                }
            }
            

            
            return result;
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

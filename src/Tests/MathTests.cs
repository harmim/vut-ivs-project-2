/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System;
using Disassembler.Calculator.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math = Disassembler.Calculator.Math.Math;

namespace Disassembler.Tests
{
	/// <summary>
	///     Disassembler.Calculator.Math.Math library tests.
	/// </summary>
	[TestClass]
	public class MathTests
	{
		/// Accuracy for tests with double numbers.
		private const double Accuracy = 1e-6;

		/// Disassembler.Calculator.Math.Math object.
		private readonly IMath math;

		/// <summary>
		///     MathTests construct.
		/// </summary>
		public MathTests()
		{
			this.math = new Math();
		}

		/// <summary>
		///     Math.Sum test.
		/// </summary>
		[TestMethod]
		public void SumTest()
		{
			// are equal
			Assert.AreEqual(0, this.math.Sum(0, 0));
			Assert.AreEqual(-10, this.math.Sum(-5, -5));
			Assert.AreEqual(-42, this.math.Sum(42, -84));
			Assert.AreEqual(-50000000, this.math.Sum(-100000000, 50000000));
			Assert.AreEqual(15, this.math.Sum(7, 8));
			Assert.AreEqual(128, this.math.Sum(-128, 256));
			Assert.AreEqual(100000000, this.math.Sum(50000000, 50000000));
			Assert.AreEqual(1, this.math.Sum(0.5, 0.5), Accuracy);
			Assert.AreEqual(32.35723, this.math.Sum(0, 32.35723), Accuracy);

			// are not equal
			Assert.AreNotEqual(25, this.math.Sum(-25, -25));
			Assert.AreNotEqual(-25, this.math.Sum(-25, -25));
			Assert.AreNotEqual(0, this.math.Sum(0.5, 0.5), Accuracy);
			Assert.AreNotEqual(32, this.math.Sum(0, 32.35723), Accuracy);
		}

		/// <summary>
		///     Math.Sub test.
		/// </summary>
		[TestMethod]
		public void SubTest()
		{
			// are equal
			Assert.AreEqual(0, this.math.Sub(0, 0));
			Assert.AreEqual(0, this.math.Sub(-5, -5));
			Assert.AreEqual(126, this.math.Sub(42, -84));
			Assert.AreEqual(-150000000, this.math.Sub(-100000000, 50000000));
			Assert.AreEqual(-1, this.math.Sub(7, 8));
			Assert.AreEqual(-384, this.math.Sub(-128, 256));
			Assert.AreEqual(-10000000, this.math.Sub(50000000, 60000000));
			Assert.AreEqual(0.25, this.math.Sub(0.5, 0.25), Accuracy);
			Assert.AreEqual(-32.35723, this.math.Sub(0, 32.35723), Accuracy);

			// are not equal
			Assert.AreNotEqual(25, this.math.Sub(-25, -25));
			Assert.AreNotEqual(-25, this.math.Sub(-25, -25));
			Assert.AreNotEqual(0.25, this.math.Sub(0.5, 0.5), Accuracy);
			Assert.AreNotEqual(-32, this.math.Sub(0, 32.35723), Accuracy);
		}

		/// <summary>
		///     Math.Div test.
		/// </summary>
		[TestMethod]
		public void DivTest()
		{
			// divide by zero
			const string divedeByZeroNoExceptionMessage = "No exception was thrown after dividing by zero.";
			try
			{
				this.math.Div(10, 0);
				Assert.Fail(divedeByZeroNoExceptionMessage);
			}
			catch (DivideByZeroException)
			{
			}
			try
			{
				this.math.Div(-2323.5421, 0);
				Assert.Fail(divedeByZeroNoExceptionMessage);
			}
			catch (DivideByZeroException)
			{
			}

			// are equal
			Assert.AreEqual(0, this.math.Div(0, 42));
			Assert.AreEqual(1, this.math.Div(-5, -5));
			Assert.AreEqual(-0.5, this.math.Div(42, -84), Accuracy);
			Assert.AreEqual(-2, this.math.Div(-100000000, 50000000));
			Assert.AreEqual(0.875, this.math.Div(7, 8), Accuracy);
			Assert.AreEqual(-0.5, this.math.Div(-128, 256), Accuracy);
			Assert.AreEqual(2, this.math.Div(0.5, 0.25), Accuracy);
			Assert.AreEqual(0.9676971731, this.math.Div(31.312, 32.35723), Accuracy);
			Assert.AreEqual(-1.047197551, this.math.Div(System.Math.PI, -3), Accuracy);

			// are not equal
			Assert.AreNotEqual(25, this.math.Div(0, -25));
			Assert.AreNotEqual(-1.047167551, this.math.Div(System.Math.PI, -3), Accuracy);
			Assert.AreNotEqual(-1.037197551, this.math.Div(System.Math.PI, -3), Accuracy);
		}

		/// <summary>
		///     Math.Mult test.
		/// </summary>
		[TestMethod]
		public void MultTest()
		{
			// are equal
			Assert.AreEqual(0, this.math.Mult(0, 0));
			Assert.AreEqual(0, this.math.Mult(437298, 0));
			Assert.AreEqual(0, this.math.Mult(0, 437298));
			Assert.AreEqual(25, this.math.Mult(-5, -5));
			Assert.AreEqual(-3528, this.math.Mult(42, -84));
			Assert.AreEqual(400000000, this.math.Mult(-100000000, -4));
			Assert.AreEqual(56, this.math.Mult(7, 8));
			Assert.AreEqual(-32768, this.math.Mult(-128, 256));
			Assert.AreEqual(-3000000000, this.math.Mult(50000000, -60));
			Assert.AreEqual(0.125, this.math.Mult(0.5, 0.25), Accuracy);
			Assert.AreEqual(-10.6778859, this.math.Mult(-0.33, 32.35723), Accuracy);

			// are not equal
			Assert.AreNotEqual(-625, this.math.Mult(-25, -25));
			Assert.AreNotEqual(0.26, this.math.Mult(0.5, 0.5), Accuracy);
			Assert.AreNotEqual(32.357231, this.math.Mult(2, 32.35723), Accuracy);
		}

		/// <summary>
		///     Math.Fact test.
		/// </summary>
		[TestMethod]
		public void FactTest()
		{
			// argument out of range
			const string argumentOutOfRangeExceptionMessage =
				"No exception was thrown after passed argument out of range.";
			try
			{
				this.math.Fact(-20);
				Assert.Fail(argumentOutOfRangeExceptionMessage);
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			try
			{
				this.math.Fact(-20.313);
				Assert.Fail(argumentOutOfRangeExceptionMessage);
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			try
			{
				this.math.Fact(System.Math.PI);
				Assert.Fail(argumentOutOfRangeExceptionMessage);
			}
			catch (ArgumentOutOfRangeException)
			{
			}

			// are equal
			Assert.AreEqual((ulong) 1, this.math.Fact(0));
			Assert.AreEqual((ulong) 120, this.math.Fact(5));
			Assert.AreEqual((ulong) 1.307674368e12, this.math.Fact(15), Accuracy);
			Assert.AreEqual((ulong) 40320, this.math.Fact(8));
		}

		/// <summary>
		///     Math.Pow test.
		/// </summary>
		[TestMethod]
		public void PowTest()
		{
			// not a number result
			const string notFiniteNumberExceptionMessage = "No exception was thrown when result was NaN or infinity.";
			try
			{
				this.math.Pow(0, -1);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Pow(-1, 2.5);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Pow(-1.5, -2.5);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}

			// are equal
			Assert.AreEqual(1, this.math.Pow(69, 0));
			Assert.AreEqual(0, this.math.Pow(0, 33));
			Assert.AreEqual(1, this.math.Pow(1, 42));
			Assert.AreEqual(1, this.math.Pow(1, -232.23), Accuracy);
			Assert.AreEqual(-1, this.math.Pow(-1, 97));
			Assert.AreEqual(1, this.math.Pow(-1, 98));
			Assert.AreEqual(25, this.math.Pow(5, 2));
			Assert.AreEqual(9, this.math.Pow(-3, 2));
			Assert.AreEqual(-125, this.math.Pow(-5, 3));
			Assert.AreEqual(0.125, this.math.Pow(2, -3), Accuracy);
			Assert.AreEqual(1073741824, this.math.Pow(-2, 30));
			Assert.AreEqual(2.35898248e-119, this.math.Pow(-9000, -30), Accuracy);
			Assert.AreEqual(124467.9702668, this.math.Pow(4.5, 7.8), Accuracy);
			Assert.AreEqual(8.03419544e-6, this.math.Pow(4.5, -7.8), Accuracy);
			Assert.AreEqual(0.42584909, this.math.Pow(0.33, 0.77), Accuracy);
			Assert.AreEqual(0.03225153, this.math.Pow(System.Math.PI, -3), Accuracy);

			// are not equal
			Assert.AreNotEqual(1, this.math.Pow(0, 8));
			Assert.AreNotEqual(1, this.math.Pow(1.05, 8), Accuracy);
			Assert.AreNotEqual(0.03224153, this.math.Pow(System.Math.PI, -3), Accuracy);
		}

		/// <summary>
		///     Math.Root test.
		/// </summary>
		[TestMethod]
		public void RootTest()
		{
			// not a number result
			const string notFiniteNumberExceptionMessage = "No exception was thrown when result was NaN or infinity.";
			try
			{
				this.math.Root(-1, 2);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Root(-1.7, -15.7);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Root(0, -1);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}

			// divide by zero
			const string divedeByZeroNoExceptionMessage = "No exception was thrown after dividing by zero.";
			try
			{
				this.math.Root(69, 0);
				Assert.Fail(divedeByZeroNoExceptionMessage);
			}
			catch (DivideByZeroException)
			{
			}
			try
			{
				this.math.Root(32.3112, 0);
				Assert.Fail(divedeByZeroNoExceptionMessage);
			}
			catch (DivideByZeroException)
			{
			}

			// are equal
			Assert.AreEqual(0, this.math.Root(0, 0.33), Accuracy);
			Assert.AreEqual(2, this.math.Root(8, 3));
			Assert.AreEqual(0.5, this.math.Root(8, -3), Accuracy);
			Assert.AreEqual(1.765174167, this.math.Root(5.5, 3), Accuracy);
			Assert.AreEqual(2.889430626, this.math.Root(55.78, 3.79), Accuracy);
			Assert.AreEqual(0.346088945, this.math.Root(55.78, -3.79), Accuracy);
			Assert.AreEqual(0.977899324, this.math.Root(0.064, 123), Accuracy);
			Assert.AreEqual(1.35459068, this.math.Root(9000, 30), Accuracy);
			Assert.AreEqual(0.73823038, this.math.Root(9000, -30), Accuracy);
			Assert.AreEqual(8.53755712e-21, this.math.Root(0.5, 0.015), Accuracy);
			Assert.AreEqual(0.68278406, this.math.Root(System.Math.PI, -3), Accuracy);

			// are not equal
			Assert.AreNotEqual(1, this.math.Root(0, 8));
			Assert.AreNotEqual(1, this.math.Root(1.05, 0.125), Accuracy);
			Assert.AreNotEqual(0.68277406, this.math.Root(System.Math.PI, -3), Accuracy);
		}

		/// <summary>
		///     Math.Log test.
		/// </summary>
		[TestMethod]
		public void LogTest()
		{
			// argument out of range
			const string notFiniteNumberExceptionMessage =
				"No exception was thrown when result was NaN or infinity.";
			try
			{
				this.math.Log(3, -1);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Log(-1, 3);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Log(0, 0.5);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Log(0, 1.5);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Log(5, 0);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}
			try
			{
				this.math.Log(1, 8);
				Assert.Fail(notFiniteNumberExceptionMessage);
			}
			catch (NotFiniteNumberException)
			{
			}

			// are equal
			Assert.AreEqual(0, this.math.Log(0, 1)); //special occasion
			Assert.AreEqual(0, this.math.Log(23.7, 1), Accuracy);
			Assert.AreEqual(1, this.math.Log(10, 10));
			Assert.AreEqual(6, this.math.Log(2, 64));
			Assert.AreEqual(1, this.math.Log(0.03, 0.03), Accuracy);
			Assert.AreEqual(-2.2326607568, this.math.Log(0.5, 4.7), Accuracy);
			Assert.AreEqual(1.7286851437, this.math.Log(2.9, 6.3), Accuracy);
			Assert.AreEqual(-0.87154186672, this.math.Log(0.004, 123), Accuracy);
			Assert.AreEqual(-1.1473918101, this.math.Log(123, 0.004), Accuracy);
			Assert.AreEqual(1.2722897456, this.math.Log(123, 456), Accuracy);
			Assert.AreEqual(0.89864715222, this.math.Log(0.004, 0.007), Accuracy);
			Assert.AreEqual(0.99325177301, this.math.Log(System.Math.E, 2.7), Accuracy);

			// are not equal
			Assert.AreNotEqual(1, this.math.Log(3.5, 3.6), Accuracy);
			Assert.AreNotEqual(0, this.math.Log(15, 1.01), Accuracy);
			Assert.AreNotEqual(1, this.math.Log(System.Math.E, 2.7), Accuracy);
		}
	}
}

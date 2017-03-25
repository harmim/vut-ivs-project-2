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
		// accuracy for tests with double numbers
		private const double Accuracy = 1e-6;

		// Disassembler.Calculator.Math.Math object
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
			Assert.AreEqual(0.875, this.math.Div(7, 8));
			Assert.AreEqual(-0.5, this.math.Div(-128, 256), Accuracy);
			Assert.AreEqual(2, this.math.Div(0.5, 0.25));
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
			// argument out of ragne
			const string argumentOutOfRangeExceptionMessage = "No exception was thrown after passed argument out of range.";
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
			Assert.AreEqual(1, this.math.Fact(0));
			Assert.AreEqual(120, this.math.Fact(5));
			Assert.AreEqual(1.307674368e12, this.math.Fact(15), Accuracy);
			Assert.AreEqual(40320, this.math.Fact(8));
		}
	}
}

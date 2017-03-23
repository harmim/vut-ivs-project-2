/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using Disassembler.Calculator.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Disassembler.Tests
{
	[TestClass]
	public class MathTests
	{
		private readonly IMath math;

		public MathTests()
		{
			this.math = new Math();
		}

		[TestMethod]
		public void Sub_Tests()
		{
			Assert.AreEqual(this.math.Sub(0, 0), 0);
		}
	}
}

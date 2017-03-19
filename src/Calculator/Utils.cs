/**************************************************************
 * Team:      Disassembler
 *
 * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
 *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
 *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
 *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
 **************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Disassembler.Calculator
{
	/// <summary>
	///     Static helpers.
	/// </summary>
	public static class Utils
	{
		/// <summary>
		///     Checks whether given key is numeric.
		/// </summary>
		/// <param name="key">Key object.</param>
		/// <returns></returns>
		public static bool IsNumericKey(Key key)
		{
			return key >= Key.D0 && key <= Key.D9 || key >= Key.NumPad0 && key <= Key.NumPad9;
		}

		/// <summary>
		///     Remove spaces from given string.
		/// </summary>
		/// <param name="s">String to remove spaces.</param>
		/// <returns>Given string without spaces.</returns>
		public static string RemoveSpaces(string s)
		{
			return Regex.Replace(s, @"\s", "");
		}

		/// <summary>
		///     Remove geven chars from string.
		/// </summary>
		/// <param name="s">String to remove given chars.</param>
		/// <param name="chars">Chars to be removed.</param>
		/// <returns>Given string without specified chars.</returns>
		public static string RemoveChars(string s, IEnumerable<char> chars)
		{
			return chars.Aggregate(s, (current, c) => current.Replace(c.ToString(), string.Empty));
		}
	}
}

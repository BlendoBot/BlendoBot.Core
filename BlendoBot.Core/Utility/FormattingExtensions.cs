using System;
using System.Collections.Generic;
using System.Text;

namespace BlendoBot.Core.Utility {
	/// <summary>
	/// Small useful methods for working with strings in messages.
	/// </summary>
	public static class FormattingExtensions {
		/// <summary>
		/// Returns a new string with bold tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Bold(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"**{s}**";
		}

		/// <summary>
		/// Returns a new string with italic tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Italics(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"*{s}*";
		}

		/// <summary>
		/// Returns a new string with underline tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Underline(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"__{s}__";
		}

		/// <summary>
		/// Returns a new string with strikeout tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Strikeout(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"~~{s}~~";
		}

		/// <summary>
		/// Returns a new string with code tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Code(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"`{s}`";
		}

		/// <summary>
		/// Returns a new string with code block tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string CodeBlock(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"```\n{s}\n```";
		}

		/// <summary>
		/// Returns a new string with spoiler tags around the string, or nothing if the string is empty.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Spoiler(this string s) {
			return string.IsNullOrWhiteSpace(s) ? s : $"||{s}||";
		}
	}
}

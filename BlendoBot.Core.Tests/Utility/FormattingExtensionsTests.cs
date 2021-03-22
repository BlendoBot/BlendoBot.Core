using BlendoBot.Core.Utility;
using System;
using Xunit;

namespace BlendoBot.Core.Tests.Utility {
	public class FormattingExtensionsTests {
		[Theory]
		[InlineData("test", "**test**")]
		[InlineData("a longer line", "**a longer line**")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestBold(string input, string output) {
			Assert.Equal(input.Bold(), output);
		}

		[Theory]
		[InlineData("test", "*test*")]
		[InlineData("a longer line", "*a longer line*")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestItalics(string input, string output) {
			Assert.Equal(input.Italics(), output);
		}

		[Theory]
		[InlineData("test", "__test__")]
		[InlineData("a longer line", "__a longer line__")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestUnderline(string input, string output) {
			Assert.Equal(input.Underline(), output);
		}

		[Theory]
		[InlineData("test", "~~test~~")]
		[InlineData("a longer line", "~~a longer line~~")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestStrikeout(string input, string output) {
			Assert.Equal(input.Strikeout(), output);
		}

		[Theory]
		[InlineData("test", "`test`")]
		[InlineData("a longer line", "`a longer line`")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestCode(string input, string output) {
			Assert.Equal(input.Code(), output);
		}

		[Theory]
		[InlineData("test", "```\ntest\n```")]
		[InlineData("a longer line", "```\na longer line\n```")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestCodeBlock(string input, string output) {
			Assert.Equal(input.CodeBlock(), output);
		}

		[Theory]
		[InlineData("test", "||test||")]
		[InlineData("a longer line", "||a longer line||")]
		[InlineData(null, null)]
		[InlineData("", "")]
		public void TestSpoiler(string input, string output) {
			Assert.Equal(input.Spoiler(), output);
		}
	}
}

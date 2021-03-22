using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlendoBot.Core.Tests.Demo {
	public class DemoCommandTests {
		[Fact]
		public void TestGetGuildId() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Equal(testGuildId, command.GuildId);
		}

		[Fact]
		public void TestBotMethods() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Same(program, command.BotMethods);
		}

		[Fact]
		public void TestDefaultTerm() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Equal("test", command.DefaultTerm);
		}

		[Fact]
		public void TestName() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Equal("Test Command", command.Name);
		}

		[Fact]
		public void TestDescription() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Equal("Responds back, and nothing more.", command.Description);
		}

		[Fact]
		public void TestUsage() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			program.AddCommand(testGuildId, command);
			program.CommandPrefix = "?";
			Assert.Equal("?test", command.Usage);
		}

		[Fact]
		public void TestAuthor() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			Assert.Equal("Biendeo", command.Author);
		}

		[Fact]
		public void TestVersion() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			// This is a bit too implementation specific.
			Assert.Equal(typeof(DemoCommandTests).Assembly.GetName().Version?.ToString() ?? "1.0.0", command.Version);
		}

		[Fact]
		public void TestStartupSuccess() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			command.IntendedStartupResult = true;
			program.AddCommand(testGuildId, command);
			Assert.True(command.StartedUp);
			Assert.Same(command, program.GetCommand<DemoCommand>(this, testGuildId));
		}

		[Fact]
		public void TestStartupError() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			command.IntendedStartupResult = false;
			Assert.False(program.AddCommand(testGuildId, command));
			Assert.False(command.StartedUp);
			Assert.Null(program.GetCommand<DemoCommand>(this, testGuildId));
		}

		[Fact]
		public void TestMessage() {
			const ulong testGuildId = 1;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			// Can't create a DSharpPlus object so this cannot be tested in isolation.
		}
	}
}

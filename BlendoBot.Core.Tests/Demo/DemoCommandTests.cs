using BlendoBot.Core.Interfaces;
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
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Equal(testGuildId, command.GuildId);
		}

		[Fact]
		public void TestServiceProvider() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Same(serviceProvider, command.ServiceProvider);
		}

		[Fact]
		public void TestDefaultTerm() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Equal("test", command.DefaultTerm);
		}

		[Fact]
		public void TestName() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Equal("Test Command", command.Name);
		}

		[Fact]
		public void TestDescription() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Equal("Responds back, and nothing more.", command.Description);
		}

		[Fact]
		public void TestUsage() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			serviceProvider.CommandManager.AddCommand(testGuildId, command);
			serviceProvider.CommandManager.CommandPrefix = "?";
			Assert.Equal("?test", command.Usage);
		}

		[Fact]
		public void TestAuthor() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			Assert.Equal("Biendeo", command.Author);
		}

		[Fact]
		public void TestVersion() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			// This is a bit too implementation specific.
			Assert.Equal(typeof(DemoCommandTests).Assembly.GetName().Version?.ToString() ?? "1.0.0", command.Version);
		}

		[Fact]
		public void TestStartupSuccess() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider) {
				IntendedStartupResult = true
			};
			serviceProvider.CommandManager.AddCommand(testGuildId, command);
			Assert.True(command.StartedUp);
			Assert.Same(command, serviceProvider.CommandManager.GetCommand<DemoCommand>(this, testGuildId));
		}

		[Fact]
		public void TestStartupError() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider) {
				IntendedStartupResult = false
			};
			Assert.False(serviceProvider.CommandManager.AddCommand(testGuildId, command));
			Assert.False(command.StartedUp);
			Assert.Null(serviceProvider.CommandManager.GetCommand<DemoCommand>(this, testGuildId));
		}

		[Fact]
		public void TestMessage() {
			const ulong testGuildId = 1;
			var serviceProvider = new DemoServiceProvider();
			var command = new DemoCommand(testGuildId, serviceProvider);
			// Can't create a DSharpPlus object so this cannot be tested in isolation.
		}
	}
}

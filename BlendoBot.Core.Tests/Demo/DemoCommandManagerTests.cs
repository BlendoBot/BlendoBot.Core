using BlendoBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlendoBot.Core.Tests.Demo {
	public class DemoCommandManagerTests {
		[Fact]
		public void TestGetCommand() {
			const ulong testGuildId = 1;
			const ulong testNonGuildId = 2;
			var serviceProvider = new DemoServiceProvider();
			var commandManager = serviceProvider.CommandManager;
			var command = new DemoCommand(testGuildId, serviceProvider);
			commandManager.AddCommand(testGuildId, command);
			Assert.Same(command, commandManager.GetCommand<DemoCommand>(this, testGuildId));
			Assert.Null(commandManager.GetCommand<DemoCommand>(this, testNonGuildId));
		}
	}
}

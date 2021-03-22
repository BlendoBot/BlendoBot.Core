using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlendoBot.Core.Tests.Demo {
	public class DemoProgramTests {
		[Fact]
		public void TestGetCommand() {
			const ulong testGuildId = 1;
			const ulong testNonGuildId = 2;
			var program = new DemoProgram();
			var command = new DemoCommand(testGuildId, program);
			program.AddCommand(testGuildId, command);
			Assert.Same(command, program.GetCommand<DemoCommand>(this, testGuildId));
			Assert.Null(program.GetCommand<DemoCommand>(this, testNonGuildId));
		}
	}
}

using BlendoBot.Core.Command;
using BlendoBot.Core.Interfaces;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	[Command(Guid = "blendobot.core.demo.democommandroot", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	class DemoCommandRoot : BaseCommand {
		public DemoCommandRoot(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandtierone", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandRoot))]
	class DemoCommandTierOne : BaseCommand {
		public DemoCommandTierOne(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandtiertwoa", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandTierOne))]
	class DemoCommandTierTwoA : BaseCommand {
		public DemoCommandTierTwoA(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandtiertwob", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandTierOne))]
	class DemoCommandTierTwoB : BaseCommand {
		public DemoCommandTierTwoB(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandtierthree", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandTierTwoA))]
	[CommandDependency(DependsOn = typeof(DemoCommandTierTwoB))]
	class DemoCommandTierThree : BaseCommand {
		public DemoCommandTierThree(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandbaddependencyone", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandBadDependencyTwo))]
	class DemoCommandBadDependencyOne : BaseCommand {
		public DemoCommandBadDependencyOne(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}

	[Command(Guid = "blendobot.core.demo.democommandbaddependencytwo", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	[CommandDependency(DependsOn = typeof(DemoCommandBadDependencyOne))]
	class DemoCommandBadDependencyTwo : BaseCommand {
		public DemoCommandBadDependencyTwo(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) { }

		public override string Description => throw new NotImplementedException();

		public override string Usage => throw new NotImplementedException();

		public override Task OnMessage(MessageCreateEventArgs e) {
			throw new NotImplementedException();
		}

		public override Task<bool> Startup() {
			throw new NotImplementedException();
		}
	}
}

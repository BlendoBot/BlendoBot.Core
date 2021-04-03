using BlendoBot.Core.Command;
using BlendoBot.Core.Interfaces;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	[Command(Guid = "blendobot.core.demo.democommand", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	class DemoCommand : BaseCommand {
		public DemoCommand(ulong guildId, IBotServiceProvider serviceProvider) : base(guildId, serviceProvider) {}

		public bool StartedUp { get; private set; } = false;
		public bool IntendedStartupResult { get; set; } = true;
		public IReadOnlyList<MessageCreateEventArgs> MessagesReceived => messagesReceived;
		private readonly List<MessageCreateEventArgs> messagesReceived = new();

		public override string Description => "Responds back, and nothing more.";

		public override string Usage => $"{ServiceProvider.GetService<ICommandManager>().GetCommandTerm(this, this)}";

		public override Task OnMessage(MessageCreateEventArgs e) {
			messagesReceived.Add(e);
			return Task.CompletedTask;
		}

		public override Task<bool> Startup() {
			StartedUp = IntendedStartupResult;
			return Task.FromResult(IntendedStartupResult);
		}
	}
}

using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	[Command(Guid = "blendobot.core.demo.democommand", Name = "Test Command", Author = "Biendeo", DefaultTerm = "test")]
	class DemoCommand : CommandBase {
		public DemoCommand(ulong guildId, IBotMethods botMethods) : base(guildId, botMethods) {
			messagesReceived = new List<MessageCreateEventArgs>();
			IntendedStartupResult = true;
		}

		public bool StartedUp { get; private set; }
		public bool IntendedStartupResult { get; set; }
		public IReadOnlyList<MessageCreateEventArgs> MessagesReceived => messagesReceived;
		private List<MessageCreateEventArgs> messagesReceived;

		public override string Description => "Responds back, and nothing more.";

		public override string Usage => $"{BotMethods.GetHelpCommandTerm(this, GuildId)}";

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

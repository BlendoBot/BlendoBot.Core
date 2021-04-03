using BlendoBot.Core.Entities;
using BlendoBot.Core.Interfaces;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoDiscordInteractor : IDiscordInteractor {
		public Task<DiscordChannel> GetChannel(object o, ulong channelId) {
			throw new NotImplementedException();
		}

		public Task<DiscordUser> GetUser(object o, ulong userId) {
			throw new NotImplementedException();
		}

		public Task<bool> IsUserAdmin(object o, DiscordGuild guild, DiscordChannel channel, DiscordUser user) {
			throw new NotImplementedException();
		}

		public Task<DiscordMessage> SendException(object o, SendExceptionEventArgs e) {
			throw new NotImplementedException();
		}

		public Task<DiscordMessage> SendFile(object o, SendFileEventArgs e) {
			throw new NotImplementedException();
		}

		public Task<DiscordMessage> SendMessage(object o, SendMessageEventArgs e) {
			throw new NotImplementedException();
		}
	}
}

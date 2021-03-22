using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoProgram : IBotMethods {
		public Dictionary<ulong, Dictionary<string, CommandBase>> GuildCommands { get; set; }
		public Dictionary<ulong, List<IMessageListener>> GuildMessageListeners { get; set; }
		public List<LogEventArgs> LogEvents { get; set; }

		public DemoProgram() {
			GuildCommands = new();
			GuildMessageListeners = new();
			LogEvents = new();
		}

		public bool AddCommand(ulong guildId, CommandBase command) {
			if (!GuildCommands.ContainsKey(guildId)) {
				GuildCommands.Add(guildId, new());
			}
			string targetName = GenerateUniqueName(new(GuildCommands[guildId].Keys), command.DefaultTerm);
			var result = command.Startup();
			result.Wait();
			if (result.Result) {
				GuildCommands[guildId].Add(targetName, command);
				return true;
			} else {
				return false;
			}
		}

		public string GenerateUniqueName(HashSet<string> existingNames, string targetName, int maxAttempts = 100) {
			if (!existingNames.Contains(targetName)) {
				return targetName;
			}
			for (int i = 2; i <= maxAttempts; ++i) {
				string foundName = $"{targetName}-{i}";
				if (!existingNames.Contains(foundName)) {
					return foundName;
				}
			}
			throw new InvalidOperationException($"GenerateUniqueName couldn't find a unique name for {targetName} within {maxAttempts} variations!");
		}

		public void AddMessageListener(object o, ulong guildId, IMessageListener messageListener) {
			throw new NotImplementedException();
		}

		public void AddReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener) {
			throw new NotImplementedException();
		}

		public bool DoesKeyExist(object o, string configHeader, string configKey) {
			throw new NotImplementedException();
		}

		public Task<DiscordChannel> GetChannel(object o, ulong channelId) {
			throw new NotImplementedException();
		}

		public T GetCommand<T>(object o, ulong guildId) where T : CommandBase {
			if (GuildCommands.ContainsKey(guildId)) {
				return GuildCommands[guildId].First(c => c.Value is T).Value as T;
			}
			return null;
		}

		public string GetCommandCommonDataPath(object o, CommandBase command) {
			return "commondatapath";
		}

		public string GetCommandInstanceDataPath(object o, CommandBase command) {
			return "instancedatapath";
		}

		public string GetHelpCommandTerm(object o, ulong guildId) {
			throw new NotImplementedException();
		}

		public Task<DiscordUser> GetUser(object o, ulong userId) {
			throw new NotImplementedException();
		}

		public Task<bool> IsUserAdmin(object o, DiscordGuild guild, DiscordChannel channel, DiscordUser user) {
			throw new NotImplementedException();
		}

		public void Log(object o, LogEventArgs e) {
			LogEvents.Add(e);
		}

		public string ReadConfig(object o, string configHeader, string configKey) {
			throw new NotImplementedException();
		}

		public void RemoveMessageListener(object o, ulong guildId, IMessageListener messageListener) {
			throw new NotImplementedException();
		}

		public void RemoveReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener) {
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

		public void WriteConfig(object o, string configHeader, string configKey, string configValue) {
			throw new NotImplementedException();
		}
	}
}

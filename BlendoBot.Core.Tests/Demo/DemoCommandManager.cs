using BlendoBot.Core.Command;
using BlendoBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoCommandManager : ICommandManager {
		public readonly Dictionary<ulong, Dictionary<string, BaseCommand>> GuildCommands = new();
		public readonly Dictionary<ulong, List<IMessageListener>> GuildMessageListeners = new();
		public string CommandPrefix = "?";

		public bool AddCommand(ulong guildId, BaseCommand command) {
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

		public static string GenerateUniqueName(HashSet<string> existingNames, string targetName, int maxAttempts = 100) {
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

		public T GetCommand<T>(object o, ulong guildId) where T : BaseCommand {
			if (GuildCommands.ContainsKey(guildId)) {
				return GuildCommands[guildId].FirstOrDefault(c => c.Value is T).Value as T;
			}
			return null;
		}

		public string GetCommandCommonDataPath(object o, BaseCommand command) {
			return "commondatapath";
		}

		public string GetCommandInstanceDataPath(object o, BaseCommand command) {
			return "instancedatapath";
		}

		public string GetHelpCommandTerm(object o, ulong guildId) {
			return CommandPrefix + "help";
		}

		public string GetCommandTerm(object o, BaseCommand command) {
			return CommandPrefix + command.Term;
		}

		public BaseCommand GetCommandByTerm(object o, ulong guildId, string term) {
			if (GuildCommands.ContainsKey(guildId) && GuildCommands[guildId].TryGetValue(term, out BaseCommand command)) {
				return command;
			}
			return null;
		}

		public BaseCommand GetCommandByGuid(object o, ulong guildId, string guid) {
			if (GuildCommands.ContainsKey(guildId)) {
				return GuildCommands[guildId].Values.FirstOrDefault(c => c.Guid == guid);
			}
			return null;
		}

		public void AddMessageListener(object o, ulong guildId, IMessageListener messageListener) {
			throw new NotImplementedException();
		}

		public void RemoveMessageListener(object o, ulong guildId, IMessageListener messageListener) {
			throw new NotImplementedException();
		}

		public void AddReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener) {
			throw new NotImplementedException();
		}

		public void RemoveReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener) {
			throw new NotImplementedException();
		}

		public string GetCommandPrefix(object o, ulong guildId) => CommandPrefix;
	}
}

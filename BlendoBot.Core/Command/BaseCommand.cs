using BlendoBot.Core.Interfaces;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command {
	/// <summary>
	/// The base class for implementing common command functionality. Commands should extend this class and define
	/// their own functionality. All command should also include a <see cref="CommandAttribute"/>.
	/// </summary>
	public abstract class BaseCommand {
		protected BaseCommand(ulong guildId, IBotMethods botMethods) {
			GuildId = guildId;
			BotMethods = botMethods;
			attribute = GetType().GetCustomAttributes<CommandAttribute>().Single();
			DepdenentCommands = GetType().GetCustomAttributes<CommandDependencyAttribute>().Select(cd => cd.DependsOn).ToArray();
			Version = GetType().Assembly.GetName().Version?.ToString() ?? "1.0.0";
			Term = DefaultTerm;
		}

		private readonly CommandAttribute attribute;

		/// <summary>
		/// The commands that this command depends on. Ideally if a command is disabled for a guild, all the dependent
		/// commands should be disabled as well. Optional dependencies should be internally handled by the
		/// implementation and shouldn't be in this array.
		/// </summary>
		public Type[] DepdenentCommands { get; init; }

		/// <summary>
		/// The guild ID that this command reacts to. This is so the command is aware of its specific instance.
		/// </summary>
		public ulong GuildId { get; init; }

		/// <summary>
		/// References delegated functions that commands can use to interact with Discord and the program.
		/// </summary>
		public IBotMethods BotMethods { get; init; }

		/// <summary>
		/// The string that users will need to type in order to access this command. This starts with the
		/// <see cref="DefaultTerm"/>, but will inevitably be unique for each command within a guild.
		/// </summary>
		public string Term { get; set; }

		/// <summary>
		/// The default string that users will need to type in order to access this command. This may not necessarily
		/// be what the user ends up typing, but it should be something that's reasonably identifiable to the command.
		/// </summary>
		public string DefaultTerm => attribute.DefaultTerm;

		/// <summary>
		/// The user-friendly name for this command. This should be presentable in an about context.
		/// </summary>
		public string Name => attribute.Name;

		/// <summary>
		/// The user-unfriendly name for this command. Should only be referred to by programs to ensure the uniqueness
		/// of a command.
		/// </summary>
		public string Guid => attribute.Guid;

		/// <summary>
		/// A description of this command. Appears in about. This is just to describe the high level functionality of
		/// the command and shouldn't be duplicating <see cref="Usage"/>.
		/// </summary>
		public abstract string Description { get; }

		/// <summary>
		/// A string representing the typical usage of the command. Appears in help commands.
		/// </summary>
		public abstract string Usage { get; }

		/// <summary>
		/// The author of the command. Appears in about commands.
		/// </summary>
		public string Author => attribute.Author;

		/// <summary>
		/// The version of the command. Appears in about commands.
		/// </summary>
		public string Version { get; init; }

		/// <summary>
		/// Called when this instance is being constructed and added to the guild. All instances of all commands must
		/// return true from this before they can be added to the program's roster of active commands. This is useful
		/// for late-loaded commands, or commands that must initialise something shared across all instances of it.
		/// </summary>
		public abstract Task<bool> Startup();

		/// <summary>
		/// Called when this command's term is invoked in a guild channel. The command can do what it wants from here
		/// on, but ideally it should present something back to the channel that sent the command.
		/// </summary>
		public abstract Task OnMessage(MessageCreateEventArgs e);
	}
}

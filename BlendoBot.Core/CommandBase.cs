﻿using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core {
	public abstract class CommandBase {
		protected CommandBase(ulong guildId, IBotMethods botMethods) {
			GuildId = guildId;
			BotMethods = botMethods;
			attribute = GetType().GetCustomAttributes(typeof(CommandAttribute)).Single() as CommandAttribute;
			Version = GetType().Assembly.GetName().Version?.ToString() ?? "1.0.0";
			Term = DefaultTerm;
		}

		private CommandAttribute attribute;

		/// <summary>
		/// The guild ID that this command reacts to. This is useful for commands to load persistent memory related to
		/// a specific guild.
		/// </summary>
		public ulong GuildId { get; init; }

		/// <summary>
		/// References delegated functions that commands can use to interact with Discord and the program.
		/// </summary>
		public IBotMethods BotMethods { get; init; }

		/// <summary>
		/// The string that users will need to type in order to access this command.
		/// </summary>
		public string Term { get; set; }

		/// <summary>
		/// The default string that users will need to type in order to access this command.
		/// </summary>
		public string DefaultTerm => attribute.DefaultTerm;

		/// <summary>
		/// The user-friendly name for this command. Appears in help.
		/// </summary>
		public string Name => attribute.Name;

		/// <summary>
		/// A description of this command. Appears in help.
		/// </summary>
		public abstract string Description { get; }

		/// <summary>
		/// A string representing the typical usage of the command. Appears in help.
		/// </summary>
		public abstract string Usage { get; }

		/// <summary>
		/// The author of the command. Appears in about.
		/// </summary>
		public string Author => attribute.Author;

		/// <summary>
		/// The version of the command. Appears in about.
		/// </summary>
		public string Version { get; init; }

		/// <summary>
		/// The functions that should setup this command. This is very useful for commands that require
		/// some persistent memory across usages. The return determines whether the startup was
		/// successful or not. If it is unsuccessful, the command will not be added to the bot.
		/// </summary>
		public abstract Task<bool> Startup();

		/// <summary>
		/// The function that handles this command. Since all commands are made by creating an
		/// event, all command handles must forward the MessageCreateEventArgs from when the
		/// message was received. They're also async, so they'll need to return Task.
		/// </summary>
		public abstract Task OnMessage(MessageCreateEventArgs e);
	}
}

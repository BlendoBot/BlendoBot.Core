using BlendoBot.Core.Entities;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// Handles sending and receiving data from Discord.
	/// </summary>
	public interface IDiscordInteractor : IBotService {

		/// <summary>
		/// Sends a message given a source object (for debugging) and an args object.
		/// </summary>
		Task<DiscordMessage> SendMessage(object o, SendMessageEventArgs e);

		/// <summary>
		/// Sends a file given a source object (for debugging) and an args object.
		/// </summary>
		Task<DiscordMessage> SendFile(object o, SendFileEventArgs e);

		/// <summary>
		/// Sends an exception given a source object (for debugging) and an args object. Exceptions are more for just
		/// throwing out debugging at a user and shouldn't be intended for proper use cases.
		/// </summary>
		Task<DiscordMessage> SendException(object o, SendExceptionEventArgs e);

		/// <summary>
		/// Returns whether a user for a given guild is an admin. This is true if either the user is a guild admin in
		/// Discord, or if they've been manually granted admin via the bot's admin co
		/// </summary>
		Task<bool> IsUserAdmin(object o, DiscordGuild guild, DiscordChannel channel, DiscordUser user);

		/// <summary>
		/// Given a channel ID, returns the channel object.
		/// </summary>
		Task<DiscordChannel> GetChannel(object o, ulong channelId);

		/// <summary>
		/// Given a user ID, returns the user object.
		/// </summary>
		Task<DiscordUser> GetUser(object o, ulong userId);
	}
}

using BlendoBot.Core.Command;
using BlendoBot.Core.Entities;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace BlendoBot.Core.Services;

/// <summary>
/// Handles sending and receiving data from Discord.
/// </summary>
public interface IDiscordInteractor : IBotService {
	/// <summary>
	/// Sends a message given a source object (for debugging) and an args object. The args should describe all the
	/// information that gets sent to the channel.
	/// </summary>
	Task<DiscordMessage> Send(object o, SendEventArgs e);

	/// <summary>
	/// Sends a generic message telling the user to correct the arguments when using a command.
	/// </summary>
	Task<DiscordMessage> SendUnknownArgumentsMessage(object o, DiscordChannel channel, ICommand command);

	/// <summary>
	/// Returns whether a user for a given guild is a guild admin. For users that are also a BlendoBot admin, use
	/// <see cref="IAdminRepository.IsUserAdmin(object, DiscordGuild, DiscordChannel, DiscordUser)"/>.
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

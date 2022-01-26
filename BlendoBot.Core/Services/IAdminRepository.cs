using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace BlendoBot.Core.Services;

/// <summary>
/// Handles authenticating whether a user is a BlendoBot admin.
/// </summary>
public interface IAdminRepository : IBotService {

	/// <summary>
	/// Returns whether a user for a given guild is a BlendoBot admin. This returns true only if the user has been
	/// granted an admin by the bot, and not if they're a guild admin. Commands should generally use
	/// <see cref="IsUserAdmin(object, DiscordGuild, DiscordChannel, DiscordUser)"/> to catch both cases. If you
	/// just want whether they're a guild admin, use
	/// <see cref="IDiscordInteractor.IsUserAdmin(object, DiscordGuild, DiscordChannel, DiscordUser)"/>.
	/// </summary>
	Task<bool> IsUserBlendoBotAdmin(object o, DiscordGuild guild, DiscordChannel channel, DiscordUser user);

	/// <summary>
	/// Returns whether a user for a given guild is an admin. This is true either if
	/// <see cref="IsUserBlendoBotAdmin(object, DiscordGuild, DiscordChannel, DiscordUser)(object, DiscordGuild, DiscordChannel, DiscordUser)"/>
	/// or <see cref="IDiscordInteractor.IsUserAdmin(object, DiscordGuild, DiscordChannel, DiscordUser)"/> are true.
	/// </summary>
	Task<bool> IsUserAdmin(object o, DiscordGuild guild, DiscordChannel channel, DiscordUser user);
}

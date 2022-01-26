using BlendoBot.Core.Module;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace BlendoBot.Core.Reactions;

/// <summary>
/// The public interface for a reaction listener. All reaction listeners must implement this. Reaction listeners
/// are registered with <see cref="Services.IModuleManager.RegisterReactionListener(IModule, BlendoBot.Core.Reactions.IReactionListener, ulong)"/>
/// on a single message, and are only invoked on reaction additions to that message.
/// </summary>
public interface IReactionListener {
	/// <summary>
	/// Called when a reaction is added to the message this is registered to.
	/// </summary>
	Task OnReactionAdd(MessageReactionAddEventArgs e);

	/// <summary>
	/// The module that this reaction listener belongs to.
	/// </summary>
	IModule Module { get; }
}

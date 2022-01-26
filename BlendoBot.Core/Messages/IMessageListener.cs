using BlendoBot.Core.Module;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace BlendoBot.Core.Messages;

/// <summary>
/// The public interface for a message listener. All message listeners must implement this. Message listeners
/// are registered with <see cref="Services.IModuleManager.RegisterMessageListener(IModule, BlendoBot.Core.Messages.IMessageListener)"/>
/// on an entire guild, and are responsible for managing their own scope.
/// </summary>
public interface IMessageListener {
	/// <summary>
	/// Called when any message in sent in the guild.
	/// </summary>
	Task OnMessage(MessageCreateEventArgs e);

	/// <summary>
	/// The module that this message listener belongs to.
	/// </summary>
	IModule Module { get; }
}

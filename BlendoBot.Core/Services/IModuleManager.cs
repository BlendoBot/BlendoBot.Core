using BlendoBot.Core.Command;
using BlendoBot.Core.Messages;
using BlendoBot.Core.Module;
using BlendoBot.Core.Reactions;

namespace BlendoBot.Core.Services;

/// <summary>
/// Manages all modules for this bot, and exposes functionality for modules to extend themselves with.
/// </summary>
public interface IModuleManager : IBotService {
	/// <summary>
	/// Registers a command under the supplied module. Outputs the term that the command is mapped to.
	/// Returns whether the command was successfully registered or not.
	/// </summary>
	public bool RegisterCommand(IModule module, ICommand command, out string commandTerm);

	/// <summary>
	/// Unregisters a command. Returns whether the command was successfully unregistered. If the command
	/// was not registered already, this returns false.
	/// </summary>
	public bool UnregisterCommand(IModule module, ICommand command);

	/// <summary>
	/// Registers a message listener under the supplied module. Returns whether the message listener was
	/// successfully registered or not.
	/// </summary>
	public bool RegisterMessageListener(IModule module, IMessageListener messageListener);

	/// <summary>
	/// Unregisters a message listener. Returns whether the message listener was successfully unregistered.
	/// If the message listener was not registered already, this returns false.
	/// </summary>
	public bool UnregisterMessageListener(IModule module, IMessageListener messageListener);

	/// <summary>
	/// Registers a reaction listener under the supplied module. Returns whether the reactionn listener was
	/// successfully registered or not.
	/// </summary>
	public bool RegisterReactionListener(IModule module, IReactionListener reactionListener, ulong messageId);

	/// <summary>
	/// Unregisters a reaction listener. Returns whether the reaction listener was successfully unregistered.
	/// If the reaction listener was not registered already, this returns false.
	/// </summary>
	public bool UnregisterReactionListener(IModule module, IReactionListener reactionListener, ulong messageId);

	/// <summary>
	/// Returns the current registered term for a command.
	/// </summary>
	public string GetCommandTerm(ICommand command);

	/// <summary>
	/// Returns the current registered term for a command including the guild's command prefix at the beginning.
	/// </summary>
	public string GetCommandTermWithPrefix(ICommand command);

	/// <summary>
	/// Returns what a user would type to get help on a command.
	/// </summary>
	public string GetHelpTermForCommand(ICommand command);

	/// <summary>
	/// Returns a guild's instance of a supplied module.
	/// </summary>
	public T GetModule<T>(ulong guildId) where T : IModule;
}

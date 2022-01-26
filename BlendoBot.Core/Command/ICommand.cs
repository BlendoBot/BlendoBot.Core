using BlendoBot.Core.Module;
using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command;

/// <summary>
/// Defines a command that can be registered
/// </summary>
public interface ICommand {
	/// <summary>
	/// The module that this command belongs to.
	/// </summary>
	public IModule Module { get; }

	/// <summary>
	/// A unique identifier for this command. Commands with the same GUID should be treated as the same instance
	/// of a command (i.e. the GUID tells BlendoBot whether it's the same command or not).
	/// </summary>
	public string Guid { get; }

	/// <summary>
	/// The term that this command would ideally be called. Frontends should respect this if no other commands
	/// within this guild have this term, but a command may not necessarily get this term if there's a guild
	/// specified rename, or if there's already a command with this name. This is not the current term of the
	/// command.
	/// </summary>
	public string DesiredTerm { get; }

	/// <summary>
	/// A user friendly description of what the command does.
	/// </summary>
	public string Description { get; }

	/// <summary>
	/// A mapping of parameter types to user friendly descriptions of how to use the command. You may provide
	/// a key of <see cref="string.Empty"/> for no parameter instructions. You may also indicate general
	/// instructions by using keys that begin with an upper-case character (i.e. "General Instructions"). Do note
	/// that a maximum of ten keys can exist in this mapping, and each value can be at most 1024 characters.
	/// </summary>
	public Dictionary<string, string> Usage { get; }

	/// <summary>
	/// Called when this command's term is invoked in a guild channel. The command can do what it wants from here
	/// on, but ideally it should present something back to the channel that sent the command.
	/// <paramref name="tokenizedMessage"/> should be the user's sent message, without the command term, split on
	/// spaces (handling quotations). The raw message is always available in <paramref name="e"/>.
	/// </summary>
	public abstract Task OnMessage(MessageCreateEventArgs e, string[] tokenizedMessage);
}

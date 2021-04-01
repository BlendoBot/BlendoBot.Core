using BlendoBot.Core.Command;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// The public interface for a reaction listener. All reaction listeners must implement this.
	/// </summary>
	public interface IReactionListener {
		/// <summary>
		/// Fired whenever a reaction is added to a message in the guild. The reaction listener should properly
		/// determine whether it responds to the action or not.
		/// </summary>

		Task OnReactionAdd(MessageReactionAddEventArgs e);

		/// <summary>
		/// The command that this message listener relates to.
		/// </summary>
		BaseCommand Command { get; }
	}
}

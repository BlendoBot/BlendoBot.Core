using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace BlendoBot.Core {
	/// <summary>
	/// The public interface for a reaction listener. All reaction listeners must implement this.
	/// </summary>
	public interface IReactionListener {

		Task OnReactionAdd(MessageReactionAddEventArgs e);

		CommandBase Command { get; }
	}
}

using BlendoBot.Core.Command;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// The public interface for a message listener. All message listeners must implement this.
	/// </summary>
	public interface IMessageListener {
		/// <summary>
		/// Fired whenever a message is sent to the guild. The message listener should properly determine whether it
		/// responds to the message or not.
		/// </summary>
		Task OnMessage(MessageCreateEventArgs e);

		/// <summary>
		/// The command that this message listener relates to.
		/// </summary>
		BaseCommand Command { get; }
	}
}

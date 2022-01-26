using DSharpPlus.Entities;
using System;

namespace BlendoBot.Core.Entities;

/// <summary>
/// An object that contains various arguments involved with sending a message.
/// </summary>
public class SendEventArgs : EventArgs {
	/// <summary>
	/// The body of the message that will be sent.
	/// </summary>
	public string Message { get; set; }

	/// <summary>
	/// The local path to a file to send.
	/// </summary>
	public string FilePath { get; set; }

	/// <summary>
	/// An exception to print along with the message.
	/// </summary>
	public Exception Exception { get; set; }

	/// <summary>
	/// An embed to print along with the message. This will not be shown in the instance of an exception!
	/// </summary>
	public DiscordEmbed Embed { get; set; }

	/// <summary>
	/// The channel to send to.
	/// </summary>
	public DiscordChannel Channel { get; set; }

	/// <summary>
	/// A tag for this event, will be logged to help diagnose what kind of data got run. This should not contain
	/// user data.
	/// </summary>
	public string Tag { get; set; }
}

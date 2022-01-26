using BlendoBot.Core.Entities;

namespace BlendoBot.Core.Services;

/// <summary>
/// Logs to a source whenever invoked. It is the front-end's responsibility to tell the bot maintainer where these
/// logs are sent to.
/// </summary>
public interface ILogger : IBotService {
	/// <summary>
	/// Logs a message given a source object (for debugging) and an args object.
	/// </summary>
	void Log(object o, LogEventArgs e);
}

using BlendoBot.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
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
}

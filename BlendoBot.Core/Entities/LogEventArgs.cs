using System;
using System.Collections.Generic;
using System.Text;

namespace BlendoBot.Core.Entities {
	/// <summary>
	/// Various types to help specify between log messages.
	/// </summary>
	public enum LogType {
		/// <summary>
		/// For logging purposes and indicates everything is running smoothly.
		/// </summary>
		Log,
		/// <summary>
		/// For when something can lead to an error, but things are working correctly for now.
		/// </summary>
		Warning,
		/// <summary>
		/// For when a problem has occurred, things may not be working correctly now.
		/// </summary>
		Error,
		/// <summary>
		/// For when the program cannot continue anymore.
		/// </summary>
		Critical
	}

	/// <summary>
	/// A log event consists of a log type and a message. This encapsulates both.
	/// </summary>
	public class LogEventArgs {
		public LogType Type { get; set; }
		public string Message { get; set; }
	}
}

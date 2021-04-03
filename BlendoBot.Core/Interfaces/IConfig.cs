using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// An interface to manage frontend configuration. The config should consist of dictionary of dictionaries of
	/// strings (i.e. a string header key, followed by a string config key should return a string value).
	/// </summary>
	public interface IConfig : IBotService {
		/// <summary>
		/// Reads a string from the config given a source object (for debugging), a header name of the config section
		/// and a given key.
		/// <exception cref="IndexOutOfRangeException">If the header or key does not exist.</exception>
		/// </summary>
		string ReadConfig(object o, string configHeader, string configKey);

		/// <summary>
		/// Reads a string from the config given a source object (for debugging), a header name of the config section,
		/// a given key and a default value if that key doesn't exist. The result will be the supplied default value if
		/// the header or key do not exist.
		/// </summary>
		string ReadConfigOrDefault(object o, string configHeader, string configKey, string defaultValue);

		/// <summary>
		/// Returns whether a key exists in the config or not. This is useful for commands that wish to change some
		/// behaviour based on whether a key exists.
		/// </summary>
		bool DoesConfigKeyExist(object o, string configHeader, string configKey);

		/// <summary>
		/// Writes a string to the config given a source object (for debugging), a given key/value pair and the
		/// header name of the config section.
		/// </summary>
		void WriteConfig(object o, string configHeader, string configKey, string configValue);
	}
}

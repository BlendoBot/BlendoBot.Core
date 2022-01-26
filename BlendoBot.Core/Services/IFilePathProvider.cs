using BlendoBot.Core.Module;

namespace BlendoBot.Core.Services;

/// <summary>
/// An interface to provide modules paths to locations where it can store files.
/// </summary>
public interface IFilePathProvider : IBotService {
	/// <summary>
	/// Returns a directory path that is unique to this module, but common across all guilds. This is
	/// intended for modules which persist data across multiple guilds. The returned directory should
	/// exist if it doesn't already after calling this method.
	/// </summary>
	string GetCommonDataDirectoryPath(IModule module);

	/// <summary>
	/// Returns a directory path that is unique to this module within the guild. This is intended for
	/// modules persisting their own data without interacting with other modules or guilds. The returned
	/// directory should exist if it doesn't already after calling this method.
	/// </summary>
	string GetDataDirectoryPath(IModule module);
}

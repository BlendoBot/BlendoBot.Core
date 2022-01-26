using System;

namespace BlendoBot.Core.Module;

/// <summary>
/// Defines this class as a module for BlendoBot. Classes with this attribute MUST have only one constructor. That
/// constructor can only take <see cref="IBotService"/> derived parameters.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ModuleAttribute : Attribute {
	/// <summary>
	/// A human readable name of the module.
	/// </summary>
	public string Name { get; init; }

	/// <summary>
	/// A unique GUID for this module. This may be presented to an administrator of the bot for them to identify
	/// your module.
	/// </summary>
	public string Guid { get; init; }

	/// <summary>
	/// The author of the module, used purely to help identify the module.
	/// </summary>
	public string Author { get; init; }

	/// <summary>
	/// The version of the module. Should be used to identify this module for debugging.
	/// </summary>
	public string Version { get; init; }

	/// <summary>
	/// The URL of the module, such as a GitHub repository link.
	/// </summary>
	public string Url { get; init; }
}

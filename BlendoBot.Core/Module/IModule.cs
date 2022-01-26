using System.Threading.Tasks;

namespace BlendoBot.Core.Module;

/// <summary>
/// Defines a class as a BlendoBot module, and thus can be loaded into the program. Modules are instanced per-guild
/// and should be responsible for the business logic for a feature. Modules should be constructed exclusively with
/// <see cref="Services.IBotService"/> implemented types. Modules should also include the annotation <see cref="ModuleAttribute"/>
/// to define details about them, and optionally <see cref="ModuleDependencyAttribute"/> to describe load order
/// dependencies with other modules.
/// </summary>
public interface IModule {
	/// <summary>
	/// Executed when the module has been created but not yet added to a guild. Returns whether the module is able
	/// to successfully instantiate everything.
	/// </summary>
	public Task<bool> Startup(ulong guildId);
}

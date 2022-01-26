using System;

namespace BlendoBot.Core.Module;

/// <summary>
/// Defines a dependency that the module with this attribute has. The module with this attribute cannot be created
/// for a guild that does not have the <see cref="DependsOn"/> module instantiated.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ModuleDependencyAttribute : Attribute {
	public Type DependsOn { get; init; }
}

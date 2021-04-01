using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command {
	/// <summary>
	/// Defines a command that this command depends on to function. Note that cyclic dependencies are not valid, so a
	/// command cannot depend on another command that inevitably relies on it.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class CommandDependencyAttribute : Attribute {
		public Type DependsOn { get; init; }
	}
}

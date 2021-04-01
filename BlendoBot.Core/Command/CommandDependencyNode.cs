using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command {
	/// <summary>
	/// Describes a node in the command dependency tree.
	/// </summary>
	public class CommandDependencyNode {
		/// <summary>
		/// The command's type. This is always assignable to a <see cref="BaseCommand"/>.
		/// </summary>
		public Type CommandType { get; init; }

		/// <summary>
		/// The guid of the command. This helps identify uniqueness.
		/// </summary>
		public string Guid { get; init; }

		/// <summary>
		/// All the nodes that this command depends on to exist. The key is the <see cref="Guid"/> of that node.
		/// </summary>
		public IReadOnlyDictionary<string, CommandDependencyNode> DependsOn => dependsOn;
		internal Dictionary<string, CommandDependencyNode> dependsOn = new();

		/// <summary>
		/// All the nodes that depend on this command to exist. The key is the <see cref="Guid"/> of that node.
		/// </summary>
		public IReadOnlyDictionary<string, CommandDependencyNode> DependedBy => dependedBy;
		internal Dictionary<string, CommandDependencyNode> dependedBy = new();

		internal CommandDependencyNode(Type commandType, string guid) {
			CommandType = commandType;
			Guid = guid;
		}
	}
}

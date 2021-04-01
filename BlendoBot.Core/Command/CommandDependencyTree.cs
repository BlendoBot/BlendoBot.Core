using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command {
	/// <summary>
	/// Describes the command dependency tree with a given set of commands. Commands that are referred to via
	/// dependencies and not explicitly given will be implicitly added to this tree.
	/// </summary>
	public class CommandDependencyTree {
		/// <summary>
		/// All the commands in this dependency tree, keyed by the <see cref="Guid"/> of the command.
		/// </summary>
		public IReadOnlyDictionary<string, CommandDependencyNode> Nodes => nodes;
		private readonly Dictionary<string, CommandDependencyNode> nodes = new();

		/// <summary>
		/// All the commands in this dependency tree that do not depend on any other commands, keyed by the
		/// <see cref="Guid"/> of the command.
		/// </summary>
		public IReadOnlyDictionary<string, CommandDependencyNode> NoDependencyNodes => noDependencyNodes;
		private readonly Dictionary<string, CommandDependencyNode> noDependencyNodes = new();

		public CommandDependencyTree(Type[] commandTypes) {
			if (commandTypes.All(t => t.IsAssignableTo(typeof(BaseCommand)))) {
				foreach (var type in commandTypes) {
					var seenGuids = new Stack<string>();
					InitialiseCommandType(type, seenGuids);
				}
			} else {
				throw new ArgumentException($"Not all commands are of type {nameof(BaseCommand)}");
			}
		}

		private void InitialiseCommandType(Type commandType, Stack<string> seenGuids) {
			var attribute = commandType.GetCustomAttribute<CommandAttribute>();
			CommandDependencyNode currentNode;
			bool existingNode;
			if (nodes.ContainsKey(attribute.Guid)) {
				currentNode = nodes[attribute.Guid];
				existingNode = true;
			} else {
				currentNode = new(commandType, attribute.Guid);
				nodes[attribute.Guid] = currentNode;
				existingNode = false;
			}
			if (seenGuids.Count > 0) {
				var previousNode = nodes[seenGuids.Peek()];
				previousNode.dependsOn[attribute.Guid] = currentNode;
				currentNode.dependedBy[seenGuids.Peek()] = previousNode;
			}
			if (seenGuids.Contains(attribute.Guid)) {
				throw new InvalidOperationException($"Circular dependency detected, {string.Join(" -> ", seenGuids)} -> {attribute.Guid}");
			}
			if (!existingNode) {
				seenGuids.Push(attribute.Guid);
				var dependencies = commandType.GetCustomAttributes<CommandDependencyAttribute>();
				if (dependencies.Any()) {
					foreach (var dependency in dependencies) {
						InitialiseCommandType(dependency.DependsOn, seenGuids);
					}
				} else {
					noDependencyNodes.Add(attribute.Guid, currentNode);
				}
				seenGuids.Pop();
			}
		}
	}
}

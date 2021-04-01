using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Command {
	/// <summary>
	/// Defines details about a command. These will populate fields in <see cref="BaseCommand"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class CommandAttribute : Attribute {
		public string Guid { get; init; }
		public string Name { get; init; }
		public string Author { get; init; }
		public string DefaultTerm { get; init; }
	}
}

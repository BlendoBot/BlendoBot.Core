using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// An interface that allows services to be received. Services are assumed to be singleton so the same instance of
	/// a service should exist for all guilds and commands.
	/// </summary>
	public interface IBotServiceProvider {
		/// <summary>
		/// Returns a service of type T or returns null.
		/// </summary>
		T GetService<T>() where T : IBotService;
	}
}

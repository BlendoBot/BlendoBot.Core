using BlendoBot.Core.Command;
using BlendoBot.Core.Entities;
using BlendoBot.Core.Interfaces;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoServiceProvider : IBotServiceProvider {
		public readonly DemoCommandManager CommandManager = new();
		public readonly DemoConfig Config = new();
		public readonly DemoDiscordInteractor DiscordInteractor = new();
		public readonly DemoLogger Logger = new();

		public T GetService<T>() where T : IBotService => (T)(typeof(T) switch {
			ICommandManager => (IBotService)CommandManager,
			IConfig => Config,
			IDiscordInteractor => DiscordInteractor,
			ILogger => Logger,
			_ => default
		});
	}
}

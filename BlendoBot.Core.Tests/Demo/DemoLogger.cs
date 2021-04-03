using BlendoBot.Core.Entities;
using BlendoBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoLogger : ILogger {
		public readonly List<LogEventArgs> LogEvents = new();

		public void Log(object o, LogEventArgs e) {
			LogEvents.Add(e);
		}
	}
}

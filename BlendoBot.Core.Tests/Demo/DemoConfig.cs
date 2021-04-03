using BlendoBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Tests.Demo {
	class DemoConfig : IConfig {
		public bool DoesConfigKeyExist(object o, string configHeader, string configKey) {
			throw new NotImplementedException();
		}

		public string ReadConfig(object o, string configHeader, string configKey) {
			throw new NotImplementedException();
		}

		public string ReadConfigOrDefault(object o, string configHeader, string configKey, string defaultValue) {
			throw new NotImplementedException();
		}

		public void WriteConfig(object o, string configHeader, string configKey, string configValue) {
			throw new NotImplementedException();
		}
	}
}

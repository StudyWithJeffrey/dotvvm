using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotVVM.Framework.Configuration
{
    public class DefaultSerializerSettingsProvider : ISerializerSettingsProvider
    {
        public JsonSerializerSettings Settings { get; private set; }

        public DefaultSerializerSettingsProvider()
        {
            Settings = new JsonSerializerSettings();
        }
    }
}

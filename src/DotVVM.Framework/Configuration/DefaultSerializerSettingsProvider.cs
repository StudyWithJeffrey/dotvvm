using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotVVM.Framework.Configuration
{
    public class DefaultSerializerSettingsProvider : ISerializerSettingsProvider
    {
        public JsonSerializerSettings Settings { get; private set; }

        public static DefaultSerializerSettingsProvider Instance { get; private set; }

        public DefaultSerializerSettingsProvider()
        {
            Settings = new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            };
            Settings.Converters.Add(new DotvvmDateTimeConverter());
            Settings.Converters.Add(new StringEnumConverter());

            if (Instance == null)
                Instance = this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotVVM.Framework.Configuration
{
    public interface ISerializerSettingsProvider
    {
        JsonSerializerSettings Settings { get; }
    }
}

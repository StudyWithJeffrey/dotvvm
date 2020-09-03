﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Diagnostics.Models;
using Newtonsoft.Json;

namespace DotVVM.Framework.Diagnostics
{

    public class DiagnosticsInformationSender : IDiagnosticsInformationSender
    {
        private DotvvmDiagnosticsConfiguration configuration;
        private readonly ISerializerSettingsProvider serializerSettingsProvider;

        public DiagnosticsInformationSender(DotvvmDiagnosticsConfiguration configuration, ISerializerSettingsProvider serializerSettingsProvider)
        {
            this.configuration = configuration;
            this.serializerSettingsProvider = serializerSettingsProvider;
        }

        public async Task SendInformationAsync(DiagnosticsInformation information)
        {
            var hostname = configuration.GetDiagnosticsServerHostname();
            var port = configuration.GetDiagnosticsServerPort();
            if (hostname != null && port.HasValue)
            {
                using (var client = new TcpClient())
                {
                    try
                    {
                        await client.ConnectAsync(hostname, port.Value);
                        using (var stream = new StreamWriter(client.GetStream()))
                        {
                            await stream.WriteAsync(JsonConvert.SerializeObject(information, serializerSettingsProvider.Settings));
                            await stream.FlushAsync();
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
        }
    }
}

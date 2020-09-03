﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DotVVM.Framework.Configuration
{
    internal class DotvvmConfigurationException : Exception
    {
        internal DotvvmConfigurationException()
        {
        }

        internal DotvvmConfigurationException(string message) : base(message)
        {
        }

        internal DotvvmConfigurationException(DotvvmConfiguration configuration, List<DotvvmConfigurationAssertResult<RouteBase>> routes, List<DotvvmConfigurationAssertResult<DotvvmControlConfiguration>> controls)
            : base(message: BuildMessage(configuration, routes, controls))
        {
        }

        private static string BuildMessage(DotvvmConfiguration configuration, List<DotvvmConfigurationAssertResult<RouteBase>> routes, List<DotvvmConfigurationAssertResult<DotvvmControlConfiguration>> controls)
        {
            var sb = new StringBuilder();
            BuildRoutesMessage(routes, sb);
            BuildControlsMessage(configuration, controls, sb);
            return sb.ToString();
        }

        private static void BuildRoutesMessage(List<DotvvmConfigurationAssertResult<RouteBase>> routes, StringBuilder sb)
        {
            sb.AppendLine("DotvvmConfiguration contains incorrect registrations.");
            if (routes != null && routes.Any())
            {
                var routeNameMissing = false;
                sb.AppendLine("Invalid route registrations: ");
                foreach (var routeBase in routes)
                {
                    if (routeBase.Reason == DotvvmConfigurationAssertReason.MissingRouteName)
                    {
                        routeNameMissing = true;
                    }

                    if (routeBase.Reason == DotvvmConfigurationAssertReason.MissingFile)
                    {
                        sb.Append("Route '");
                        sb.Append(routeBase.Value.RouteName);
                        sb.Append("' has missing file '");
                        sb.Append(routeBase.Value.VirtualPath);
                        sb.Append("'.");
                        sb.AppendLine();
                    }
                }

                if (routeNameMissing)
                {
                    sb.AppendLine("One ore more routes have missing name!");
                }

                sb.AppendLine();
            }
        }

        private static void BuildControlsMessage(DotvvmConfiguration configuration, List<DotvvmConfigurationAssertResult<DotvvmControlConfiguration>> controls, StringBuilder sb)
        {
            var serializationSettingsProvider = configuration.ServiceProvider.GetRequiredService<ISerializerSettingsProvider>();
            if (controls != null && controls.Any())
            {
                sb.AppendLine("Invalid control registrations: ");
                foreach (var control in controls)
                {
                    if (control.Reason == DotvvmConfigurationAssertReason.InvalidCombination)
                    {
                        sb.Append("Control '");
                        sb.Append(JsonConvert.SerializeObject(control.Value, serializationSettingsProvider.Settings));
                        sb.Append("' has set invalid combination of properties.");
                    }

                    if (control.Reason == DotvvmConfigurationAssertReason.MissingFile)
                    {
                        sb.Append("Control '");
                        sb.Append(control.Value.TagPrefix ?? "<null>");
                        sb.Append(":");
                        sb.Append(control.Value.TagName ?? "<null>");
                        sb.Append("' has missing file '");
                        sb.Append(control.Value.Src ?? "<null>");
                        sb.Append("'.");
                    }
                    sb.AppendLine();
                }
            }
        }

        protected DotvvmConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

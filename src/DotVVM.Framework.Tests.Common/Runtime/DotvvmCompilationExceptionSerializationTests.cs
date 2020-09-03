using System;
using System.Collections.Generic;
using System.Text;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DotVVM.Framework.Tests.Common.Runtime
{
    [TestClass]
    public class DotvvmCompilationExceptionSerializationTests
    {
        private DotvvmConfiguration configuration;

        [TestInitialize]
        public void TestInit()
        {
            configuration = DotvvmConfiguration.CreateDefault(services => {
                services.AddSingleton<ISerializerSettingsProvider, DefaultSerializerSettingsProvider>();
            });
        }

        [TestMethod]
        public void DotvvmCompilationException_SerializationAndDeserialization_WorksCorrectly()
        {
            var compilationException =
                new DotvvmCompilationException("Compilation error", new Exception("inner exception"));

            var settings = configuration.ServiceProvider.GetRequiredService<ISerializerSettingsProvider>().Settings;
            var serializedObject = JsonConvert.SerializeObject(compilationException, settings);

            var deserializedObject = JsonConvert.DeserializeObject<DotvvmCompilationException>(serializedObject);
        }
    }
}

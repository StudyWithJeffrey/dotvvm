﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.CommandLine.Commands.Core;
using DotVVM.CommandLine.Metadata;
using DotVVM.CommandLine.ProjectSystem;
using DotVVM.CommandLine.Commands.Templates;
using DotVVM.CommandLine.Core;
using DotVVM.CommandLine.Core.Metadata;
using DotVVM.CommandLine.Security;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Security;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DotVVM.CommandLine.Commands.Handlers
{
    public class GenerateUiTestStubCommandHandler : CommandBase
    {
        public override string Name => "Generate UI Test Stub";

        public override string[] Usages => new[] {"dotvvm gen uitest <NAME>", "dotvvm gut <NAME>"};

        private const string PageObjectsText = "PageObjects";

        public override bool TryConsumeArgs(Arguments args, DotvvmProjectMetadata dotvvmProjectMetadata)
        {
            if (string.Equals(args[0], "gen", StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(args[1], "uitest", StringComparison.CurrentCultureIgnoreCase))
            {
                args.Consume(2);
                return true;
            }

            if (string.Equals(args[0], "gut", StringComparison.CurrentCultureIgnoreCase))
            {
                args.Consume(1);
                return true;
            }

            return false;
        }

        public override void Handle(Arguments args, DotvvmProjectMetadata dotvvmProjectMetadata)
        {

            // make sure the test directory exists
            if (string.IsNullOrEmpty(dotvvmProjectMetadata.UITestProjectPath))
            {
                var hintProjectName = $"..\\{dotvvmProjectMetadata.ProjectName}.Tests";
                dotvvmProjectMetadata.UITestProjectPath = ConsoleHelpers.AskForValue($"Enter the path to the test project\n(relative to DotVVM project directory, e.g. '{hintProjectName}'): ", hintProjectName);
            }

            var testProjectDirectory = dotvvmProjectMetadata.GetUITestProjectFullPath();
            if (!Directory.Exists(testProjectDirectory))
            {
                GenerateTestProject(testProjectDirectory);
            }

            // make sure we know the test project namespace
            if (string.IsNullOrEmpty(dotvvmProjectMetadata.UITestProjectRootNamespace))
            {
                dotvvmProjectMetadata.UITestProjectRootNamespace = Path.GetFileName(testProjectDirectory);
            }

            // generate the test stubs
            var name = args[0];
            var files = ExpandFileNames(name);

            foreach (var file in files)
            {
                Console.WriteLine($"Generating stub for {file}...");

                // determine full type name and target file
                var relativePath = PathHelpers.GetDothtmlFileRelativePath(dotvvmProjectMetadata, file);
                var relativeTypeName = $"{PathHelpers.TrimFileExtension(relativePath)}PageObject";
                var fullTypeName = $"{dotvvmProjectMetadata.UITestProjectRootNamespace}.{PageObjectsText}.{PathHelpers.CreateTypeNameFromPath(relativeTypeName)}";
                var targetFileName = Path.Combine(dotvvmProjectMetadata.UITestProjectPath, PageObjectsText, relativeTypeName + ".cs");

                // TODO: move to generator project
                // generate the file
                //var generator = new SeleniumPageObjectGenerator();
                //var config = new SeleniumGeneratorConfiguration() {
                //    TargetNamespace = PathHelpers.GetNamespaceFromFullType(fullTypeName),
                //    HelperName = PathHelpers.GetTypeNameFromFullType(fullTypeName),
                //    HelperFileFullPath = targetFileName,
                //    ViewFullPath = file
                //};

                //generator.ProcessMarkupFile(
                //    DotvvmConfiguration.CreateDefault(services
                //        => services.TryAddSingleton<IViewModelProtector, FakeViewModelProtector>()),
                //    config);
            }
        }

        private void GenerateTestProject(string projectDirectory)
        {
            var projectFileName = Path.GetFileName(projectDirectory);
            var testProjectPath = Path.Combine(projectDirectory, projectFileName + ".csproj");
            var fileContent = GetProjectFileTextContent();

            FileSystemHelpers.WriteFile(testProjectPath, fileContent);

            CreatePageObjectsDirectory(projectDirectory);
        }

        private static void CreatePageObjectsDirectory(string projectDirectory)
        {
            var objectsDirectory = Path.Combine(projectDirectory, PageObjectsText);
            if (!Directory.Exists(objectsDirectory))
            {
                Directory.CreateDirectory(objectsDirectory);
            }
        }

        private string GetProjectFileTextContent()
        {
            var projectTemplate = new TestProjectTemplate();

            return projectTemplate.TransformText();
        }
    }
}
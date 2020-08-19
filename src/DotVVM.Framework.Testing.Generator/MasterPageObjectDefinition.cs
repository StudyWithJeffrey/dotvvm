﻿using System;

namespace DotVVM.Framework.Testing.Generator
{
    public class MasterPageObjectDefinition : PageObjectDefinition
    {
        public MasterPageObjectDefinition(string masterPageFullPath)
        {
            MasterPageFullPath = masterPageFullPath ?? throw new ArgumentNullException(nameof(masterPageFullPath));
        }
        public string MasterPageFullPath { get; protected set; }
    }
}
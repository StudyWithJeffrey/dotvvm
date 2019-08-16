using System;
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Runtime;
using DotVVM.Framework.Hosting;

namespace DotVVM.Framework.Controls
{
    /// <summary>
    /// Displays all validation messages from the current Validation.Target.
    /// </summary>
    [ControlMarkupOptions(AllowContent = false)]
    public class ValidationSummary : HtmlGenericControl
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationSummary"/> class.
        /// </summary>
        public ValidationSummary()
        {
            TagName = "ul";
        }


        /// <summary>
        /// Gets or sets whether the errors from child objects in the viewmodel will be displayed too.
        /// </summary>
        [MarkupOptions(AllowBinding = false)]
        public bool IncludeErrorsFromChildren
        {
            get { return (bool) GetValue(IncludeErrorsFromChildrenProperty); }
            set { SetValue(IncludeErrorsFromChildrenProperty, value); }
        }
        public static readonly DotvvmProperty IncludeErrorsFromChildrenProperty
            = DotvvmProperty.Register<bool, ValidationSummary>(c => c.IncludeErrorsFromChildren, false);


        /// <summary>
        /// Gets or sets whether the errors from the <see cref="Validation.TargetProperty"/> object will be displayed too.
        /// </summary>
        [MarkupOptions(AllowBinding = false)]
        public bool IncludeErrorsFromTarget
        {
            get { return (bool) GetValue(IncludeErrorsFromTargetProperty); }
            set { SetValue(IncludeErrorsFromTargetProperty, value); }
        }
        public static readonly DotvvmProperty IncludeErrorsFromTargetProperty
            = DotvvmProperty.Register<bool, ValidationSummary>(c => c.IncludeErrorsFromTarget, false);

        /// <summary>
        /// Adds all attributes that should be added to the control begin tag.
        /// </summary>
        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.AddAttributesToRender(writer, context);

            var expression = KnockoutHelper.GetValidationTargetExpression(this);
            if(expression == null)
            {
                return;
            }

            var group = new KnockoutBindingGroup();
            {
                group.Add("target", expression);
                group.Add("includeErrorsFromChildren", IncludeErrorsFromChildren.ToString().ToLower());
                group.Add("includeErrorsFromTarget", IncludeErrorsFromTarget.ToString().ToLower());
            }
            writer.AddKnockoutDataBind("dotvvm-validationSummary", group);
        }
    }
}

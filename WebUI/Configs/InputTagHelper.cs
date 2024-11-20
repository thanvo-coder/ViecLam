using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Configs
{
    [HtmlTargetElement("input", Attributes = "asp-for")]
    public class InputTagHelper : TagHelper
    {
        public override int Order { get; } = int.MaxValue;

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            // Process only if 'maxlength' attribute is not present already
            if (context.AllAttributes["maxlength"] == null)
            {
                // Attempt to check for a MaxLength annotation
                var maxLength = GetMaxLength(For.ModelExplorer.Metadata.ValidatorMetadata);
                if (maxLength > 0)
                {
                    output.Attributes.Add("maxlength", maxLength);
                }
            }
            if (context.AllAttributes["minlength"] == null)
            {
                // Attempt to check for a MaxLength annotation
                var minLength = GetMinLength(For.ModelExplorer.Metadata.ValidatorMetadata);
                if (minLength >= 0)
                {
                    output.Attributes.Add("minlength", minLength);
                }
            }
        }

        private static int GetMaxLength(IReadOnlyList<object> validatorMetadata)
        {
            for (var i = 0; i < validatorMetadata.Count; i++)
            {
                if (validatorMetadata[i] is StringLengthAttribute stringLengthAttribute && stringLengthAttribute.MaximumLength > 0)
                {
                    return stringLengthAttribute.MaximumLength;
                }

                if (validatorMetadata[i] is MaxLengthAttribute maxLengthAttribute && maxLengthAttribute.Length > 0)
                {
                    return maxLengthAttribute.Length;
                }
            }
            return 0;
        }

        private static int GetMinLength(IReadOnlyList<object> validatorMetadata)
        {
            for (var i = 0; i < validatorMetadata.Count; i++)
            {
                if (validatorMetadata[i] is StringLengthAttribute stringLengthAttribute && stringLengthAttribute.MinimumLength > 0)
                {
                    return stringLengthAttribute.MaximumLength;
                }

                if (validatorMetadata[i] is MinLengthAttribute minLengthAttribute && minLengthAttribute.Length > 0)
                {
                    return minLengthAttribute.Length;
                }
            }
            return 0;
        }
    }
}
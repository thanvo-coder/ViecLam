using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Configs
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private IValidationAttributeAdapterProvider innerProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));

            var type = attribute.GetType();
            if (type.Name == "RequiredAttribute") attribute.ErrorMessage = "{0} là bắt buộc.";

            //if (type == typeof(CustomRequiredAttribute))
            //    return new RequiredAttributeAdapter((RequiredAttribute)attribute, stringLocalizer);

            return innerProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquineElegance.WebApp.Models
{ public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult == null || string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
                return null;

            string attemptedValue = valueResult.AttemptedValue.Replace(",", ".");

            decimal parsedValue;
            if (decimal.TryParse(attemptedValue, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
            {
                return parsedValue;
            }

            return null;
        }
    }
}
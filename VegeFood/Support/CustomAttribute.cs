using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace VegeFood.Support
{
    public sealed class IncludeArray : ValidationAttribute
    {
        public object[] CheckArray { get; set; }
        private bool allowNull;

        public IncludeArray(bool allowNull = false)
        {
            this.allowNull = allowNull;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return allowNull;
            if (CheckArray == null) return true;
            bool result = false;
            foreach (object item in CheckArray)
                if (value.Equals(item))
                {
                    result = true;
                    break;
                }
            return result;
        }
    }

    public class AuthorizedAttribute: ResultFilterAttribute
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            context.HttpContext.Request.Headers.Add("abc", "123");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            context.HttpContext.Request.Headers.Add("abc", "123");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sanctuary.Common.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method,Inherited = false,AllowMultiple = true)]
    public class UrlSanitizationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? postalCode)
        {
            if (string.IsNullOrWhiteSpace((string?)postalCode) || !Regex.IsMatch((string)postalCode, RegexConstants.RegexNumbersOnly))
            {
                return false;
            }

            return true;
        }
    }
}

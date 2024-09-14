using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Exception
{
    public class NumericAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            if (value is string str)
            {
                return decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
            }
            return false;
        }
    }
}

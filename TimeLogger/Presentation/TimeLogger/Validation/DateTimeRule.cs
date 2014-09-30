using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace TimeLogger.ViewModels.Validation
{
    public class DateTimeRule : ValidationRule
    {
        private TimeSpan ts;
        
        public DateTimeRule()
        {
            ts = new TimeSpan();
        } 
      
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool valid = false;

            try
            {
                if (TimeSpan.TryParse((string)value, out ts) && ((string)value).Length == 5)
                    valid = true;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if (!valid)
            {
                return new ValidationResult(false,
                  "Please enter an age in the range: ");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

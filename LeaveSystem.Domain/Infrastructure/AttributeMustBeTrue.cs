using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Infrastructure
{
    public class AttributeMustBeTrue : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //return base.IsValid(value);
            return value is bool && (bool)value;
        }
    }
}

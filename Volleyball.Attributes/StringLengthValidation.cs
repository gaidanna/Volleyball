using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Property)]
    public class StringLengthValidationAttribute : Attribute
    {
        private string validationExplanation;
        public readonly int StringLength;

        public StringLengthValidationAttribute(int stringLength)
        {
            StringLength = stringLength;
        }

        public string ValidationExplanation
        {
            get
            { return validationExplanation; }
            set
            { validationExplanation = value; }
        }
    }
}

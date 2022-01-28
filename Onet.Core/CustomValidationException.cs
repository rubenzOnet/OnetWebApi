using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Core
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException() : base()
        { }

        public CustomValidationException(string message) : base(message)
        { }

        public CustomValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
        public enum ExceptionType
        {
            Invalid_distance, Invalid_time
        }
        public ExceptionType Type;
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }
    }
}

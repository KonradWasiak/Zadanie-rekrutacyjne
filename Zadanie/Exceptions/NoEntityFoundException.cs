using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie.Exceptions
{
    public class NoEntityFoundException : Exception
    {
        public NoEntityFoundException()
        { }

        public NoEntityFoundException(string message)
            : base(message)
        { }

        public NoEntityFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

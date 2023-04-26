using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Application.Exceptions
{
    public class BaseException : Exception
    {
        public int Code { get; set; }

        public IDictionary<string, string[]>? Errors { get; set; }

        public BaseException(string message, int code)
            : base(message) => this.Code = code;
    }
}

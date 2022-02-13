using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //ctor overloading
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success = success; bunu set etmeyi diger ctora biraktim
        }
        public Result(bool success)
        {
            Success = success;
        }

        //get readonlydir, ctorda set edilebilir.
        public bool Success { get; }
        public string Message { get; }
    }
}

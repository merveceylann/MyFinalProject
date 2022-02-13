
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)  //mesajli hali
        {
        }
        public ErrorDataResult(T data) : base(data, false) //mesajsiz hali
        {
        }
        public ErrorDataResult(string message) : base(default, false, message) //sadece mesajli hali
        {
        }
        public ErrorDataResult() : base(default, false) //mesajsiz ve default hali
        {
        }

    }
}

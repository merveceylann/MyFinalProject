using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)  //mesajli hali
        {
        }
        public SuccessDataResult(T data) : base(data, true) //mesajsiz hali
        {
        }
        public SuccessDataResult(string message) : base(default, true, message) //sadece mesajli hali
        {
        }
        public SuccessDataResult() : base(default, true) //mesajsiz ve default hali
        {
        }
    }
}

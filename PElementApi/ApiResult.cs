using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PElementApi
{
    public class ApiResult<T> where T: class
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Result { get; set; }
    }
}

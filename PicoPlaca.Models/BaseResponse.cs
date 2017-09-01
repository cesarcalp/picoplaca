using System;
using System.Collections.Generic;
using System.Text;

namespace PicoPlaca.Models
{
    public abstract class BaseResponse
    {
        public string Message { set; get; }
        public string Code { set; get; }
    }
}

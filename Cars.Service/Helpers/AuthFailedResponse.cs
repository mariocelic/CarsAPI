using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Service.Helpers
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

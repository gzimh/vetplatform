using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public dynamic Payload { get; set; }
    }
}

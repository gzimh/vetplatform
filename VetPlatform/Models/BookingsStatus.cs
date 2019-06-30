using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public static class BookingsStatus
    {
        public static string Pending => nameof(Pending);
        public static string Done => nameof(Done);
        public static string Canceled => nameof(Canceled);
    }
}

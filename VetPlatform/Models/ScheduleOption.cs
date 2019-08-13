using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPlatform.Api.Models
{
    public class ScheduleOption
    {
        public ScheduleOption(string time, bool isAvailable = true)
        {
            this.Time = time;
            this.IsAvailable = isAvailable;
        }

        public string Time { get; set; }
        public bool IsAvailable { get; set; }
    }
}

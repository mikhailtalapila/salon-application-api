using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Data.Entities
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTimeOffset? Start { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}

using Salon.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Salon.Data.Entities
{
    public class SalonSchedule: AbstractDataEntity
    {
        public int Id { get; set; }
        public int? TimeSpanId { get; set; }
        [ForeignKey("TimeSpanId")]
        public virtual TimeSlot TimeSlot { get; set; }
    }
}

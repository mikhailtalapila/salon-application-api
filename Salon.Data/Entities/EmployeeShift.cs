using Salon.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Salon.Data.Entities
{
    public class EmployeeShift: AbstractDataEntity
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }

        public int? TimeSpanId { get; set; }
        [ForeignKey("TimeSpanId")]
        public virtual TimeSlot TimeSlot { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public bool? Deleted { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

    }
}

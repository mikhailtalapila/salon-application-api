using Salon.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Salon.Data.Entities
{
    public class Employee: AbstractDataEntity
    {
        public int Id { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        public string LastInitial { get; set; }       
        
        public DateTime? HireDate { get; set; }
        public bool? IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImageSource { get; set; }
        public string Remarks { get; set; }
        public int? TitleId { get; set; }
        [ForeignKey("TitleId")]
        public virtual EmployeeTitle CurrentTitle { get; set; }
        public virtual ICollection<Qualification> EmployeeQualifications { get; set; }
        public virtual ICollection<Appointment> EmployeeAppointments { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}

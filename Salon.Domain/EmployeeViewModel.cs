using Salon.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Domain
{
    public class EmployeeViewModel: AbstractDomainEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string LastInitial { get; set; }
        public GenderViewModel Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public TitleViewModel Title { get; set; }
        public ICollection<EmployeeScheduleViewModel> EmplooyeeShifts { get; set; }
        public ICollection<NoteViewModel> Notes { get; set; }
        public ICollection<QualificationViewModel> Qualifications { get; set; }
    }
}

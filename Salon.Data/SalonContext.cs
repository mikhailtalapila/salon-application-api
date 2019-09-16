using Microsoft.EntityFrameworkCore;
using Salon.Data.Entities;
using System;

namespace Salon.Data
{
    public class SalonContext: DbContext
    {
        public SalonContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Salon;User Id=xxxxx;password=xxxxxxxx;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        public SalonContext(DbContextOptions options): base(options) {}
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentTransaction> AppointmentTransactions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GiftCard> GiftCards { get; set; }
        public virtual DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<SalonSchedule> SalonSchedules { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<CustomerServicePreference> CustomerServicePreferences { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<AppointmentProduct> AppointmentProducts { get; set; }
        public virtual DbSet<CustomerProductPreference> CustomerProductPreferences { get; set; }
        public virtual DbSet<GroupParty> GroupParties { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual DbSet<ServiceStep> ServiceSteps { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CustomerContactPreference> CustomerContactPreferences { get; set; }
        public virtual DbSet<ContactAcceptance> ContactAcceptances { get; set; }       

    }
}

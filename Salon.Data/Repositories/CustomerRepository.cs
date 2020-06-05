using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salon.Data.Base;
using Salon.Data.Entities;
using Salon.Data.Repositories.Interfaces;
using Salon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salon.Data.Repositories
{
    public class CustomerRepository : EntityMappingRepository<Customer, CustomerViewModel>, ICustomerRepository
    {
        public CustomerRepository(SalonContext salonContext, IMapper mapper) : base(salonContext, mapper) { }
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return _context.Set<Customer>()
                        .Include(x => x.GiftCards)
                        .Include(x => x.Appointments)
                        .Where(x => x.IsDeleted == false)
                        .OrderBy(x => x.FirstName)
                        .Select(x => MapFrom(x));
        }
        public CustomerViewModel GetCustomerById(int id)
        {
            var customerEntity = _context.Set<Customer>()
                .Include(x => x.Gender)
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefault();
            if (customerEntity != null)
            {
                return MapFrom(customerEntity);
            }
            return null;
        }
        public CustomerViewModel AddNewCustomer(CustomerViewModel customerViewModel)
        {
            var entity = MapTo(customerViewModel);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();

            return MapFrom(entity);
        }
        public CustomerViewModel UpdateCustomer(CustomerViewModel customer)
        {
            if (customer.Id <= 0)
                return null;
            _context.Entry(MapTo(customer)).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }
        public CustomerViewModel DeleteCustomer(CustomerViewModel customer)
        {
            if (customer.Id <= 0)
                return null;
            customer.IsDeleted = true;
            _context.Entry(MapTo(customer)).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }
    }
}

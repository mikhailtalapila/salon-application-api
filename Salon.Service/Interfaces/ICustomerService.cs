﻿using Salon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetAllCustomers();
        CustomerViewModel GetCustomerById(int id);
    }
}

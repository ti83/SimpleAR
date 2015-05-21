using System;
using System.Collections.Generic;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;
using System.Linq;

namespace SimpleAR_DAL.Managers
{
    public class CustomerManager
    {
        public static void SaveCustomer(Customer customer)
        {
            var context = ManagerFactories.CreateContextManager();
            if (customer.Id == null)
            {
                context.Customers.Add(customer);
            }
            else
            {
                var dbCustomer = context.Customers.Single(c => c.Id == customer.Id);
                if (dbCustomer == null)
                {
                    throw new Exception(String.Format("Couldn't find a customer with the id of {0}",customer.Id));
                }
                dbCustomer.Name = customer.Name;
            }
            context.SaveChanges();
        }

        public static List<Customer> GetCustomers()
        {
            var context = ManagerFactories.CreateContextManager();
            return context.Customers.ToList();
        }

        public static void DeleteCustomer(int id)
        {
            var context = ManagerFactories.CreateContextManager();
            var customer = context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}

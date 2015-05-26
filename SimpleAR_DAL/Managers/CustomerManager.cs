// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerManager.cs" company="">
//   
// </copyright>
// <summary>
//   The customer manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;

namespace SimpleAR_DAL.Managers
{
    /// <summary>
    /// The customer manager.
    /// </summary>
    public class CustomerManager
    {
        /// <summary>
        /// The save customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public static void SaveCustomer(Customer customer)
        {
            var context = ManagerFactories.CreateContextManager();
            if (customer.Id == null)
            {
                context.Customers.Add(customer);
            }
            else
            {
                var dbRecord = context.Customers.Single(c => c.Id == customer.Id);
                if (dbRecord == null)
                {
                    throw new Exception(string.Format("Couldn't find a customer with the id of {0}", customer.Id));
                }

                dbRecord.Name = customer.Name;
            }

            context.SaveChanges();
        }

        /// <summary>
        /// The get customers.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Customer> GetCustomers()
        {
            var context = ManagerFactories.CreateContextManager();
            return context.Customers.ToList();
        }

        /// <summary>
        /// The delete customer.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
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

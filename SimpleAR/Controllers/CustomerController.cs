// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerController.cs" company="">
//   
// </copyright>
// <summary>
//   The customer controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    /// <summary>
    /// The customer controller.
    /// </summary>
    public class CustomerController :  ICustomerController
    {
        /// <summary>
        /// Gets or sets the new customer name.
        /// </summary>
        public string NewCustomerName { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController()
        {
            LoadCustomersFromDB();
        }

        /// <summary>
        /// The add new customer.
        /// </summary>
        public void AddNewCustomer()
        {
            var customer = new Customer() {Name = NewCustomerName};
            CustomerManager.SaveCustomer(customer);
            GlobalLists.Customers.Add(customer);
            NewCustomerName = string.Empty;

        }

        /// <summary>
        /// The delete customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        public void DeleteCustomer(Customer customer)
        {
            if (!customer.Id.HasValue)
            {
                GlobalLists.Customers.Remove(customer);
            }
            else
            {
                GlobalLists.Customers.Remove(customer);
                CustomerManager.DeleteCustomer(customer.Id.Value);
            }
        }

        /// <summary>
        /// The save customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        public void SaveCustomer(Customer customer)
        {
            CustomerManager.SaveCustomer(customer);
            LoadCustomersFromDB();
        }

        /// <summary>
        /// The load customers from db.
        /// </summary>
        private void LoadCustomersFromDB()
        {
            GlobalLists.Customers.Clear();
            var dbCustomers = CustomerManager.GetCustomers();
            foreach (var customer in dbCustomers)
            {
                GlobalLists.Customers.Add(customer);
            }
        }

    }
}

using SimpleAR_DAL.Managers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;


namespace SimpleAR.Controllers
{
    public class CustomerController :  ICustomerController
    {
        public string NewCustomerName { get; set; }


        public CustomerController()
        {
            LoadCustomersFromDB();
        }

        public void AddNewCustomer()
        {
            var customer = new Customer() {Name = NewCustomerName};
            CustomerManager.SaveCustomer(customer);
            GlobalLists.Customers.Add(customer);
            NewCustomerName = string.Empty;

        }

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

        public void SaveCustomer(Customer customer)
        {
            CustomerManager.SaveCustomer(customer);
            LoadCustomersFromDB();
        }

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

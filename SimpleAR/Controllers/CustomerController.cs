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
        public List<Customer> Customers { get; set; }
        public string NewCustomerName { get; set; }


        public CustomerController()
        {
            LoadCustomersFromDB();
        }

        public void AddNewCustomer()
        {
            CustomerManager.SaveCustomer(new Customer() { Name = NewCustomerName });
            Customers = CustomerManager.GetCustomers();
            NewCustomerName = string.Empty;

        }

        public void DeleteCustomer(Customer customer)
        {
            if (!customer.Id.HasValue)
            {
                Customers.Remove(customer);
            }
            else
            {
                CustomerManager.DeleteCustomer(customer.Id.Value);
                LoadCustomersFromDB();
            }

        }

        public void SaveCustomer(Customer customer)
        {
            CustomerManager.SaveCustomer(customer);
            LoadCustomersFromDB();
        }

        private void LoadCustomersFromDB()
        {
            Customers = CustomerManager.GetCustomers();        
        }

    }
}

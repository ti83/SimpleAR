using System.Collections.Generic;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    using System.Windows.Input;

    /// <summary>
    /// The CustomerController interface.
    /// </summary>
    public interface ICustomerController
    {

        List<Customer> Customers { get; set; }
        string NewCustomerName { get; set; }

        void AddNewCustomer();

        void DeleteCustomer(Customer customer);

        void SaveCustomer(Customer customer);
    }
}

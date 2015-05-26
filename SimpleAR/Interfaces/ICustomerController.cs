// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerController.cs" company="">
//   
// </copyright>
// <summary>
//   The CustomerController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The CustomerController interface.
    /// </summary>
    public interface ICustomerController
    {
        /// <summary>
        /// Gets or sets the new customer name.
        /// </summary>
        string NewCustomerName { get; set; }

        /// <summary>
        /// The add new customer.
        /// </summary>
        void AddNewCustomer();

        /// <summary>
        /// The delete customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        void DeleteCustomer(Customer customer);

        /// <summary>
        /// The save customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        void SaveCustomer(Customer customer);
    }
}

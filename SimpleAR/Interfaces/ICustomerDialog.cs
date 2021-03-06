﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerDialog.cs" company="">
//   
// </copyright>
// <summary>
//   The CustomerDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The CustomerDialog interface.
    /// </summary>
    public interface ICustomerDialog
    {
        /// <summary>
        /// The edit customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool EditCustomer(Customer customer);

        /// <summary>
        /// The confirm customer delete.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <returns>
        /// The <see cref="MessageBoxResult"/>.
        /// </returns>
        MessageBoxResult ConfirmCustomerDelete(string customerName);
    }
}

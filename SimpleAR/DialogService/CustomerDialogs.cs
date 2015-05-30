// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDialogs.cs" company="">
//   
// </copyright>
// <summary>
//   The customer dialogs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    /// <summary>
    /// The customer dialogs.
    /// </summary>
    public class CustomerDialogs : ICustomerDialog
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
        public bool EditCustomer(Customer customer)
        {
            var viewModel = ViewModelFactory.CreateEditCustomerViewModel(customer);
            var view = ViewFactory.CreatEditCustomerView(viewModel);
            var result  = view.ShowDialog();
            if (!result.HasValue || !result.Value)
            {
                return false;
            }

            customer.Name = viewModel.CustomerName;

            return true;
        }

        /// <summary>
        /// The confirm customer delete.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <returns>
        /// The <see cref="MessageBoxResult"/>.
        /// </returns>
        public MessageBoxResult ConfirmCustomerDelete(string customerName)
        {
            return MessageBox.Show(string.Format("Are you sure you want to delete {0}?  This will remove all records associated with them.", customerName), "Delete Customer?", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}

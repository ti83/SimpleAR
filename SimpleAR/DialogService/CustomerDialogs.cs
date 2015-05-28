// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDialogs.cs" company="">
//   
// </copyright>
// <summary>
//   The customer dialogs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



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
    }
}

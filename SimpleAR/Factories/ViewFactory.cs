// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The view factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.ViewModels;
using SimpleAR.Views;

namespace SimpleAR.Factories
{
    /// <summary>
    /// The view factory.
    /// </summary>
    public class ViewFactory
    {
        /// <summary>
        /// The creat edit customer view.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="EditCustomerView"/>.
        /// </returns>
        internal static EditCustomerView CreatEditCustomerView(EditCustomerViewModel viewModel)
        {
            return new EditCustomerView() { DataContext = viewModel };
        }

        /// <summary>
        /// The create edit service view.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="EditServiceView"/>.
        /// </returns>
        internal static EditServiceView CreateEditServiceView(EditServiceViewModel viewModel)
        {
            return new EditServiceView() { DataContext = viewModel };
        }

        /// <summary>
        /// The create edit ledger record view.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="EditLedgerRecordView"/>.
        /// </returns>
        internal static EditLedgerRecordView CreateEditLedgerRecordView(EditLedgerRecordViewModel viewModel)
        {
            return new EditLedgerRecordView() { DataContext = viewModel };
        }
    }
}

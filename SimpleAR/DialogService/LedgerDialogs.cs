// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LedgerDialogs.cs" company="">
//   
// </copyright>
// <summary>
//   The ledger dialogs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    /// <summary>
    /// The ledger dialogs.
    /// </summary>
    public class LedgerDialogs : ILedgerDialog
    {
        /// <summary>
        /// The edit ledger record item.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool EditLedgerRecordItem(Ledger ledger)
        {
            var viewModel = ViewModelFactory.CreateEditLedgerRecordViewModel(ledger);
            var view = ViewFactory.CreateEditLedgerRecordView(viewModel);
            var result = view.ShowDialog();

            if (!result.HasValue || !result.Value)
            {
                return false;
            }

            ledger.ServiceName = viewModel.SelectedService != null ? viewModel.SelectedService.ServiceName : string.Empty;
            ledger.ServiceId = viewModel.SelectedService != null && viewModel.SelectedService.Id.HasValue ? viewModel.SelectedService.Id.Value : 0;
            ledger.CustomerName = viewModel.SelectedCustomer != null ? viewModel.SelectedCustomer.Name : string.Empty;
            ledger.CustomerId = viewModel.SelectedCustomer != null && viewModel.SelectedCustomer.Id.HasValue ? viewModel.SelectedCustomer.Id.Value : 0;
            ledger.DOS = viewModel.DOS;
            ledger.PricePerUnit = viewModel.PricePerUnit;
            ledger.NumberOfUnits = viewModel.NumberOfUnits;
            ledger.UnitType = viewModel.UnitType;

            return true;

        }

        public MessageBoxResult ConfirmServiceDelete(Ledger ledger)
        {
            var message = string.Format("Are you sure you want to delete {0} performed for {1} on {2}?", ledger.ServiceName, ledger.CustomerName, ledger.DOS.Value.ToShortDateString());
            return MessageBox.Show(message, "Delete Ledger Entry?", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }
    }
}

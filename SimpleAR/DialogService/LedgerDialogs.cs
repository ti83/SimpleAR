using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    public class LedgerDialogs : ILedgerDialog
    {
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
    }
}

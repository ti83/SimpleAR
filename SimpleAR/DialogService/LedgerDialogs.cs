using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Factories;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    public class LedgerDialogs
    {
        public static bool EditLedgerRecordItem(Ledger ledger)
        {
            var viewModel = ViewModelFactory.CreateEditLedgerRecordViewModel(ledger);
            var view = ViewFactory.CreateEditLedgerRecordView(viewModel);
            var result = view.ShowDialog();

            if (!result.HasValue || !result.Value)
            {
                return false;
            }

            //customer.Name = viewModel.CustomerName;

            return true;

        }
    }
}

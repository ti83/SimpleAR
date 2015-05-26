using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.ViewModels;
using SimpleAR.Views;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Factories
{
    public class ViewFactory
    {
        internal static EditCustomerView CreatEditCustomerView(EditCustomerViewModel viewModel)
        {
            return new EditCustomerView() { DataContext = viewModel };
        }

        internal static EditServiceView CreateEditServiceView(EditServiceViewModel viewModel)
        {
            return new EditServiceView() { DataContext = viewModel };
        }

        internal static EditLedgerRecordView CreateEditLedgerRecordView(EditLedgerRecordViewModel viewModel)
        {
            return new EditLedgerRecordView() { DataContext = viewModel };
        }
    }
}

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
        public static EditCustomerView CreatEditCustomerView(EditCustomerViewModel viewModel)
        {
            return new EditCustomerView() { DataContext = viewModel };
        }
    }
}

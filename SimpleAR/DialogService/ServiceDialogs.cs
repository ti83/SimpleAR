using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Factories;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    public class ServiceDialogs
    {
        public static bool EditService(Service service)
        {
            var viewModel = ViewModelFactory.CreatedEditServiceViewModel(service);
            var view = ViewFactory.CreateEditServiceView(viewModel);
            var result = view.ShowDialog();
            if (!result.HasValue || !result.Value)
            {
                return false;
            }

            service.ServiceName = viewModel.ServiceName;
            service.PricePerUnit = viewModel.PricePerUnit;
            service.UnitType = viewModel.UnitType;

            return true;
        }
    }
}

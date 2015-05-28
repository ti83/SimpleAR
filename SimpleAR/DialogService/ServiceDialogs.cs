// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceDialogs.cs" company="">
//   
// </copyright>
// <summary>
//   The service dialogs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    /// <summary>
    /// The service dialogs.
    /// </summary>
    public class ServiceDialogs : IServiceDialog
    {
        /// <summary>
        /// The edit service.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool EditService(Service service)
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

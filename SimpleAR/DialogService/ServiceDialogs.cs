// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceDialogs.cs" company="">
//   
// </copyright>
// <summary>
//   The service dialogs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
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

        /// <summary>
        /// The confirm service delete.
        /// </summary>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <returns>
        /// The <see cref="MessageBoxResult"/>.
        /// </returns>
        public MessageBoxResult ConfirmServiceDelete(string serviceName)
        {
            return MessageBox.Show(string.Format("Are you sure you want to delete {0}?", serviceName), "Delete Service?", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}

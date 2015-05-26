// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceController.cs" company="">
//   
// </copyright>
// <summary>
//   The service controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    /// <summary>
    /// The service controller.
    /// </summary>
    public class ServiceController : IServiceController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceController"/> class.
        /// </summary>
        public ServiceController()
        {
            LoadServicesFromDB();
        }

        /// <summary>
        /// Gets or sets the new service name.
        /// </summary>
        public string NewServiceName { get; set; }

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
        public decimal? NewPricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the new unit type.
        /// </summary>
        public string NewUnitType { get; set; }

        /// <summary>
        /// The add new service.
        /// </summary>
        public void AddNewService()
        {
            var service = new Service()
            {
                ServiceName = NewServiceName, 
                PricePerUnit = NewPricePerUnit ?? 0, 
                UnitType = NewUnitType
            };
            ServiceManager.SaveService(service);
            GlobalLists.Services.Add(service);
            NewServiceName = string.Empty;
            NewPricePerUnit = null;
            NewUnitType = string.Empty;
        }

        /// <summary>
        /// The delete service.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        public void DeleteService(Service service)
        {
            if (!service.Id.HasValue)
            {
                GlobalLists.Services.Remove(service);
            }
            else
            {
                ServiceManager.DeleteService(service.Id.Value);
                GlobalLists.Services.Remove(service);
            }
        }

        /// <summary>
        /// The save service.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        public void SaveService(Service service)
        {
            ServiceManager.SaveService(service);
            LoadServicesFromDB();
        }

        /// <summary>
        /// The load services from db.
        /// </summary>
        private void LoadServicesFromDB()
        {
            GlobalLists.Services.Clear();
            var dbServices = ServiceManager.GetServices();
            foreach (var service in dbServices)
            {
                GlobalLists.Services.Add(service);
            }
        }
    }
}

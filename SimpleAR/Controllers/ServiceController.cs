using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    public class ServiceController : IServiceController
    {
        public ServiceController()
        {
            LoadServicesFromDB();
        }

        public List<Service> Services { get; set; }

        public string NewServiceName { get; set; }

        public decimal? NewPricePerUnit { get; set; }

        public string NewUnitType { get; set; }

        public void AddNewService()
        {
            ServiceManager.SaveService(new Service()
            {
                ServiceName = NewServiceName,
                PricePerUnit = NewPricePerUnit ?? 0,
                UnitType = NewUnitType
            });
            LoadServicesFromDB();
            NewServiceName = string.Empty;
            NewPricePerUnit = null;
            NewUnitType = string.Empty;
        }

        public void DeleteService(Service service)
        {
            if (!service.Id.HasValue)
            {
                Services.Remove(service);
            }
            else
            {
                ServiceManager.DeleteService(service.Id.Value);
                LoadServicesFromDB();
            }
        }

        public void SaveService(Service service)
        {
            ServiceManager.SaveService(service);
            LoadServicesFromDB();
        }

        private void LoadServicesFromDB()
        {
            Services = ServiceManager.GetServices();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Common;
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

        public string NewServiceName { get; set; }

        public decimal? NewPricePerUnit { get; set; }

        public string NewUnitType { get; set; }

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

        public void SaveService(Service service)
        {
            ServiceManager.SaveService(service);
            LoadServicesFromDB();
        }

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

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
            Services = ServiceManager.GetServices();
        }

        public List<Service> Services { get; set; }

        public string NewServiceName { get; set; }

        public decimal NewServiceCost { get; set; }

        public void AddNewService()
        {
            
        }

        public void DeleteService(SimpleAR_DAL.DBModels.Service customer)
        {
            
        }

        public void SaveService(SimpleAR_DAL.DBModels.Service customer)
        {
            
        }
    }
}

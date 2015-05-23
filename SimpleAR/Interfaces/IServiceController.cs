using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    public interface IServiceController
    {
        List<Service> Services { get; set; }
        string NewServiceName { get; set; }
        decimal NewServiceCost { get; set; }

        void AddNewService();

        void DeleteService(Service customer);

        void SaveService(Service customer);
    }
}

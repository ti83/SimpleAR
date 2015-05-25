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
        string NewServiceName { get; set; }
        decimal? NewPricePerUnit { get; set; }
        string NewUnitType { get; set; }

        void AddNewService();

        void DeleteService(Service customer);

        void SaveService(Service customer);
    }
}

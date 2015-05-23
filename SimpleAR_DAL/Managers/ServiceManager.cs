using System;
using System.Collections.Generic;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;
using System.Linq;

namespace SimpleAR_DAL.Managers
{
    public class ServiceManager
    {
        public static void SaveService(Service service)
        {
            var context = ManagerFactories.CreateContextManager();
            if (service.Id == null)
            {
                context.Services.Add(service);
            }
            else
            {
                var dbRecord = context.Services.Single(c => c.Id == service.Id);
                if (dbRecord == null)
                {
                    throw new Exception(String.Format("Couldn't find a service with the id of {0}", service.Id));
                }
                dbRecord.ServiceName = dbRecord.ServiceName;
                dbRecord.Cost = dbRecord.Cost;
            }
            context.SaveChanges();
        }

        public static List<Service> GetServices()
        {
            var context = ManagerFactories.CreateContextManager();
            return context.Services.ToList();
        }

        public static void DeleteService(int id)
        {
            var context = ManagerFactories.CreateContextManager();
            var service = context.Services.FirstOrDefault(c => c.Id == id);
            if (service != null)
            {
                context.Services.Remove(service);
                context.SaveChanges();
            }
        }
    }
}

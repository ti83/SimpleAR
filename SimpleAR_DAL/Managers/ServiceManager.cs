// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="">
//   
// </copyright>
// <summary>
//   The service manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;

namespace SimpleAR_DAL.Managers
{
    /// <summary>
    /// The service manager.
    /// </summary>
    public class ServiceManager
    {
        /// <summary>
        /// The save service.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public static void SaveService(Service service)
        {
            using (var context = ManagerFactories.CreateContextManager())
            {
                 if (service.Id == null)
                {
                    context.Services.Add(service);
                }
                else
                {
                    var dbRecord = context.Services.Single(c => c.Id == service.Id);
                    if (dbRecord == null)
                    {
                        throw new Exception(string.Format("Couldn't find a service with the id of {0}", service.Id));
                    }

                    dbRecord.ServiceName = service.ServiceName;
                    dbRecord.PricePerUnit = service.PricePerUnit;
                    dbRecord.UnitType = service.UnitType;
                }

                context.SaveChanges();               
            }
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Service> GetServices()
        {
            using (var context = ManagerFactories.CreateContextManager())
            {
                return context.Services.ToList();
            }
        }

        /// <summary>
        /// The delete service.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public static void DeleteService(int id)
        {
            using (var context = ManagerFactories.CreateContextManager())
            {
                var service = context.Services.FirstOrDefault(c => c.Id == id);
                if (service != null)
                {
                    context.Services.Remove(service);
                    context.SaveChanges();
                }                
            }
        }
    }
}

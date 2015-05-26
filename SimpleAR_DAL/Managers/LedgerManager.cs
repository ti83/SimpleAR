// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LedgerManager.cs" company="">
//   
// </copyright>
// <summary>
//   The ledger manager.
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
    /// The ledger manager.
    /// </summary>
    public class LedgerManager
    {
        /// <summary>
        /// The save ledger item.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public static void SaveLedgerItem(Ledger ledger)
        {
            var context = ManagerFactories.CreateContextManager();
            if (ledger.Id == null)
            {
                context.LedgerRecords.Add(ledger);
            }
            else
            {
                var dbRecord = context.LedgerRecords.Single(c => c.Id == ledger.Id);
                if (dbRecord == null)
                {
                    throw new Exception(string.Format("Couldn't find a ledger with the id of {0}", ledger.Id));
                }

                dbRecord.CustomerId = ledger.CustomerId;
                dbRecord.ServiceId = ledger.ServiceId;
                dbRecord.DateOfService = ledger.DateOfService;
                dbRecord.ServiceName = ledger.ServiceName;
                dbRecord.CustomerName = ledger.CustomerName;
                dbRecord.PricePerUnit = ledger.PricePerUnit;
                dbRecord.NumberOfUnits = ledger.NumberOfUnits;
                dbRecord.UnitType = ledger.UnitType;
            }

            context.SaveChanges();
        }

        /// <summary>
        /// The get ledger entries.
        /// </summary>
        /// <param name="startDate">
        /// The start date.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Ledger> GetLedgerEntries(DateTime startDate, DateTime endDate)
        {
            var start = startDate.ToFileTime().ToString();
            var end = endDate.ToFileTime().ToString();
            var context = ManagerFactories.CreateContextManager();

            var result = from l in context.LedgerRecords
                where string.Compare(l.DateOfService, start) >= 0 && string.Compare(l.DateOfService, end) <= 0
                select l;
            return result.ToList();
        }

        /// <summary>
        /// The delete ledger item.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public static void DeleteLedgerItem(int id)
        {
            var context = ManagerFactories.CreateContextManager();
            var ledger = context.LedgerRecords.FirstOrDefault(c => c.Id == id);
            if (ledger != null)
            {
                context.LedgerRecords.Remove(ledger);
                context.SaveChanges();
            }
        }

    }
}

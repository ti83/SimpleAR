using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;

namespace SimpleAR_DAL.Managers
{
    public class LedgerManager
    {
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
                    throw new Exception(String.Format("Couldn't find a ledger with the id of {0}", ledger.Id));
                }
                dbRecord.CustomerId = ledger.CustomerId;
                dbRecord.ServiceId = ledger.ServiceId;
                dbRecord.DateOfService = ledger.DateOfService;
                dbRecord.ServiceName = ledger.ServiceName;
                dbRecord.PricePerUnit = ledger.PricePerUnit;
                dbRecord.NumberOfUnits = ledger.NumberOfUnits;
                dbRecord.UnitType = ledger.UnitType;
            }
            context.SaveChanges();
        }

        public static List<Ledger> GetLedgerEntries()
        {
            var context = ManagerFactories.CreateContextManager();
            return context.LedgerRecords.ToList();
        }

        public static void DeleteLedgerIt(int id)
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

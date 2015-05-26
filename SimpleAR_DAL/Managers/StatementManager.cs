// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementManager.cs" company="">
//   
// </copyright>
// <summary>
//   The statement manager.
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
    /// The statement manager.
    /// </summary>
    public class StatementManager
    {
        public static List<Customer> GetStatementsForDateRange(DateTime startDate, DateTime endDate)
        {
            var start = startDate.ToFileTime().ToString();
            var end = endDate.ToFileTime().ToString();
            var context = ManagerFactories.CreateContextManager();

            var ledgerRecords = (from l in context.LedgerRecords
                                 where string.Compare(l.DateOfService, start) >= 0 && string.Compare(l.DateOfService, end) <= 0
                                 select l).ToList();
            var customers = ConstructCustomerList(ledgerRecords);
            PopulateLedgerRecords(customers, ledgerRecords);

            return customers;
        }

        private static List<Customer> ConstructCustomerList(List<Ledger> ledgerRecords)
        {
            var uniqueCustomerIdList = (from lr in ledgerRecords select lr.CustomerId).Distinct().ToList();
            var context = ManagerFactories.CreateContextManager();
            var customers = context.Customers.Where(c => c.Id.HasValue && uniqueCustomerIdList.Contains(c.Id.Value));

            return customers.ToList();
        }

        private static void PopulateLedgerRecords(List<Customer> customers, List<Ledger> ledgerRecords)
        {
            foreach (var customer in customers)
            {
                customer.LedgerItems = ledgerRecords.Where(lr => customer.Id.HasValue && lr.CustomerId == customer.Id.Value).ToList();
            }
        }

    }
}

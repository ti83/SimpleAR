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
    public class StatementController : IStatementController
    {
        public StatementController()
        {
            StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);

        }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<Customer> GetStatementsForDateRange()
        {
            if (!StartDate.HasValue) return null;
            if (!EndDate.HasValue) return null;
            return StatementManager.GetStatementsForDateRange(StartDate.Value, EndDate.Value);
        }
    }
}

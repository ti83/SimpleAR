using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class CustomerStatementViewModel
    {
        public string CustomerName { get; set; }
        public List<Ledger> StatementRecords { get; set; }
        public Decimal StatementTotal { get; set; }
    }
}

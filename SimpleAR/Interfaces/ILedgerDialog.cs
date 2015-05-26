using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    public interface ILedgerDialog
    {
        bool EditLedgerRecordItem(Ledger ledger);
    }
}

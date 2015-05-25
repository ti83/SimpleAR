using System;
using System.Collections.Generic;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    public interface ILedgerController
    {
        List<Ledger> LedgerRecords { get; set; }

        Customer NewSelectedCustomer { get; set; }

        Service NewSelectedService { get; set; }

        decimal? NewPricePerUnit { get; set; }

        decimal? NewNumberOfUnits { get; set; }

        DateTime? NewDOS { get; set; }

    }
}
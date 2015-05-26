// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILedgerController.cs" company="">
//   
// </copyright>
// <summary>
//   The LedgerController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The LedgerController interface.
    /// </summary>
    public interface ILedgerController
    {
        /// <summary>
        /// Gets or sets the ledger records.
        /// </summary>
        List<Ledger> LedgerRecords { get; set; }

        /// <summary>
        /// Gets or sets the new selected customer.
        /// </summary>
        Customer NewSelectedCustomer { get; set; }

        /// <summary>
        /// Gets or sets the new selected service.
        /// </summary>
        Service NewSelectedService { get; set; }

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
        decimal? NewPricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the new number of units.
        /// </summary>
        decimal? NewNumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the new dos.
        /// </summary>
        DateTime? NewDOS { get; set; }

        /// <summary>
        /// Gets or sets the ledger start date.
        /// </summary>
        DateTime? LedgerStartDate { get; set; }

        /// <summary>
        /// Gets or sets the ledger end date.
        /// </summary>
        DateTime? LedgerEndDate { get; set; }

        /// <summary>
        /// The add new ledger record.
        /// </summary>
        void AddNewLedgerRecord();

        /// <summary>
        /// The delete ledger.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        void DeleteLedger(Ledger ledger);

        /// <summary>
        /// The update filter.
        /// </summary>
        void UpdateFilter();

        /// <summary>
        /// The save ledger record.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        void SaveLedgerRecord(Ledger ledger);
    }
}
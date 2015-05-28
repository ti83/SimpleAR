// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LedgerController.cs" company="">
//   
// </copyright>
// <summary>
//   The ledger controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    /// <summary>
    /// The ledger controller.
    /// </summary>
    public class LedgerController : ILedgerController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerController"/> class.
        /// </summary>
        public LedgerController()
        {
            LedgerStartDate = DateTime.Today.AddDays(-90);
            LedgerEndDate = DateTime.Today;
            LoadLedgerFromDB();
            NewDOS = DateTime.Today;
        }

        /// <summary>
        /// The load ledger from db.
        /// </summary>
        private void LoadLedgerFromDB()
        {
            LedgerRecords = LedgerManager.GetLedgerEntries(LedgerStartDate.Value, LedgerEndDate.Value);
            LedgerRecords = LedgerRecords.OrderByDescending(lr => lr.DateOfService).ToList();
        }

        /// <summary>
        /// Gets or sets the ledger records.
        /// </summary>
        public List<Ledger> LedgerRecords { get; set; }

        /// <summary>
        /// Gets or sets the new selected customer.
        /// </summary>
        public Customer NewSelectedCustomer { get; set; }

        /// <summary>
        /// Gets or sets the _ new selected service.
        /// </summary>
        private Service _NewSelectedService { get; set; }

        /// <summary>
        /// Gets or sets the new selected service.
        /// </summary>
        public Service NewSelectedService
        {
            get
            {
                return _NewSelectedService;
            }

            set
            {
                _NewSelectedService = value;
                if (_NewSelectedService != null)
                {
                    NewPricePerUnit = _NewSelectedService.PricePerUnit;
                }
            }
        }

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
        public decimal? NewPricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the new number of units.
        /// </summary>
        public decimal? NewNumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the new dos.
        /// </summary>
        public DateTime? NewDOS { get; set; }

        /// <summary>
        /// Gets or sets the ledger start date.
        /// </summary>
        public DateTime? LedgerStartDate { get; set; }

        /// <summary>
        /// Gets or sets the ledger end date.
        /// </summary>
        public DateTime? LedgerEndDate { get; set; }

        /// <summary>
        /// The add new ledger record.
        /// </summary>
        public void AddNewLedgerRecord()
        {
            var ledger = new Ledger()
            {
                CustomerId = NewSelectedCustomer.Id ?? 0, 
                CustomerName = NewSelectedCustomer.Name, 
                DOS = NewDOS, 
                NumberOfUnits = NewNumberOfUnits ?? 0, 
                UnitType = NewSelectedService.UnitType, 
                ServiceName = NewSelectedService.ServiceName, 
                PricePerUnit = NewPricePerUnit ?? 0, 
                ServiceId = NewSelectedService.Id ?? 0
            };
            LedgerManager.SaveLedgerItem(ledger);
            LoadLedgerFromDB();
            NewSelectedCustomer = null;
            NewSelectedService = null;
            NewPricePerUnit = null;
            NewNumberOfUnits = null;
            NewDOS = DateTime.Today;
        }

        /// <summary>
        /// The delete ledger.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        public void DeleteLedger(Ledger ledger)
        {
            if (!ledger.Id.HasValue)
            {
                LedgerRecords.Remove(ledger);
            }
            else
            {
                LedgerRecords.Remove(ledger);
                LedgerManager.DeleteLedgerItem(ledger.Id.Value);
            }
        }

        /// <summary>
        /// The update filter.
        /// </summary>
        public void UpdateFilter()
        {
            LoadLedgerFromDB();
        }

        /// <summary>
        /// The save ledger record.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        public void SaveLedgerRecord(Ledger ledger)
        {
            LedgerManager.SaveLedgerItem(ledger);
            LoadLedgerFromDB();
        }
    }
}

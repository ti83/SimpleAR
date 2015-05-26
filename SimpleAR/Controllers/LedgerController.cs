using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    public class LedgerController : ILedgerController
    {
        public LedgerController()
        {
            LedgerStartDate = DateTime.Today.AddDays(-90);
            LedgerEndDate = DateTime.Today;
            LoadLedgerFromDB();
            NewDOS = DateTime.Today;
        }

        private void LoadLedgerFromDB()
        {
            LedgerRecords = LedgerManager.GetLedgerEntries(LedgerStartDate.Value,LedgerEndDate.Value);
            LedgerRecords = LedgerRecords.OrderByDescending(lr => lr.DateOfService).ToList();
        }

        public List<Ledger> LedgerRecords { get; set; }

        public Customer NewSelectedCustomer { get; set; }

        private Service _NewSelectedService { get; set; }

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

        public decimal? NewPricePerUnit { get; set; }

        public decimal? NewNumberOfUnits { get; set; }

        public DateTime? NewDOS { get; set; }

        public DateTime? LedgerStartDate { get; set; }

        public DateTime? LedgerEndDate { get; set; }

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

        public void UpdateFilter()
        {
            LoadLedgerFromDB();
        }

        public void SaveLedgerRecord(Ledger ledger)
        {
            LedgerManager.SaveLedgerItem(ledger);
            LoadLedgerFromDB();
        }
    }
}

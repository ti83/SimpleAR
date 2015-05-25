using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.Controllers
{
    public class LedgerController : ILedgerController
    {
        public LedgerController()
        {
            LoadLedgerFromDB();
            NewDOS = DateTime.Today;
        }

        private void LoadLedgerFromDB()
        {
            LedgerRecords = LedgerManager.GetLedgerEntries();
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Interfaces;

namespace SimpleAR.ViewModels
{
    public class LedgerViewModel
    {
        public LedgerViewModel()
        {
            
        }

        public LedgerViewModel(ILedgerController controller)
        {
            Controller = controller;
        }

        private ILedgerController Controller { get; set; }
    }
}

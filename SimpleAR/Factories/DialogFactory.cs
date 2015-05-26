using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.DialogService;
using SimpleAR.Interfaces;

namespace SimpleAR.Factories
{
    public class DialogFactory
    {
        private static ILedgerDialog _ledgerDialog;
        public static ILedgerDialog CreateLedgerDialog()
        {
            if (_ledgerDialog == null)
            {
                _ledgerDialog = new LedgerDialogs();
            }
            return _ledgerDialog;
        }

        private static ICustomerDialog _customerDialog;
        public static ICustomerDialog CreateCustomerDialog()
        {
            if (_customerDialog == null)
            {
                _customerDialog = new CustomerDialogs();
            }
            return _customerDialog;
        }

        private static IServiceDialog _serviceDialog;
        public static IServiceDialog CreateServiceDialog()
        {
            if (_serviceDialog == null)
            {
                _serviceDialog = new ServiceDialogs();
            }
            return _serviceDialog;
        }
    }
}

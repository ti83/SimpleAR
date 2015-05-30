// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The dialog factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.DialogService;
using SimpleAR.Interfaces;

namespace SimpleAR.Factories
{
    /// <summary>
    /// The dialog factory.
    /// </summary>
    public class DialogFactory
    {
        /// <summary>
        /// The _ledger dialog.
        /// </summary>
        private static ILedgerDialog _ledgerDialog;

        /// <summary>
        /// The create ledger dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="ILedgerDialog"/>.
        /// </returns>
        public static ILedgerDialog CreateLedgerDialog()
        {
            if (_ledgerDialog == null)
            {
                _ledgerDialog = new LedgerDialogs();
            }

            return _ledgerDialog;
        }

        /// <summary>
        /// The _customer dialog.
        /// </summary>
        private static ICustomerDialog _customerDialog;

        /// <summary>
        /// The create customer dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="ICustomerDialog"/>.
        /// </returns>
        public static ICustomerDialog CreateCustomerDialog()
        {
            if (_customerDialog == null)
            {
                _customerDialog = new CustomerDialogs();
            }

            return _customerDialog;
        }

        /// <summary>
        /// The _service dialog.
        /// </summary>
        private static IServiceDialog _serviceDialog;

        /// <summary>
        /// The create service dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="IServiceDialog"/>.
        /// </returns>
        public static IServiceDialog CreateServiceDialog()
        {
            if (_serviceDialog == null)
            {
                _serviceDialog = new ServiceDialogs();
            }

            return _serviceDialog;
        }

        /// <summary>
        /// The _message dialog.
        /// </summary>
        private static IMessageDialog _messageDialog;

        /// <summary>
        /// The create message dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="IMessageDialog"/>.
        /// </returns>
        public static IMessageDialog CreateMessageDialog()
        {
            if (_messageDialog == null)
            {
                _messageDialog = new MessageDialog();
            }
            return _messageDialog;
        }
    }
}

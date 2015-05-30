// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILedgerDialog.cs" company="">
//   
// </copyright>
// <summary>
//   The LedgerDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The LedgerDialog interface.
    /// </summary>
    public interface ILedgerDialog
    {
        /// <summary>
        /// The edit ledger record item.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool EditLedgerRecordItem(Ledger ledger);

        /// <summary>
        /// The confirm service delete.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        /// <returns>
        /// The <see cref="MessageBoxResult"/>.
        /// </returns>
        MessageBoxResult ConfirmServiceDelete(Ledger ledger);
    }

}

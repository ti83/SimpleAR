// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceDialog.cs" company="">
//   
// </copyright>
// <summary>
//   The ServiceDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Windows;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The ServiceDialog interface.
    /// </summary>
    public interface IServiceDialog
    {
        /// <summary>
        /// The edit service.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool EditService(Service service);

        /// <summary>
        /// The confirm service delete.
        /// </summary>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <returns>
        /// The <see cref="MessageBoxResult"/>.
        /// </returns>
        MessageBoxResult ConfirmServiceDelete(string serviceName);
    }
}

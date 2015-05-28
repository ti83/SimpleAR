// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceController.cs" company="">
//   
// </copyright>
// <summary>
//   The ServiceController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR_DAL.DBModels;

namespace SimpleAR.Interfaces
{
    /// <summary>
    /// The ServiceController interface.
    /// </summary>
    public interface IServiceController
    {
        /// <summary>
        /// Gets or sets the new service name.
        /// </summary>
        string NewServiceName { get; set; }

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
        decimal? NewPricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the new unit type.
        /// </summary>
        string NewUnitType { get; set; }

        /// <summary>
        /// The add new service.
        /// </summary>
        void AddNewService();

        /// <summary>
        /// The delete service.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        void DeleteService(Service customer);

        /// <summary>
        /// The save service.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        void SaveService(Service customer);
    }
}

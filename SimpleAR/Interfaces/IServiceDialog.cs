// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceDialog.cs" company="">
//   
// </copyright>
// <summary>
//   The ServiceDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



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
    }
}

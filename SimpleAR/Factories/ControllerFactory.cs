﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The controller factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using SimpleAR.Controllers;
using SimpleAR.Interfaces;

namespace SimpleAR.Factories
{
    /// <summary>
    /// The controller factory.
    /// </summary>
    public class ControllerFactory
    {
        /// <summary>
        /// The create customer controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ICustomerController"/>.
        /// </returns>
        internal static ICustomerController CreateCustomerController()
        {
            return new CustomerController();
        }

        /// <summary>
        /// The create service controller.
        /// </summary>
        /// <returns>
        /// The <see cref="IServiceController"/>.
        /// </returns>
        internal static IServiceController CreateServiceController()
        {
            return new ServiceController();
        }

        /// <summary>
        /// The create ledger controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ILedgerController"/>.
        /// </returns>
        internal static ILedgerController CreateLedgerController()
        {
            return new LedgerController();
        }
    }
}

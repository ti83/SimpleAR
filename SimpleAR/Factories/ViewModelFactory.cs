﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The view model factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Linq;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR.ViewModels;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Factories
{
    /// <summary>
    /// The view model factory.
    /// </summary>
    class ViewModelFactory
    {
        /// <summary>
        /// The create customer view model.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <returns>
        /// The <see cref="CustomersViewModel"/>.
        /// </returns>
        internal static CustomersViewModel CreateCustomerViewModel(ICustomerController controller)
        {
            var dialogService = DialogFactory.CreateCustomerDialog();
            return new CustomersViewModel(controller, dialogService);
        }

        /// <summary>
        /// The create edit customer view model.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="EditCustomerViewModel"/>.
        /// </returns>
        internal static EditCustomerViewModel CreateEditCustomerViewModel(Customer customer)
        {
            return new EditCustomerViewModel()
            {
                CustomerName = customer.Name
            };
        }

        /// <summary>
        /// The create service view model.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceViewModel"/>.
        /// </returns>
        internal static ServiceViewModel CreateServiceViewModel(IServiceController controller)
        {
            var dialogService = DialogFactory.CreateServiceDialog();
            return new ServiceViewModel(controller, dialogService);
        }

        /// <summary>
        /// The created edit service view model.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <returns>
        /// The <see cref="EditServiceViewModel"/>.
        /// </returns>
        internal static EditServiceViewModel CreatedEditServiceViewModel(Service service)
        {
            return new EditServiceViewModel()
            {
                ServiceName = service.ServiceName, 
                PricePerUnit = service.PricePerUnit, 
                UnitType = service.UnitType
            };
        }

        /// <summary>
        /// The create ledger view model.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <returns>
        /// The <see cref="LedgerViewModel"/>.
        /// </returns>
        internal static LedgerViewModel CreateLedgerViewModel(ILedgerController controller)
        {
            var dialogService = DialogFactory.CreateLedgerDialog();
            return new LedgerViewModel(controller, dialogService);
        }

        /// <summary>
        /// The create edit ledger record view model.
        /// </summary>
        /// <param name="ledger">
        /// The ledger.
        /// </param>
        /// <returns>
        /// The <see cref="EditLedgerRecordViewModel"/>.
        /// </returns>
        internal static EditLedgerRecordViewModel CreateEditLedgerRecordViewModel(Ledger ledger)
        {
            var selectedCustomer = GlobalLists.Customers.FirstOrDefault(c => c.Id == ledger.CustomerId);
            var selectedService = GlobalLists.Services.FirstOrDefault(s => s.Id == ledger.ServiceId);
            return new EditLedgerRecordViewModel()
            {
                SelectedCustomer = selectedCustomer, 
                SelectedService = selectedService, 
                DOS = ledger.DOS, 
                PricePerUnit = ledger.PricePerUnit, 
                NumberOfUnits = ledger.NumberOfUnits, 
                UnitType = ledger.UnitType
            };
        }
    }
}

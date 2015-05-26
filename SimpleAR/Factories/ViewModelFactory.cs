using System.Linq;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR.ViewModels;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Factories
{
    class ViewModelFactory
    {
        internal static CustomersViewModel CreateCustomerViewModel(ICustomerController controller)
        {
            var dialogService = DialogFactory.CreateCustomerDialog();
            return new CustomersViewModel(controller, dialogService);
        }

        internal static EditCustomerViewModel CreateEditCustomerViewModel(Customer customer)
        {
            return new EditCustomerViewModel()
            {
                CustomerName = customer.Name
            };
        }

        internal static ServiceViewModel CreateServiceViewModel(IServiceController controller)
        {
            var dialogService = DialogFactory.CreateServiceDialog();
            return new ServiceViewModel(controller, dialogService);
        }

        internal static EditServiceViewModel CreatedEditServiceViewModel(Service service)
        {
            return new EditServiceViewModel()
            {
                ServiceName = service.ServiceName,
                PricePerUnit = service.PricePerUnit,
                UnitType = service.UnitType
            };
        }

        internal static LedgerViewModel CreateLedgerViewModel(ILedgerController controller)
        {
            var dialogService = DialogFactory.CreateLedgerDialog();
            return new LedgerViewModel(controller, dialogService);
        }

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

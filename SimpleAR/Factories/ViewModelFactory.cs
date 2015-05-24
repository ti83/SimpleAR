using SimpleAR.Interfaces;
using SimpleAR.ViewModels;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Factories
{
    class ViewModelFactory
    {
        internal static CustomersViewModel CreateCustomerViewModel(ICustomerController controller)
        {
            return new CustomersViewModel(controller);
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
            return new ServiceViewModel(controller);
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
            return new LedgerViewModel(controller);
        }
    }
}

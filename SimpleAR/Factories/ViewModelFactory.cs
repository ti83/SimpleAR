using SimpleAR.Interfaces;
using SimpleAR.ViewModels;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Factories
{
    class ViewModelFactory
    {
        public static CustomersViewModel CreateCustomerViewModel(ICustomerController controller)
        {
            return new CustomersViewModel(controller);
        }

        public static EditCustomerViewModel CreateEditCustomerViewModel(Customer customer)
        {
            return new EditCustomerViewModel()
            {
                CustomerName = customer.Name
            };
        }
    }
}

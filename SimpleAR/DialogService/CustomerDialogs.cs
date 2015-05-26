using SimpleAR.Factories;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.DialogService
{
    public class CustomerDialogs : ICustomerDialog
    {
        public bool EditCustomer(Customer customer)
        {
            var viewModel = ViewModelFactory.CreateEditCustomerViewModel(customer);
            var view = ViewFactory.CreatEditCustomerView(viewModel);
            var result  = view.ShowDialog();
            if (!result.HasValue || !result.Value)
            {
                return false;
            }

            customer.Name = viewModel.CustomerName;

            return true;
        }
    }
}

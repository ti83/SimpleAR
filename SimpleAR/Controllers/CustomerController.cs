using SimpleAR_DAL.Managers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR_DAL.DBModels;


namespace SimpleAR.Controllers
{
    public class CustomerController : INotifyPropertyChanged
    {
        public CustomerController()
        {
            Customers = CustomerManager.GetCustomers();
            AddNewCustomerCommand = new DelegateCommand(HandleAddNewCustomerCommand);
            DeleteCustomerCommand = new DelegateCommand(HandleDeleteCustomerCommand);
        }

        public List<Customer> Customers { get; set; }
        public string NewCustomerName { get; set; }

#region ICommand Properties

        public ICommand AddNewCustomerCommand { get; private set; }
        public ICommand DeleteCustomerCommand { get; private set; }

#endregion

        #region ICommand Methods

        private void HandleAddNewCustomerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewCustomerName))
            {
                MessageBox.Show("Please specify a customer name.");
                return;
            }
            CustomerManager.SaveCustomer(new Customer() { Name = NewCustomerName });
            Customers = CustomerManager.GetCustomers();
            NewCustomerName = string.Empty;
            OnPropertyChanged("NewCustomerName");
            OnPropertyChanged("Customers");
        }

        private void HandleDeleteCustomerCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer == null) return;

            if (!customer.Id.HasValue)
            {
                Customers.Remove(customer);
            }
            else
            {
                var result = MessageBox.Show(string.Format("Are you sure you want to delete {0}?  This will remove all records associated with them.",customer.Name), "Delete Customer?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    CustomerManager.DeleteCustomer(customer.Id.Value);
                    Customers = CustomerManager.GetCustomers();
                }
            }
            OnPropertyChanged("Customers");
        }

        #endregion

        #region Implement INotifyPropertyChanged

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

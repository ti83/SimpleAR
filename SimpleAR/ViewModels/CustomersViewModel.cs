using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.DialogService;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Managers;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The customers view model.
    /// </summary>
    public class CustomersViewModel : INotifyPropertyChanged
    {
        #region Class Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        public CustomersViewModel()
        {
            // This is just a stub so that the wpf designer can initialize this control in the editor.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        public CustomersViewModel(ICustomerController controller)
        {
            this.Controller = controller;
            AddNewCustomerCommand = new DelegateCommand(HandleAddNewCustomerCommand);
            DeleteCustomerCommand = new DelegateCommand(HandleDeleteCustomerCommand);
            EditCustomerCommand = new DelegateCommand(HandleEditCustomerCommand);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        private ICustomerController Controller { get; set; }

        public List<Customer> Customers
        {
            get
            {
                if (Controller == null) return null;
                return Controller.Customers;
            }
            set
            {
                Controller.Customers = value;
                OnPropertyChanged("Customers");
            }
        }

        public string NewCustomerName
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewCustomerName;
            }
            set
            {
                Controller.NewCustomerName = value;
                OnPropertyChanged("NewCustomerName");
            }
        }

        #endregion

        #region ICommand Properties

        public ICommand AddNewCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }

        #endregion

        #region ICommand Methods

        private void HandleAddNewCustomerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewCustomerName))
            {
                MessageBox.Show("Please specify a customer name.");
                return;
            }
            Controller.AddNewCustomer();
            OnPropertyChanged("NewCustomerName");
            OnPropertyChanged("Customers");
        }

        private void HandleDeleteCustomerCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer == null) return;

            var result = MessageBox.Show(string.Format("Are you sure you want to delete {0}?  This will remove all records associated with them.", customer.Name), "Delete Customer?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Controller.DeleteCustomer(customer);
            }

            OnPropertyChanged("Customers");
        }

        private void HandleEditCustomerCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer == null)
            {
                return;
            }

            if (CustomerDialogs.EditCustomer(customer))
            {
                Controller.SaveCustomer(customer);
                OnPropertyChanged("Customers");
            }
        }

        #endregion

        #region Implement INotifyPropertyChanged

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The customers view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

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
        /// <param name="dialogService">
        /// </param>
        public CustomersViewModel(ICustomerController controller, ICustomerDialog dialogService)
        {
            Controller = controller;
            DialogService = dialogService;
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

        /// <summary>
        /// Gets or sets the dialog service.
        /// </summary>
        private ICustomerDialog DialogService { get; set; }

        /// <summary>
        /// Gets or sets the new customer name.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the add new customer command.
        /// </summary>
        public ICommand AddNewCustomerCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete customer command.
        /// </summary>
        public ICommand DeleteCustomerCommand { get; set; }

        /// <summary>
        /// Gets or sets the edit customer command.
        /// </summary>
        public ICommand EditCustomerCommand { get; set; }

        #endregion

        #region ICommand Methods

        /// <summary>
        /// The handle add new customer command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleAddNewCustomerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewCustomerName))
            {
                MessageBox.Show("Please specify a customer name.");
                return;
            }

            Controller.AddNewCustomer();
            OnPropertyChanged("NewCustomerName");
        }

        /// <summary>
        /// The handle delete customer command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleDeleteCustomerCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer == null) return;

            var result = MessageBox.Show(string.Format("Are you sure you want to delete {0}?  This will remove all records associated with them.", customer.Name), "Delete Customer?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Controller.DeleteCustomer(customer);
            }

        }

        /// <summary>
        /// The handle edit customer command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleEditCustomerCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer == null)
            {
                return;
            }

            if (DialogService.EditCustomer(customer))
            {
                Controller.SaveCustomer(customer);
            }
        }

        #endregion

        #region Implement INotifyPropertyChanged

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

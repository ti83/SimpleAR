// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The service view model.
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
    /// The service view model.
    /// </summary>
    public class ServiceViewModel :INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceViewModel"/> class.
        /// </summary>
        public ServiceViewModel()
        {
            // This is just a stub so that the wpf designer can initialize this control in the editor.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceViewModel"/> class.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="dialogService">
        /// The dialog service.
        /// </param>
        public ServiceViewModel(IServiceController controller, IServiceDialog dialogService)
        {
            Controller = controller;
            DialogService = dialogService;
            AddNewServiceCommand = new DelegateCommand(HandleAddNewServiceCommand);
            DeleteServiceCommand = new DelegateCommand(HandleDeleteServiceCommand);
            EditServiceCommand = new DelegateCommand(HandleEditServiceCommand);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        private IServiceController Controller { get; set; }

        /// <summary>
        /// Gets or sets the dialog service.
        /// </summary>
        private IServiceDialog DialogService { get; set; }

        /// <summary>
        /// Gets or sets the new service name.
        /// </summary>
        public string NewServiceName 
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewServiceName;
            }

            set
            {
                Controller.NewServiceName = value;
                OnPropertyChanged("NewServiceName");

            }
        }

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
        public decimal? NewPricePerUnit
        {
            get
            {
                if (Controller == null) return 0;
                return Controller.NewPricePerUnit;                
            }

            set
            {
                Controller.NewPricePerUnit = value;
                OnPropertyChanged("NewPricePerUnit");
            }
        }

        /// <summary>
        /// Gets or sets the new unit type.
        /// </summary>
        public string NewUnitType
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewUnitType;
            }

            set
            {
                Controller.NewUnitType = value;
                OnPropertyChanged("NewUnitType");

            }
        }


        #endregion

        #region ICommand Properties

        /// <summary>
        /// Gets or sets the add new service command.
        /// </summary>
        public ICommand AddNewServiceCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete service command.
        /// </summary>
        public ICommand DeleteServiceCommand { get; set; }

        /// <summary>
        /// Gets or sets the edit service command.
        /// </summary>
        public ICommand EditServiceCommand { get; set; }

        #endregion

        #region ICommand Methods

        /// <summary>
        /// The handle add new service command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleAddNewServiceCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(NewServiceName))
            {
                MessageBox.Show("Please specify a service name.");
                return;
            }

            if (!NewPricePerUnit.HasValue)
            {
                MessageBox.Show("Please specify a price per unit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(NewUnitType))
            {
                MessageBox.Show("Please specify a unit type");
                return;
            }

            Controller.AddNewService();
            OnPropertyChanged("NewServiceName");
            OnPropertyChanged("NewPricePerUnit");
            OnPropertyChanged("NewUnitType");
            OnPropertyChanged("Services");
        }

        /// <summary>
        /// The handle delete service command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleDeleteServiceCommand(object obj)
        {
            var service = obj as Service;
            if (service == null) return;

            var result = MessageBox.Show(string.Format("Are you sure you want to delete {0}?", service.ServiceName), "Delete Service?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Controller.DeleteService(service);
            }

            OnPropertyChanged("Services");
        }

        /// <summary>
        /// The handle edit service command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleEditServiceCommand(object obj)
        {
            var service = obj as Service;
            if (service == null)
            {
                return;
            }

            if (DialogService.EditService(service))
            {
                Controller.SaveService(service);
                OnPropertyChanged("Services");
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

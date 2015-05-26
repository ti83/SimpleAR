using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.DialogService;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class ServiceViewModel :INotifyPropertyChanged
    {
        public ServiceViewModel()
        {
            // This is just a stub so that the wpf designer can initialize this control in the editor.
        }

        public ServiceViewModel(IServiceController controller, IServiceDialog dialogService)
        {
            Controller = controller;
            DialogService = dialogService;
            AddNewServiceCommand = new DelegateCommand(HandleAddNewServiceCommand);
            DeleteServiceCommand = new DelegateCommand(HandleDeleteServiceCommand);
            EditServiceCommand = new DelegateCommand(HandleEditServiceCommand);
        }

        #region Properties

        private IServiceController Controller { get; set; }
        private IServiceDialog DialogService { get; set; }

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

        public ICommand AddNewServiceCommand { get; set; }
        public ICommand DeleteServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }

        #endregion

        #region ICommand Methods

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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}

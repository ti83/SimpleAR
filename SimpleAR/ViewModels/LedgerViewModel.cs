using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public class LedgerViewModel : INotifyPropertyChanged
    {
        public LedgerViewModel()
        {
            // This is just a stub so that the wpf designer can initialize this control in the editor.            
        }

        public LedgerViewModel(ILedgerController controller, ILedgerDialog dialogService)
        {
            Controller = controller;
            DialogService = dialogService;
            AddNewServiceCommand = new DelegateCommand(HandleAddNewServiceCommand);
            DeleteServiceCommand = new DelegateCommand(HandleDeleteServiceCommand);
            EditServiceCommand = new DelegateCommand(HandleEditServiceCommand);
            UpdateFilterCommand = new DelegateCommand(HandleUpdateFilterCommand);
        }

        #region Properties

        private ILedgerController Controller { get; set; }
        private ILedgerDialog DialogService { get;set; }

        public List<Ledger> LedgerRecords
        {
            get
            {
                if (Controller == null) return null;
                return Controller.LedgerRecords;
            }
            set
            {
                Controller.LedgerRecords = value;
                OnPropertyChanged("LedgerRecords");
            }
        }

        public Customer NewSelectedCustomer 
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewSelectedCustomer;
            } 
            set
            {
                Controller.NewSelectedCustomer = value;
                OnPropertyChanged("NewSelectedCustomer");
            } 
        }

        public Service NewSelectedService
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewSelectedService;
            }
            set
            {
                Controller.NewSelectedService = value;
                OnPropertyChanged("NewSelectedService");
                OnPropertyChanged("NewPricePerUnit");
            }
        }

        public decimal? NewPricePerUnit
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewPricePerUnit;
            }
            set
            {
                Controller.NewPricePerUnit = value;
                OnPropertyChanged("NewPricePerUnit");
            }
        }

        public decimal? NewNumberOfUnits
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewNumberOfUnits;
            }
            set
            {
                Controller.NewNumberOfUnits = value;
                OnPropertyChanged("NewNumberOfUnits");
            }
        }

        public DateTime? NewDOS
        {
            get
            {
                if (Controller == null) return null;
                return Controller.NewDOS;
            }
            set
            {
                if (Controller == null) return;
                Controller.NewDOS = value;
                OnPropertyChanged("NewDOS");
            }
        }

        public DateTime? LedgerStartDate
        {
            get
            {
                if (Controller == null) return null;
                return Controller.LedgerStartDate;                
            }
            set
            {
                if (Controller == null) return;
                Controller.LedgerStartDate = value;
                OnPropertyChanged("LedgerStartDate");
            }
        }

        public DateTime? LedgerEndDate
        {
            get
            {
                if (Controller == null) return null;
                return Controller.LedgerEndDate;
            }
            set
            {
                if (Controller == null) return;
                Controller.LedgerEndDate = value;
                OnPropertyChanged("LedgerEndDate");
            }
        }

        #endregion

        #region ICommand Properties

        public ICommand AddNewServiceCommand { get; set; }
        public ICommand DeleteServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }
        public ICommand UpdateFilterCommand { get; set; }

        #endregion

        #region ICommand Methods

        private void HandleAddNewServiceCommand(object obj)
        {
            if (NewSelectedCustomer == null)
            {
                MessageBox.Show("Please specify a customer.");
                return;
            }
            if (NewSelectedService == null)
            {
                MessageBox.Show("Please specify a Service.");
                return;
            }
            if (NewPricePerUnit == null)
            {
                MessageBox.Show("Please specify a price.");
                return;
            }
            if (NewNumberOfUnits == null)
            {
                MessageBox.Show(string.Format("Please specify the number of {0}.",NewSelectedService.UnitType));
                return;
            }
            if (NewDOS == null)
            {
                MessageBox.Show("Please specify a Date Of Service.");
                return;
            }
            Controller.AddNewLedgerRecord();
            OnPropertyChanged("NewSelectedCustomer");
            OnPropertyChanged("NewSelectedService");
            OnPropertyChanged("NewPricePerUnit");
            OnPropertyChanged("NewNumberOfUnits");
            OnPropertyChanged("NewDOS");
            OnPropertyChanged("LedgerRecords");
        }

        private void HandleDeleteServiceCommand(object obj)
        {
            var ledger = obj as Ledger;
            if (ledger == null) return;

            var message = string.Format("Are you sure you want to delete {0} performed for {1} on {2}?", ledger.ServiceName, ledger.CustomerName, ledger.DOS.Value.ToShortDateString());
            var result = MessageBox.Show(message, "Delete Ledger Entry?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Controller.DeleteLedger(ledger);
            }

            OnPropertyChanged("LedgerRecords");
        }

        private void HandleEditServiceCommand(object obj)
        {
            var ledger = obj as Ledger;
            if (ledger == null)
            {
                return;
            }

            if (DialogService.EditLedgerRecordItem(ledger))
            {
                Controller.SaveLedgerRecord(ledger);
                OnPropertyChanged("LedgerRecords");
            }
        }

        private void HandleUpdateFilterCommand(object obj)
        {
            if (LedgerStartDate == null)
            {
                MessageBox.Show("Please specify start date for the ledger filter.");
                return;
            }
            if (LedgerEndDate == null)
            {
                MessageBox.Show("Please specify end date for the ledger filter.");
                return;
            }
            Controller.UpdateFilter();
            OnPropertyChanged("LedgerRecords");
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

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LedgerViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The ledger view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The ledger view model.
    /// </summary>
    public class LedgerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerViewModel"/> class.
        /// </summary>
        public LedgerViewModel()
        {
            // This is just a stub so that the wpf designer can initialize this control in the editor.            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LedgerViewModel"/> class.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="dialogService">
        /// The dialog service.
        /// </param>
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

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        private ILedgerController Controller { get; set; }

        /// <summary>
        /// Gets or sets the dialog service.
        /// </summary>
        private ILedgerDialog DialogService { get;set; }

        /// <summary>
        /// Gets or sets the ledger records.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the new selected customer.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the new selected service.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the new price per unit.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the new number of units.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the new dos.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the ledger start date.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the ledger end date.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the update filter command.
        /// </summary>
        public ICommand UpdateFilterCommand { get; set; }

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
                MessageBox.Show(string.Format("Please specify the number of {0}.", NewSelectedService.UnitType));
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

        /// <summary>
        /// The handle delete service command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
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

        /// <summary>
        /// The handle edit service command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
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

        /// <summary>
        /// The handle update filter command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
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

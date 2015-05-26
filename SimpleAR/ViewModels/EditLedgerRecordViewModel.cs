// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditLedgerRecordViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The edit ledger record view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    /// <summary>
    /// The edit ledger record view model.
    /// </summary>
    public class EditLedgerRecordViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditLedgerRecordViewModel"/> class.
        /// </summary>
        public EditLedgerRecordViewModel()
        {
            SaveCommand = new DelegateCommand(HandleSaveCommand);
        }

        /// <summary>
        /// Gets or sets the dos.
        /// </summary>
        public DateTime? DOS { get;set; }

        /// <summary>
        /// Gets or sets the selected customer.
        /// </summary>
        public Customer SelectedCustomer { get; set; }

        /// <summary>
        /// Gets or sets the _ selected service.
        /// </summary>
        private Service _SelectedService { get; set; }

        /// <summary>
        /// Gets or sets the selected service.
        /// </summary>
        public Service SelectedService
        {
            get
            {
                return _SelectedService;                
            }

            set
            {
                _SelectedService = value;
                if (_SelectedService == null)
                {
                    PricePerUnit = 0;
                    UnitType = string.Empty;
                }
                else
                {
                    PricePerUnit = _SelectedService.PricePerUnit;
                    UnitType = _SelectedService.UnitType;
                }

                OnPropertyChanged("SelectedService");
                OnPropertyChanged("ServiceTotal");
            }
        }

        /// <summary>
        /// Gets or sets the _ price per unit.
        /// </summary>
        private decimal _PricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        public decimal PricePerUnit
        {
            get { return _PricePerUnit; }
            set
            {
                _PricePerUnit = value;
                OnPropertyChanged("PricePerUnit");
                OnPropertyChanged("ServiceTotal");
            }
        }

        /// <summary>
        /// Gets or sets the _ number of units.
        /// </summary>
        private decimal _NumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the number of units.
        /// </summary>
        public decimal NumberOfUnits
        {
            get { return _NumberOfUnits; }
            set
            {
                _NumberOfUnits = value;
                OnPropertyChanged("NumberOfUnits");
                OnPropertyChanged("ServiceTotal");
            }
        }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Gets the service total.
        /// </summary>
        public decimal ServiceTotal
        {
            get
            {
                return PricePerUnit * NumberOfUnits;
            }
        }

        #region ICommand Properties

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region ICommand Methods

        /// <summary>
        /// The handle save command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void HandleSaveCommand(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.DialogResult = true;
                window.Close();
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

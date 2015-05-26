using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleAR.Common;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class EditLedgerRecordViewModel : INotifyPropertyChanged
    {
        public EditLedgerRecordViewModel()
        {
            SaveCommand = new DelegateCommand(HandleSaveCommand);
        }

        public DateTime? DOS { get;set; }

        public Customer SelectedCustomer { get; set; }

        private Service _SelectedService { get; set; }
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

        private decimal _PricePerUnit { get; set; }
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

        private decimal _NumberOfUnits { get; set; }
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

        public string UnitType { get; set; }

        public decimal ServiceTotal
        {
            get
            {
                return PricePerUnit * NumberOfUnits;
            }
        }

        #region ICommand Properties

        public ICommand SaveCommand { get; set; }

        #endregion

        #region ICommand Methods

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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class LedgerViewModel : INotifyPropertyChanged
    {
        public LedgerViewModel()
        {
            
        }

        public LedgerViewModel(ILedgerController controller)
        {
            Controller = controller;
        }

        private ILedgerController Controller { get; set; }

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
                Controller.NewDOS = value;
                OnPropertyChanged("NewDOS");
            }
        }

        #region Implement INotifyPropertyChanged

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}

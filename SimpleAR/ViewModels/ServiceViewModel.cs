using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR.Interfaces;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.ViewModels
{
    public class ServiceViewModel :INotifyPropertyChanged
    {
        public ServiceViewModel()
        {
            

        }

        public ServiceViewModel(IServiceController controller)
        {
            Controller = controller;
        }

        private IServiceController Controller { get; set; }

        public List<Service> Services
        {
            get
            {
                if (Controller == null) return null;
                return Controller.Services;
            }
            set
            {
                Controller.Services = value;
                OnPropertyChanged("Services");
            }
        }

        public string NewServiceName {
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

        public decimal NewServiceCost
        {
            get
            {
                if (Controller == null) return 0;
                return Controller.NewServiceCost;                
            }
            set
            {
                Controller.NewServiceCost = value;
                OnPropertyChanged("NewServiceCost");
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

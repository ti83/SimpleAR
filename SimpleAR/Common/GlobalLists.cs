using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Common
{
    public class GlobalLists
    {
        public GlobalLists()
        {
            Customers = new ObservableCollection<Customer>();
            Services = new ObservableCollection<Service>();
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public static ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public static ObservableCollection<Service> Services = new ObservableCollection<Service>();
        //{Binding Source={x:Static MyNamespace:MyStaticClass.MyProperty}, Mode=OneWay}
    }
}

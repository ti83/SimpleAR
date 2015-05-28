// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalLists.cs" company="">
//   
// </copyright>
// <summary>
//   The global lists.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.ObjectModel;
using SimpleAR_DAL.DBModels;

namespace SimpleAR.Common
{
    /// <summary>
    /// The global lists.
    /// </summary>
    public class GlobalLists
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalLists"/> class.
        /// </summary>
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

// {Binding Source={x:Static MyNamespace:MyStaticClass.MyProperty}, Mode=OneWay}
    }
}

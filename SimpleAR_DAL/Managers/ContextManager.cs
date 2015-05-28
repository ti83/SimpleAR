// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextManager.cs" company="">
//   
// </copyright>
// <summary>
//   The context manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Data.Entity;
using SimpleAR_DAL.DBModels;

namespace SimpleAR_DAL.Managers
{
    /// <summary>
    /// The context manager.
    /// </summary>
    public class ContextManager : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextManager"/> class.
        /// </summary>
        public ContextManager() : base("name=MyDbCS") { }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Gets or sets the ledger records.
        /// </summary>
        public DbSet<Ledger> LedgerRecords { get; set; }
    }
}

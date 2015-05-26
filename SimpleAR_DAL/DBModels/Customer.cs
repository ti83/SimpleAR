// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
//   
// </copyright>
// <summary>
//   The customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{
    /// <summary>
    /// The customer.
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Column("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the records.
        /// </summary>
        [NotMapped]
        public List<Ledger> LedgerItems { get; set; }
    }
}

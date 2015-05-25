using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{
    /// <summary>
    /// The ledger.
    /// </summary>
    [Table("Ledger")]
    public class Ledger
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Column("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the service id.
        /// </summary>
        [Column("ServiceId")]
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the date of service.
        /// </summary>
        [Column("DateOfService")]
        public string DateOfService { get; set; }

        /// <summary>
        /// Gets or sets the dos.
        /// </summary>
        [NotMapped]
        public DateTime? DOS
        {
            get
            {
                long unixDate;
                if (long.TryParse(DateOfService, out unixDate))
                {
                    return DateTime.FromFileTime(unixDate);
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    DateOfService = value.Value.ToFileTime().ToString();
                }
                else
                {
                    DateOfService = string.Empty;
                }
            }
        }

        [Column("CustomerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        [Column("ServiceName")]
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        [Column("PricePerUnit")]
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the number of units.
        /// </summary>
        [Column("NumberOfUnits")]
        public decimal NumberOfUnits { get; set; }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        [Column("UnitType")]
        public string UnitType { get; set; }

        /// <summary>
        /// Gets the total.
        /// </summary>
        [NotMapped]
        public decimal ServiceTotal
        {
            get
            {
                return PricePerUnit * NumberOfUnits;
            }
        }
    }
}

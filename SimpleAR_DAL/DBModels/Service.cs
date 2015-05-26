// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="">
//   
// </copyright>
// <summary>
//   The service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{
    /// <summary>
    /// The service.
    /// </summary>
    [Table("Service")]
    public class Service
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Column("Id")]
        public int? Id { get; set; }

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
        /// Gets or sets the unit type.
        /// </summary>
        [Column("UnitType")]
        public string UnitType { get; set; }
    }
}

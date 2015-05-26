using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{
    [Table("Service")]
    public class Service
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Column("ServiceName")]
        public string ServiceName { get; set; }

        [Column("PricePerUnit")]
        public decimal PricePerUnit { get; set; }

        [Column("UnitType")]
        public string UnitType { get; set; }
    }
}

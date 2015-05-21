


//using System.Data.Linq.Mapping;

using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{

    [Table("Customer")]
    public class Customer
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}

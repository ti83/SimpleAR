using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAR_DAL.DBModels
{
//    CREATE TABLE `Service` (
//    `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
//    `ServiceName`	TEXT,
//    `Cost`	REAL
//     );
    [Table("Service")]
    public class Service
    {
        [Column("Id")]
        public int? Id { get; set; }

        [Column("ServiceName")]
        public string ServiceName { get; set; }

        [Column("Cost")]
        public decimal Cost { get; set; }
    }
}

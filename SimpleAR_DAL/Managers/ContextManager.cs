using System.Data.Entity;
using SimpleAR_DAL.DBModels;

namespace SimpleAR_DAL.Managers
{
    public class ContextManager : DbContext
    {
        public ContextManager() : base("name=MyDbCS") { }
        public DbSet<Customer> Customers { get; set; }
    }
}

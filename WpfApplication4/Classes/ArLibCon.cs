using System.Data.Entity;

namespace ArLib.Classes
{
    public class ArLibCon : DbContext
    {
        public DbSet<Administrator> Administration { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public ArLibCon() : base("ArLibConnectionString")
        {
            Database.SetInitializer<ArLibCon>(new ArLibInitializer());
        }
    }
}

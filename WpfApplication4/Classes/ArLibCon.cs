using System.Data.Entity;

namespace ArLib.Classes
{
    public class ArLibCon : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

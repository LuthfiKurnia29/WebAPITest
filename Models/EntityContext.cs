using Microsoft.EntityFrameworkCore;

namespace TestDOT.Models
{
    public class EntityContext(DbContextOptions<EntityContext> options) : DbContext(options)
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Products> Products { get; set; }
        internal DbSet<Transaksi> Transaksi { get; set; }

        /// <summary>
        /// RelationTable
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

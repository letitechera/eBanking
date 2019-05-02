using eBanking.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBanking.DAL
{
    public class eBankingContext : DbContext
    {
        public eBankingContext() : base("eBanking.DAL.eBankingContext")
        {
            Database.SetInitializer(new eBankingInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Transference> Transferences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transference>().HasRequired(m => m.OriginAccount)
                      .WithMany(m => m.OriginTransferences).HasForeignKey(m => m.OriginAccountId)
                      .WillCascadeOnDelete(false); 
            modelBuilder.Entity<Transference>().HasRequired(m => m.DestinationAccount)
                      .WithMany(m => m.DestinationTransferences).HasForeignKey(m => m.DestinationAccountId)
                      .WillCascadeOnDelete(false);
        }
    }
}

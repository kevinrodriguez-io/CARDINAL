using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class CardinalDbContext : DbContext {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCutting> AccountCuttings { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDirectionHistory> UserDirectionHistories { get; set; }

        public CardinalDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=cardinal-db;Trusted_Connection=True;MultipleActiveResultSets=true") {
        }

        public CardinalDbContext(string nameOrConnectionString) : base(nameOrConnectionString) {
        }

    }
}

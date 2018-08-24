using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardinal.Model;

namespace Cardinal.Service {
    public class AccountService : IAccountService {

        private CardinalDbContext dbContext;

        public AccountService(CardinalDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public void Add(Account account) {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
        }

        public Account GetAccount(int id) {
            return dbContext.Accounts.Find(id);
        }

        public Account GetAccountForCardIdentifier(string cardIdentifier) {
            var card = dbContext.Cards.Where(I => I.Identifier == cardIdentifier).First();
            return card.Account;
        }

        public List<Account> GetAccounts() {
            return dbContext.Accounts.ToList();
        }

        public List<Account> GetAccountsByUserId(int userId) {
            return dbContext.Accounts.Where(I => I.UserId == userId).ToList();
        }

        public void Remove(Account account) {
            dbContext.Accounts.Remove(account);
            dbContext.SaveChanges();
        }

        public void Update(Account account) {
            var original = dbContext.Accounts.Find(account.Id);
            original.Type = account.Type;
            original.CuttingDate = account.CuttingDate;
            original.CashPayment = account.CashPayment;
            dbContext.SaveChanges();
        }
    }
}

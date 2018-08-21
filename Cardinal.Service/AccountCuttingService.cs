using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public class AccountCuttingService : IAccountCuttingService {

        private CardinalDbContext context;

        public AccountCuttingService(CardinalDbContext context) {
            this.context = context;
        }

        public void Add(AccountCutting accountCutting) {
            context.AccountCuttings.Add(accountCutting);
            context.SaveChanges();
        }

        public AccountCutting GetAccountCutting(int id) => context.AccountCuttings.Find(id);

        public List<AccountCutting> GetAccountCuttings() => context.AccountCuttings.ToList();

        public List<AccountCutting> GetAccountCuttingsByAccount(int accountId) => context.Accounts.Find(accountId).AccountCuttings.ToList();

        public void Remove(AccountCutting accountCutting) {
            context.AccountCuttings.Remove(accountCutting);
            context.SaveChanges();
        }

        public void Update(AccountCutting accountCutting) {
            var originalAccountCutting = context.AccountCuttings.Find(accountCutting.Id);
            context.Entry(originalAccountCutting).CurrentValues.SetValues(accountCutting);
            context.SaveChanges();
        }

    }
}

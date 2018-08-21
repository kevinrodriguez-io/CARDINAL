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

        public void GenerateAllAccountCuttings(DateTime fromDate, DateTime toDate) {

            // Process accounts that have at least 1 transaction for the current month.
            List<Account> accountsToProcess = context.Accounts.Where(A => A.AccountTransactions
                .Where(T => T.TransactionDate > fromDate && T.TransactionDate < toDate)
                .Count() > 0
            ).ToList();

            foreach (Account account in accountsToProcess) {
                AccountCutting accountCutting = new AccountCutting();
                List<Transaction> transactionsToProcess = account.AccountTransactions.Where(T => T.TransactionDate > fromDate && T.TransactionDate < toDate).ToList();
                decimal negatives = transactionsToProcess.Select(T => T.Withdrawal == null ? Decimal.Zero : T.Withdrawal.Value).Sum();
                decimal positives = transactionsToProcess.Select(T => T.Deposit == null ? Decimal.Zero : T.Deposit.Value).Sum();
                accountCutting.CashPayment = negatives + positives;
                accountCutting.RealPayment = accountCutting.CashPayment;

                // Set fields and save data.

            }
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

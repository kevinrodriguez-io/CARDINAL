using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardinal.Model;

namespace Cardinal.Service {
    public class TransactionService : ITransactionService {

        private CardinalDbContext context;
        public TransactionService(CardinalDbContext context) {
            this.context = context;
        }

        public void Add(Transaction transaction) {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        public Transaction GetTransaction(int id) {
            return context.Transactions.Find(id);
        }

        public List<Transaction> GetTransactions() {
            return context.Transactions.ToList();
        }

        public List<Transaction> GetTransactionsByAccountId(int accountId) {
            return context.Transactions.Where(I => I.AccountId == accountId).ToList();
        }

        public List<Transaction> GetTransactionsByUserId(int userId) {
            return context.Users.Find(userId).Accounts.SelectMany(I => I.AccountTransactions).ToList();
        }

        public void Remove(Transaction transaction) {
            context.Transactions.Remove(transaction);
        }

        public void Update(Transaction transaction) {
            var originalTransaction = context.Transactions.Find(transaction.Id);
            context.Entry(originalTransaction).CurrentValues.SetValues(transaction);
            context.SaveChanges();
        }

        public List<Card> GetCardsByUserId(int userId)
        {
            User user = context.Users.Find(userId);
            if (user == null) throw new Exception("Usuario no encontrado");
            List<Card> cards = user.Accounts.SelectMany(Account => Account.Cards).ToList();
            return cards;
        }

        public List<Card> GetCardsByAccountId(int accountId)
        {
            return context.Cards.Where(Card => Card.AccountId == accountId).ToList();
        }
    }
}

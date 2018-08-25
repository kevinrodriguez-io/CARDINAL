using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public interface ITransactionService {
        void Add(Transaction transaction);
        void Remove(Transaction transaction);
        void Update(Transaction transaction);
        Transaction GetTransaction(int id);
        List<Transaction> GetTransactions();
        List<Transaction> GetTransactionsByAccountId(int accountId);
        List<Transaction> GetTransactionsByUserId(int userId);
        List<Card> GetCardsByAccountId(int accountId);
        List<Card> GetCardsByUserId(int userId);
       
    }
}

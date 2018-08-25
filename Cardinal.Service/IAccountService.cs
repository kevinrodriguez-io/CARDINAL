using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public interface IAccountService {
        void Add(Account account);
        void Remove(Account account);
        void Update(Account account);
        Account GetAccount(int id);
        Account GetAccountForCardIdentifier(string cardIdentifier);
        List<Account> GetAccounts();
        List<Account> GetAccountsByUserId(int userId);
        Task ReBuildAccountsModel();
        Task<string> PredictAccountType(float amount);
    }
}

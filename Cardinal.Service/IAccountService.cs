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
        List<Account> GetAccounts();
        List<Account> GetAccountsByUserId(int userId);
    }
}

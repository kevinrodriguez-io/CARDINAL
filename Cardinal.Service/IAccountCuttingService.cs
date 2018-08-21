using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public interface IAccountCuttingService {

        void Add(AccountCutting accountCutting);
        void Remove(AccountCutting accountCutting);
        void Update(AccountCutting accountCutting);

        AccountCutting GetAccountCutting(int id);
        List<AccountCutting> GetAccountCuttings();
        List<AccountCutting> GetAccountCuttingsByAccount(int accountId);

    }
}

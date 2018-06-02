using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public interface IUserService {
        void Add(User user);
        void Remove(User user);
        void Update(User user);
        User GetUser(int id);
        List<User> GetUsers();
    }
}

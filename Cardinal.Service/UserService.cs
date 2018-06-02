using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardinal.Model;
using System.Data.Entity;

namespace Cardinal.Service {
    public class UserService : IUserService {

        private CardinalDbContext dbContext;

        public UserService(CardinalDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public void Add(User user) {
            throw new NotImplementedException();
        }

        public User GetUser(int id) {
            throw new NotImplementedException();
        }

        public List<User> GetUsers() {
            throw new NotImplementedException();
        }

        public void Remove(User user) {
            throw new NotImplementedException();
        }

        public void Update(User user) {
            throw new NotImplementedException();
        }
    }
}

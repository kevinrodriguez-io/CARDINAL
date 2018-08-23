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
        private IUserDirectionHistoryService userDirectionHistoryService;

        public UserService(CardinalDbContext dbContext) {
            this.dbContext = dbContext;
            userDirectionHistoryService = new UserDirectionHistoryService(dbContext);
        }

        public void Add(User user) {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public User GetUser(int id) {
            return dbContext.Users.Find(id);
        }

        public List<User> GetUsers() {
            return dbContext.Users.ToList();
        }

        public void Remove(User user) {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        public void Update(User user) {
            var original = dbContext.Users.Find(user.Id);
            dbContext.Entry(original).CurrentValues.SetValues(user);
            dbContext.SaveChanges();
        }
    }
}

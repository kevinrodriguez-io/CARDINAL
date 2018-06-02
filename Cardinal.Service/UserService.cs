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
            var originalUser = dbContext.Users.Find(user.Id);
            originalUser.Name = user.Name;
            originalUser.LastName = user.LastName;
            originalUser.BirthDate = user.BirthDate;
            originalUser.Direction = user.Direction;
            originalUser.Email = user.Email;
            originalUser.PhoneNumber = user.PhoneNumber;
            dbContext.SaveChanges();
        }
    }
}

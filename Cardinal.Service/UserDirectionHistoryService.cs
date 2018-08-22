using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardinal.Model;

namespace Cardinal.Service {
    public class UserDirectionHistoryService : IUserDirectionHistoryService {

        private CardinalDbContext context;

        public UserDirectionHistoryService(CardinalDbContext context) {
            this.context = context;
        }

        public void Add(UserDirectionHistory userDirectionHistory) {
            context.UserDirectionHistories.Add(userDirectionHistory);
            context.SaveChanges();
        }

        public List<UserDirectionHistory> GetUserDirectionHistories() => context.UserDirectionHistories.ToList();
        public List<UserDirectionHistory> GetUserDirectionHistoriesByUserId(int userId) => context.Users.Find(userId).UserDirectionHistories.ToList();
        public UserDirectionHistory GetUserDirectionHistory(int id) => context.UserDirectionHistories.Find(id);

        public void Remove(UserDirectionHistory userDirectionHistory) {
            context.UserDirectionHistories.Remove(userDirectionHistory);
            context.SaveChanges();
        }

        public void Update(UserDirectionHistory userDirectionHistory) {
            var original = context.UserDirectionHistories.Find(userDirectionHistory.Id);
            context.Entry(original).CurrentValues.SetValues(userDirectionHistory);
            context.SaveChanges();
        }
    }
}

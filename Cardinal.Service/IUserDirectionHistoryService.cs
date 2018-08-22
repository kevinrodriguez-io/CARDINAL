using Cardinal.Model;
using System.Collections.Generic;

namespace Cardinal.Service {
    public interface IUserDirectionHistoryService {
        void Add(UserDirectionHistory userDirectionHistory);
        void Remove(UserDirectionHistory userDirectionHistory);
        void Update(UserDirectionHistory userDirectionHistory);
        UserDirectionHistory GetUserDirectionHistory(int id);
        List<UserDirectionHistory> GetUserDirectionHistories();
        List<UserDirectionHistory> GetUserDirectionHistoriesByUserId(int userId);
    }
}

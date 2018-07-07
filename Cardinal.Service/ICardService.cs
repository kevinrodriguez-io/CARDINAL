using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public interface ICardService {
        void Add(Card card);
        void Remove(Card card);
        void Update(Card card);
        Card GetCard(int id);
        List<Card> GetCards();
        List<Card> GetCardsByAccountId(int accountId);
        List<Card> GetCardsByUserId(int userId);
    }
}

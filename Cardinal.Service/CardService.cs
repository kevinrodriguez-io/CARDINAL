using Cardinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Service {
    public class CardService : ICardService {
        private CardinalDbContext context;
        public CardService(CardinalDbContext context) {
            this.context = context;
        }

        public void Add(Card card) {
            context.Cards.Add(card);
            context.SaveChanges();
        }

        public Card GetCard(int id) {
            return context.Cards.Find(id);
        }

        public List<Card> GetCards() {
            return context.Cards.ToList();
        }

        public List<Card> GetCardsByAccountId(int accountId) {
            return context.Cards.Where(Card => Card.AccountId == accountId).ToList();
        }

        public List<Card> GetCardsByUserId(int userId) {
            User user = context.Users.Find(userId);
            if (user == null) throw new Exception("Usuario no encontrado");
            List<Card> cards = user.Accounts.SelectMany(Account => Account.Cards).ToList();
            return cards;
        }

        public void Remove(Card card) {
            context.Cards.Remove(card);
            context.SaveChanges();
        }

        public void Update(Card card) {
            Card originalCard = context.Cards.Find(card.Id);
            context.Entry(originalCard).CurrentValues.SetValues(card);
            context.SaveChanges();
        }
    }
}

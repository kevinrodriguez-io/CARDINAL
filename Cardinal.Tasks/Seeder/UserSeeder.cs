using Cardinal.Model;
using Faker;
using System;
using System.Linq;

namespace Cardinal.Tasks.Seeder {

    public interface IUserSeederDelegate {
        void DidSeedUsers();
        void DidSeedAccounts();
        void DidSeedCards();
        void DidSeedTransactions();
    }

    public class UserSeeder {

        private readonly string[] brands = new string[] { "Visa", "MasterCard", "American Express" };
        private CardinalDbContext context;

        public IUserSeederDelegate UserSeederDelegate { get; set; } = null;

        public UserSeeder(CardinalDbContext context) {
            this.context = context;
        }

        public void RunSeeder() {
            SeedUsers(5000);
            UserSeederDelegate?.DidSeedUsers();
            Console.WriteLine("Seeded users");
            foreach (var user in context.Users.ToList()) SeedAccountsForUser(user, RandomNumber.Next(1, 3));
            UserSeederDelegate?.DidSeedAccounts();
            Console.WriteLine("Seeded accounts");
            foreach (var account in context.Accounts.ToList()) SeedCardsForAccount(account, RandomNumber.Next(1, 2));
            UserSeederDelegate?.DidSeedCards();
            Console.WriteLine("Seeded cards");
            foreach (var card in context.Cards.ToList()) SeedTransactionsForCard(card, RandomNumber.Next(5, 50));
            UserSeederDelegate?.DidSeedTransactions();
            Console.WriteLine("Seeded transactions");
        }

        private void SeedUsers(int amount) {
            for (int i = 0; i < amount; i++)
                context.Users.Add(new User {
                    BirthDate = RandomDay(new DateTime(1960, 1, 1), DateTime.Today),
                    Direction = $"{Address.Country()} {Address.UsState()} {Address.City()} {Address.StreetAddress(true)}",
                    Email = Internet.Email(),
                    Name = Name.First(),
                    LastName = Name.Last(),
                    PhoneNumber = Phone.Number()
                });
            context.SaveChanges();
        }
        private void SeedAccountsForUser(User user, int amount) {
            for (int i = 0; i < amount; i++) {
                int cashPayment = RandomNumber.Next(500, 2000000);

                string accountType = "";
                if (cashPayment < 1000) accountType = "Junior";
                else if (cashPayment < 10000) accountType = "Bronze";
                else if (cashPayment < 100000) accountType = "Silver";
                else if (cashPayment < 1000000) accountType = "Gold";
                else if (cashPayment < 10000000) accountType = "Platinum";
                else accountType = "Shark";

                context.Accounts.Add(new Account {
                    UserId = user.Id,
                    CashPayment = cashPayment,
                    CuttingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, RandomNumber.Next(1, 30)),
                    Type = accountType
                });
            }
            context.SaveChanges();
        }
        private void SeedCardsForAccount(Account account, int amount) {
            for (int i = 0; i < amount; i++)
                context.Cards.Add(new Card {
                    Brand = $"{brands[RandomNumber.Next(0, brands.Length - 1)]} {Internet.DomainName()}",
                    ExpirationDate = RandomDay(new DateTime(2020, 3, 1), new DateTime(2033, 3, 1)),
                    Identifier = $"{RandomNumber.Next(4000, 5999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)}",
                    AccountId = account.Id
                });
            context.SaveChanges();
        }
        private void SeedTransactionsForCard(Card card, int amount) {
            decimal? depositTotal = 0, withdrawalTotal = 0;
            for (int t = 0; t < amount; t++) {

                bool isDeposit = RandomNumber.Next(-100, 100) >= 0;

                decimal withdrawal = decimal.Zero;
                decimal deposit = decimal.Zero;

                bool generateWithdrawal = false;
                bool generateDeposit = false;

                if (isDeposit) {
                    deposit = RandomNumber.Next(5, 1000);
                    generateDeposit = true;
                } else {
                    withdrawal = RandomNumber.Next(5, 1000);
                    generateWithdrawal = true;
                }

                if (!generateDeposit && !generateWithdrawal) break;

                Transaction transaction = new Transaction {
                    AssignedCard = card.Identifier,
                    TransactionDate = DateTime.Now,
                    AccountId = card.AccountId
                };

                transaction.Deposit = generateDeposit ? deposit : decimal.Zero;
                transaction.Withdrawal = generateWithdrawal ? withdrawal : decimal.Zero;

                depositTotal += transaction.Deposit;
                withdrawalTotal += transaction.Withdrawal;

                context.Transactions.Add(transaction);

                if (withdrawalTotal > card.Account.CashPayment) break;
            }
            context.SaveChanges();
        }

        private Random gen = new Random();
        private DateTime RandomDay(DateTime start, DateTime end) {
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}

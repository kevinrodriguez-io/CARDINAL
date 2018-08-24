using Cardinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using Cardinal.Model;

namespace Cardinal.Tasks.Seeder {
    public class UserSeeder {

        private readonly string[] brands = new string[] { "Visa", "MasterCard", "American Express" };
        //private readonly string[] cardType = new string[] { "Shark", "Platinum", "Gold", "Silver", "Bronze", "Junior" };

        private CardinalDbContext context;

        private List<User> users = new List<User>();

        public UserSeeder(CardinalDbContext context) {
            this.context = context;
        }

        public void GenerateUsers(int amount) {
            for (int i = 0; i < amount; i++) {
                PrepareUser(1, 5, 2, 3, 50, 100);
            }
            context.SaveChanges();
        }

        private void PrepareUser(
            int fakeAccountsMinAmount,
            int fakeAccountsMaxAmount,
            int fakeCardsMinAmount,
            int fakeCardsMaxAmount,
            int fakeTransactionsMinAmount,
            int fakeTransactionsMaxAmount
        ) {

            var user = new User {
                BirthDate = RandomDay(new DateTime(1960, 1, 1), DateTime.Today),
                Direction = $"{Address.Country()} {Address.UsState()} {Address.City()} {Address.StreetAddress(true)}",
                Email = Internet.Email(),
                Name = Name.First(),
                LastName = Name.Last(),
                PhoneNumber = Phone.Number()
            };

            context.Users.Add(user);

            if (fakeAccountsMinAmount == 0) return;
            int fakeAccountsToGenerate = RandomNumber.Next(fakeAccountsMinAmount, fakeAccountsMaxAmount);

            for (int a = 0; a < fakeAccountsToGenerate; a++) {

                var cashPayment = RandomNumber.Next(500, 2000000);
                string accountType = null;

                if (cashPayment < 1000) {
                    accountType = "Junior";
                } else if (cashPayment < 10000) {
                    accountType = "Bronze";
                } else if (cashPayment < 100000) {
                    accountType = "Silver";
                } else if (cashPayment < 1000000) {
                    accountType = "Gold";
                } else if (cashPayment < 10000000) {
                    accountType = "Platinum";
                } else {
                    accountType = "Shark";
                }

                var account = new Account {
                    UserId = user.Id,
                    CashPayment = cashPayment,
                    CuttingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, RandomNumber.Next(1, 30)),
                    Type = accountType
                };

                if (fakeCardsMinAmount == 0) {
                    context.Accounts.Add(account);
                    continue;
                }

                context.Accounts.Add(account);

                int fakeCardsToGenerate = RandomNumber.Next(fakeCardsMinAmount, fakeCardsMaxAmount);

                for (int c = 0; c < fakeCardsToGenerate; c++) {

                    var card = new Card {
                        Brand = $"{brands[RandomNumber.Next(0, brands.Length - 1)]} {Internet.DomainName()}",
                        ExpirationDate = RandomDay(new DateTime(2020, 3, 1), new DateTime(2033, 3, 1)),
                        Identifier = $"{RandomNumber.Next(4000, 5999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)}",
                        AccountId = account.Id
                    };

                    if (fakeTransactionsMinAmount == 0) {
                        context.Cards.Add(card);
                        continue;
                    }

                    context.Cards.Add(card);

                    int fakeTransactionsToGenerate = RandomNumber.Next(fakeTransactionsMinAmount, fakeTransactionsMaxAmount);

                    decimal? depositTotal = 0, withdrawalTotal = 0;

                    for (int t = 0; t < fakeTransactionsToGenerate; t++) {

                        var isDeposit = RandomNumber.Next(0, 1) == 1;

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

                        if (!generateDeposit && generateWithdrawal) break;

                        var transaction = new Transaction {
                            AssignedCard = card.Identifier,
                            TransactionDate = DateTime.Now,
                            AccountId = account.Id
                        };

                        transaction.Deposit = generateDeposit ? deposit : decimal.Zero;
                        transaction.Withdrawal = generateWithdrawal ? withdrawal : decimal.Zero;

                        depositTotal += transaction.Deposit;
                        withdrawalTotal += transaction.Withdrawal;

                        context.Transactions.Add(transaction);

                        if (withdrawalTotal > account.CashPayment) break;

                    }

                }

            }
        }

        private Random gen = new Random();
        private DateTime RandomDay(DateTime start, DateTime end) {
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}

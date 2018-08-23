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

        private IUserService userService;

        private List<User> users = new List<User>();

        public UserSeeder(IUserService userService) {
            this.userService = userService;
        }

        void PrepareUser(
            int fakeAccountsMinAmount,
            int fakeAccountsMaxAmount,
            int fakeCardsMinAmount,
            int fakeCardsMaxAmount,
            int fakeTransactionsMinAmount,
            int fakeTransactionsMaxAmount
        ) {

            User user = new User {
                BirthDate = RandomDay(new DateTime(1960, 1, 1), DateTime.Today),
                Direction = $"{Address.Country()} {Address.UsState()} {Address.City()} {Address.StreetAddress(true)}",
                Email = Internet.Email(),
                Name = Name.First(),
                LastName = Name.Last(),
                PhoneNumber = Phone.Number()
            };

            users.Add(user);

            if (fakeAccountsMinAmount == 0) return;
            int fakeAccountsToGenerate = RandomNumber.Next(fakeAccountsMinAmount, fakeAccountsMaxAmount);

            for (int a = 0; a < fakeAccountsToGenerate; a++) {
                Account account = new Account {
                    CashPayment = RandomNumber.Next(500, 20000),
                    CuttingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, RandomNumber.Next(1, 30)),
                    Type = Internet.DomainWord()
                };

                if (fakeCardsMinAmount == 0) {
                    user.Accounts.Add(account);
                    continue;
                }

                int fakeCardsToGenerate = RandomNumber.Next(fakeCardsMinAmount, fakeCardsMaxAmount);

                for (int c = 0; c < fakeCardsToGenerate; c++) {
                    Card card = new Card {
                        Brand = $"{brands[RandomNumber.Next(0, brands.Length - 1)]} {Internet.DomainName()}",
                        ExpirationDate = RandomDay(new DateTime(2020, 3, 1), new DateTime(2033, 3, 1)),
                        Identifier = $"{RandomNumber.Next(4000, 5999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)}"
                    };

                    if (fakeTransactionsMinAmount == 0) {
                        account.Cards.Add(card);
                        continue;
                    }

                    int fakeTransactionsToGenerate = RandomNumber.Next(fakeTransactionsMinAmount, fakeTransactionsMaxAmount);

                    for (int t = 0; t < fakeTransactionsToGenerate; t++) {

                    }

                }

            }



        }

        private Random gen = new Random();
        private DateTime RandomDay(DateTime start, DateTime end) {
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}

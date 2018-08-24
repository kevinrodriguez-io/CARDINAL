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

            var user = new User {
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
                    CashPayment = cashPayment,
                    CuttingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, RandomNumber.Next(1, 30)),
                    Type = accountType
                };

                if (fakeCardsMinAmount == 0) {
                    user.Accounts.Add(account);
                    continue;
                }

                int fakeCardsToGenerate = RandomNumber.Next(fakeCardsMinAmount, fakeCardsMaxAmount);

                for (int c = 0; c < fakeCardsToGenerate; c++) {

                    var card = new Card {
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

                        var cardForTransaction = account.Cards.ElementAt(RandomNumber.Next(0, account.Cards.Count));

                        var isDeposit = RandomNumber.Next(0, 1) == 1;

                        decimal withdrawal = decimal.Zero;
                        decimal deposit = decimal.Zero;

                        bool generateWithdrawal = false;
                        bool generateDeposit = false;

                        if (isDeposit) {
                            var allDeposits = account.AccountTransactions.Where(I => I.AssignedCard == cardForTransaction.Identifier).Sum(I => I.Deposit);
                            var allDepositsNotNull = allDeposits == null ? decimal.Zero : allDeposits.Value;
                            var depositMax = Convert.ToInt32(account.CashPayment - allDepositsNotNull);
                            if (depositMax > 5) {
                                deposit = RandomNumber.Next(5, );
                                generateDeposit = true;
                            }
                        } else {
                            var allWithdrawals = account.AccountTransactions.Where(I => I.AssignedCard == cardForTransaction.Identifier).Sum(I => I.Withdrawal);
                            var allWithdrawalsNotNull = allWithdrawals == null ? decimal.Zero : allWithdrawals.Value;
                            var withdrawalMax = Convert.ToInt32(account.CashPayment - allWithdrawalsNotNull);
                            if (withdrawalMax > 5) {

                            }
                        }

                        var transaction = new Transaction {
                            AssignedCard = cardForTransaction.Identifier,
                        };

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

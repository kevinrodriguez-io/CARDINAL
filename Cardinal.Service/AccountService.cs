using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cardinal.Model;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO;
using Microsoft.ML.Transforms;
using Microsoft.ML.Trainers;
using Cardinal.Model.AI;
using Cardinal.Service.AI.Model;

namespace Cardinal.Service {
    public class AccountService : IAccountService {

        private CardinalDbContext context;
        public AccountService(CardinalDbContext context) {
            this.context = context;
        }

        public void Add(Account account) {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public Account GetAccount(int id) {
            return context.Accounts.Find(id);
        }

        public Account GetAccountForCardIdentifier(string cardIdentifier) {
            var card = context.Cards.Where(I => I.Identifier == cardIdentifier).First();
            return card.Account;
        }

        public List<Account> GetAccounts() {
            return context.Accounts.ToList();
        }

        public List<Account> GetAccountsByUserId(int userId) {
            return context.Accounts.Where(I => I.UserId == userId).ToList();
        }

        public void Remove(Account account) {
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public void Update(Account account) {
            var original = context.Accounts.Find(account.Id);
            original.Type = account.Type;
            original.CuttingDate = account.CuttingDate;
            original.CashPayment = account.CashPayment;
            context.SaveChanges();
        }

        private const string CSV_FILE_NAME = "training.csv";
        private const string MODEL_FILE_NAME = "trained.ml";

        public async Task ReBuildAccountsModel() {
            if (File.Exists(MODEL_FILE_NAME)) File.Delete(MODEL_FILE_NAME);

            var allAccounts = context.Accounts.ToList();

            List<string> lines = new List<string> { };
            foreach (var account in allAccounts) {
                lines.Add($"{account.CashPayment},{account.Type}");
            }

            if (File.Exists(CSV_FILE_NAME)) File.Delete(CSV_FILE_NAME);
            File.WriteAllLines(CSV_FILE_NAME, lines);

            var pipeline = new LearningPipeline();
            pipeline.Add(new TextLoader(CSV_FILE_NAME).CreateFrom<AccountData>(separator: ','));
            pipeline.Add(new Dictionarizer("Label"));
            pipeline.Add(new ColumnConcatenator("Features", "Amount"));
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            var model = pipeline.Train<AccountData, AccountPrediction>();

            await model.WriteAsync(MODEL_FILE_NAME);
        }

        public async Task<string> PredictAccountType(float amount) {
            if (!File.Exists(MODEL_FILE_NAME)) await ReBuildAccountsModel();
            var model = await PredictionModel.ReadAsync<AccountData, AccountPrediction>(MODEL_FILE_NAME);
            var result = model.Predict(new AccountData { Amount = amount });
            return result.PredictedLabels;
        }

    }
}

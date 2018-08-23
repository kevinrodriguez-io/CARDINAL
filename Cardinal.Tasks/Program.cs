using Cardinal.Model;
using Cardinal.Service;
using System;
using Unity;
using static System.Console;

namespace Cardinal.Tasks {
    public class Program {

        private static IUnityContainer container;
        public static IUnityContainer Container {
            get {
                if (container == null)
                    container = new UnityContainer();
                return container;
            }
        }

        private static void ConfigureDependencyInjection() {
            container.RegisterType<CardinalDbContext>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ICardService, CardService>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IUserDirectionHistoryService, UserDirectionHistoryService>();
        }

        public static void Main(string[] args) {
            ConfigureDependencyInjection();
        }

    }
}

﻿using Cardinal.Model;
using Cardinal.Service;
using Cardinal.Tasks.Seeder;
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
            Container.RegisterType<CardinalDbContext>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<IAccountService, AccountService>();
            Container.RegisterType<ICardService, CardService>();
            Container.RegisterType<ITransactionService, TransactionService>();
            Container.RegisterType<IUserDirectionHistoryService, UserDirectionHistoryService>();
            container.RegisterType<UserSeeder>();
        }

        public static void Main(string[] args) {
            ConfigureDependencyInjection();
            WriteLine("Generating stuff");
            var seeder = Container.Resolve<UserSeeder>();
            WriteLine("Saving stuff");
            seeder.GenerateUsers(16000);
            WriteLine("Saving stuff done!");
            ReadKey();
        }

    }
}

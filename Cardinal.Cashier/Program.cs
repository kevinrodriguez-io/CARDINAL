using Cardinal.Model;
using Cardinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Cardinal.Cashier {
    static class Program {

        private static IUnityContainer container;
        public static IUnityContainer Container {
            get {
                if (container == null)
                    container = new UnityContainer();
                return container;
            }
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {

            // Register Services and Database
            container.RegisterType<CardinalDbContext>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ICardService, CardService>();
            container.RegisterType<ITransactionService, TransactionService>();

            // Register Forms
            container.RegisterType<Cashier>();
            container.RegisterType<frmDeposito>();
            container.RegisterType<FrmWithdrawal>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cashier());
        }
    }
}

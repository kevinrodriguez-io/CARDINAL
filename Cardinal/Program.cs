using Cardinal.Model;
using Cardinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Cardinal {
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
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            container = new UnityContainer();
            
            // Register Services and Database

            container.RegisterType<CardinalDbContext>();
            container.RegisterType<IUserService, UserService>();

            // Register Forms

            container.RegisterType<Main>();
            container.RegisterType<Users>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<Main>());
        }
    }
}

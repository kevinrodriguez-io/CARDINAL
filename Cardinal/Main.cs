using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Cardinal {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void mnExit_Click(object sender, EventArgs e) {
            MessageBox.Show("¡Gracias por usar Cardinal!");
            Application.Exit();
        }

        private void mnUsers_Click(object sender, EventArgs e) {
            var usersForm = Program.Container.Resolve<Users>();
            usersForm.Visible = true;
        }
    }
}

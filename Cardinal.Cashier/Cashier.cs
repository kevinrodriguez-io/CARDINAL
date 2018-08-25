using System;
using Unity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Cardinal.Cashier
{
    public partial class Cashier : Form
    {
        

        public Cashier()
        {
            InitializeComponent();

            Bunifu.Framework.Lib.Elipse.Apply(this, 15);
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenFormPanel(object Formhijo)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fh);
            this.panelContainer.Tag = fh;
            fh.Show();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            OpenFormPanel(Program.Container.Resolve<frmDeposit>());

        }

    }
}

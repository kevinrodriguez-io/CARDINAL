using Cardinal.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardinal.Cashier
{
    public partial class frmDeposito : Form
    {

        private ITransactionService transactionService;

        // Add additional services as parameters, Depencency Injection will provide them at runtime
        public frmDeposito(ITransactionService transactionService)
        {
            InitializeComponent();
            this.transactionService = transactionService;
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

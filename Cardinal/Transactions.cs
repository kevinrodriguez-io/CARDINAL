using Cardinal.Model;
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

namespace Cardinal {
    public partial class Transactions : Form {

        public Account Account { get; set; }

        private ITransactionService transactionService;
        public Transactions(ITransactionService transactionService) {
            InitializeComponent();
            this.transactionService = transactionService;
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e) {


        }
    }
}

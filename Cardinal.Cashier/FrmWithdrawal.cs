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

namespace Cardinal.Cashier {
    public partial class FrmWithdrawal : Form {

        private ITransactionService transactionService;

        public FrmWithdrawal(ITransactionService transactionService) {
            InitializeComponent();
            this.transactionService = transactionService;
        }
    }
}

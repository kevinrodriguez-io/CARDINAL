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

        private List<Transaction> AllTransactions { get; set; }
        private List<Transaction> DisplayTransactions { get; set; }

        private ITransactionService transactionService;
        public Transactions(ITransactionService transactionService) {
            InitializeComponent();
            this.transactionService = transactionService;
            
        }
        private void Transactions_Load(object sender, EventArgs e) {
            AllTransactions = transactionService.GetTransactionsByAccountId(Account.Id);
            DisplayTransactions = ((Transaction[])AllTransactions.ToArray().Clone()).ToList();
            LoadTransactionsListToDataGridView();
        }

        private void LoadTransactionsListToDataGridView() {
            var bindingList = new BindingList<Transaction>(DisplayTransactions);
            var source = new BindingSource(bindingList, null);
            dgvTransactions.DataSource = source;
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e) {
        }
        
        private void PerformSearch(string pattern) {
            DisplayTransactions = ((Transaction[])AllTransactions.ToArray().Clone()).ToList();
            DisplayTransactions = DisplayTransactions.Where(I =>
                I.Id.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.AssignedCard.ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.Deposit.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.Withdrawal.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.TransactionDate.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant())
            ).ToList();
            LoadTransactionsListToDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            PerformSearch(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            PerformSearch(((TextBox)sender).Text);
        }
        
    }
}

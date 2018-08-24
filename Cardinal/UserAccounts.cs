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
using Unity;

namespace Cardinal {
    public partial class UserAccounts : Form {

        private IAccountService accountService;

        public User User { get; set; } = null; // Se setea después de construirse
        private Account CurrentAccount { get; set; } = null; // Se obtiene a partir del usuario actual, o se crea una nueva si no tiene
        public List<Account> AllUserAccounts { get; set; }

        public UserAccounts(IAccountService accountService) {
            this.accountService = accountService;
            InitializeComponent();
        }

        private void UserAccounts_Load(object sender, EventArgs e) {
            AllUserAccounts = accountService.GetAccountsByUserId(User.Id);
            try {
                CurrentAccount = User.Accounts.First();
            } catch (ArgumentNullException) {
                CurrentAccount = new Account();
            } catch (InvalidOperationException) {
                CurrentAccount = new Account();
            }
            LoadUserAccountsListToDataGridView();
            FillInterfaceWithSelectedUserAccount();
        }

        private void LoadUserAccountsListToDataGridView() {
            var bindingList = new BindingList<Account>(AllUserAccounts);
            var source = new BindingSource(bindingList, null);
            dgvUserAccounts.DataSource = source;
        }

        private void RefreshUserAccountsList() {
            AllUserAccounts = accountService.GetAccountsByUserId(User.Id);
            LoadUserAccountsListToDataGridView();
        }

        private void FillInterfaceWithSelectedUserAccount() {
            txtId.Text = CurrentAccount.Id != 0 ? CurrentAccount.Id.ToString() : "";
            txtType.Text = CurrentAccount.Type;
            txtCashPayment.Text = CurrentAccount.CashPayment.ToString();
            dtpCuttingDate.Value = CurrentAccount.Id != 0 ? CurrentAccount.CuttingDate : DateTime.Now;
        }

        private void SetSelectedUserAccountFields() {
            CurrentAccount.UserId = User.Id;
            CurrentAccount.Type = txtType.Text;
            CurrentAccount.CashPayment = Convert.ToDecimal(txtCashPayment.Text);
            CurrentAccount.CuttingDate = dtpCuttingDate.Value;
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            try {
                var user = accountService.GetAccount(Int32.Parse(txtId.Text));
                if (user != null) {
                    CurrentAccount = user;
                    FillInterfaceWithSelectedUserAccount();
                } else {
                    MessageBox.Show("No se ha encontrado la cuenta con el id: " + txtId.Text);
                }
            } catch (FormatException) {
                MessageBox.Show("Por favor ingresa un número válido en el campo de Id");
            }
            RefreshUserAccountsList();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            SetSelectedUserAccountFields();
            try {
                accountService.Update(CurrentAccount);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido actualizar la cuenta, error: " + ex.Message);
                return;
            }
            RefreshUserAccountsList();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            try {
                accountService.Remove(CurrentAccount);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar la cuenta, error: " + ex.Message);
            }
            RefreshUserAccountsList();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            SetSelectedUserAccountFields();
            try {
                accountService.Add(CurrentAccount);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido crear la cuenta, error: " + ex.Message);
            }
            RefreshUserAccountsList();
        }

        private void tsmiTransactions_Click(object sender, EventArgs e) {
            Transactions transactionsForm = Program.Container.Resolve<Transactions>();
            transactionsForm.Account = CurrentAccount;
            transactionsForm.Visible = true;
        }

        private void tsmiAccountCuttings_Click(object sender, EventArgs e) {
            MessageBox.Show("En construcción!");
        }

        private void dgvUserAccounts_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected) {
                var account = accountService.GetAccount(Int32.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                CurrentAccount = account;
                if (CurrentAccount == null) CurrentAccount = new Account();
                FillInterfaceWithSelectedUserAccount();
            }
        }

        private void tsmiCards_Click(object sender, EventArgs e) {
            Cards cardsForm = Program.Container.Resolve<Cards>();
            cardsForm.Account = CurrentAccount;
            cardsForm.Visible = true;
        }

        private async void btnRebuildModel_Click(object sender, EventArgs e) {
            try {
                prbLoader.MarqueeAnimationSpeed = 30;
                await accountService.ReBuildAccountsModel();
            } catch (Exception ex) {
                MessageBox.Show($"{ex.Message}", "Error reconstruyendo modelo de aprendizaje");
            } finally {
                prbLoader.MarqueeAnimationSpeed = 0;
            }
        }

        private async void btnSuggestType_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtCashPayment.Text) || !float.TryParse(txtCashPayment.Text, out float result)) {
                MessageBox.Show("Datos no válidos", "Por favor ingrese un dato válido en el campo de monto para sugerir un tipo de cuenta");
                return;
            }
            try {
                prbLoader.MarqueeAnimationSpeed = 30;
                var predicted = await accountService.PredictAccountType(float.Parse(txtCashPayment.Text));
                txtType.Text = predicted;
            } catch (Exception ex) {
                MessageBox.Show($"{ex.Message}", "Error al predecir tipo de cuenta");
            } finally {
                prbLoader.MarqueeAnimationSpeed = 0;
            }
        }
    }
}

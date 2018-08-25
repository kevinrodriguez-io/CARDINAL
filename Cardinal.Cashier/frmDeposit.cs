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
using Cardinal.Model;

namespace Cardinal.Cashier
{

    public partial class frmDeposit : Form
    {

        public Account Account { get; set; }

        public Transaction CurrentTransaction { get; set; }



        private ITransactionService transactionService;
        private ICardService cardService;
        private IUserService userService;
        private IAccountService accountService;
        // Add additional services as parameters, Depencency Injection will provide them at runtime
        public frmDeposit(
            ITransactionService transactionService,
            ICardService cardService,
            IUserService userService,
            IAccountService accountService
        ) {
            InitializeComponent();
            this.transactionService = transactionService;
            this.cardService = cardService;
            this.userService = userService;
            this.accountService = accountService;
        }

  

        private void frmDeposito_Load(object sender, EventArgs e) {

            LoadComboBoxUSerIdToComboBox();
        }
        

        /*
            Cada vez que ud selecciona un usuario
            tiene que llamar este metodo con el id del usuario

            TAREA:
                #1 | Id usuario           | (Ingresar) => btnIngesar_Click(object bla bla) // Valida que el usuario sea valido
                #1.Mejor | Combobox Text = Nombre usuario Value = Usuario.Id | => cbbUsuarios_SelectionChanged() ... (Buscar como se llama)
                // 
                #2 LLAMAR LoadCardsToComboBoxForUserId cuando mete un valor nuevo en el textbox o combobox de usuario
                #3 A la hora de ingresar el deposito o retiro, llama GetCardIdentifierFromCardsCombobox() para el valor
                    de AssignedCard

        */
        private void LoadCardsToComboBoxForUserId(int userId) {
            cmbCards.Items.Clear();
            var userCards = cardService.GetCardsByUserId(userId);
            cmbCards.Items.AddRange(userCards.Select(I => new ComboBoxItem { Text = I.Identifier, Value = I.Identifier }).ToArray());
        }

        private void LoadComboBoxUSerIdToComboBox()
        {
            var userID = userService.GetUsers();
            cmbCustomers.Items.AddRange(userID.Select(I => new ComboBoxItem { Text = I.Name, Value = I.Id }).ToArray());
        }

        // Cuando ocupe obtener el valor del combo de cards le manda por parametro cmbCards, y cuando ocupe el de usuarios, cmbUsuarios
        // Para usuarios este objeto lo Convert.ToInt32, para cmbCards lo convierte a string Convert.ToString()
        // Obtener id de usuario seleccionado: Convert.ToInt32(GetObjectFromCombobox(cmbUsuarios))
        // Obtener num tarjeta seleccionado: Convert.ToString(GetObjectFromCombobox(cmbCards))

        private object GetObjectFromCombobox(ComboBox combo) => ((ComboBoxItem)combo.SelectedItem).Value;

        

        private void SaveTransaction() {

            try
            {


                var deposit = Convert.ToDecimal(txtQuantity.Text);
                var withdrawal = Convert.ToDecimal(txtWithDrawal.Text);



                var cardIdentifier = Convert.ToString(GetObjectFromCombobox(cmbCards));
                var account = accountService.GetAccountForCardIdentifier(cardIdentifier);

                var transaction = new Transaction
                {
                    AccountId = account.Id,
                    TransactionDate = DateTime.Now,
                    AssignedCard = cardIdentifier,
                    Deposit = deposit,
                    Withdrawal = withdrawal
                };
                transactionService.Add(transaction);
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void loadTransactionListCashier()
        {
            var bindingList = new BindingList<Transaction>();
            var source = new BindingSource(bindingList, null);
        }


        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        public void LoadCardsListToComboBox()
        {

        }

        private void SetSelectedTransactionsFields()
        {
            CurrentTransaction.Deposit = Convert.ToInt32(GetObjectFromCombobox(cmbCustomers));
            CurrentTransaction.Deposit = Convert.ToDecimal(txtQuantity.Text);
            CurrentTransaction.Withdrawal = Convert.ToDecimal(txtWithDrawal.Text);
            CurrentTransaction.TransactionDate = dtDateDeposit.Value;
            CurrentTransaction.AssignedCard = Convert.ToString(GetObjectFromCombobox(cmbCards)); //cmbCards.Items;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtWithDrawal.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;

            }
            SaveTransaction();
            MessageBox.Show("Transaccion Realizada Correctamente");
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomers_SelectionIndexChanged(object sender, EventArgs e)
        {
            LoadCardsToComboBoxForUserId(Convert.ToInt32(GetObjectFromCombobox(cmbCustomers)));
        }
    }
}

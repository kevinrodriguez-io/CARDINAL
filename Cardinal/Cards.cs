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
    public partial class Cards : Form {

        public Account Account { get; set; }
        public Card CurrentCard { get; set; }
        public List<Card> AllAccountCards { get; set; }

        private ICardService cardService;
        public Cards(ICardService cardService) {
            this.cardService = cardService;
            InitializeComponent();
        }

        private void RefreshCardsList() {
            AllAccountCards = cardService.GetCardsByAccountId(Account.Id);
            LoadCardsListToDataGridView();
        }

        private void LoadCardsListToDataGridView() {
            var bindingList = new BindingList<Card>(AllAccountCards);
            var source = new BindingSource(bindingList, null);
            dgvCards.DataSource = source;
        }

        private void FillInterfaceWithSelectedCard() {
            txtId.Text = CurrentCard.Id != 0 ? CurrentCard.Id.ToString() : "";
            txtBrand.Text = CurrentCard.Brand;
            txtCardNumber.Text = CurrentCard.Identifier;
            dtpExpirationDate.Value = CurrentCard.Id != 0 ? CurrentCard.ExpirationDate : DateTime.Now;
        }

        private void SetSelectedCardFields() {
            CurrentCard.AccountId = Account.Id;
            CurrentCard.Brand = txtBrand.Text;
            CurrentCard.Identifier = txtCardNumber.Text;
            CurrentCard.ExpirationDate = dtpExpirationDate.Value;
        }

        #region Events
        private void Cards_Load(object sender, EventArgs e) {
            AllAccountCards = cardService.GetCardsByAccountId(Account.Id);
            try {
                CurrentCard = Account.Cards.First();
            } catch (InvalidOperationException) {
                CurrentCard = new Card();
            }
            LoadCardsListToDataGridView();
            FillInterfaceWithSelectedCard();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            try {
                var card = cardService.GetCard(Int32.Parse(txtId.Text));
                if (card != null) {
                    CurrentCard = card;
                    FillInterfaceWithSelectedCard();
                } else {
                    MessageBox.Show("No se ha encontrado la tarjeta con el id: " + txtId.Text);
                }
            } catch (FormatException) {
                MessageBox.Show("Por favor ingresa un número válido en el campo de Id");
            }
            RefreshCardsList();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            SetSelectedCardFields();
            try {
                cardService.Update(CurrentCard);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido actualizar la tarjeta, error: " + ex.Message);
                return;
            }
            RefreshCardsList();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            try {
                cardService.Remove(CurrentCard);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar la tarjeta, error: " + ex.Message);
            }
            RefreshCardsList();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            SetSelectedCardFields();
            try {
                cardService.Add(CurrentCard);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido crear la tarjeta, error: " + ex.Message);
            }
            RefreshCardsList();
        }
        #endregion

        private void dgvCards_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected) {
                var card = cardService.GetCard(Int32.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                CurrentCard = card;
                if (CurrentCard == null) CurrentCard = new Card();
                FillInterfaceWithSelectedCard();
            }
        }
    }
}

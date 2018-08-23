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
    public partial class Users : Form {

        private IUserService userService;
        private IUserDirectionHistoryService userDirectionHistoryService;

        public User CurrentUser { get; set; }
        public List<User> AllUsers { get; set; }

        public Users(IUserService userService, IUserDirectionHistoryService userDirectionHistoryService) {
            InitializeComponent();
            this.userService = userService;
            this.userDirectionHistoryService = userDirectionHistoryService;
        }

        #region UI_Logic

        private void FillInterfaceWithSelectedUser() {
            txtId.Text = CurrentUser.Id != 0 ? CurrentUser.Id.ToString() : "";
            txtName.Text = CurrentUser.Name;
            txtLastname.Text = CurrentUser.LastName;
            txtDirection.Text = CurrentUser.Direction;
            txtEmail.Text = CurrentUser.Email;
            txtPhone.Text = CurrentUser.PhoneNumber;
            dtpBirthDate.Value = CurrentUser.Id != 0 ? CurrentUser.BirthDate : DateTime.Now;
        }

        private void SetSelectedUserFields() {
            CurrentUser.Name = txtName.Text;
            CurrentUser.LastName = txtLastname.Text;
            CurrentUser.Direction = txtDirection.Text;
            CurrentUser.Email = txtEmail.Text;
            CurrentUser.PhoneNumber = txtPhone.Text;
            CurrentUser.BirthDate = dtpBirthDate.Value;
        }

        private void RefreshUsersList() {
            AllUsers = userService.GetUsers();
            LoadUsersListToDataGridView();
        }

        private void LoadUsersListToDataGridView() {
            var bindingList = new BindingList<User>(AllUsers);
            var source = new BindingSource(bindingList, null);
            dgvUsers.DataSource = source;
        }

        #endregion

        #region Events

        private void Users_Load(object sender, EventArgs e) {
            AllUsers = userService.GetUsers();
            try {
                CurrentUser = AllUsers.First();
            } catch (InvalidOperationException) { // This happens when there is no "First" element on the list (Empty)
                CurrentUser = new User();
            }
            LoadUsersListToDataGridView();
            FillInterfaceWithSelectedUser();
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            try {
                var user = userService.GetUser(Int32.Parse(txtId.Text));
                if (user != null) {
                    CurrentUser = user;
                    FillInterfaceWithSelectedUser();
                } else {
                    MessageBox.Show("No se ha encontrado el usuario con el id: " + txtId.Text);
                }
            } catch (FormatException) {
                MessageBox.Show("Por favor ingresa un número válido en el campo de Id");
            }
            RefreshUsersList();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {

            var shouldAddToDirecitonHistory = txtDirection.Text != CurrentUser.Direction;
            var originalDirection = (string)CurrentUser.Direction.Clone();

            SetSelectedUserFields();
            try {
                userService.Update(CurrentUser);
                if (shouldAddToDirecitonHistory) userDirectionHistoryService.Add(new UserDirectionHistory {
                    ChangedDate = DateTime.Now,
                    LastDirection = originalDirection,
                    NewDirection = CurrentUser.Direction,
                    UserId = CurrentUser.Id
                });
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido actualizar el usuario, error: " + ex.Message);
                return;
            }
            RefreshUsersList();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            try {
                userService.Remove(CurrentUser);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido eliminar el usuario, error: " + ex.Message);
            }
            RefreshUsersList();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            SetSelectedUserFields();
            try {
                userService.Add(CurrentUser);
            } catch (Exception ex) {
                MessageBox.Show("No se ha podido crear el usuario, error: " + ex.Message);
            }
            RefreshUsersList();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected) {
                var user = userService.GetUser(Int32.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                CurrentUser = user;
                if (CurrentUser == null) CurrentUser = new User();
                FillInterfaceWithSelectedUser();
            }
        }

        private void tsmiUserAccounts_Click(object sender, EventArgs e) {
            var userAccountsForm = Program.Container.Resolve<UserAccounts>();
            userAccountsForm.User = CurrentUser;
            userAccountsForm.Visible = true;
        }

        private void tsmiUserDirectionHistory_Click(object sender, EventArgs e) {
            var userDirectionHistories = Program.Container.Resolve<UserDirectionHistories>();
            userDirectionHistories.User = CurrentUser;
            userDirectionHistories.Visible = true;
        }

        #endregion

    }
}

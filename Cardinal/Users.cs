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
    public partial class Users : Form {

        private IUserService userService;

        public User CurrentUser { get; set; }
        public List<User> AllUsers { get; set; }

        public Users(IUserService userService) {
            this.userService = userService;
            InitializeComponent();
        }

        #region UI_Logic

        private void FillInterfaceWithSelectedUser() {
            txtId.Text = CurrentUser.Id.ToString();
            txtName.Text = CurrentUser.Name;
            txtLastname.Text = CurrentUser.LastName;
            txtDirection.Text = CurrentUser.Direction;
            txtEmail.Text = CurrentUser.Email;
            txtPhone.Text = CurrentUser.PhoneNumber;
            dtpBirthDate.Value = CurrentUser.BirthDate;
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
            SetSelectedUserFields();
            try {
                userService.Update(CurrentUser);
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

        #endregion

    }
}

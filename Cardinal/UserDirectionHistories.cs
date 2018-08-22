using Cardinal.Model;
using Cardinal.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Cardinal {
    public partial class UserDirectionHistories : Form {

        public User User { get; set; }

        private List<UserDirectionHistory> AllUserDirectionHistories { get; set; }
        private List<UserDirectionHistory> DisplayUserDirectionHistories { get; set; }

        private IUserDirectionHistoryService userDirectionHistoryService;

        public UserDirectionHistories(IUserDirectionHistoryService userDirectionHistoryService) {
            InitializeComponent();
            this.userDirectionHistoryService = userDirectionHistoryService;
        }

        private void UserDirectionHistories_Load(object sender, EventArgs e) {
            AllUserDirectionHistories = userDirectionHistoryService.GetUserDirectionHistoriesByUserId(User.Id);
            DisplayUserDirectionHistories = ((UserDirectionHistory[])AllUserDirectionHistories.ToArray().Clone()).ToList();
        }

        private void LoadUserDirectionHistoriesListToDataGridView() {
            var bindingList = new BindingList<UserDirectionHistory>(DisplayUserDirectionHistories);
            var source = new BindingSource(bindingList, null);
            dgvUserDirections.DataSource = source;
        }

        private void PerformSearch(string pattern) {
            DisplayUserDirectionHistories = ((UserDirectionHistory[])AllUserDirectionHistories.ToArray().Clone()).ToList();
            DisplayUserDirectionHistories = DisplayUserDirectionHistories.Where(I =>
                I.Id.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.LastDirection.ToLowerInvariant().Contains(pattern.ToLowerInvariant()) ||
                I.NewDirection.ToString().ToLowerInvariant().Contains(pattern.ToLowerInvariant())
            ).ToList();
            LoadUserDirectionHistoriesListToDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            PerformSearch(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            PerformSearch(((TextBox)sender).Text);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projman_client
{
    public partial class UsersListView : IBaseView
    {
        public UsersListView()
        {
            InitializeComponent();
            presenter_ = new UsersListPresenter(this);
            presenter_.updateUsersList();
        }

        public void showUsers(List<User> users)
        {
            users_list.DataSource = users;
            Refresh();
        }

        public void navigateToEditUser(User user)
        {
            navigate(new EditUserView(user));
        }

        private void users_list_SelectionChanged(object sender, EventArgs e)
        {
            users_list.ClearSelection();
        }

        private void users_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            int row = e.RowIndex;
            if (row >= 0)
            {
                var user = (grid.DataSource as List<User>)[row];
                presenter_.onEditUserClick(user);
            }
        }

        private void add_user_button_Click(object sender, EventArgs e)
        {
            presenter_.onNewUserClick();
        }


        private UsersListPresenter presenter_;
    }
}

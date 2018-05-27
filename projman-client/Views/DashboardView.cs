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
    public partial class DashboardView : IBaseView
    {
        public DashboardView()
        {
            InitializeComponent();
            presenter_ = new DashboardPresenter(this);
        }

        public void navigateToProjectsList()
        {
            navigate(new ProjectsListView());
        }

        public void navigateToUsersList()
        {
            navigate(new UsersListView());
        }

        public void HideUsers()
        {
            users_button.Visible = false;
        }

        private void projects_button_Click(object sender, EventArgs e)
        {
            presenter_.onProjectsListClick();
        }

        private void users_button_Click(object sender, EventArgs e)
        {
            presenter_.onUsersListClick();
        }


        DashboardPresenter presenter_;
    }
}

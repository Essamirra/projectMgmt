using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    public class DashboardPresenter
    {
        public DashboardPresenter(DashboardView view)
        {
            view_ = view;
            var user = DataProviderFactory.getDataProvider().getCurrentUser();
            if (user.role != Projman.Server.User.Types.Role.Admin)
            {
                view_.HideUsers();
            }
        }

        public void onProjectsListClick()
        {
            view_.navigateToProjectsList();
        }

        public void onUsersListClick()
        {
            view_.navigateToUsersList();
        }

        DashboardView view_;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class UsersListPresenter
    {
        public UsersListPresenter(UsersListView view)
        {
            view_ = view;
        }

        public void onNewUserClick()
        {
            view_.navigateToEditUser(new User());
        }

        public void onEditUserClick(User user)
        {
            view_.navigateToEditUser(user);
        }

        public void updateUsersList()
        {
            var users = DataProvider.Instance.getUsers();
            view_.showUsers(users);
        }

        private UsersListView view_;
    }
}

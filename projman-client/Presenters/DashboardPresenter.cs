using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projman_client.Views;

namespace projman_client
{
    public class DashboardPresenter
    {
        public DashboardPresenter(DashboardView view)
        {
            view_ = view;
            var user = DataProviderFactory.getDataProvider().getCurrentUser();
            switch (user.role)
            {
                case Projman.Server.User.Types.Role.Admin:
                    {
                        navigate_ = new List<string> { PROJECTS, USERS };
                        break;
                    }
                case Projman.Server.User.Types.Role.Manager:
                    {
                        navigate_ = new List<string> { PROJECTS };
                        break;
                    }
                case Projman.Server.User.Types.Role.User:
                    {
                        navigate_ = new List<string> { TASKS };
                        break;
                    }
            }
            view.SetButtons(navigate_);
        }

        public void onButtonClick(int i)
        {
            if ((i < 0) || (i >= navigate_.Count))
            {
                return;
            }

            if (navigate_[i] == PROJECTS)
            {
                view_.Navigate(new ProjectsListView());
            }
            else if (navigate_[i] == USERS)
            {
                view_.Navigate(new UsersListView());
            }
            else if (navigate_[i] == TASKS)
            {
                view_.Navigate(new ViewAssignedTasks());
            }
        }

        private List<string> navigate_;
        private DashboardView view_;

        private const string PROJECTS = "Проекты";
        private const string USERS = "Пользователи";
        private const string TASKS = "Задачи";
    }
}

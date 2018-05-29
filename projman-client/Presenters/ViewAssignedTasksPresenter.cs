using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projman_client.Views;

namespace projman_client.Presenters
{
    class ViewAssignedTasksPresenter
    {
        private User _user;
        private ViewAssignedTasks _view;
        public ViewAssignedTasksPresenter(ViewAssignedTasks view)
        {
            _view = view;
            _view.ShowData(DataProviderFactory.getDataProvider().GetCurrentUserTasks());
        }

        public void onTaskClick(Task task)
        {
            _view.NavigateToCloseTask(task);
        }
    }
}

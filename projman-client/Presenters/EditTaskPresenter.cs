using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projman_client.Views.ViewInterfaces;

namespace projman_client
{
    class EditTaskPresenter
    {
        private IDataProvider _provider = DataProviderFactory.getDataProvider();
        private IEditTaskView _view;

        public EditTaskPresenter(IEditTaskView view, Task task, bool editMode)
        {
            _view = view;
            if(!editMode)
            view.ShowTask(task, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User);
            else
            {
                view.ShowTaskInEditMode(task);
            }
        }

        public void OnEditTaskClick(Task task)
        {
            _view.ShowTaskInEditMode(task);
        }

        public void OnSaveClick(Task task)
        {
            _provider.saveTask(task);
            _view.ShowTask(task, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User);
        }

        public void OnDiscardClick(Task task)
        {
            _view.ShowTask(task, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User);
           
        }

        public void OnAssginTaskClick(Task originalTask)
        {
            _view.ShowAssignDialog(_provider.getUsersForAssign());
        }

        public void OnAsigneeChoosen(User dialogChosedUser, Task task)
        {
            task.AssignedUser = dialogChosedUser;
            task.Status = Projman.Server.Task.Types.Status.Assigned;
            task.AssignedDate = DateTime.Now;
            _provider.saveTask(task);
            _view.ShowTask(task, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User, _provider.getCurrentUser().role != Projman.Server.User.Types.Role.User);
        }

        public void OnCloseClick(Task originalTask)
        {
           
            _provider.CloseTask(originalTask);
            _view.GoBack();
        }
    }
}

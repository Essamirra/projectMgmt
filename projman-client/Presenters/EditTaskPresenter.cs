using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projman_client.Views.ViewInterfaces;

namespace projman_client
{
    class EditTaskPresenter
    {
        private IDataProvider _provider = DataProviderFactory.getDataProvider();
        private IEditTaskView _view;

        public EditTaskPresenter(IEditTaskView view, Task task)
        {
            _view = view;
            view.ShowTask(task);
        }

        public void OnEditTaskClick(Task task)
        {
            _view.ShowTaskInEditMode(task);
        }

        public void OnSaveClick(Task task)
        {
            _provider.saveTask(task);
            _view.ShowTask(task);
        }

        public void OnDiscardClick(Task task)
        {
            _view.ShowTask(task);
        }
    }
}

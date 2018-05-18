using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projman_client.Views.ViewInterfaces;

namespace projman_client
{
    class EditProjectPresenter
    {
        private IDataProvider _provider = DataProviderFactory.getDataProvider();
        private IEditProjectView _view;
        public EditProjectPresenter(IEditProjectView editProjectView, Project project)
        {
            _view = editProjectView;
            _view.ShowData(project);
        }

        public void OnSaveClick(Project project)
        {
            _provider.saveProject(project);
            _view.NavigateToProjectView(project);
        }

        public void OnDiscardClick(Project project)
        {
            _view.NavigateToProjectView(project);
        }


    }
}

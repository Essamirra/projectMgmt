using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class ProjectsListPresenter
    {
        private IDataProvider _provider = DataProviderFactory.getDataProvider();
        public ProjectsListPresenter(ProjectsListView view)
        {
            view_ = view;
        }

        public void OnProjectClick(Project project)
        {
            view_.navigateToProject(project);
        }

        public void UpdateProjectsList()
        {
            var projects = _provider.getProjects();
            view_.showProjects(projects);
        }

        private ProjectsListView view_;
    }
}

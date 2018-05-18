using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class ProjectsListPresenter
    {
        public ProjectsListPresenter(ProjectsListView view)
        {
            view_ = view;
        }

        public void onProjectClick(Project project)
        {
            view_.navigateToProject("");
        }

        public void updateProjectsList()
        {
            var projects = DataProvider.Instance.getProjects();
            view_.showProjects(projects);
        }

        private ProjectsListView view_;
    }
}

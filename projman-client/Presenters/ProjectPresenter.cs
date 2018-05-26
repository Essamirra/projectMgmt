using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class ProjectPresenter
    {
        public ProjectPresenter(ProjectView view, Project project)
        {
            view_ = view;
            project_ = project;
        }

        public void onTaskClick(Task task)
        {
            view_.navigateToEditTask(task);
        }

        public void onNewTaskClick()
        {
            view_.navigateToEditTask(new Task());
        }

        public void onEditProjectClick()
        {
            view_.navigateToEditProject(project_);
        }

        public void updateTasks()
        {
            var tasks = DataProviderFactory.getDataProvider().getTasks(project_.id);
            view_.showData(project_, tasks);
        }


        ProjectView view_;
        Project project_;

        public void onStatisticsClick()
        {
            var tasks = DataProviderFactory.getDataProvider().getTasks(project_.id);
            view_.navigateToStatistic(tasks);
        }
    }
}

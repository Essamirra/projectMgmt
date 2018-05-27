using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projman_client.Views;

namespace projman_client
{
    public partial class ProjectView : IBaseView
    {
        public ProjectView(Project project)
        {
            InitializeComponent();
            presenter_ = new ProjectPresenter(this, project);
            presenter_.updateTasks();
        }

        public void navigateToEditTask(Task task)
        {
            navigate(new EditTaskView(task));
        }

        public void navigateToEditProject(Project project)
        {
            navigate(new EditProjectView(project));
        }

        public void showData(Project project, List<Task> tasks)
        {
            label_name.Text = project.name;
            label_description.Text = project.description;
            label_start_date.Text = project.startDate.ToString();
            label_end_date.Text = project.EndDate.ToString();

            tasks_list.DataSource = tasks;
        }

        private void tasks_list_SelectionChanged(object sender, EventArgs e)
        {
            tasks_list.ClearSelection();
        }

        private void edit_project_button_Click(object sender, EventArgs e)
        {
            presenter_.onEditProjectClick();
        }

        private void tasks_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            int row = e.RowIndex;
            if (row >= 0)
            {
                var task = (grid.DataSource as List<Task>)[row];
                presenter_.onTaskClick(task);
            }
        }

        private void add_task_button_Click(object sender, EventArgs e)
        {
            presenter_.onNewTaskClick();
        }


        private ProjectPresenter presenter_;

        private void button1_Click(object sender, EventArgs e)
        {
            presenter_.onStatisticsClick();
        }

        public void navigateToStatistic(List<Task> project)
        {
            navigate(new StatisticsView(project));
        }

        private void ProjectView_VisibleChanged(object sender, EventArgs e)
        {
            presenter_.updateTasks();
        }
    }
}

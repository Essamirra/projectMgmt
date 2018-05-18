using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projman_client
{
    public partial class ProjectsListView : IBaseView
    {
        public ProjectsListView()
        {
            InitializeComponent();
            presenter_ = new ProjectsListPresenter(this);
            presenter_.updateProjectsList();
        }

        public void navigateToProject(string id)
        {
            var project = DataProvider.Instance.getProject(id);
            navigate(new ProjectView(project));
        }

        public void showProjects(List<Project> projects)
        {
            projects_list.DataSource = projects;
        }

        private void project_list_SelectionChanged(object sender, EventArgs e)
        {
            projects_list.ClearSelection();
        }

        private void projects_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            int row = e.RowIndex;
            if (row >= 0)
            {
                var project = (grid.DataSource as List<Project>)[row];
                presenter_.onProjectClick(project);
            }
        }


        private ProjectsListPresenter presenter_;
    }
}

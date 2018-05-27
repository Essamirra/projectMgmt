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
        private ProjectsListPresenter _presenter;
        public ProjectsListView()
        {
            InitializeComponent();
            _presenter = new ProjectsListPresenter(this);
            _presenter.UpdateProjectsList();
        }

        public void navigateToProject(Project id)
        {
           if(id.id is null)
               navigate(new EditProjectView(id));
            navigate(new ProjectView(id));
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
                _presenter.OnProjectClick(project);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.OnProjectClick(new Project());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projman_client.Views.ViewInterfaces;

namespace projman_client
{
    public partial class EditProjectView : IBaseView, IEditProjectView
    {
        private Project _currentProject;
        private EditProjectPresenter _presenter;
        public EditProjectView(Project project)
        {
            
            
            InitializeComponent();
            _presenter = new EditProjectPresenter(this, project);


        }

        

        private void _saveButton_Click(object sender, EventArgs e)
        {
            _presenter.OnSaveClick(_currentProject);
        }

        public void ShowData(Project project)
        {
            _currentProject = project;
            propertyGrid1.SelectedObject = _currentProject;
            Refresh();
        }

        public void NavigateToProjectView(Project project)
        {
            navigate(new ProjectsListView());
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
           _presenter.OnDiscardClick(_currentProject);
        }
    }
}

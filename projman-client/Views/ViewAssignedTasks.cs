using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projman_client.Presenters;

namespace projman_client.Views
{
    public partial class ViewAssignedTasks : IBaseView
    {
        private ViewAssignedTasksPresenter _presenter;
        public ViewAssignedTasks()
        {
            InitializeComponent();
            _presenter = new ViewAssignedTasksPresenter(this); 
        }

        public void ShowData( List<Task> tasks)
        {
            dataGridView1.DataSource = tasks;
        }

        private void tasks_list_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void tasks_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            int row = e.RowIndex;
            if (row >= 0)
            {
                var task = (grid.DataSource as List<Task>)[row];
                _presenter.onTaskClick(task);
            }
        }

        public void NavigateToCloseTask(Task task)
        {
            navigate(new EditTaskView(task));
        }
    }
}

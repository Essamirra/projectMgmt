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
    public partial class EditTaskView : IBaseView, IEditTaskView
    {
        private EditTaskPresenter _presenter;
        private Task _originalTask;
        private Task _copiedTask;
        
      
        public EditTaskView(Task task)
        {
            InitializeComponent();
            _presenter = new EditTaskPresenter(this, task);
        }

        public void ShowTask(Task task)
        {
            propertyGrid1.SelectedObject = task;
            propertyGrid1.Enabled = false;
            _originalTask = task;
            HideSaveCancel();
            Refresh();
            

        }

        public void ShowTaskInEditMode(Task task)
        {
            _copiedTask = CreateCopy(task);
            _originalTask = task;
            propertyGrid1.SelectedObject = _copiedTask;
            propertyGrid1.Enabled = true;
            UnhideSaveCancel();
            Refresh();

        }

        private Task CreateCopy(Task task)
        {
            return  new Task() { description =  task.description, id = task.id, title = task.title};
        }

        private void HideSaveCancel()
        {
          
            tableLayoutPanel1.RowStyles[2].Height = 0;
           
        }

        private void UnhideSaveCancel()
        {
            tableLayoutPanel1.RowStyles[2].Height = 50;
           
        }

        
        private void _editButton_Click(object sender, EventArgs e)
        {
            _presenter.OnEditTaskClick(_originalTask);
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            _presenter.OnSaveClick(_copiedTask);
        }

        private void _discardButton_Click(object sender, EventArgs e)
        {
            _presenter.OnDiscardClick(_originalTask);
        }
    }
}

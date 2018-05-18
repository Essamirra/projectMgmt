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
    public partial class EditUserView : IBaseView
    {
        public EditUserView(User user)
        {
            InitializeComponent();
            presenter_ = new EditUserPresenter(this, user);
        }

        public void ShowData(User user)
        {
            current_user_ = user;
            property_grid.SelectedObject = user;
            Refresh();
        }

        public void NavigateToUserView(User user)
        {
            back();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            presenter_.OnSaveClick(current_user_);
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            presenter_.OnDiscardClick(current_user_);
        }


        private User current_user_;
        private EditUserPresenter presenter_;
    }
}

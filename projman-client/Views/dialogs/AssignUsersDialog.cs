using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projman_client.Views.dialogs
{
    public partial class AssignUsersDialog : Form
    {
        private List<User> _users;
        public User ChosedUser { get; set; }
        public AssignUsersDialog(List<User> users)
        {
            InitializeComponent();
            listBox1.DataSource = users;
            _users = users;
            listBox1.SelectionMode = SelectionMode.One;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            var chosed = (User) listBox.SelectedItem;
            ChosedUser = chosed;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

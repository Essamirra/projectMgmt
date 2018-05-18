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
    public partial class LoginView : IBaseView
    {
        public LoginView()
        {
            InitializeComponent();
            presenter_ = new LoginPresenter(this);
        }

        public void navigateToDashboard()
        {
            navigate(new DashboardView());
        }

        private void button_LoginClick(object sender, EventArgs e)
        {
            presenter_.login(textbox_login.Text, textbox_password.Text);
        }

        LoginPresenter presenter_;
    }
}

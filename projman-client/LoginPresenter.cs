using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class LoginPresenter
    {
        public LoginPresenter(LoginView view)
        {
            view_ = view;
        }

        public void login(string login, string password)
        {
            DataProvider.Instance.login(login, password);
            view_.navigateToDashboard();
        }

        LoginView view_;
    }
}

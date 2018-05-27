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
            try
            {
                DataProviderFactory.getDataProvider().login(login, password);
                view_.navigateToDashboard();
            }
            catch (Grpc.Core.RpcException e)
            {
                view_.showError("Can not login to server, please try again later");
            }

            
        }

        LoginView view_;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Grpc.Core;

namespace projman_client
{
    class EditUserPresenter
    {
        private User _oldUser;
        public EditUserPresenter(EditUserView view, User user)
        {
            view_ = view;
            _oldUser = user;
            view_.ShowData(user);
        }

        public void OnSaveClick(User user)
        {
            try
            {
                provider_.saveUser(user);
                view_.NavigateToUserView(user);
            }
            catch (Grpc.Core.RpcException e)
            {
                if(e.StatusCode == StatusCode.PermissionDenied)
                    view_.showError("You are not authorized");
                view_.NavigateToUserView(user);
            }
            
        }

        public void OnDiscardClick(User user)
        {
            
            view_.NavigateToUserView(_oldUser);
        }


        private IDataProvider provider_ = DataProviderFactory.getDataProvider();
        private EditUserView view_;
    }
}

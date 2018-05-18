using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class EditUserPresenter
    {
        public EditUserPresenter(EditUserView view, User user)
        {
            view_ = view;
            view_.ShowData(user);
        }

        public void OnSaveClick(User user)
        {
            provider_.saveUser(user);
            view_.NavigateToUserView(user);
        }

        public void OnDiscardClick(User user)
        {
            view_.NavigateToUserView(user);
        }


        private IDataProvider provider_ = DataProviderFactory.getDataProvider();
        private EditUserView view_;
    }
}

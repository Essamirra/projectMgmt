using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace projman_client
{
    public class BaseViewArgs : EventArgs
    {
        public BaseViewArgs(IBaseView view)
        {
            View = view;
        }
        public IBaseView View { get; set; } = null;
    }


    public class IBaseView : UserControl
    {
        public void showError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        protected void navigate(IBaseView view)
        {
            WantOpenView?.Invoke(this, new BaseViewArgs(view));
        }
        public event EventHandler<BaseViewArgs> WantOpenView;
    }


    public class Project
    {
        public string id { get; set; } = "stub_id";
        public string name { get; set; } = "stub_name";
        public string description { get; set; } = "stub_description";
        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = false;
        public DateTime closedWhen { get; set; } = DateTime.Now;
    }


    public enum Role
    {
        ADMIN,
        MANAGER,
        USER
    }

    public class User
    {
        public string id { get; set; } = "stub_id";
        public string firstName { get; set; } = "stub_firstName";
        public string lastName { get; set; } = "stub_lastName";
        public string login { get; set; } = "stub_login";
        public string password { get; set; } = "stub_password";
        public Role role { get; set; } = Role.USER;
    }

    public class Task
    {
        [Browsable(false)]
        public string projectId { get; set; }
        [Browsable(false)]
        public string id { get; set; } = "stub_id";
        
        public string title { get; set; } = "stub_title";
        public string description { get; set; } = "stub_description";
    }

    public class ProjectStatistics
    { };
}

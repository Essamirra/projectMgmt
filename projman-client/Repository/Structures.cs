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
        protected void back()
        {
            WantBack?.Invoke(this, new EventArgs());
        }
       
        public event EventHandler<BaseViewArgs> WantOpenView;
        public event EventHandler<EventArgs> WantBack;
    }


    public class Project
    {
        private Projman.Server.Project.Types.Status _status;

        public long? id { get; set; } = null;
        public string name { get; set; } = "stub_name";
        public string description { get; set; } = "stub_description";
        public DateTime startDate { get; set; }
        public bool isActive { get; set; } = false;
        public DateTime closedWhen { get; set; }
        public DateTime EndDate { get; set; }

        public Projman.Server.Project.Types.Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }


    public enum Role
    {
        ADMIN,
        MANAGER,
        USER
    }

    public class User
    {
        [DisplayName("Id"), ReadOnly(true)]
        public long id { get; set; } = 0;
        [DisplayName("Имя")]
        public string firstName { get; set; } = "stub_firstName";
        [DisplayName("Фамилия")]
        public string lastName { get; set; } = "stub_lastName";
        [DisplayName("Логин")]
        public string login { get; set; } = "stub_login";
        [DisplayName("Пароль")]
        public string password { get; set; } = "stub_password";
        [DisplayName("Роль")]
        public Projman.Server.User.Types.Role role { get; set; } = Projman.Server.User.Types.Role.User;
    }

    public class Task
    {
        
        private DateTime _assignedDate;
        private User _assignedUser;
        private User _createdByUser;
        private Projman.Server.Task.Types.Status _status;
        private DateTime _closeDate;
        private DateTime _createdDate;

        [Browsable(false)]
        public long? projectId { get; set; }
        [Browsable(false)]
        public long id { get; set; } = 0;
        
        public string title { get; set; } = "stub_title";
        public string description { get; set; } = "stub_description";
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Parse("12/12/2018");

       

        public DateTime AssignedDate
        {
            get { return _assignedDate; }
            set { _assignedDate = value; }
        }

        public User AssignedUser
        {
            get { return _assignedUser; }
            set { _assignedUser = value; }
        }

        public User CreatedByUser
        {
            get { return _createdByUser; }
            set { _createdByUser = value; }
        }

        public Projman.Server.Task.Types.Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime CloseDate
        {
            get { return _closeDate; }
            set { _closeDate = value; }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
    }

    public class ProjectStatistics
    { };
}

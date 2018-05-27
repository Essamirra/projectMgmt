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
        [DisplayName("Id"), ReadOnly(true)]
        public long? id { get; set; } = null;
        [DisplayName("Название")]
        public string name { get; set; } = "stub_name";
        [DisplayName("Описание")]
        public string description { get; set; } = "stub_description";
        [DisplayName("Начало")]
        public DateTime startDate { get; set; }
        [DisplayName("Активна")]
        public bool isActive { get; set; } = false;
        [DisplayName("Дата закрытия"), ReadOnly(true)]
        public DateTime closedWhen { get; set; }
        [DisplayName("Конец")]
        public DateTime EndDate { get; set; }

        [DisplayName("Статус")]
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

        public override string ToString()
        {
            return firstName + " " + lastName + " {id = " + id + "}";
        }
    }

    public class Task
    {
        
        private DateTime _assignedDate;
        private User _assignedUser;
        private User _createdByUser;
        private Projman.Server.Task.Types.Status _status;
        private DateTime _closeDate;
        private DateTime _createdDate;

        [ReadOnly(true)]
        public long? projectId { get; set; }
        [ReadOnly(true)]
        public long id { get; set; } = 0;
        
        public string title { get; set; } = "stub_title";
        public string description { get; set; } = "stub_description";
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Parse("12/12/2018");


        [DisplayName("Дата назначения"), ReadOnly(true)]
        public DateTime AssignedDate
        {
            get { return _assignedDate; }
            set { _assignedDate = value; }
        }
        [DisplayName("Исполнитель"), ReadOnly(true)]
        public User AssignedUser
        {
            get { return _assignedUser; }
            set { _assignedUser = value; }
        }
        [DisplayName("Создана"), ReadOnly(true)]
        public User CreatedByUser
        {
            get { return _createdByUser; }
            set { _createdByUser = value; }
        }
        [DisplayName("Статус"), ReadOnly(true)]
        public Projman.Server.Task.Types.Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
        [DisplayName("Закрыта"), ReadOnly(true)]
        public DateTime CloseDate
        {
            get { return _closeDate; }
            set { _closeDate = value; }
        }
        [DisplayName("Дата создания"), ReadOnly(true)]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
    }

    public class ProjectStatistics
    { };
}

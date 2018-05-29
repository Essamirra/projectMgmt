using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    
    class FakeDataProvider : IDataProvider
    {
        private static readonly FakeDataProvider instance = new FakeDataProvider();
        private Dictionary<long?, Project> _projects = new Dictionary<long?, Project>();
        private Dictionary<long, Task> _tasks = new Dictionary<long, Task>();
        public FakeDataProvider()
        {
            var p1 = new Project();
            _projects.Add(p1.id, p1);
            var p2 = new Project(){id = 2};
            var p3 = new Project() { id =3 };
            _projects.Add(p2.id, p2);
            _projects.Add(p3.id, p3);

            var task = new Task() {projectId = p1.id};
            _tasks.Add(task.id, task);
            var task1 = new Task() {id = 2, projectId = p2.id};
            _tasks.Add(task1.id, task1);
            


        }
        public void login(string login, string password)
        {

        }
        public void logout()
        {

        }

        public List<Project> getProjects()
        {
            return _projects.Values.ToList();
        }

        public Project getProject(long id)
        {
            return _projects[id];
        }

        public void saveProject(Project project)
        {
            _projects[project.id] = project;
        }

        public void getProjectStatistics(long projectId)
        {

        }



        public List<Task> getTasks(long? projectId)
        {
            return _tasks.Values.Where(t => t.projectId == projectId).ToList();
        }

        public Task getTask(long id)
        {
            return _tasks[id];
        }

        public void saveTask(Task task)
        {
            _tasks[task.id] = task;
        }



        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() {firstName = "ADMIN", id = 1, lastName = "Admin", login = "adm", password = "adm", role = Projman.Server.User.Types.Role.Admin});
            users.Add(new User() { firstName = "mngr", id = 2, lastName = "nd", login = "mgr", password = "mgr", role = Projman.Server.User.Types.Role.Manager });
            users.Add(new User() { firstName = "usr", id = 3, lastName = "usr", login = "usr", password = "usr", role = Projman.Server.User.Types.Role.User });
            users.Add(new User());
            users.Add(new User());
            return users;
        }

        public User getUser(long id)
        {
            return new User();
        }

        public User getCurrentUser()
        {
            return new User();
        }

        public List<Task> GetCurrentUserTasks()
        {
            throw new NotImplementedException();
        }

        public void CloseTask(Task originalTask)
        {
            throw new NotImplementedException();
        }

        public void saveUser(User user)
        { }

        public List<User> getUsersForAssign()
        {
            throw new NotImplementedException();
        }

        public void createProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}

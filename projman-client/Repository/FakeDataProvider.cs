using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    
    class DataProvider : IDataProvider
    {
        private static readonly DataProvider instance = new DataProvider();
        List<Project> _projects = new List<Project>() { new Project(), new Project(), new Project() };
       
        public void login(string login, string password)
        {

        }
        public void logout()
        {

        }

        public List<Project> getProjects()
        {
            return _projects;
        }

        public Project getProject(string id)
        {
            return new Project();
        }

        public void saveProject(Project project)
        {
           
        }

        public void getProjectStatistics(string projectId)
        {

        }



        public List<Task> getTasks(string projectId)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task());
            tasks.Add(new Task());
            return tasks;
        }

        public Task getTask(string id)
        {
            return new Task();
        }

        public void saveTask(Task task)
        { }



        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() {firstName = "ADMIN", id = "1", lastName = "Admin", login = "adm", password = "adm", role = Role.ADMIN});
            users.Add(new User() { firstName = "mngr", id = "2", lastName = "nd", login = "mgr", password = "mgr", role = Role.MANAGER });
            users.Add(new User() { firstName = "usr", id = "3", lastName = "usr", login = "usr", password = "usr", role = Role.USER });
            users.Add(new User());
            users.Add(new User());
            return users;
        }

        public User getUser(string id)
        {
            return new User();
        }

        public void saveUser(User user)
        { }
    }
}

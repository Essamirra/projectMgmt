using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projman_client
{
    class DataProvider
    {
        private static readonly DataProvider instance = new DataProvider();
        private DataProvider() { }
        public static DataProvider Instance
        {
            get { return instance; }
        }

        public void login(string login, string password)
        {

        }
        public void logout()
        {

        }



        public List<Project> getProjects()
        {
            List<Project> projects = new List<Project>();
            projects.Add(new Project());
            projects.Add(new Project());
            projects.Add(new Project());
            return projects;
        }

        public Project getProject(string id)
        {
            return new Project();
        }

        public void saveProject(Project project)
        { }

        public void getProjectStatistics(string projectId)
        { }



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
            users.Add(new User());
            users.Add(new User());
            users.Add(new User());
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

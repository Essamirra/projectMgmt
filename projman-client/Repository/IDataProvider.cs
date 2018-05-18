using System.Collections.Generic;

namespace projman_client
{
    
        public interface IDataProvider
        {
            void login(string login, string password);
            void logout();
            List<Project> getProjects();
            Project getProject(string id);
            void saveProject(Project project);
            void getProjectStatistics(string projectId);
            List<Task> getTasks(string projectId);
            Task getTask(string id);
            void saveTask(Task task);
            List<User> getUsers();
            User getUser(string id);
        }

}
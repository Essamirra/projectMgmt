using System.Collections.Generic;

namespace projman_client
{
    
        public interface IDataProvider
        {
            void login(string login, string password);
            void logout();
            List<Project> getProjects();
            Project getProject(long id);
            void saveProject(Project project);
            void getProjectStatistics(long projectId);
            List<Task> getTasks(long? projectId);
            Task getTask(long id);
            void saveTask(Task task);
            List<User> getUsers();
            User getUser(long id);
            void saveUser(User user);

            List<User> getUsersForAssign();
            User getCurrentUser();
            List<Task> GetCurrentUserTasks();
            void CloseTask(Task originalTask);
        }

}
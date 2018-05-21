using System;
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using Projman.Server;

namespace projman_client
{
    class RealDataProvider : IDataProvider
    {
        private Channel _channel;
        private Auth.AuthClient _authClient;
        private Projects.ProjectsClient _projectsClient;
        private Tasks.TasksClient _tasksClient;
        private Users.UsersClient _usersClient;
        private string _currentToken;

        public RealDataProvider()
        {
            _channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            _authClient = new Auth.AuthClient(_channel);
            _projectsClient = new Projects.ProjectsClient(_channel);
            _tasksClient = new Tasks.TasksClient(_channel);
            _usersClient = new Users.UsersClient(_channel);
        }

        public void login(string login, string password)
        {
            var loginResult = _authClient.login(new LoginRequest { Login = login, Password = password });
            // TODO: handle error
            _currentToken = loginResult.Token;
        }

        public void logout()
        {
            var logoutResult = _authClient.logout(new LogoutRequest { Token = _currentToken });
            // TODO: handle error
            _currentToken = null;
        }

        public List<Project> getProjects()
        {
            return _projectsClient.getProjects(new GetProjectsRequest() { Token = _currentToken }).Projects
                .Select(project => new Project {
                    id = project.Id,
                    closedWhen = new DateTime(project.ClosedWhen),
                    description = project.Description,
                    endDate = new DateTime(project.EndDate),
                    isActive = project.Status == Projman.Server.Project.Types.Status.Open,
                    name = project.Name,
                    startDate = new DateTime(project.StartDate) }
                )
                .ToList();
        }

        public Project getProject(long id)
        {
            return null; // TODO
        }

        public void saveProject(Project project)
        {
            // TODO
        }

        public void getProjectStatistics(long projectId)
        {
            // TODO
        }


        public List<Task> getTasks(long projectId)
        {
            return null; // TODO
        }

        public Task getTask(long id)
        {
            return null; // TODO
        }

        public void saveTask(Task task)
        {
            // TODO
        }


        public List<User> getUsers()
        {
            return new List<User>();
        }

        public User getUser(long id)
        {
            return new User();
        }

        public void saveUser(User user)
        {
            // TODO
        }
    }
}
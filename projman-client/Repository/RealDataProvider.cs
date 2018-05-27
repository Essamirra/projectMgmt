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
                    EndDate = new DateTime(project.EndDate),
                    isActive = project.Status == Projman.Server.Project.Types.Status.Open,
                    name = project.Name,
                    startDate = new DateTime(project.StartDate) }
                )
                .ToList();
        }

        public Project getProject(long id)
        {
            throw new NotImplementedException("GET PROJECT");
        }

        public void saveProject(Project project)
        {
          _projectsClient.saveProject(new SaveProjectRequest()
            {
                Project = ConvertToServer(project),
                Token = _currentToken
            });
          
        }

        private Projman.Server.Project ConvertToServer(Project project)
        {
            Projman.Server.Project res = new Projman.Server.Project();
            res.ClosedWhen = ConvertDateToUnix(project.closedWhen);
            res.Description = project.description;
            res.EndDate = ConvertDateToUnix(project.EndDate);
            res.Id = project.id ?? 0;
            res.Name = project.name;
            res.Status = project.Status;
            return res;
        }

        private int ConvertDateToUnix(DateTime time)
        {
           return (Int32)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        public void getProjectStatistics(long projectId)
        {
            throw new NotImplementedException("GET PROJECT STATISTIC");
        }


        public List<Task> getTasks(long? projectId)
        {
            throw new NotImplementedException("GET TASKS");
        }

        public Task getTask(long id)
        {
            throw new NotImplementedException("GET TASK");
        }

        public void saveTask(Task task)
        {
            throw new NotImplementedException("SAVE TASK");
        }


        public List<User> getUsers()
        {
            var res = _usersClient.getUsers(new GetUsersRequest()
            {
                Token = _currentToken
            });
            return res.Users.Select(convertToClient).ToList();
          
        }

        private User convertToClient(Projman.Server.User user)
        {
           User u = new User();
            u.id = user.Id;
            u.firstName = user.FirstName;
            u.lastName = user.LastName;
            u.login = user.Login;
            u.password = user.Password;
            u.role = user.Role;
            return u;
        }

        public User getUser(long id)
        {
            throw new NotImplementedException("GET USER");
        }

        public void saveUser(User user)
        {
            _usersClient.saveUser(new SaveUserRequest()
            {
                Token = _currentToken,
                User = ConvertToServer(user)

            });
        }

        private Projman.Server.User ConvertToServer(User user)
        {
            var u = new Projman.Server.User
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                Id = user.id,
                Login = user.login,
                Password = user.password,
                Role = user.role
            };
            return u;
        }
    }
}
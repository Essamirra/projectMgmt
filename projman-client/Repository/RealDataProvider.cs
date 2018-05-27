using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        private User _currentUser;

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
            _currentUser = ConvertToClient(loginResult.User);
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
                    closedWhen = CheckDate(project.ClosedWhen),
                    description = project.Description,
                    EndDate = CheckDate(project.EndDate),
                    isActive = project.Status == Projman.Server.Project.Types.Status.Open,
                    name = project.Name,
                    startDate = CheckDate(project.StartDate) }
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
            res.ClosedWhen = ConvertDate(project.closedWhen);
            res.Description = project.description;
            res.EndDate = ConvertDate(project.EndDate);
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
           var res = _tasksClient.getTasks(new GetTasksRequest()
            {
                ProjectId = projectId.Value,
                Token = _currentToken

            });
            return res.Tasks.Select(ConvertToClient).ToList();
        }

        private Task ConvertToClient(Projman.Server.Task task)
        {
            var t = new Task();
            t.id = task.Id;
            t.EndDate = CheckDate(task.EndDate);
            t.StartDate = CheckDate(task.StartDate);
            t.projectId = task.ProjectId;
            t.description = task.Description;
            t.title = task.Title;
            t.AssignedUser = getUser(task.AssigneeUserId);
            t.AssignedDate = CheckDate(task.AssignedDate);
            t.CreatedByUser = getUser(task.CreatedByUserId);
            t.Status = task.Status;
            t.CloseDate = CheckDate(task.CloseDate);
            t.CreatedDate = CheckDate(task.CreatedDate);
            return t;
        }

        private DateTime CheckDate(long taskCreatedDate)
        {
            return taskCreatedDate <= ConvertDateToUnix(DateTime.MinValue)
                ? DateTime.MinValue
                : new DateTime(taskCreatedDate);
        }

        public Task getTask(long id)
        {
            throw new NotImplementedException("GET TASK");
        }

        public void saveTask(Task task)
        {
            _tasksClient.saveTask(new SaveTaskRequest()
            {
                Task = ConvertToServer(task),
                Token = _currentToken
            });
        }

        private Projman.Server.Task ConvertToServer(Task task)
        {
            Projman.Server.Task t = new Projman.Server.Task
            {
                AssignedDate = ConvertDate(task.AssignedDate),
                AssigneeUserId = task.AssignedUser?.id ?? 0,
                CloseDate = ConvertDate(task.CloseDate),
                CreatedByUserId = task.CreatedByUser?.id ?? _currentUser.id,
                CreatedDate = ConvertDate(task.CreatedDate),
                Description = task.description,
                ProjectId = task.projectId.Value,
                Status = task.Status,
                Title = task.title,
                Id = task.id,
                StartDate = ConvertDate(task.StartDate),
                EndDate = ConvertDate(task.EndDate)
            };
            return t;
        }

        private long ConvertDate(DateTime taskCloseDate)
        {
            return taskCloseDate == DateTime.MinValue ? 0 : ConvertDateToUnix(taskCloseDate);
        }


        public List<User> getUsers()
        {
            var res = _usersClient.getUsers(new GetUsersRequest()
            {
                Token = _currentToken
            });
            return res.Users.Select(ConvertToClient).ToList();
          
        }

        private User ConvertToClient(Projman.Server.User user)
        {
            User u = new User
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                login = user.Login,
                password = user.Password,
                role = user.Role
            };
            return u;
        }

        public User getUser(long id)
        {
            return getUsers().FirstOrDefault(s => s.id == id);
        }

        public void saveUser(User user)
        {
            _usersClient.saveUser(new SaveUserRequest()
            {
                Token = _currentToken,
                User = ConvertToServer(user)

            });
        }

        public List<User> getUsersForAssign()
        {
            return getUsers().Where(s => s.role == Projman.Server.User.Types.Role.User).ToList();
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
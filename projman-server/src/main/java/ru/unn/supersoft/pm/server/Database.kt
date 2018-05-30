package ru.unn.supersoft.pm.server

import ru.unn.supersoft.pm.api.Project
import ru.unn.supersoft.pm.api.Task
import ru.unn.supersoft.pm.api.User

interface Database {
    //region Projects
    fun getProject(id: Long): Project?

    fun getProjects(): List<Project>
    fun insertProject(project: Project)
    //region Tasks
    fun getTask(id: Long): Task?

    fun getTasks(): List<Task>
    fun getTasksInProject(projectId: Long): List<Task>
    fun getAssignedTasks(assignedTo: Long): List<Task>
    fun insertTask(task: Task)
    //region Sessions
    fun getUserIdForToken(token: String): Long

    fun createSession(token: String, userId: Long)
    fun removeSession(token: String)
    //region Users
    fun insertUser(user: User)

    fun getUsers(): List<User>
    fun getUser(id: Long): User?
    fun getUserByLogin(login: String): User?
}
package ru.unn.supersoft.pm.server

import ru.unn.supersoft.pm.api.Project
import ru.unn.supersoft.pm.api.Task
import ru.unn.supersoft.pm.api.User
import ru.unn.supersoft.pm.server.util.NamedParameterPreparedStatement
import ru.unn.supersoft.pm.server.util.NamedParameterPreparedStatement.createNamedParameterPreparedStatement
import java.sql.Connection
import java.sql.DriverManager
import java.sql.ResultSet
import java.sql.Types

private const val TABLE_PROJECT = "project"
private const val TABLE_TASK = "task"
private const val TABLE_USER = "humans"
private const val TABLE_SESSION = "session"

class ProjManDb(inMemory: Boolean) : Database, AutoCloseable {
    override fun saveProject(project: Project) {
        update(TABLE_PROJECT, "id = :id", "name", "description", "startDate", "endDate", "closedWhen", "status") {
            setLong("id", project.id)
            setString("name", project.name)
            setString("description", project.description)
            setLong("startDate", project.startDate)
            setLong("endDate", project.endDate)
            setLong("closedWhen", project.closedWhen)
            setInt("status", project.status.number)
        }
    }

    override fun saveTask(task: Task) {
        update(TABLE_TASK, "id = :id", "title", "description", "createdDate", "startDate", "endDate", "assignedDate", "closeDate", "projectId", "createdByUserId", "assigneeUserId", "status") {
            setLong("id", task.id)
            setString("title", task.title)
            setString("description", task.description)
            setLong("createdDate", task.createdDate)
            setLong("startDate", task.startDate)
            setLong("endDate", task.endDate)
            setLong("assignedDate", task.assignedDate)
            setLong("closeDate", task.closeDate)
            setLong("projectId", task.projectId)
            setLong("createdByUserId", task.createdByUserId)
            setLong("assigneeUserId", task.assigneeUserId)
            setInt("status", task.status.number)
        }
    }

    override fun saveUser(user: User) {
        update(TABLE_USER, "id = :id", "firstName", "lastName", "login", "password", "role") {
            setLong("id", user.id)
            setString("firstName", user.firstName)
            setString("lastName", user.lastName)
            setString("login", user.login)
            setString("password", user.password)
            setInt("role", user.role.number)
        }
    }

    private val connection: Connection

    init {
        Class.forName("org.postgresql.Driver")
        val address = "jdbc:postgresql://ec2-46-137-94-97.eu-west-1.compute.amazonaws.com:5432/d6jqq8cufl0h2b?user=sgwtaqesqzfaew&password=2c3d5f7d04014a3e7edb93124aa4a2ce4d1bfdf8fdfea572c40f4a5fc57ac3af"
        // Connect
        val connectionUrl = if (inMemory) "jdbc:sqlite::memory:" else address
        connection = DriverManager.getConnection(connectionUrl)

        // Create tables if not exists
        initTables()
    }

    //region Projects
    override fun getProject(id: Long): Project? {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_PROJECT WHERE id = :id").use { statement ->
            statement.setLong("id", id)
            val resultSet = statement.executeQuery()

            return if (resultSet.next()) {
                parseProject(resultSet)
            } else {
                null
            }
        }
    }

    override fun getProjects(): List<Project> {
        connection.prepareStatement("SELECT * FROM $TABLE_PROJECT").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<Project>()
            while (resultSet.next()) {
                result.add(parseProject(resultSet))
            }
            return result
        }
    }


    override fun insertProject(project: Project) {
        if (project.id > 0)
        insert(TABLE_PROJECT, "id", "name", "description", "startDate", "endDate", "closedWhen", "status") {
             setLong("id", project.id)
            setString("name", project.name)
            setString("description", project.description)
            setLong("startDate", project.startDate)
            setLong("endDate", project.endDate)
            setLong("closedWhen", project.closedWhen)
            setInt("status", project.status.number)
        }
        else
            insert(TABLE_PROJECT, "name", "description", "startDate", "endDate", "closedWhen", "status") {
                setString("name", project.name)
                setString("description", project.description)
                setLong("startDate", project.startDate)
                setLong("endDate", project.endDate)
                setLong("closedWhen", project.closedWhen)
                setInt("status", project.status.number)
            }

    }
    //endregion

    //region Tasks
    override fun getTask(id: Long): Task? {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_TASK WHERE id = :id").use { statement ->
            statement.setLong("id", id)
            val resultSet = statement.executeQuery()

            return if (resultSet.next()) {
                parseTask(resultSet)
            } else {
                null
            }
        }
    }

    override fun getTasks(): List<Task> {
        connection.prepareStatement("SELECT * FROM $TABLE_TASK").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<Task>()
            while (resultSet.next()) {
                result.add(parseTask(resultSet))
            }
            return result
        }
    }

    override fun getTasksInProject(projectId: Long): List<Task> {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_TASK WHERE projectId = cast(:projectId as varchar)").use { statement ->
            statement.setLong("projectId", projectId)

            val resultSet = statement.executeQuery()
            val result = mutableListOf<Task>()
            while (resultSet.next()) {
                result.add(parseTask(resultSet))
            }
            return result
        }
    }

    override fun getAssignedTasks(assignedTo: Long): List<Task> {
        createNamedParameterPreparedStatement(connection,
                "SELECT * FROM $TABLE_TASK WHERE assigneeUserId = cast (:assignedTo as varchar) AND status = ${Task.Status.ASSIGNED_VALUE}"
        ).use { statement ->
            statement.setLong("assignedTo", assignedTo)

            val resultSet = statement.executeQuery()
            val result = mutableListOf<Task>()
            while (resultSet.next()) {
                result.add(parseTask(resultSet))
            }
            return result
        }
    }

    override fun insertTask(task: Task) {
        if (task.id > 0)
        insert(TABLE_TASK, "id", "title", "description", "createdDate", "startDate", "endDate", "assignedDate", "closeDate", "projectId", "createdByUserId", "assigneeUserId", "status") {
            setLong("id", task.id)
            setString("title", task.title)
            setString("description", task.description)
            setLong("createdDate", task.createdDate)
            setLong("startDate", task.startDate)
            setLong("endDate", task.endDate)
            setLong("assignedDate", task.assignedDate)
            setLong("closeDate", task.closeDate)
            setLong("projectId", task.projectId)
            setLong("createdByUserId", task.createdByUserId)
            setLong("assigneeUserId", task.assigneeUserId)
            setInt("status", task.status.number)
        }
        else
            insert(TABLE_TASK, "title", "description", "createdDate", "startDate", "endDate", "assignedDate", "closeDate", "projectId", "createdByUserId", "assigneeUserId", "status") {

                setString("title", task.title)
                setString("description", task.description)
                setLong("createdDate", task.createdDate)
                setLong("startDate", task.startDate)
                setLong("endDate", task.endDate)
                setLong("assignedDate", task.assignedDate)
                setLong("closeDate", task.closeDate)
                setLong("projectId", task.projectId)
                setLong("createdByUserId", task.createdByUserId)
                setLong("assigneeUserId", task.assigneeUserId)
                setInt("status", task.status.number)
            }
    }
    //endregion

    //region Sessions
    override fun getUserIdForToken(token: String): Long {
        createNamedParameterPreparedStatement(connection, "SELECT userId FROM $TABLE_SESSION WHERE token = :token").use { statement ->
            statement.setString("token", token)
            val resultSet = statement.executeQuery()

            return if (resultSet.next()) {
                resultSet.getLong("userId")
            } else {
                0
            }
        }
    }

    override fun createSession(token: String, userId: Long) {
        insert(TABLE_SESSION, "token", "userId") {
            setString("token", token)
            setLong("userId", userId)
        }
    }

    override fun removeSession(token: String) {
        createNamedParameterPreparedStatement(connection, "DELETE FROM $TABLE_SESSION WHERE token = :token").use { statement ->
            statement.execute()
        }
    }
    //endregion

    //region Users
    override fun insertUser(user: User) {
        if (user.id > 0)
        insert(TABLE_USER, "id", "firstName", "lastName", "login", "password", "role") {
            setLong("id", user.id)
            setString("firstName", user.firstName)
            setString("lastName", user.lastName)
            setString("login", user.login)
            setString("password", user.password)
            setInt("role", user.role.number)
        }
        else
            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
                setString("firstName", user.firstName)
                setString("lastName", user.lastName)
                setString("login", user.login)
                setString("password", user.password)
                setInt("role", user.role.number)
            }
    }

    override fun getUsers(): List<User> {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_USER").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<User>()
            while (resultSet.next()) {
                result.add(parseUser(resultSet))
            }
            return result
        }
    }

    override fun getUser(id: Long): User? {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_USER WHERE id = :id").use { statement ->
            statement.setLong("id", id)
            val resultSet = statement.executeQuery()
            return if (resultSet.next()) parseUser(resultSet) else null
        }
    }

    override fun getUserByLogin(login: String): User? {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_USER WHERE login = :login").use { statement ->
            statement.setString("login", login)
            val resultSet = statement.executeQuery()
            return if (resultSet.next()) parseUser(resultSet, withPassword = true) else null
        }
    }
    //endregion

    override fun close() {
        connection.close()
    }

    private fun initTables() {
        connection.createStatement().use { statement ->
            fun createTable(name: String, vararg fields: Pair<String, String>) {
                val s = "CREATE TABLE IF NOT EXISTS $name (${fields.joinToString { it.first + " " + it.second }})"
                println(s)
                statement.execute(s)
            }

            createTable(TABLE_PROJECT,
                    "id" to "SERIAL PRIMARY KEY",
                    "name" to "TEXT",
                    "description" to "TEXT",
                    "startDate" to "INTEGER",
                    "endDate" to "INTEGER",
                    "closedWhen" to "INTEGER",
                    "status" to "INTEGER"
            )
            createTable(TABLE_SESSION,
                    "token" to "SERIAL PRIMARY KEY",
                    "userId" to "INTEGER"
            )

            createTable(TABLE_TASK,
                    "id" to "SERIAL PRIMARY KEY",
                    "title" to "TEXT",
                    "description" to "TEXT",
                    "createdDate" to "INTEGER",
                    "startDate" to "INTEGER",
                    "endDate" to "INTEGER",
                    "assignedDate" to "INTEGER",
                    "closeDate" to "INTEGER",
                    "projectId" to "TEXT",
                    "createdByUserId" to "TEXT",
                    "assigneeUserId" to "TEXT",
                    "status" to "INTEGER"
            )

            createTable(TABLE_USER,
                    "id" to "SERIAL PRIMARY KEY",
                    "firstName" to "TEXT",
                    "lastName" to "TEXT",
                    "login" to "TEXT UNIQUE",
                    "password" to "TEXT",
                    "role" to "INTEGER"
            )

//            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
//                setString("firstName", "admin")
//                setString("lastName", "admin")
//                setString("login", "admin")
//                setString("password", "admin")
//                setInt("role", User.Role.ADMIN_VALUE)
//            }
//            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
//                setString("firstName", "manager")
//                setString("lastName", "manager")
//                setString("login", "manager")
//                setString("password", "manager")
//                setInt("role", User.Role.MANAGER_VALUE)
//            }
//            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
//                setString("firstName", "worker")
//                setString("lastName", "worker")
//                setString("login", "worker")
//                setString("password", "worker")
//                setInt("role", User.Role.USER_VALUE)
//            }
//
//            insert(TABLE_PROJECT, "name", "description", "startDate", "endDate", "closedWhen", "status") {
//                setString("name", "AAA")
//                setString("description", "BBB")
//                setLong("startDate", 100500)
//                setLong("endDate", 200400)
//                setLong("closedWhen", 500600)
//                setInt("status", Project.Status.OPEN_VALUE)
//            }
        }
    }

    private fun insert(table: String, vararg fields: String, init: NamedParameterPreparedStatement.() -> Unit) {
        val s = "INSERT INTO $table (${fields.joinToString()}) VALUES (${fields.joinToString { ":$it" }})"
        println(s)
        createNamedParameterPreparedStatement(connection,
                s
        ).use { statement ->
            init(statement)
            statement.executeUpdate()
        }
    }

    private fun update(table: String, where: String, vararg fields: String, init: NamedParameterPreparedStatement.() -> Unit) {
        val s = "UPDATE $table SET ${fields.joinToString { "$it = :$it" }} WHERE $where"
        createNamedParameterPreparedStatement(connection,
                s
        ).use { statement ->
            init(statement)
            System.out.println(statement);
            statement.executeUpdate()
        }
    }

    private fun parseProject(resultSet: ResultSet): Project {
        return Project.newBuilder().apply {
            id = resultSet.getLong("id")
            name = resultSet.getString("name")
            description = resultSet.getString("description")
            startDate = resultSet.getLong("startDate")
            endDate = resultSet.getLong("endDate")
            closedWhen = resultSet.getLong("closedWhen")
            status = Project.Status.forNumber(resultSet.getInt("status"))
        }.build()
    }

    private fun parseTask(resultSet: ResultSet): Task {
        return Task.newBuilder().apply {
            id = resultSet.getLong("id")
            title = resultSet.getString("title")
            description = resultSet.getString("description")
            createdDate = resultSet.getLong("createdDate")
            startDate = resultSet.getLong("startDate")
            endDate = resultSet.getLong("endDate")
            assignedDate = resultSet.getLong("assignedDate")
            closeDate = resultSet.getLong("closeDate")
            projectId = resultSet.getLong("projectId")
            createdByUserId = resultSet.getLong("createdByUserId")
            assigneeUserId = resultSet.getLong("assigneeUserId")
            status = Task.Status.forNumber(resultSet.getInt("status"))
        }.build()
    }

    private fun parseUser(resultSet: ResultSet, withPassword: Boolean = false): User {
        return User.newBuilder().apply {
            id = resultSet.getLong("id")
            firstName = resultSet.getString("firstName")
            lastName = resultSet.getString("lastName")
            login = resultSet.getString("login")
            password = resultSet.getString("password")
            role = User.Role.forNumber(resultSet.getInt("role"))
        }.build()
    }
}

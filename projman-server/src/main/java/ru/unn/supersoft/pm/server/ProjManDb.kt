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

private const val TABLE_PROJECT = "Project"
private val TABLE_PROJECT_FIELDS = mapOf(
        "id" to "INTEGER PRIMARY KEY AUTOINCREMENT",
        "name" to "STRING",
        "description" to "STRING",
        "startDate" to "INTEGER",
        "endDate" to "INTEGER",
        "closedWhen" to "INTEGER",
        "status" to "INTEGER"
)
private const val TABLE_TASK = "Task"
private const val TABLE_USER = "User"
private const val TABLE_SESSION = "Session"

class ProjManDb(inMemory: Boolean) : AutoCloseable {
    private val connection: Connection

    init {
        // Check for sqlite loaded
        Class.forName("org.sqlite.JDBC")

        // Connect
        val connectionUrl = if (inMemory) "jdbc:sqlite::memory:" else "jdbc:sqlite:main.db"
        connection = DriverManager.getConnection(connectionUrl)

        // Create tables if not exists
        initTables()
    }

    //region Projects
    fun getProject(id: Long): Project? {
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

    fun getProjects(): List<Project> {
        connection.prepareStatement("SELECT * FROM $TABLE_PROJECT").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<Project>()
            while (resultSet.next()) {
                result.add(parseProject(resultSet))
            }
            return result
        }
    }


    fun insertProject(project: Project) {
        insert(TABLE_PROJECT, "id", "name", "description", "startDate", "endDate", "closedWhen", "status") {
            if (project.id > 0) setLong("id", project.id) else setNull("id", Types.NULL)
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
    fun getTask(id: Long): Task? {
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

    fun getTasks(): List<Task> {
        connection.prepareStatement("SELECT * FROM $TABLE_TASK").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<Task>()
            while (resultSet.next()) {
                result.add(parseTask(resultSet))
            }
            return result
        }
    }

    fun getTasksInProject(projectId: Long): List<Task> {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_TASK WHERE projectId = :projectId").use { statement ->
            statement.setLong("projectId", projectId)

            val resultSet = statement.executeQuery()
            val result = mutableListOf<Task>()
            while (resultSet.next()) {
                result.add(parseTask(resultSet))
            }
            return result
        }
    }

    fun getAssignedTasks(assignedTo: Long): List<Task> {
        createNamedParameterPreparedStatement(connection,
                "SELECT * FROM $TABLE_TASK WHERE assigneeUserId = :assignedTo AND status = ${Task.Status.ASSIGNED_VALUE}"
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

    fun insertTask(task: Task) {
        insert(TABLE_TASK, "id", "title", "description", "createdDate", "startDate", "endDate", "assignedDate", "closeDate", "projectId", "createdByUserId", "assigneeUserId", "status") {
            if (task.id > 0) setLong("id", task.id) else setNull("id", Types.NULL)
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
    fun getUserIdForToken(token: String): Long {
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

    fun createSession(token: String, userId: Long) {
        insert(TABLE_SESSION, "token", "userId") {
            setString("token", token)
            setLong("userId", userId)
        }
    }

    fun removeSession(token: String) {
        createNamedParameterPreparedStatement(connection, "DELETE FROM $TABLE_SESSION WHERE token = :token").use { statement ->
            statement.execute()
        }
    }
    //endregion

    //region Users
    fun insertUser(user: User) {
        insert(TABLE_USER, "id", "firstName", "lastName", "login", "password", "role") {
            if (user.id > 0) setLong("id", user.id) else setNull("id", Types.NULL)
            setString("firstName", user.firstName)
            setString("lastName", user.lastName)
            setString("login", user.login)
            setString("password", user.password)
            setInt("role", user.role.number)
        }
    }

    fun getUsers(): List<User> {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_USER").use { statement ->
            val resultSet = statement.executeQuery()
            val result = mutableListOf<User>()
            while (resultSet.next()) {
                result.add(parseUser(resultSet))
            }
            return result
        }
    }

    fun getUser(id: Long): User? {
        createNamedParameterPreparedStatement(connection, "SELECT * FROM $TABLE_USER WHERE id = :id").use { statement ->
            statement.setLong("id", id)
            val resultSet = statement.executeQuery()
            return if (resultSet.next()) parseUser(resultSet) else null
        }
    }

    fun getUserByLogin(login: String): User? {
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
                statement.execute("CREATE TABLE IF NOT EXISTS $name (${fields.joinToString { it.first + " " + it.second }})")
            }

            createTable(TABLE_PROJECT,
                    "id" to "INTEGER PRIMARY KEY AUTOINCREMENT",
                    "name" to "STRING",
                    "description" to "STRING",
                    "startDate" to "INTEGER",
                    "endDate" to "INTEGER",
                    "closedWhen" to "INTEGER",
                    "status" to "INTEGER"
            )
            createTable(TABLE_SESSION,
                    "token" to "STRING PRIMARY KEY",
                    "userId" to "INTEGER"
            )

            createTable(TABLE_TASK,
                    "id" to "INTEGER PRIMARY KEY AUTOINCREMENT",
                    "title" to "STRING",
                    "description" to "STRING",
                    "createdDate" to "INTEGER",
                    "startDate" to "INTEGER",
                    "endDate" to "INTEGER",
                    "assignedDate" to "INTEGER",
                    "closeDate" to "INTEGER",
                    "projectId" to "STRING",
                    "createdByUserId" to "STRING",
                    "assigneeUserId" to "STRING",
                    "status" to "INTEGER"
            )

            createTable(TABLE_USER,
                    "id" to "INTEGER PRIMARY KEY AUTOINCREMENT",
                    "firstName" to "STRING",
                    "lastName" to "STRING",
                    "login" to "STRING UNIQUE",
                    "password" to "STRING",
                    "role" to "INTEGER"
            )

            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
                setString("firstName", "admin")
                setString("lastName", "admin")
                setString("login", "admin")
                setString("password", "admin")
                setInt("role", User.Role.ADMIN_VALUE)
            }
            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
                setString("firstName", "manager")
                setString("lastName", "manager")
                setString("login", "manager")
                setString("password", "manager")
                setInt("role", User.Role.MANAGER_VALUE)
            }
            insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
                setString("firstName", "worker")
                setString("lastName", "worker")
                setString("login", "worker")
                setString("password", "worker")
                setInt("role", User.Role.ADMIN_VALUE)
            }

            insert(TABLE_PROJECT, "name", "description", "startDate", "endDate", "closedWhen", "status") {
                setString("name", "AAA")
                setString("description", "BBB")
                setLong("startDate", 100500)
                setLong("endDate", 200400)
                setLong("closedWhen", 500600)
                setInt("status", Project.Status.OPEN_VALUE)
            }
        }
    }

    private fun insert(table: String, vararg fields: String, init: NamedParameterPreparedStatement.() -> Unit) {
        createNamedParameterPreparedStatement(connection,
                "INSERT OR REPLACE INTO $table (${fields.joinToString()}) VALUES (${fields.joinToString { ":$it" }})"
        ).use { statement ->
            init(statement)
            statement.executeUpdate()
        }
    }

    private fun update(table: String, where: String, vararg fields: String, init: NamedParameterPreparedStatement.() -> Unit) {
        createNamedParameterPreparedStatement(connection,
                "UPDATE $table SET (${fields.joinToString { "$it = :$it" }}) WHERE $where"
        ).use { statement ->
            init(statement)
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

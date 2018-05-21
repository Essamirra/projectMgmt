package ru.unn.supersoft.pm.server

import ru.unn.supersoft.pm.api.Project
import ru.unn.supersoft.pm.api.User
import ru.unn.supersoft.pm.server.model.Session
import ru.unn.supersoft.pm.server.util.NamedParameterPreparedStatement
import ru.unn.supersoft.pm.server.util.NamedParameterPreparedStatement.createNamedParameterPreparedStatement
import java.sql.Connection
import java.sql.DriverManager
import java.sql.ResultSet

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
        insert(TABLE_PROJECT, "name", "description", "startDate", "endDate", "closedWhen", "status") {
            setString("name", project.name)
            setString("description", project.description)
            setLong("startDate", project.startDate)
            setLong("endDate", project.endDate)
            setLong("closedWhen", project.closedWhen)
            setInt("status", project.status.number)
        }
    }

    fun updateProject(project: Project) {
        update(TABLE_PROJECT, "id = :id", "name", "description", "startDate", "endDate", "closedWhen", "status") {
            setString("id", project.id.toString())
            setString("name", project.name)
            setString("description", project.description)
            setLong("startDate", project.startDate)
            setLong("endDate", project.endDate)
            setLong("closedWhen", project.closedWhen)
            setInt("status", project.status.number)
        }
    }

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

    fun insertUser(user: User) {
        insert(TABLE_USER, "firstName", "lastName", "login", "password", "role") {
            setString("firstName", user.firstName)
            setString("lastName", user.lastName)
            setString("login", user.login)
            setString("password", user.password)
            setInt("role", user.role.number)
        }
    }

    fun updateUser(user: User) {
        update(TABLE_USER, "id = :id", "firstName", "lastName", "login", "password", "role") {
            setLong("id", user.id)
            setString("firstName", user.firstName)
            setString("lastName", user.lastName)
            setString("login", user.login)
            setString("password", user.password)
            setInt("role", user.role.number)
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
            return if (resultSet.next()) parseUser(resultSet) else null
        }
    }

    private fun parseSession(resultSet: ResultSet): Session {
        return Session(resultSet.getInt("userId"), resultSet.getString("token"))
    }

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

            createTable("Task",
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
                setString("firstName", "Admin")
                setString("lastName", "Admin")
                setString("login", "admin")
                setString("password", "admin") // TODO hash password
                setInt("role", User.Role.ADMIN.number)
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
                "INSERT INTO $table (${fields.joinToString()}) VALUES (${fields.joinToString { ":$it" }})"
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
    private fun parseUser(resultSet: ResultSet): User {
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

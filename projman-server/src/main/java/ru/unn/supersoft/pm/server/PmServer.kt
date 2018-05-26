package ru.unn.supersoft.pm.server

import io.grpc.Server
import io.grpc.ServerBuilder
import io.grpc.Status
import io.grpc.StatusRuntimeException
import io.grpc.stub.StreamObserver
import ru.unn.supersoft.pm.api.*
import java.util.*
import java.util.logging.Logger

class PmServer {
    companion object {
        private val logger = Logger.getLogger(PmServer::class.java.name)

        @JvmStatic
        fun main(args: Array<String>) {
            val server = PmServer()
            server.start()
            server.blockUntilShutdown()
        }
    }

    private var server: Server? = null

    val db = ProjManDb(true)

    private fun start() {
        val port = 50051
        server = ServerBuilder.forPort(port)
                .addService(AuthImpl())
                .addService(ProjectsImpl())
                .addService(TasksImpl())
                .addService(UsersImpl())
                .build()
                .start()
        logger.info("Server started, listening on $port")
        Runtime.getRuntime().addShutdownHook(Thread {
            System.err.println("*** shutting down gRPC server since JVM is shutting down")
            stop()
            System.err.println("*** server shut down")
        })
    }

    private fun stop() {
        server?.shutdown()
    }

    private fun blockUntilShutdown() {
        server?.awaitTermination()
    }

    private fun User?.checkHasRole(roles: Set<User.Role>,
                                   onSuccess: (User) -> Unit,
                                   onError: (StatusRuntimeException) -> Unit) {
        if (this == null) {
            onError(StatusRuntimeException(Status.PERMISSION_DENIED))
        } else if (roles.contains(role)) {
            onSuccess(this)
        } else {
            onError(StatusRuntimeException(Status.PERMISSION_DENIED))
        }
    }

    private fun getUserByToken(token: String): User? {
        val userId = db.getUserIdForToken(token)
        return if (userId != 0L) db.getUser(userId) else null
    }

    private inner class AuthImpl : AuthGrpc.AuthImplBase() {
        override fun login(request: LoginRequest, responseObserver: StreamObserver<LoginResult>) {
            try {
                val userByLogin = db.getUserByLogin(request.login)
                if (userByLogin == null || userByLogin.password != request.password) { // TODO: password hash
                    responseObserver.onError(StatusRuntimeException(Status.UNAUTHENTICATED.withDescription("Invalid login or password")))
                    return
                }
                val token = UUID.randomUUID().toString()
                db.createSession(token, userByLogin.id) // TODO: handle collisions

                responseObserver.onNext(LoginResult.newBuilder()
                        .setToken(token)
                        .setUser(userByLogin.toBuilder().clearPassword())
                        .build())
                responseObserver.onCompleted()
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.UNAVAILABLE.withDescription(e.message)))
            }
        }

        override fun logout(request: LogoutRequest, responseObserver: StreamObserver<LogoutResult>) {
            try {
                db.removeSession(request.token)
                responseObserver.onNext(LogoutResult.newBuilder().build())
                responseObserver.onCompleted()
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.UNAVAILABLE.withDescription(e.message)))
            }
        }
    }

    private inner class ProjectsImpl : ProjectsGrpc.ProjectsImplBase() {
        override fun getProjects(request: GetProjectsRequest, responseObserver: StreamObserver<GetProjectsResult>) {
            try {
                responseObserver.onNext(GetProjectsResult.newBuilder().addAllProjects(db.getProjects()).build())
                responseObserver.onCompleted()
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.UNAVAILABLE.withDescription(e.message)))
            }
        }

        override fun getProject(request: GetProjectRequest, responseObserver: StreamObserver<GetProjectResult>) {
            try {
                getUserByToken(request.token).checkHasRole(setOf(User.Role.MANAGER, User.Role.ADMIN), {
                    val project = db.getProject(request.id)
                    if (project != null) {
                        responseObserver.onNext(GetProjectResult.newBuilder().setProject(project).build())
                        responseObserver.onCompleted()
                    } else {
                        responseObserver.onError(StatusRuntimeException(Status.NOT_FOUND
                                .withDescription("Project with id = ${request.id} not found")))
                    }
                }, { e ->
                    responseObserver.onError(e)
                })
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }

        override fun saveProject(request: SaveProjectRequest, responseObserver: StreamObserver<SaveProjectResult>) {
            try {
                getUserByToken(request.token).checkHasRole(setOf(User.Role.MANAGER, User.Role.ADMIN), {
                    if (request.project.id == 0L) {
                        db.insertProject(request.project)
                    } else {
                        db.updateProject(request.project)
                    }
                    responseObserver.onNext(SaveProjectResult.getDefaultInstance())
                    responseObserver.onCompleted()
                }, { e ->
                    responseObserver.onError(e)
                })
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }

    }

    private inner class TasksImpl : TasksGrpc.TasksImplBase() {
        override fun getTasks(request: GetTasksRequest, responseObserver: StreamObserver<GetTasksResult>) {
            try {
                val user = getUserByToken(request.token)
                when {
                    user == null -> {
                        responseObserver.onError(StatusRuntimeException(Status.PERMISSION_DENIED))
                    }
                    user.role == User.Role.USER -> {
                        responseObserver.onNext(GetTasksResult.newBuilder().addAllTasks(db.getAssignedTasks(request.projectId, user.id)).build())
                        responseObserver.onCompleted()
                    }
                    else -> {
                        responseObserver.onNext(GetTasksResult.newBuilder().addAllTasks(db.getTasksInProject(request.projectId)).build())
                        responseObserver.onCompleted()
                    }
                }
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.UNAVAILABLE.withDescription(e.message)))
            }
        }

        override fun closeTask(request: CloseTaskRequest, responseObserver: StreamObserver<CloseTaskResult>) {
            try {
                getUserByToken(request.token)?.let {
                    val task = db.getTask(request.taskId)?.toBuilder()?.apply {
                        status = Task.Status.CLOSED
                        closeDate = Date().time
                    }?.build()

                    if (task != null) {
                        db.insertTask(task)
                    }
                    responseObserver.onNext(CloseTaskResult.getDefaultInstance())
                    responseObserver.onCompleted()
                } ?: responseObserver.onError(StatusRuntimeException(Status.PERMISSION_DENIED))

            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }

        override fun saveTask(request: SaveTaskRequest, responseObserver: StreamObserver<SaveTaskResult>) {
            try {
                getUserByToken(request.token).checkHasRole(setOf(User.Role.MANAGER, User.Role.ADMIN), {
                    db.insertTask(request.task)
                    responseObserver.onNext(SaveTaskResult.getDefaultInstance())
                    responseObserver.onCompleted()
                }, { e ->
                    responseObserver.onError(e)
                })
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }
    }

    private inner class UsersImpl : UsersGrpc.UsersImplBase() {
        override fun getUsers(request: GetUsersRequest, responseObserver: StreamObserver<GetUsersResult>) {
            try {
                getUserByToken(request.token).checkHasRole(setOf(User.Role.MANAGER, User.Role.ADMIN), {
                    responseObserver.onNext(GetUsersResult.newBuilder().addAllUsers(db.getUsers()).build())
                    responseObserver.onCompleted()
                }, { e ->
                    responseObserver.onError(e)
                })
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }

        override fun saveUser(request: SaveUserRequest, responseObserver: StreamObserver<SaveUserResult>) {
            try {
                getUserByToken(request.token).checkHasRole(setOf(User.Role.ADMIN), {
                    db.insertUser(request.user)
                    responseObserver.onNext(SaveUserResult.getDefaultInstance())
                    responseObserver.onCompleted()
                }, { e ->
                    responseObserver.onError(e)
                })
            } catch (e: Exception) {
                responseObserver.onError(StatusRuntimeException(Status.INTERNAL.withDescription(e.message)))
            }
        }
    }
}

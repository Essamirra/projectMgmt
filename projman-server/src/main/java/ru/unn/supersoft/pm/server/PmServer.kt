package ru.unn.supersoft.pm.server

import io.grpc.Server
import io.grpc.ServerBuilder
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

    private class AuthImpl : AuthGrpc.AuthImplBase() {
        override fun login(request: LoginRequest, responseObserver: StreamObserver<LoginResult>) {
            responseObserver.onNext(LoginResult.newBuilder().setToken("Hello World!").build())
            responseObserver.onCompleted()
        }

        override fun logout(request: LogoutRequest, responseObserver: StreamObserver<LogoutResult>) {
            responseObserver.onNext(LogoutResult.newBuilder().build())
            responseObserver.onCompleted()
        }
    }

    private class ProjectsImpl : ProjectsGrpc.ProjectsImplBase() {
        override fun getProjects(request: GetProjectsRequest, responseObserver: StreamObserver<GetProjectsResult>) {
            responseObserver.onNext(GetProjectsResult.newBuilder().addAllProjects(listOf(
                    Project.newBuilder().apply {
                        id = "1"
                        name = "Project 1"
                        description = "smth"
                        startDate = Date().time
                        endDate = Date().time + 100000
                        status = Project.Status.OPEN
                    }.build()
            )).build())
            responseObserver.onCompleted()
        }

        override fun getProject(request: GetProjectRequest, responseObserver: StreamObserver<GetProjectResult>) {
            responseObserver.onNext(GetProjectResult.newBuilder().setProject(
                    Project.newBuilder().apply {
                        id = "1"
                        name = "Project 5"
                        description = "smth"
                        startDate = Date().time
                        endDate = Date().time + 100000
                        status = Project.Status.OPEN
                    }.build()
            ).build())
            responseObserver.onCompleted()
        }

        override fun saveProject(request: SaveProjectRequest, responseObserver: StreamObserver<SaveProjectResult>) {
            responseObserver.onNext(SaveProjectResult.newBuilder().apply {
                project = request.project.toBuilder().setId("555").build()
            }.build())
            responseObserver.onCompleted()
        }
    }

    private class TasksImpl : TasksGrpc.TasksImplBase() {
        override fun getTasks(request: GetTasksRequest, responseObserver: StreamObserver<GetTasksResult>) {
            responseObserver.onNext(GetTasksResult.getDefaultInstance())
            responseObserver.onCompleted()
        }

        override fun getTask(request: GetTaskRequest, responseObserver: StreamObserver<GetTaskResult>) {
            responseObserver.onNext(GetTaskResult.getDefaultInstance())
            responseObserver.onCompleted()
        }

        override fun saveTask(request: SaveTaskRequest, responseObserver: StreamObserver<SaveTaskResult>) {
            responseObserver.onNext(SaveTaskResult.getDefaultInstance())
            responseObserver.onCompleted()
        }
    }

    private class UsersImpl : UsersGrpc.UsersImplBase() {
        override fun getUsers(request: GetUsersRequest, responseObserver: StreamObserver<GetUsersResult>) {
            responseObserver.onNext(GetUsersResult.getDefaultInstance())
            responseObserver.onCompleted()
        }

        override fun getUser(request: GetUserRequest, responseObserver: StreamObserver<GetUserResult>) {
            responseObserver.onNext(GetUserResult.getDefaultInstance())
            responseObserver.onCompleted()
        }

        override fun saveUser(request: SaveUserRequest, responseObserver: StreamObserver<SaveUserResult>) {
            responseObserver.onNext(SaveUserResult.getDefaultInstance())
            responseObserver.onCompleted()
        }
    }
}

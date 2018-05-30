package ru.unn.supersoft.pm.server

import io.grpc.Status
import io.grpc.StatusRuntimeException
import io.grpc.stub.StreamObserver
import ru.unn.supersoft.pm.api.*
import java.util.*

class AuthService(
        private val db: Database
) : AuthGrpc.AuthImplBase() {
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
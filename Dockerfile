# syntax=docker/dockerfile:1

# Comments are provided throughout this file to help you get started.
# If you need more help, visit the Dockerfile reference guide at
# https://docs.docker.com/engine/reference/builder/

################################################################################

# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md

# Create a stage for building the application.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
ARG TARGETARCH

COPY . /source

WORKDIR /source/StudentsApp/StudentsApp

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

# or SHA (e.g., mcr.microsoft.com/dotnet/aspnet@sha256:f3d99f54d504a21d38e4cc2f13ff47d67235efeeb85c109d3d1ff1808b38d034).
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS final
WORKDIR /app

# Copy everything needed to run the app from the "build" stage.
COPY --from=build /app .

# Create a non-privileged user that the app will run under.
# See https://docs.docker.com/develop/develop-images/dockerfile_best-practices/#user
ARG UID=10001
RUN adduser \
    --disabled-password \
    --gecos "" \
    --home "/nonexistent" \
    --shell "/sbin/nologin" \
    --no-create-home \
    --uid "${UID}" \
    appuser
USER appuser

ENTRYPOINT ["dotnet", "StudentsApp.dll"]

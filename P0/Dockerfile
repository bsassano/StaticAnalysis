# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
# Makes a directory if it does not already exist

# Copy csproj and restore as distinct layers
# Copies from outside of the container into the container
# csproj will be copied into our app directory
COPY *.csproj ./
# helps grab existing dependencies
RUN dotnet restore

# Copy everything else and build
COPY *.cs ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "P0.dll"]
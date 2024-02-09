#Get the base image from Microsoft's official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

#Copy CSPROJ file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

#Copy project files and build the project release
COPY . ./
RUN dotnet publish -c Release -o out

#Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ChatBackend.dll"]

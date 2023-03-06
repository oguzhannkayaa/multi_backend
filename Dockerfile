# Start with the official .NET 6 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project files to the container
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build the project
RUN dotnet build -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Start with a fresh image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variables for the Entity Framework Core database connection string
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__MyDbContext=<your_connection_string>

# Expose port 80 to the outside world
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "MultiBackend.dll"]
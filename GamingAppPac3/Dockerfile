# Use official .NET 7 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# Copy all files from repo into the container
COPY . .

# Start the app
ENTRYPOINT ["dotnet", "GamingAppPac3.dll"]

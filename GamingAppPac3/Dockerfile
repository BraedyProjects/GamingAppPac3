# ---- BUILD STAGE ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . ./

# Publish the app to the /out directory
RUN dotnet publish -c Release -o out

# ---- RUNTIME STAGE ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy from build stage
COPY --from=build /app/out ./

# Start the app
ENTRYPOINT ["dotnet", "GamingAppPac3.dll"]

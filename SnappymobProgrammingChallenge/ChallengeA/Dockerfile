# Use the official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy the project files
COPY ChallengeA/*.csproj ./ChallengeA/
RUN dotnet restore ./ChallengeA/ChallengeA.csproj

# Publish the project
COPY ChallengeA/. ./ChallengeA/
RUN dotnet publish ChallengeA/ChallengeA.csproj -c Release -o /app/publish

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app

# Copy the published files
COPY --from=build /app/publish .

# Set the entrypoint to run the application
ENTRYPOINT ["dotnet", "ChallengeA.dll"]

# Ensure the generated file is written to /app/generatedData (shared volume)
VOLUME /app/generatedData

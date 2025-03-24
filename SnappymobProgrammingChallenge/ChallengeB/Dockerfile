# Use the official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy the project files
COPY ChallengeB/*.csproj ./ChallengeB/
RUN dotnet restore ./ChallengeB/ChallengeB.csproj

# Publish the project
COPY ChallengeB/. ./ChallengeB/
RUN dotnet publish ChallengeB/ChallengeB.csproj -c Release -o /app/publish

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app

# Copy the published files
COPY --from=build /app/publish .

# Set the entrypoint to run the application
ENTRYPOINT ["dotnet", "ChallengeB.dll"]

# Ensure the generated file is read from /app/generatedData (shared volume)
VOLUME /app/generatedData

# ===============
# BUILD IMAGE
# ===============
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers

WORKDIR /app/RabbitCommunicationLib
COPY ./RabbitCommunicationLib/*.csproj ./
RUN dotnet restore

WORKDIR /app/MatchDb/MatchEntities/MatchEntities
COPY ./MatchDb/MatchEntities/MatchEntities/*.csproj ./
RUN dotnet restore

WORKDIR /app/MatchDb/Database
COPY ./MatchDb/Database/*.csproj ./
RUN dotnet restore

WORKDIR /app/MatchWriter
COPY ./MatchWriter/*.csproj ./
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY ./RabbitCommunicationLib ./RabbitCommunicationLib
COPY ./MatchDb/Database ./MatchDb/Database
COPY ./MatchDb/MatchEntities ./MatchDb/MatchEntities
COPY ./MatchWriter/ ./MatchWriter

RUN dotnet publish MatchWriter/ -c Release -o out


# ===============
# RUNTIME IMAGE
# ===============
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MatchWriter.dll"]
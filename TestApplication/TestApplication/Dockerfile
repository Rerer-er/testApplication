#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestApplication/TestApplication.csproj", "TestApplication/"]
COPY ["Pact/Pact.csproj", "Pact/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["ActionDB/ActionDB.csproj", "ActionDB/"]
RUN dotnet restore "TestApplication/TestApplication.csproj"
COPY . .
WORKDIR "/src/TestApplication"
RUN dotnet build "TestApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApplication.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/I3Lab.API/I3Lab.API.csproj", "src/API/I3Lab.API/"]
COPY ["src/User/I3Lab.User.Application/I3Lab.Users.Application.csproj", "src/User/I3Lab.User.Application/"]
COPY ["src/User/I3Lab.User.Domain/I3Lab.Users.Domain.csproj", "src/User/I3Lab.User.Domain/"]
COPY ["src/BuildingBlocks/I3Lab.BuildingBlocks.Domain/I3Lab.BuildingBlocks.Domain.csproj", "src/BuildingBlocks/I3Lab.BuildingBlocks.Domain/"]
COPY ["src/User/I3Lab.User.Infrastructure/I3Lab.Users.Infrastructure.csproj", "src/User/I3Lab.User.Infrastructure/"]
RUN dotnet restore "./src/API/I3Lab.API/I3Lab.API.csproj"
COPY . .
WORKDIR "/src/src/API/I3Lab.API"
RUN dotnet build "./I3Lab.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./I3Lab.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "I3Lab.API.dll"]
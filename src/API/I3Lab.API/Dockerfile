# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/I3Lab.API/I3Lab.API.csproj", "src/API/I3Lab.API/"]
COPY ["src/BuildingBlocks/I3Lab.BuildingBlocks.Infrastructure/I3Lab.BuildingBlocks.Infrastructure.csproj", "src/BuildingBlocks/I3Lab.BuildingBlocks.Infrastructure/"]
COPY ["src/BuildingBlocks/I3Lab.BuildingBlocks.Application/I3Lab.BuildingBlocks.Application.csproj", "src/BuildingBlocks/I3Lab.BuildingBlocks.Application/"]
COPY ["src/BuildingBlocks/I3Lab.BuildingBlocks.Domain/I3Lab.BuildingBlocks.Domain.csproj", "src/BuildingBlocks/I3Lab.BuildingBlocks.Domain/"]
COPY ["src/Modules/Administration/I3Lab.Administration.Application/I3Lab.Administration.Application.csproj", "src/Modules/Administration/I3Lab.Administration.Application/"]
COPY ["src/Modules/Doctor/I3Lab.Doctor.IntegrationEvents/I3Lab.Doctors.IntegrationEvents.csproj", "src/Modules/Doctor/I3Lab.Doctor.IntegrationEvents/"]
COPY ["src/Modules/Administration/I3Lab.Administration.Domain/I3Lab.Administration.Domain.csproj", "src/Modules/Administration/I3Lab.Administration.Domain/"]
COPY ["src/Modules/Administration/I3Lab.Administration.IntegrationEvents/I3Lab.Administration.IntegrationEvents.csproj", "src/Modules/Administration/I3Lab.Administration.IntegrationEvents/"]
COPY ["src/Modules/Administration/I3Lab.Administration.Infrastructure/I3Lab.Administration.Infrastructure.csproj", "src/Modules/Administration/I3Lab.Administration.Infrastructure/"]
COPY ["src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Infrastructure/I3Lab.Modules.BlobFailes.Infrastructure.csproj", "src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Infrastructure/"]
COPY ["src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Api/I3Lab.Modules.BlobFailes.Api.csproj", "src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Api/"]
COPY ["src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Application/I3Lab.Modules.BlobFailes.Application.csproj", "src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Application/"]
COPY ["src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Domain/I3Lab.Modules.BlobFailes.Domain.csproj", "src/Modules/BlobFiles/I3Lab.Modules.BlobFailes.Domain/"]
COPY ["src/Modules/Clinic/I3Lab.Clinic.Application/I3Lab.Clinics.Application.csproj", "src/Modules/Clinic/I3Lab.Clinic.Application/"]
COPY ["src/Modules/Clinic/I3Lab.Clinic.Domain/I3Lab.Clinics.Domain.csproj", "src/Modules/Clinic/I3Lab.Clinic.Domain/"]
COPY ["src/Modules/Clinic/I3Lab.Clinic.Infrastructure/I3Lab.Clinics.Infrastructure.csproj", "src/Modules/Clinic/I3Lab.Clinic.Infrastructure/"]
COPY ["src/Modules/Doctor/I3Lab.Doctor.Infrastructure/I3Lab.Doctors.Infrastructure.csproj", "src/Modules/Doctor/I3Lab.Doctor.Infrastructure/"]
COPY ["src/Modules/Doctor/I3Lab.Doctor.Application/I3Lab.Doctors.Application.csproj", "src/Modules/Doctor/I3Lab.Doctor.Application/"]
COPY ["src/Modules/Doctor/I3Lab.Doctor.Domain/I3Lab.Doctors.Domain.csproj", "src/Modules/Doctor/I3Lab.Doctor.Domain/"]
COPY ["src/Modules/Work/I3Lab.Work.Application/I3Lab.Treatments.Application.csproj", "src/Modules/Work/I3Lab.Work.Application/"]
COPY ["src/User/I3Lab.User.IntegrationEvents/I3Lab.Users.IntegrationEvents.csproj", "src/User/I3Lab.User.IntegrationEvents/"]
COPY ["src/Modules/Work/I3Lab.Work.Domain/I3Lab.Treatments.Domain.csproj", "src/Modules/Work/I3Lab.Work.Domain/"]
COPY ["src/Modules/Work/I3Lab.Work.Infrastructure/I3Lab.Treatments.Infrastructure.csproj", "src/Modules/Work/I3Lab.Work.Infrastructure/"]
COPY ["src/User/I3Lab.User.Application/I3Lab.Users.Application.csproj", "src/User/I3Lab.User.Application/"]
COPY ["src/User/I3Lab.User.Domain/I3Lab.Users.Domain.csproj", "src/User/I3Lab.User.Domain/"]
COPY ["src/User/I3Lab.User.Infrastructure/I3Lab.Users.Infrastructure.csproj", "src/User/I3Lab.User.Infrastructure/"]
RUN dotnet restore "./src/API/I3Lab.API/I3Lab.API.csproj"
COPY . .
WORKDIR "/src/src/API/I3Lab.API"
RUN dotnet build "./I3Lab.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./I3Lab.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "I3Lab.API.dll"]
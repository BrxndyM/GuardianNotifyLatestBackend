FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/GuardianNotifyBackend.Web.Host/GuardianNotifyBackend.Web.Host.csproj", "src/GuardianNotifyBackend.Web.Host/"]
COPY ["src/GuardianNotifyBackend.Web.Core/GuardianNotifyBackend.Web.Core.csproj", "src/GuardianNotifyBackend.Web.Core/"]
COPY ["src/GuardianNotifyBackend.Application/GuardianNotifyBackend.Application.csproj", "src/GuardianNotifyBackend.Application/"]
COPY ["src/GuardianNotifyBackend.Core/GuardianNotifyBackend.Core.csproj", "src/GuardianNotifyBackend.Core/"]
COPY ["src/GuardianNotifyBackend.EntityFrameworkCore/GuardianNotifyBackend.EntityFrameworkCore.csproj", "src/GuardianNotifyBackend.EntityFrameworkCore/"]
WORKDIR "/src/src/GuardianNotifyBackend.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/GuardianNotifyBackend.Web.Host", "src/GuardianNotifyBackend.Web.Host"]
COPY ["src/GuardianNotifyBackend.Web.Core", "src/GuardianNotifyBackend.Web.Core"]
COPY ["src/GuardianNotifyBackend.Application", "src/GuardianNotifyBackend.Application"]
COPY ["src/GuardianNotifyBackend.Core", "src/GuardianNotifyBackend.Core"]
COPY ["src/GuardianNotifyBackend.EntityFrameworkCore", "src/GuardianNotifyBackend.EntityFrameworkCore"]
WORKDIR "/src/src/GuardianNotifyBackend.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "GuardianNotifyBackend.Web.Host.dll"]

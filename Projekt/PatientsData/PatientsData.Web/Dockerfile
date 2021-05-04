
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PatientsData.Web/PatientsData.Web.csproj", "PatientsData.Web/"]
COPY ["PatientsData.Infrastructure/PatientsData.Infrastructure.csproj", "PatientsData.Infrastructure/"]
COPY ["PatientsData.Domain/PatientsData.Domain.csproj", "PatientsData.Domain/"]
RUN dotnet restore "PatientsData.Web/PatientsData.Web.csproj"
COPY . .
WORKDIR "/src/PatientsData.Web"
RUN dotnet build "PatientsData.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientsData.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientsData.Web.dll"]
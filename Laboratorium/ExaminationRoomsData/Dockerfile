FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ExaminationRoomsData.Web/ExaminationRoomsData.Web.csproj", "ExaminationRoomsData.Web/"]
COPY ["ExaminationRoomsData.Infrastructure/ExaminationRoomsData.Infrastructure.csproj", "ExaminationRoomsData.Infrastructure/"]
COPY ["ExaminationRoomsData.Domain/ExaminationRoomsData.Domain.csproj", "ExaminationRoomsData.Domain/"]
RUN dotnet restore "ExaminationRoomsData.Web/ExaminationRoomsData.Web.csproj"
COPY . .
WORKDIR "/src/ExaminationRoomsData.Web"
RUN dotnet build "ExaminationRoomsData.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExaminationRoomsData.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExaminationRoomsData.Web.dll"]
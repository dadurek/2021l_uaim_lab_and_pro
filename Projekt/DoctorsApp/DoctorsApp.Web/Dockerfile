FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DoctorsApp.Web/DoctorsApp.Web.csproj", "DoctorsApp.Web/"]
RUN dotnet restore "DoctorsApp.Web/DoctorsApp.Web.csproj"
COPY . .
WORKDIR "/src/DoctorsApp.Web"
RUN dotnet build "DoctorsApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorsApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorsApp.Web.dll"]
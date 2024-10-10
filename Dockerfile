FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIROMENT Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["MnogoLibAPI/MnogoLibAPI.csproj", "MnogoLibAPI/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "MnogoLibAPI/MnogoLibAPI.csproj"

COPY . .
FROM build as publish
RUN dotnet publish "MnogoLibAPI/MnogoLibAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MnogoLibAPI.dll"]
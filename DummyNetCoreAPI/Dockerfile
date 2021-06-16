FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DummyNetCoreAPI/DummyNetCoreAPI.csproj", "DummyNetCoreAPI/"]
RUN dotnet restore "DummyNetCoreAPI/DummyNetCoreAPI.csproj"
COPY . .
WORKDIR "/src/DummyNetCoreAPI"
RUN dotnet build "DummyNetCoreAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DummyNetCoreAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DummyNetCoreAPI.dll"]
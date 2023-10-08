FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab 01.csproj", "./"]
RUN dotnet restore "Lab 01.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Lab 01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab 01.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab 01.dll"]

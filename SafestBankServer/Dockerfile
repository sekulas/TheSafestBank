FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/SafestBankServer.Application/SafestBankServer.Application.csproj", "SafestBankServer.Application/"]
COPY ["src/SafestBankServer.Infrastructure/SafestBankServer.Infrastructure.csproj", "SafestBankServer.Infrastructure/"]
COPY ["src/SafestBankServer.Core/SafestBankServer.Core.csproj", "SafestBankServer.Core/"]
COPY ["src/SafestBankServer.Web/SafestBankServer.Web.csproj", "SafestBankServer.Web/"]

RUN dotnet restore "SafestBankServer.Web/SafestBankServer.Web.csproj"


WORKDIR "/src/SafestBankServer.Web/"
COPY . .

RUN dotnet build "SafestBankServer.Web.csproj" -c Release -o /app/build --no-restore


FROM build AS publish
RUN dotnet publish "SafestBankServer.Web.csproj" -c Release -o /app/publish --no-restore

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
COPY "src/SafestBankServer.Web/appsettings.json" .
RUN rm -rf /app/src
ENTRYPOINT ["dotnet", "SafestBankServer.Web.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["src/MyWebApp.csproj", "MyWebApp/"]
#RUN dotnet restore "./MyWebApp/./MyWebApp.csproj"
#COPY . .
#WORKDIR "/src/MyWebApp"
#RUN dotnet build "./MyWebApp.csproj" -c %BUILD_CONFIGURATION% -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./MyWebApp.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MyWebApp.dll"]

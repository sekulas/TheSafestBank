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

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
RUN rm -rf /app/src
ENTRYPOINT ["dotnet", "SafestBankServer.Web.dll"]
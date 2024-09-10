FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./SPAR.Api/SPAR.Api.csproj", "./"]
COPY ["./SPAR.Application/SPAR.Application.csproj", "./"]
COPY ["./SPAR.Common/SPAR.Common.csproj", "./"]
COPY ["./SPAR.Domain/SPAR.Domain.csproj", "./"]
COPY ["./SPAR.Infrastructure/SPAR.Infrastructure.csproj", "./"]
COPY ["./SPAR.Repositories/SPAR.Repositories.csproj", "./"]
COPY Directory.Build.props ./
RUN dotnet restore "SPAR.Api.csproj"
COPY . .
WORKDIR "/src/SPAR.Api"
RUN dotnet build "SPAR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SPAR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS="https://+:443"
ENV ASPNETCORE_HTTPS_PORT=5001
ENV ASPNETCORE_ENVIRONMENT=Docker
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Qwerty123!"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/localhost.pfx

ENTRYPOINT [ "dotnet", "SPAR.Api.dll" ]
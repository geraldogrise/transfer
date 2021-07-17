FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app
EXPOSE 44313
EXPOSE 8090

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY ./*.sln ./
COPY ["/1 - Services/BR.Rodobens.Migration.Api.Service/*.csproj", "1 - Services/BR.Rodobens.Migration.Api.Service/"]
COPY ["/2 - Application/BR.Rodobens.Migration.Application/*.csproj", "2 - Application/BR.Rodobens.Migration.Application/"]
COPY ["/3 - Domain/BR.Rodobens.Migration.Domain/*.csproj", "3 - Domain/BR.Rodobens.Migration.Domain/"]
COPY ["/4 - Infra/4.1 - Data/BR.Rodobens.Migration.Infra.Data/*.csproj", "4 - Infra/4.1 - Data/BR.Rodobens.Migration.Infra.Data/"]
COPY ["/4 - Infra/4.2 - CrossCutting/BR.Rodobens.Migration.Infra.CrossCutting/*.csproj", "4 - Infra/4.2 - CrossCutting/BR.Rodobens.Migration.Infra.CrossCutting/"]
COPY ["/4 - Infra/4.2 - CrossCutting/BR.Rodobens.Migration.Infra.CrossCutting.Ioc/*.csproj", "4 - Infra/4.2 - CrossCutting/BR.Rodobens.Migration.Infra.CrossCutting.Ioc/"]
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out 
FROM base AS final
WORKDIR /app 
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BR.Rodobens.Migration.Api.Service.dll"]

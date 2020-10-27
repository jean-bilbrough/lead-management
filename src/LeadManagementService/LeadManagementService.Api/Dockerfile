FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "LeadManagementService.Api/LeadManagementService.Api.csproj"
RUN dotnet build "LeadManagementService.Api/LeadManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LeadManagementService.Api/LeadManagementService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeadManagementService.Api.dll"]
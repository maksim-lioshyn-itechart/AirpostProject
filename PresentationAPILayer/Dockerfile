#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PresentationAPILayer/PresentationAPILayer.csproj", "PresentationAPILayer/"]
RUN dotnet restore "PresentationAPILayer/PresentationAPILayer.csproj"
COPY . .
WORKDIR "/src/PresentationAPILayer"
RUN dotnet build "PresentationAPILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PresentationAPILayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresentationAPILayer.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["../TesteIngaia2/TesteIngaia2.csproj", "../TesteIngaia2/"]
RUN dotnet restore "../TesteIngaia2/TesteIngaia2.csproj"
COPY . .
WORKDIR "/src/../TesteIngaia2"
RUN dotnet build "TesteIngaia2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteIngaia2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteIngaia2.dll"]
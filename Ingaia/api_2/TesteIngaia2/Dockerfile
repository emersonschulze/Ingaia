FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["TesteIngaia2.csproj", "api_2/TesteIngaia2/"]
RUN dotnet restore "api_2/TesteIngaia2/TesteIngaia2.csproj"
COPY . .
WORKDIR "/src/api_2/TesteIngaia2/"
RUN dotnet build "TesteIngaia2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteIngaia2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TesteIngaia2.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TesteIngaia2.dll
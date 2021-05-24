FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

RUN dotnet restore "./TesteIngaia.csproj"
RUN dotnet publish "TesteIngaia.csproj" -c Release -o out


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "TesteIngaia.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TesteIngaia.dll
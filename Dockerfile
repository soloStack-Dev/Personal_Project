FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY MyMvcProject/MyMvcProject.csproj MyMvcProject/
RUN dotnet restore MyMvcProject/MyMvcProject.csproj

COPY . .
RUN dotnet publish MyMvcProject/MyMvcProject.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MyMvcProject.dll"]

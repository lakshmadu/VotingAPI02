FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["VotingAPI/VotingAPI.csproj", "VotingAPI/"]
COPY ["VotingAPI.Models/VotingAPI.Models.csproj","VotingAPI.Models/"]
COPY ["VotingAPI.DataAccess/VotingAPI.DataAccess.csproj","VotingAPI.DataAccess/"] 
COPY ["VotingAPI.Services/VotingAPI.Services.csproj","VotingAPI.Services/"]
RUN dotnet restore "VotingAPI/VotingAPI.csproj"
COPY . .
WORKDIR "/src/VotingAPI"
RUN dotnet build "VotingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VotingAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VotingAPI.dll"]

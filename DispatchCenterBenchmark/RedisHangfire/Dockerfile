FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "RedisHangfire.dll", "--urls=http://0.0.0.0:80"]
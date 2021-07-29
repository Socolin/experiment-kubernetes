FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY ./bin/Release/publish/ /app
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT "./SimpleWebApplication"
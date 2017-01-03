FROM microsoft/aspnetcore:1.1.0
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Production

EXPOSE 5000
ENTRYPOINT ["dotnet", "NancySignalrRaven.dll"]
COPY . /app



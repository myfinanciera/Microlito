
FROM siigo.azurecr.io/dotnet6-build AS build-env

COPY . .

RUN dotnet publish -c Release -o ./out --self-contained true --runtime linux-x64 --framework net6.0 /p:RuntimeFrameworkVersion=6.0.0

#----------------
FROM siigo.azurecr.io/dotnet6-runtime

WORKDIR /app/out

COPY --from=build-env --chown=app:app /app/out .

ENTRYPOINT ["./Siigo.Microservice.Api"]



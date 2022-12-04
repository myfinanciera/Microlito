# initial

$token="95d2c39b82a246761a52e2fe5fdecc4a82f75c57"
$dir=(Get-Location).Path
$localhost="http://localhost:81"
$projectName="Siigo.Microservice"

#dotnet tool install --global dotnet-sonarscanner --version 5.*
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=opencover
dotnet build-server shutdown


dotnet sonarscanner begin /k:"${projectName}" -d:sonar.host.url="${localhost}" -d:sonar.login="${token}" -d:sonar.language="cs" -d:sonar.exclusions="**/bin/**/*,**/obj/**/*" -d:sonar.cs.opencover.reportsPaths="${dir}/Tests/**/coverage.opencover.xml"
dotnet restore --configfile nuget.config
dotnet build
dotnet sonarscanner end -d:sonar.login="${token}"

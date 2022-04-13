dotnet sonarscanner begin /k:"ut8uu_U2.Suite_AYAkh6-fOUOiZYequ8TD" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="1385879bdd3ceebf2e3b935d03491ecf3e4f403e"

dotnet build

dotnet sonarscanner end /d:sonar.login="1385879bdd3ceebf2e3b935d03491ecf3e4f403e"

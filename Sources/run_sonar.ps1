$token = '046ff327f6d384de8a6eaea2c25d068bab8ea038'

$binPath = '..\Binaries\AnyCPU\Debug'
$reportsPaths = 'TestResults\Coverlet'

dotnet sonarscanner begin /k:"U2.Suite" /d:sonar.host.url="http://localhost:9000" /d:sonar.login=$token /d:sonar.cs.opencover.reportsPaths="$reportsPaths\**\$xmlFile"

dotnet build

$array = @(
	'U2.Logger.Tests'
) 

if (Test-Path "$reportsPaths")
{
#	Remove-Item "$reportsPaths" -Force -Recurse
}

ForEach ($item in $array)
{
	$dll = "$binPath\$item.dll";
	coverlet "$dll" --target "dotnet" --targetargs "test $dll" --format opencover --output "$reportsPaths\$item\$xmlFile"
}

dotnet sonarscanner end /d:sonar.login="$token"

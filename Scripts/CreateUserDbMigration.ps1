param
(
	[Parameter(Mandatory = $true)] [string] $migrationName
)

$dbName = "UserDb"
$dbProviders = @("MsSql", "MySql", "Npgsql", "Oracle", "Sqlite")
$directory = "../Ribbons.Users"

foreach ($dbProvider in $dbProviders) {
	$dbContext = "${dbName}${dbProvider}"
	Write-Host  "Creating migration for ${dbContext}"
	dotnet ef migrations add $migrationName --context $dbContext --output-dir "${directory}/Migrations/${dbProvider}" --project $directory
}


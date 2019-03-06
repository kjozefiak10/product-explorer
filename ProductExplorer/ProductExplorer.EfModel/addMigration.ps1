param([String]$migrationName)

# Zmieñ katalog wykonywania skryptu
$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
cd $dir

Write-Host "Adding migration..."

# Utwórz migrację
dotnet ef migrations add $migrationName

Write-Host "Migration added."
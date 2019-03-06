# Zmieñ katalog wykonywania skryptu
$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
cd $dir

Write-Host "Creating migration..."

# Utwórz migrację
dotnet ef migrations add InitialCreate

Write-Host "Migration created."
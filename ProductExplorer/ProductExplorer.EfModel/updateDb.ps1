# Zmieñ katalog wykonywania skryptu
$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
cd $dir

Write-Host "Db updating..."

# Aktualizuj bazę
dotnet ef database update

Write-Host "Db updated."
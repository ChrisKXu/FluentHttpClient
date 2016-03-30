# Setup dnx

$Branch='dev'
iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))
dnvm install latest -r clr -arch x86 -alias default

# Restore dependencies
dnu restore --quiet

# Build
dnu build ./FluentHttpClient/project.json ./FluentHttpClient.UnitTests/project.json --quiet

# Test
dnx -p FluentHttpClient.UnitTests test

# Pack
dnu pack ./FluentHttpClient/project.json --quiet --out ./artifacts --configuration Release

# All clear
Write-Host "All clear!"

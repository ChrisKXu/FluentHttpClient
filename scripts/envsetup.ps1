# Setup dnx

$Branch='dev'
iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))
dnvm upgrade -r coreclr

# Restore dependencies
dnu restore

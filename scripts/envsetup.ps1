# Setup dnx

$Branch='dev'
iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))
dnvm install latest -r coreclr -arch x86 -alias default

# Restore dependencies
dnu restore

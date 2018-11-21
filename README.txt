For at køre programmet byg først biblioteket:
fsharpc -a awariLibComplete.fsi awariLibComplete.fs
Derefter kompiler applikationen awariApp.fsx:
fsharpc -r awariLibComplete.dll awariApp.fsx
Kør nu programmet med mono:
mono awariApp.exe

For at køre test applikationen (white-box test) kompiler applikationen awariTestApp.fsx:
fsharpc -r awariLibComplete.dll awariTestApp.fsx
Kør nu programmet med mono:
mono awariTestApp.exe

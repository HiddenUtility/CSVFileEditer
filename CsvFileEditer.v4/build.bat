@echo off

PATH="%WINDIR%\Microsoft.NET\Framework\v4.0.30319";%PATH%

csc -target:library Reader.cs Writer.cs
csc Program.cs /reference:Reader.dll /reference:Writer.dll

rem ちなみに、/target:winexe を /target:exe にすると、コンソールアプリケーションになります。

pause

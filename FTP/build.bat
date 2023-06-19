@echo off

PATH="%WINDIR%\Microsoft.NET\Framework\v4.0.30319";%PATH%

csc -target:library FtpSender.cs 
csc Test.cs /reference:FtpSender.dll

rem ちなみに、/target:winexe を /target:exe にすると、コンソールアプリケーションになります。

pause
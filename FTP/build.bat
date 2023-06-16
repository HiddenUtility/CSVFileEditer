@echo off

csc -target:library FtpSender.cs 
csc Test.cs /reference:FtpSender.dll

rem ちなみに、/target:winexe を /target:exe にすると、コンソールアプリケーションになります。

cmd /k
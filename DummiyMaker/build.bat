@echo off

PATH="%WINDIR%\Microsoft.NET\Framework\v4.0.30319";%PATH%

csc -target:library DummiyFileMaker.cs 
csc Test.cs /reference:DummiyFileMaker.dll

rem ちなみに、/target:winexe を /target:exe にすると、コンソールアプリケーションになります。

pause
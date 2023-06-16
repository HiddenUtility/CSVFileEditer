@echo off

csc -target:library library0.cs library1.cs
csc Test.cs /reference:lilibrary0b0.dll /reference:library1.dll

rem ちなみに、/target:winexe を /target:exe にすると、コンソールアプリケーションになります。

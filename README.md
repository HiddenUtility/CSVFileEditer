# 他のプロジェクトを参照する。
まず参照先にcdを移動したあと、参照元を参照設定追加する。
```
cd {YourTestProjectName}
dotnet add reference ../{YourMainProjectPath}/{YourMainProjectName}.csproj
dotnet restore
// dotnet add reference {参照するpath}で指定されたpathにあるProjectの参照を追加
```

# 99. Test環境
コマンド
```
mkdir D:\01_Muscle_Data\temp3\analog\TNGA7block\kspf0001
mkdir D:\01_Muscle_Data\temp3\analog\TNGA7crank\kspf0002
mkdir D:\01_Muscle_Data\temp3\analog\TNGA8crank\kspf0003
mkdir D:\01_Muscle_Data\temp3\judge\TNGA7block\kspf0004
mkdir D:\01_Muscle_Data\temp3\judge\TNGA7crank\kspf0005
mkdir D:\01_Muscle_Data\temp3\judge\TNGA8crank\kspf0006
mkdir D:\01_Muscle_Data\temp3\settings\TNGA7block\kspf0007
mkdir D:\01_Muscle_Data\temp3\settings\TNGA7crank\kspf0008
mkdir D:\01_Muscle_Data\temp3\settings\TNGA8crank\kspf0009
```


# 複数のプロジェクトを作る

```
dotnet new sln

dotnet new console -o {プロジェクト名}
dotnet new console -o {プロジェクト名}

```




# 0. Projectの作成

```
dotnet new console -n {YourProjectName}
// {YourProjectName}は任意のProject
```
UnitTestを行う場合下記のディレクトリ構成になる。
```
root/
├── MySolution.sln
├── MyProject/ ←テスト対象プロジェクト
└── MyProject.Tests/　←テストプロジェクト（ここにMyProjectのUnit Testを作成）
```


# 1. Project作成→TestProject作成まで

.Net Core Test ExplorerをVSCodeにインストールしておく  
拡張の設定をする。   
Dotnet-test-explorer:Test Project Pathの項目を下記にする。   
`**/*Tests.csproj`   
※テストプロジェクトの命名規則として、{YourProject}.Testsにするのが一般的なのでデフォルト設定で

# 2.Test Prpjectを作成
MS Testを使う場合のコマンドは
`dotnet new mstest -n YourTestProjectName`   
x Unitを使う場合
`dotnet new xunit -n YourTestProjectName`   

# 3. Testプロジェクトに参加させる

```
cd {YourTestProjectName}
dotnet add reference ../{YourMainProjectPath}/{YourMainProjectName}.csproj

// dotnet add reference {参照するpath}で指定されたpathにあるProjectの参照を追加
// 
```

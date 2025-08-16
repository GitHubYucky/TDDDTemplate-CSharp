## createProject

```sh
dotnet --version   # .NET SDK が入っているか確認。バージョン番号が表示されればOK
dotnet new winforms -n MyWinApp   # WinForms プロジェクトを新規作成（MyWinApp はプロジェクト名）
cd MyWinApp   # 作成したプロジェクトのフォルダに移動
dotnet run    # プロジェクトを実行 → 空のフォーム（ウィンドウ）が立ち上がる
```

## createDDDProjects

```sh
# ソリューション作成
dotnet new sln -n MyWinAppDDD

# 各レイヤープロジェクト作成
dotnet new classlib -n MyWinAppDDD.Domain
dotnet new classlib -n MyWinAppDDD.Infrastructure
dotnet new winforms -n MyWinAppDDD.WinForm
# xUnit のテストプロジェクトを新規作成
dotnet new xunit -n MyWinAppDDDTest.Test


# 参照環境
# Infrastructure は Domain に依存する
dotnet add MyWinAppDDD.Infrastructure/MyWinAppDDD.Infrastructure.csproj reference MyWinAppDDD.Domain/MyWinAppDDD.Domain.csproj

# WinForm は Domain と Infrastructure を利用する
dotnet add MyWinAppDDD.WinForm/MyWinAppDDD.WinForm.csproj reference MyWinAppDDD.Domain/MyWinAppDDD.Domain.csproj
dotnet add MyWinAppDDD.WinForm/MyWinAppDDD.WinForm.csproj reference MyWinAppDDD.Infrastructure/MyWinAppDDD.Infrastructure.csproj

# Test は Domain をテストする（必要なら Infrastructure や WinForm にも追加）
dotnet add MyWinAppDDDTest.Test/MyWinAppDDDTest.Test.csproj reference MyWinAppDDD.Domain/MyWinAppDDD.Domain.csproj
dotnet add MyWinAppDDDTest.Test/MyWinAppDDDTest.Test.csproj reference MyWinAppDDD.Infrastructure/MyWinAppDDD.Infrastructure.csproj
dotnet add MyWinAppDDDTest.Test/MyWinAppDDDTest.Test.csproj reference MyWinAppDDD.WinForm/MyWinAppDDD.WinForm.csproj

# add to solution
dotnet sln MyWinAppDDD.sln add **/*.csproj

```

## add SomeFolders to test

### Domain

```sh
cd MyWinAppDDD.Domain
mkdir Entities Exceptions Helpers Repositories ValueObjects
ls
cd ..

```

### Infrastructure

```sh
cd MyWinAppDDD.Infrastructure
mkdir SQLite
ls
cd ..
```

### WinForm

```sh
cd MyWinAppDDD.WinForm
mkdir ViewModels Views
ls
cd ..
```

### Test

```sh
cd MyWinAppDDDTest.Test
mkdir Domain Infrastructure WinForm
ls
cd ..
```

## Execute Test

```sh
dotnet test
```

## Execute

```sh
dotnet run --project MyWinAppDDD.WinForm
```

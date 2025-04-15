# AZ-204 Test Feature Management

## 專案概述

此專案是一個 ASP.NET Core Web 應用程式，展示如何使用 Azure App Configuration 和 Microsoft Feature Management 來管理功能旗標 (Feature Flags)。

## 專案結構

專案的主要目錄結構如下：

```
appsettings.Development.json
appsettings.json
Program.cs
Startup.cs
testToggle.csproj
bin/
obj/
Pages/
  _ViewImports.cshtml
  _ViewStart.cshtml
  Error.cshtml
  Error.cshtml.cs
  Index.cshtml
  Index.cshtml.cs
  Privacy.cshtml
  Privacy.cshtml.cs
  Shared/
    _Layout.cshtml
    _ValidationScriptsPartial.cshtml
Properties/
  launchSettings.json
wwwroot/
  favicon.ico
  css/
    site.css
  js/
    site.js
  lib/
    bootstrap/
    jquery/
    jquery-validation/
    jquery-validation-unobtrusive/
```

## 使用的 NuGet 套件

- **Microsoft.Azure.AppConfiguration.AspNetCore (4.5.1)**
  - 用於從 Azure App Configuration 中讀取設定。
- **Microsoft.FeatureManagement.AspNetCore (2.4.0)**
  - 用於管理功能旗標。

## 關鍵檔案與功能

### Program.cs

此檔案包含應用程式的進入點，並設定了 Azure App Configuration 與功能旗標的整合。

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .ConfigureAppConfiguration((ctx, builder) =>
        {
            builder.AddAzureAppConfiguration(o =>
            {
                o.Connect("<Your Azure App Configuration Connection String>")
                 .UseFeatureFlags();
            });
        });
```

### Pages/Index.cshtml

此頁面展示了如何根據功能旗標的狀態來顯示不同的內容。

```csharp
@if (Model.isEnabled)
{
    <div class="card">
        <div class="card-header">新功能</div>
        <div class="card-body">此功能已啟用。</div>
    </div>
}
else
{
    <div class="card">
        <div class="card-header">新功能</div>
        <div class="card-body">此功能尚未啟用。</div>
    </div>
}
```

### Pages/Shared/_Layout.cshtml

此檔案定義了應用程式的主版面配置，包含導覽列與頁腳。

```html
<header>
    <nav class="navbar navbar-expand-sm navbar-light bg-white">
        <a class="navbar-brand" asp-area="" asp-page="/Index">Home</a>
        <a class="navbar-brand" asp-area="" asp-page="/Privacy">Privacy</a>
    </nav>
</header>
```

## 如何執行專案

1. 確保已安裝 .NET 8 SDK。
2. 在專案目錄中執行以下命令以還原套件：

   ```bash
   dotnet restore
   ```

3. 執行應用程式：

   ```bash
   dotnet run
   ```

4. 開啟瀏覽器並導航至 `http://localhost:5000`。

## 注意事項

- 請確保在 `Program.cs` 中提供正確的 Azure App Configuration 連線字串。
- 功能旗標的設定可以在 Azure App Configuration 中進行管理。

## 授權

此專案採用 MIT 授權，詳見 [LICENSE](wwwroot/lib/jquery-validation/LICENSE.md)。
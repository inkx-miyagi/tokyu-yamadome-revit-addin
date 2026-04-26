param(
    [string]$Configuration = "Debug",
    [string]$RevitVersion = "2023"
)

$ErrorActionPreference = "Stop"

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot "..")
$projectPath = Join-Path $repoRoot "src\Tokyu.Yamadome.RevitAddin\Tokyu.Yamadome.RevitAddin.csproj"
$assemblyPath = Join-Path $repoRoot "src\Tokyu.Yamadome.RevitAddin\bin\$Configuration\Tokyu.Yamadome.RevitAddin.dll"
$addinDir = Join-Path $env:APPDATA "Autodesk\Revit\Addins\$RevitVersion"
$addinPath = Join-Path $addinDir "Tokyu.Yamadome.RevitAddin.addin"
$msbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"

if (-not (Test-Path $msbuild)) {
    throw "MSBuild was not found: $msbuild"
}

& $msbuild $projectPath /p:Configuration=$Configuration /p:Platform="Any CPU" /m
if ($LASTEXITCODE -ne 0) {
    throw "Build failed."
}

New-Item -ItemType Directory -Force -Path $addinDir | Out-Null

$addinXml = @"
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>Tokyu Yamadome Revit Addin</Name>
    <Assembly>$assemblyPath</Assembly>
    <AddInId>3777D65A-F446-4042-B132-3AF46BE80ACE</AddInId>
    <FullClassName>Tokyu.Yamadome.RevitAddin.App</FullClassName>
    <VendorId>INKX</VendorId>
    <VendorDescription>Ribbon prototype for Tokyu Construction Production Technology Department yamadome tools.</VendorDescription>
  </AddIn>
</RevitAddIns>
"@

Set-Content -LiteralPath $addinPath -Value $addinXml -Encoding UTF8

Write-Output "Installed Revit add-in manifest:"
Write-Output $addinPath
Write-Output "Assembly:"
Write-Output $assemblyPath


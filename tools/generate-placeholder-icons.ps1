param(
    [string]$OutputDir = ".\src\Tokyu.Yamadome.RevitAddin\Resources\Icons"
)

Add-Type -AssemblyName System.Drawing

$icons = @(
    @{ Name = "initial-settings"; Label = "設"; Color = "#2B6CB0" },
    @{ Name = "structure-visibility"; Label = "躯"; Color = "#2F855A" },
    @{ Name = "bgcd-mode"; Label = "BG"; Color = "#805AD5" },
    @{ Name = "strut-color"; Label = "色"; Color = "#DD6B20" },
    @{ Name = "case-label"; Label = "表"; Color = "#4A5568" },
    @{ Name = "bottom-level"; Label = "底"; Color = "#3182CE" },
    @{ Name = "excavation-shape"; Label = "掘"; Color = "#C05621" },
    @{ Name = "excavation-fix"; Label = "修"; Color = "#B7791F" },
    @{ Name = "model-lines"; Label = "線"; Color = "#2C7A7B" },
    @{ Name = "line-join"; Label = "結"; Color = "#285E61" },
    @{ Name = "wall"; Label = "壁"; Color = "#718096" },
    @{ Name = "waler"; Label = "腹"; Color = "#4A5568" },
    @{ Name = "strut"; Label = "梁"; Color = "#2D3748" },
    @{ Name = "corner-brace"; Label = "火"; Color = "#C53030" },
    @{ Name = "post"; Label = "柱"; Color = "#975A16" },
    @{ Name = "anchor"; Label = "錨"; Color = "#2B6CB0" },
    @{ Name = "adjust-brace"; Label = "調"; Color = "#D69E2E" },
    @{ Name = "anchor-angle"; Label = "角"; Color = "#3182CE" },
    @{ Name = "brace-count"; Label = "数"; Color = "#C53030" },
    @{ Name = "waler-priority"; Label = "勝"; Color = "#4A5568" },
    @{ Name = "platform-2d"; Label = "2D"; Color = "#38A169" },
    @{ Name = "platform"; Label = "構"; Color = "#2F855A" },
    @{ Name = "bgcd-2d"; Label = "B2"; Color = "#6B46C1" },
    @{ Name = "bgcd-3d"; Label = "B3"; Color = "#553C9A" },
    @{ Name = "backfill"; Label = "埋"; Color = "#975A16" },
    @{ Name = "split-level"; Label = "縦"; Color = "#B7791F" },
    @{ Name = "split-horizontal"; Label = "横"; Color = "#B7791F" },
    @{ Name = "existing-structure"; Label = "既"; Color = "#4A5568" },
    @{ Name = "structure-type"; Label = "型"; Color = "#718096" },
    @{ Name = "step-view"; Label = "段"; Color = "#2B6CB0" },
    @{ Name = "view"; Label = "図"; Color = "#2C5282" },
    @{ Name = "legend"; Label = "凡"; Color = "#805AD5" },
    @{ Name = "sheet"; Label = "紙"; Color = "#6B46C1" },
    @{ Name = "layout-save"; Label = "保"; Color = "#2F855A" },
    @{ Name = "template-transfer"; Label = "転"; Color = "#319795" },
    @{ Name = "schedule"; Label = "集"; Color = "#C05621" }
)

New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null

foreach ($icon in $icons) {
    $bitmap = New-Object System.Drawing.Bitmap 32, 32
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    $graphics.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
    $graphics.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::AntiAliasGridFit

    $background = [System.Drawing.ColorTranslator]::FromHtml($icon.Color)
    $brush = New-Object System.Drawing.SolidBrush $background
    $graphics.FillRectangle($brush, 0, 0, 32, 32)

    $borderPen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(230, 255, 255, 255)), 2
    $graphics.DrawRectangle($borderPen, 1, 1, 29, 29)

    $fontSize = if ($icon.Label.Length -gt 1) { 10 } else { 15 }
    $font = New-Object System.Drawing.Font "Yu Gothic UI", $fontSize, ([System.Drawing.FontStyle]::Bold), ([System.Drawing.GraphicsUnit]::Pixel)
    $textBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::White)
    $format = New-Object System.Drawing.StringFormat
    $format.Alignment = [System.Drawing.StringAlignment]::Center
    $format.LineAlignment = [System.Drawing.StringAlignment]::Center
    $rect = New-Object System.Drawing.RectangleF 0, 0, 32, 31

    $graphics.DrawString($icon.Label, $font, $textBrush, $rect, $format)

    $path = Join-Path $OutputDir "$($icon.Name).png"
    $bitmap.Save($path, [System.Drawing.Imaging.ImageFormat]::Png)

    $format.Dispose()
    $font.Dispose()
    $textBrush.Dispose()
    $borderPen.Dispose()
    $brush.Dispose()
    $graphics.Dispose()
    $bitmap.Dispose()
}

Write-Output "Generated $($icons.Count) placeholder icons in $OutputDir"


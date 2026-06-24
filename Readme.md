# MakeQrCodes

A simple C# console application that generates a QR code image from a URL using the QRCoder NuGet package. Supports optional logo embedding and customizable output paths.

## Features

- Generates a QR code from any URL defined in App.config.
- Optionally embeds a logo/icon image in the center of the QR code.
- Customizable output file path (defaults to `C:\temp\qrcode.jpg`).
- Uses ECC Level Q (25% error correction) — robust enough to handle a centered logo without losing readability.
- Automatically creates the output directory if it does not exist.
- Aqua-on-Navy color scheme when a logo is provided; Aqua-on-Black otherwise.

## Requirements

- .NET Framework (4.x) — targets the standard Windows desktop runtime.
- QRCoder NuGet package — installed automatically via packages.config on restore.
- System.Drawing (GDI+) — included with .NET Framework; used for Bitmap handling.

## Getting Started

### 1. Clone or download the repository
```
git clone https://github.com/abhidotnet/CreateQRCode.git 
cd MakeQrCodes
```

### 2. Restore NuGet packages

Open the solution in Visual Studio and build — NuGet will restore QRCoder automatically from `packages.config`.

Or via CLI:
```
nuget restore MakeQrCodes.sln
```

### 3. Configure App.config

All configuration is handled through `App.config`.

| Key        | Required | Description |
|------------|----------|-------------|
| QrUrl      | Yes      | The URL to encode into the QR code |
| LogoPath   | No       | Full path to a logo image (PNG/JPG) to embed in the center |
| OutputPath | No       | Output file path (defaults to `C:\temp\qrcode.jpg`) |

#### Example App.config
```
<appSettings> <add key="QrUrl" value="https://www.example.com" /> 
<add key="LogoPath" value="C:\logos\mylogo.png" /> 
<add key="OutputPath" value="C:\temp\myqrcode.jpg" /> 
</appSettings> ```
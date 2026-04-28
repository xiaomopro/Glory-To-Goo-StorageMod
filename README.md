# GloryToGoo Storage Mod

A BepInEx plugin for **From Glory To Goo** that increases the storage capacity of the Factory building for Crystals, Ore, and Isotopes.

> Game version: 0.3

## What This Mod Does

By default, each Factory building provides:
- Crystals storage: +25
- Ore storage: +10
- Isotopes storage: +10

With this mod, each Factory building provides:
- Crystals storage: +75 (+50 extra)
- Ore storage: +35 (+25 extra)
- Isotopes storage: +35 (+25 extra)

> **Note:** The extra capacity added by this mod will **not** be removed when a Factory is demolished. This is a known limitation and has not been fixed yet.

## Requirements

- [BepInEx 6 IL2CPP BE](https://builds.bepinex.dev/projects/bepinex_be) (bleeding edge build for IL2CPP games)
- From Glory To Goo (Steam)

## Installation

1. Download and install **BepInEx 6 IL2CPP BE** into your game folder:

```
    From Glory To Goo/
    ├── BepInEx/
    ├── doorstop_config.ini
    └── winhttp.dll
```

2. Launch the game once and close it. This allows BepInEx to initialize and generate required files.

3. Download `GloryToGooMod.dll` from the [Releases](../../releases) page.

4. Place the dll into your game folder:

```
    From Glory To Goo/BepInEx/plugins/GloryToGooMod.dll
```

5. Launch the game. The mod will be active automatically.

## Verification

To confirm the mod is working, check the BepInEx log file at:

```
From Glory To Goo/BepInEx/LogOutput.log
```

You should see lines like:

```
[Info   :GloryToGoo Mod] GloryToGoo Mod loaded!
[Info   :GloryToGoo Mod] Ore storage set to: 75
```

## Compatibility

- Works with all game modes (Campaign mode has not been tested yet)
- Compatible with existing saves
- Compatible with the official `unitConfig.json` mod system

## How It Works

This mod uses **Harmony** to hook into `GameManager.setOreStorage`, `GameManager.setUraniumStorage`, and `GameManager.setGasStorage` at runtime. Whenever the game sets storage capacity (e.g. when a Factory is placed), the mod intercepts the call and adds extra capacity on top of the base value.

The extra storage persists through map loads and save/load cycles.

## Building From Source

Requirements:
- .NET SDK 6 or later
- Game installed with BepInEx initialized

```bash
git clone https://github.com/xiaomopro/Glory-To-Goo-StorageMod.git
cd Glory-To-Goo-StorageMod
dotnet build GloryToGooMod.csproj
```

The compiled dll will be at `bin/Debug/net6.0/GloryToGooMod.dll`.

> **Note:** The `.csproj` file references dlls from a local game installation path. You may need to update the `HintPath` values in `GloryToGooMod.csproj` to match your own game directory before building.

## Configuration

To change the storage bonus values, edit the constants in `Plugin.cs` and recompile:

```csharp
public const int EXTRA_ORE_STORAGE = 50;      // Crystals bonus
public const int EXTRA_URANIUM_STORAGE = 25;   // Isotopes bonus
public const int EXTRA_GAS_STORAGE = 25;       // Ore bonus
```

##  License
This project is dedicated to the public domain under the CC0 1.0 Universal license.

Anyone can use, copy, modify, and distribute this software for any purpose, without any conditions.

Full license text:
https://creativecommons.org/publicdomain/zero/1.0/

# Lake (the game) - Speed Mod

> See what it does: https://youtu.be/xQD7RP2kzxc

## Prerequisite:
- BepInEx - v5.4.19+

## Installation :
Download the latest release build, extract the `SpeedMod.dll` file into the game's directory, under `BepInEx/plugins`.

The mod will be `automatically enabled` ingame. \
To use it, `Hold` the `LeftShift` key, either on foot, or in the vehicle.

# Compiling

## Build dependencies :

The following dlls are going in the project's `/libs` folder, get them from GitHub :
- `BepInEx.dll` - v5.4.19+
- `BepInEx.Harmony.dll` - v2+ ( Comes with BepInEx )

The next dll is available as a `locally installed` (GitHub) .nuget extension, not on the store.
- `0Harmony.dll` ( HarmonyX - v2.10+ )

Game-specifics dlls ( Put them in `/libs` ) :
- `Assembly-CSharp.dll`
- `UnityEngine.dll`
- `UnityEngine.CoreModule.dll`

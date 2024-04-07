# Summator F#

Port of the [Summator](https://github.com/raulsntos/godot-dotnet/tree/master/samples/Summator) sample project originally from the [GDExtensionSummator template](https://github.com/paddy-exe/GDExtensionSummator).

This is a F# project that uses the [Godot .NET](https://github.com/raulsntos/godot-dotnet) bindings to implement a GDExtension that can be loaded by Godot.

Please note that I'm not an F# developer so this code is likely not idiomatic, but it should be a good enough starting point.

## Usage (Native Library)

Build the F# library as a native library and put it in the lib directory of the Game project.

```bash
dotnet publish Extension -r linux-x64 -o Game/lib
```

There is a GDExtension manifest that already points to the right location so Godot can find the library.

> [!WARNING]
> Since it doesn't seem like F# supports the `[UnmanagedCallersOnly]` attribute. Building a native library and loading it as a GDExtension will not work, instead follow the steps below.
> For more context, see https://github.com/dotnet/samples/issues/5647.

## Usage (Portable DLL)

Build the F# library as a portable DLL and put it in the directory where Godot expects to find it.

The new `dotnet` module is still a work-in-progress, but if you put the DLL in the `.godot/mono/temp/bin/Debug` directory it should be able to find it (this may change in the future).

> [!NOTE]
> The new `dotnet` module is not publicly available yet.

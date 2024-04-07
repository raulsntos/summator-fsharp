namespace GDExtensionSummator

open System
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Godot.Bridge

module Library =
    [<assembly: DisableRuntimeMarshalling>]
    do ()

    let InitializeSummatorTypes (level: InitializationLevel) : unit =
        if level <> InitializationLevel.Scene then
            ignore ()
        else
            ClassDB.RegisterClass<Summator>(Action<ClassDBRegistrationContext>(Summator.BindMethods))
            |> ignore

    let DeinitializeSummatorTypes (level: InitializationLevel) : unit =
        if level <> InitializationLevel.Scene then
            ignore ()
        else
            ignore ()

    [<UnmanagedCallersOnly(EntryPoint = "summator_library_init")>]
    let SummatorLibraryInit (getProcAddress: nativeint, library: nativeint, initialization: nativeint) : bool =
        GodotBridge.Initialize(
            getProcAddress,
            library,
            initialization,
            fun config ->
                config.SetMinimumLibraryInitializationLevel(InitializationLevel.Scene)
                config.RegisterInitializer(InitializeSummatorTypes)
                config.RegisterTerminator(DeinitializeSummatorTypes)
        )

        true

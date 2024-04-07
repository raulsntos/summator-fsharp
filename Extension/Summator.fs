namespace GDExtensionSummator

open Godot
open Godot.Bridge

type Summator() =
    inherit RefCounted()

    let mutable _count: int = 0

    member this.Add(value: int) : unit = _count <- _count + value

    member this.Reset() : unit = _count <- 0

    member this.GetTotal() : int = _count

    static member BindMethods(context: ClassDBRegistrationContext) =
        context.BindConstructor(fun () -> new Summator())

        context.BindMethod(
            new StringName(nameof (Unchecked.defaultof<Summator>.Add)),
            new ParameterInfo(new StringName("value"), VariantType.Int, VariantTypeMetadata.Int32, 1),
            fun (instance: Summator) (value: int) -> instance.Add(value)
        )

        context.BindMethod(
            new StringName(nameof (Unchecked.defaultof<Summator>.Reset)),
            fun (instance: Summator) -> instance.Reset()
        )

        context.BindMethod(
            new StringName(nameof (Unchecked.defaultof<Summator>.GetTotal)),
            new ReturnInfo(VariantType.Int, VariantTypeMetadata.Int32),
            fun (instance: Summator) -> instance.GetTotal()
        )

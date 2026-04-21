namespace Feliz

open Feliz

[<AutoOpen>]
module Extensions =

    type Html with
        static member inline hgroup (xs: ReactElement) = ReactLegacy.createElement("hgroup", xs)
        static member inline hgroup (children: seq<ReactElement>) = ReactLegacy.createElement("hgroup", children)

    type prop with

        static member inline onClick(callback: unit -> unit) = prop.onClick (fun _ -> callback ())


    type React with

        static member inline ofOption(opt: ReactElement option) = Option.defaultValue Html.none opt

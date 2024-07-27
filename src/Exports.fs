namespace Glutinum.Feliz.ReactSignaturePadWrapper

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Exports =

    static member inline SignaturePad(properties: #ISignaturePadProperty list) =
        Interop.reactApi.createElement (
            import "default" "react-signature-pad-wrapper",
            createObj !!properties
        )

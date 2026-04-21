namespace Glutinum.Feliz.ReactSignaturePadWrapper

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Exports =

    static member inline SignaturePad(properties: #ISignaturePadProperty list) =
        ReactLegacy.createElement (
            unbox<ReactElement> (import "default" "react-signature-pad-wrapper"),
            createObj !!properties
        )

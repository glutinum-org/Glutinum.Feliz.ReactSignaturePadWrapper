namespace Glutinum.Feliz.ReactSignaturePadWrapper

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.SignaturePad

type SignaturePadOptions = Glutinum.SignaturePad.Options

[<Erase>]
type signaturePad =

    static member inline width(value: float) =
        Interop.mkReactResizeDetectorProperty "width" value

    static member inline height(value: float) =
        Interop.mkReactResizeDetectorProperty "height" value

    static member inline options(value: SignaturePadOptions) =
        Interop.mkReactResizeDetectorProperty "options" value

    static member inline canvasProps(properties: #IReactProperty list) =
        Interop.mkReactResizeDetectorProperty "canvasProps" (createObj !!properties)

    static member inline redrawOnResize(value: bool) =
        Interop.mkReactResizeDetectorProperty "redrawOnResize" value

    static member inline debounceInterval(value: int) =
        Interop.mkReactResizeDetectorProperty "debounceInterval" value

    static member inline ref(ref: IRefValue<SignaturePad option>) =
        Interop.mkReactResizeDetectorProperty "ref" ref

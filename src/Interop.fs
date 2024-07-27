namespace Glutinum.Feliz.ReactSignaturePadWrapper

module Interop =

    let inline mkReactResizeDetectorProperty (key: string) (value: obj) : ISignaturePadProperty =
        unbox (key, value)

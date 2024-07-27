# Glutinum.Feliz.ReactSignaturePadWrapper

<!-- Could you please keep the link below so people can find the original template 🙏 -->

[![](https://img.shields.io/badge/Project_made_using_Glutinum.Template-7679db?style=for-the-badge)](https://github.com/glutinum-org/Glutinum.Template)

[![NuGet](https://img.shields.io/nuget/v/Glutinum.Feliz.ReactSignaturePadWrapper.svg)](https://www.nuget.org/packages/Glutinum.Feliz.ReactSignaturePadWrapper)


<!-- To learn how to use the template please refer to MANUAL.md -->

<!-- You can put the documentation for your binding below -->

Binding for [react-signature-pad-wrapper](https://www.npmjs.com/package/react-signature-pad-wrapper).

## Usage

```fs
open Feliz
open Glutinum.SignaturePad
open Glutinum.Feliz.ReactSignaturePadWrapper

open type Glutinum.Feliz.ReactSignaturePadWrapper.Exports

[<ReactComponent>]
let App () =
    let signaturePadRef = React.useRef<SignaturePad option> None

    Html.div [
        SignaturePad [
            signaturePad.ref signaturePadRef
            signaturePad.redrawOnResize true
        ]

        Html.button [
            prop.text "Clear"
            prop.onClick (fun _ ->
                if signaturePadRef.current.IsSome then
                    signaturePadRef.current.Value.clear ()
            )
        ]
        Html.button [
            prop.text "Save"
            prop.onClick (fun _ ->
                if signaturePadRef.current.IsSome then
                    let base64URL = signaturePadRef.current.Value.toDataURL ()
                    debugBase64 base64URL
            )
        ]
    ]
```

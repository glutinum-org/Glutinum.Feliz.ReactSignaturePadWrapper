module Demo.App

open Feliz
open Glutinum.SignaturePad
open Glutinum.Feliz.ReactSignaturePadWrapper

open type Glutinum.Feliz.ReactSignaturePadWrapper.Exports

let private debugBase64 (base64URL: string) =
    let win = Browser.Dom.window.``open`` ()

    win.document.write (
        $"<iframe src='%s{base64URL}' frameborder='0' style='border:0; top:0px; left:0px; bottom:0px; right:0px; width:100%%; height:100%%;' allowfullscreen></iframe>"
    )

[<ReactComponent>]
let App () =
    let signaturePadRef = React.useRef<SignaturePad option> None

    Html.main [
        prop.className "container"
        prop.children [
            Html.nav [
                Html.ul [
                    Html.li "Glutinum.Feliz.ReactSignaturePadWrapper"
                ]
            ]

            Html.article [
                Html.header [
                    prop.text "Please sign below"
                ]
                Html.div [
                    SignaturePad [
                        signaturePad.ref signaturePadRef
                        signaturePad.redrawOnResize true
                    ]
                ]
                Html.footer [
                    prop.className "card-footer-center"
                    prop.children [
                        Html.button [
                            prop.className "secondary"
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
                ]
            ]

        ]
    ]

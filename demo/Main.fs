module Demo.Main

open Browser.Dom
open Feliz
open Demo.App

let root = document.getElementById "root"

ReactDOM.createRoot(root).render (App())

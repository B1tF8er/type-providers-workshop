[<EntryPoint>]
let main _ =
    printfn "JSON TYPE PROVIDERS WITH F#!"
    JsonPlaceholderProvider.run ()
    BooksProvider.run ()
    0

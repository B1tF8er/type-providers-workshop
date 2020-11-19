[<EntryPoint>]
let main _ =
    printfn "HTML TYPE PROVIDERS WITH F#!"
    NugetProvider.run ()
    QueenTypeProvider.run ()
    0

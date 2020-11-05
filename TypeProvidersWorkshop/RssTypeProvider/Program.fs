[<EntryPoint>]
let main _ =
    printfn "RSS TYPE PROVIDERS WITH F#!"

    MetalInjectionRss.getFeed ()
    MetalSucksRss.getFeed ()
    MetalUndergroundRss.getFeed ()

    0

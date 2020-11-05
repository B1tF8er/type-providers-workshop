[<EntryPoint>]
let main _ =
    printfn "RSS TYPE PROVIDERS WITH F#!"

    MetalInjectionRss.getFeed () |> ignore
    MetalSucksRss.getFeed () |> ignore
    MetalUndergroundRss.getFeed () |> ignore

    0

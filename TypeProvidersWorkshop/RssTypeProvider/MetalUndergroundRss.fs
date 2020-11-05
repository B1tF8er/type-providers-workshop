module MetalUndergroundRss

open FSharp.Data

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalUnderground"

type private RSS = XmlProvider<Url>

let private separator () =
    printfn ""
    [1 .. 100]
    |> List.iter (fun _ -> printf "=")
    printfn ""

let getFeed () =
    let feed = RSS.GetSample()
    
    let channel = feed.Channel
    let title = channel.Title
    let items = channel.Items

    separator ()
    printfn "SITE: %s" title
    separator ()

    items
    |> List.ofArray
    |> List.iter (fun item ->
        printfn "TITLE: %s" item.Title
        printfn "LINK %s" item.Link
        separator ()
    )

    ()

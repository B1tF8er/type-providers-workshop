module RssProvider

open FSharp.Data

let [<Literal>] private Url =
    @".\Resources\Sample_RSS_Feed.xml"

type private RSS = XmlProvider<Url>

let private separator () =
    printfn ""
    [1 .. 100] |> List.iter (fun _ -> printf "=")
    printfn ""

let getFeed (url : string) =
    let feed = RSS.Load(url)
    
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

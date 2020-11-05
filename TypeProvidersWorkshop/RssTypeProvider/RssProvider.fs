module RssProvider

open FSharp.Data

let [<Literal>] private Url =
    @".\Resources\Sample_RSS_Feed.xml"

type private RSS = XmlProvider<Url>

let private separator () =
    printfn ""
    [1 .. 100] |> List.iter (fun _ -> printf "=")
    printfn ""

let private displayPost (item : RSS.Item) =
    printfn "TITLE: %s" item.Title
    printfn "LINK %s" item.Link
    separator ()

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
    |> List.iter displayPost

let plotFeed (url : string) =
    let feed = RSS.Load(url)

    // TODO: plot feed using XPlot.GoogleCharts

    ()

let saveFeed (url : string) =
    let feed = RSS.Load(url)

    // TODO: save feed to File System

    ()

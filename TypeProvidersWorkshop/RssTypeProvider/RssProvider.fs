module RssProvider

open FSharp.Data
open System.Linq
open XPlot.GoogleCharts

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

let private tryGetTitle (item : RSS.Item) = 
    try item.Title.Substring(0, 5)
    with | _ -> "N/A"

let private tryGetComments (item : RSS.Item) = 
    try item.Comments2
    with | _ -> 0

let plotFeed (url : string) =
    let feed = RSS.Load(url)

    let channel = feed.Channel
    let items = channel.Items

    items
    |> Seq.ofArray
    |> Seq.map (fun item -> (item |> tryGetTitle, item |> tryGetComments))
    |> Seq.take 5
    |> Chart.Column
    |> Chart.Show

let saveFeed (url : string) =
    let feed = RSS.Load(url)

    // TODO: save feed to File System

    ()

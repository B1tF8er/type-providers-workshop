module RssOperations

open Domain
open XPlot.GoogleCharts
open System
open System.IO

// GET FEEDS
let private separator () =
    printfn ""
    [1 .. 100] |> List.iter (fun _ -> printf "=")
    printfn ""

let private displayPost (item : Item) =
    printfn "TITLE: %s" item.Title
    printfn "LINK %s" item.Link
    separator ()

let get (feed : Feed) =
    let channel = feed.Channel
    let title = channel.Title
    let items = channel.Items

    separator ()
    printfn "SITE: %s" title
    separator ()

    items
    |> List.iter displayPost

// PLOT FEEDS
let private toChart (item : Item) =
    (item.Title.Substring(0, 5), item.Comments)

let plot (feed : Feed) =
    let channel = feed.Channel
    let items = channel.Items

    items
    |> Seq.ofList
    |> Seq.map toChart
    |> Seq.take 5
    |> Chart.Column
    |> Chart.Show

// SAVE FEEDS
let private rssDirectory =
    Path.Combine(
        Environment.CurrentDirectory,
        DateTime.Now.ToShortDateString(),
        "RSS"
    )

let private tryCreateRssDirectory () =
    if not (rssDirectory |> Directory.Exists) then
        rssDirectory
        |> Directory.CreateDirectory
        |> ignore

let private writeLinksToFile (feed : Feed) =
    let title = sprintf "%s.txt" feed.Channel.Title
    let fileName = Path.Combine(rssDirectory, title)
    let links =
        feed.Channel.Items
        |> Seq.ofList
        |> Seq.map (fun item -> item.Link)

    File.WriteAllLines(fileName, links)

let save (feed : Feed) =
    () |> tryCreateRssDirectory
    feed |> writeLinksToFile

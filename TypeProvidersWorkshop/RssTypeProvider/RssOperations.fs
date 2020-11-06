module RssOperations

open Domain
open XPlot.GoogleCharts

module Get =
    let private separator () =
        printfn ""
        [1 .. 100] |> List.iter (fun _ -> printf "=")
        printfn ""

    let private displayPost (item : Item) =
        printfn "TITLE: %s" item.Title
        printfn "LINK %s" item.Link
        separator ()

    let run (feed : Feed) =
        let channel = feed.Channel
        let title = channel.Title
        let items = channel.Items

        separator ()
        printfn "SITE: %s" title
        separator ()

        items
        |> List.iter displayPost

module Plot =
    let private toChart (item : Item) =
        (item.Title, item.Comments)

    let run (feed : Feed) =
        let channel = feed.Channel
        let items = channel.Items

        items
        |> Seq.ofList
        |> Seq.map toChart
        |> Seq.take 5
        |> Chart.Column
        |> Chart.Show

module Save =
    let run (feed : Feed) =
        // TODO: save feed to File System

        ()

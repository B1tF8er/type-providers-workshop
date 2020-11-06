module RssProvider

open Domain
open FSharp.Data

let [<Literal>] private Url = @".\Resources\Sample_RSS_Feed.xml"

type private RSS = XmlProvider<Url>

let private tryGetTitle (item : RSS.Item) = 
    try item.Title.Substring(0, 5)
    with | _ -> "N/A"

let private tryGetComments (item : RSS.Item) = 
    try item.Comments2
    with | _ -> 0

let private toFeed (rss : RSS.Rss) =
    {
        Channel = {
             Title = rss.Channel.Title
             Items =
                 rss.Channel.Items
                 |> Array.map (fun item -> {
                     Title = item |> tryGetTitle
                     Link = item.Link
                     Comments = item |> tryGetComments
                 })
                 |> List.ofArray
        }
     }

let private loadRss (url : string) =
    RSS.Load(url) |> toFeed

let get (url : string) =
    url |> loadRss |> RssOperations.Get.run

let plot (url : string) =
    url |> loadRss |> RssOperations.Plot.run

let save (url : string) =
    url |> loadRss |> RssOperations.Save.run

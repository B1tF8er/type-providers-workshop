﻿module RssProvider

open Domain
open FSharp.Data

let [<Literal>] private Url = @".\Resources\Sample_RSS_Feed.xml"

type private RSS = XmlProvider<Url>

let private tryGetTitle (item : RSS.Item) = 
    try item.Title
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

let private loadRss (url : string) = RSS.Load(url) |> toFeed

let get = loadRss >> RssOperations.get

let plot = loadRss >> RssOperations.plot

let save = loadRss >> RssOperations.save

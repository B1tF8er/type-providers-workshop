open Domain
open System

let get (rssFeeds : RssFeed list) =
    rssFeeds
    |> List.iter (fun rssFeed -> rssFeed.getFeed ())

let plot (rssFeeds : RssFeed list) =
    rssFeeds
    |> List.iter (fun rssFeed -> rssFeed.plotFeed ())

let save (rssFeeds : RssFeed list) =
    rssFeeds
    |> List.iter (fun rssFeed -> rssFeed.saveFeed ())

[<EntryPoint>]
let main _ =
    printfn "RSS TYPE PROVIDERS WITH F#!"

    let rssFeeds = [
        MetalInjectionRss.create ()
        MetalSucksRss.create ()
        MetalUndergroundRss.create ()
    ]

    let userInput = Console.ReadKey().ToString().ToLowerInvariant()

    match userInput with
    | "g" -> rssFeeds |> get
    | "p" -> rssFeeds |> plot
    | "s" -> rssFeeds |> save
    | _ -> printfn "Invalid user input allowed values are: (g) Get Feeds | (p) Plot Feeds | (s) Save Feeds"

    0

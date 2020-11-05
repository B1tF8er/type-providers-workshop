open Domain
open System

let private get rssFeed = rssFeed.getFeed ()

let private plot rssFeed = rssFeed.plotFeed ()

let private save rssFeed = rssFeed.saveFeed ()

let [<Literal>] UserActionErrorMessage =
    "Invalid user action, allowed actions are: (g) Get Feeds | (p) Plot Feeds | (s) Save Feeds"

[<EntryPoint>]
let main _ =
    printfn "RSS TYPE PROVIDERS WITH F#!"

    let rssFeeds = [
        MetalInjectionRss.create ()
        MetalSucksRss.create ()
        MetalUndergroundRss.create ()
    ]

    let userAction = Console.ReadKey().ToString().ToLowerInvariant()

    match userAction with
    | "g" ->
        rssFeeds |> List.iter get
    | "p" ->
        rssFeeds |> List.iter plot
    | "s" ->
        rssFeeds |> List.iter save
    | _ ->
        printfn ""
        printfn "%s" UserActionErrorMessage

    0
